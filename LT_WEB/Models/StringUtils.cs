using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DoAN_WEB.Models
{
    public static class StringUtils
    {
        /// <summary>
        /// Loại bỏ dấu tiếng Việt từ chuỗi
        /// </summary>
        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // Chuẩn hóa chuỗi (phân giải ký tự có dấu thành ký tự cơ bản + dấu)
            text = text.Normalize(NormalizationForm.FormD);
            
            // Tạo StringBuilder để lưu kết quả
            var sb = new StringBuilder();

            // Duyệt qua từng ký tự
            foreach (char c in text)
            {
                // Kiểm tra xem ký tự có phải là dấu không
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Kiểm tra chuỗi có chứa từ khóa không phân biệt dấu
        /// </summary>
        public static bool ContainsNoAccent(this string source, string keyword)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(keyword))
                return false;

            // Loại bỏ dấu từ cả nguồn và từ khóa
            var sourceNoAccent = source.RemoveDiacritics().ToLower();
            var keywordNoAccent = keyword.RemoveDiacritics().ToLower();

            return sourceNoAccent.Contains(keywordNoAccent);
        }
    }
} 