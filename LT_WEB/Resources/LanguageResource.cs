using System.Collections.Generic;

namespace DoAN_WEB.Resources
{
    public static class LanguageResource
    {
        private static Dictionary<string, Dictionary<string, string>> _translations = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "vi", new Dictionary<string, string>
                {
                    { "PageTitle", "Tìm Kiếm Bài Hát" },
                    { "SearchTitle", "Tìm Kiếm Bài Hát" },
                    { "SearchLabel", "Nhập tên bài hát hoặc ca sĩ:" },
                    { "SearchPlaceholder", "Gõ để tìm kiếm..." },
                    { "SongInfoTitle", "Thông tin bài hát" },
                    { "ViewsText", "lượt xem" },
                    { "NoResults", "Không tìm thấy bài hát phù hợp" },
                    { "SearchError", "Đã xảy ra lỗi khi tìm kiếm" },
                    { "LoadingText", "Đang tìm..." },
                    { "LanguageToggle", "English" }
                }
            },
            {
                "en", new Dictionary<string, string>
                {
                    { "PageTitle", "Song Search" },
                    { "SearchTitle", "Find Songs" },
                    { "SearchLabel", "Enter song name or artist:" },
                    { "SearchPlaceholder", "Type to search..." },
                    { "SongInfoTitle", "Song Information" },
                    { "ViewsText", "views" },
                    { "NoResults", "No songs found matching your search" },
                    { "SearchError", "An error occurred while searching" },
                    { "LoadingText", "Searching..." },
                    { "LanguageToggle", "Tiếng Việt" }
                }
            }
        };

        public static string GetText(string language, string key)
        {
            if (string.IsNullOrEmpty(language) || !_translations.ContainsKey(language))
            {
                language = "vi"; // Default to Vietnamese
            }

            if (_translations[language].ContainsKey(key))
            {
                return _translations[language][key];
            }

            return key; // Return the key if translation not found
        }

        // Helper method để lấy ngôn ngữ chuyển đổi tiếp theo
        public static string GetNextLanguage(string currentLanguage)
        {
            return currentLanguage == "en" ? "vi" : "en";
        }
    }
} 