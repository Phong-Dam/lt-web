using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using DoAN_WEB.Models;
using DoAN_WEB.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace DoAN_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private const string LanguageKey = "UserLanguage";

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string lang)
        {
            try
            {
                // Nếu có tham số lang, lưu vào session
                if (!string.IsNullOrEmpty(lang))
                {
                    HttpContext.Session.SetString(LanguageKey, lang);
                }
                
                // Lấy ngôn ngữ từ session hoặc mặc định là tiếng Việt
                ViewBag.Language = HttpContext.Session.GetString(LanguageKey) ?? "vi";
                
                // Lấy các text theo ngôn ngữ
                ViewBag.Resources = new Dictionary<string, string>();
                
                var keys = new[] { 
                    "PageTitle", "SearchTitle", "SearchLabel", "SearchPlaceholder", 
                    "SongInfoTitle", "ViewsText", "NoResults", "SearchError", 
                    "LoadingText", "LanguageToggle" 
                };
                
                foreach (var key in keys)
                {
                    ViewBag.Resources[key] = LanguageResource.GetText(ViewBag.Language, key);
                }
                
                // Lấy ngôn ngữ tiếp theo để dùng cho nút chuyển đổi
                ViewBag.NextLanguage = LanguageResource.GetNextLanguage(ViewBag.Language);
                
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Index action");
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> SearchSongs(string term)
        {
            try
            {
                _logger.LogInformation($"Searching for songs with term: {term}");
                
                if (string.IsNullOrEmpty(term))
                {
                    return Json(new List<object>());
                }

                // Lấy tất cả bài hát từ DB
                var allSongs = await _context.Songs.ToListAsync();
                
                // Tìm kiếm không phân biệt dấu
                var filteredSongs = allSongs
                    .Where(s => s.Title.ContainsNoAccent(term) || s.Artist.ContainsNoAccent(term))
                    .OrderByDescending(s => s.Views)
                    .Take(10)
                    .Select(s => new
                    {
                        id = s.Id,
                        value = s.Title,
                        artist = s.Artist,
                        link = s.Link,
                        views = s.Views
                    })
                    .ToList();
                
                return Json(filteredSongs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error searching for songs with term: {term}");
                return Json(new List<object>());
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
