using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch.Helpper
{
    public static class Utilities
    {
        public static string StripHTML(string input)
        {
            try
            {
                if(!string.IsNullOrEmpty(input))
                {
                    return Regex.Replace(input, "<.*?>", String.Empty);
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        public static string SubstringIfLonger(string input, int length)
        {
            // Kiểm tra nếu độ dài của chuỗi lớn hơn 35
            if (input.Length > length)
            {
                // Cắt chuỗi và lấy 35 ký tự từ đầu
                return input.Substring(0, length);
            }
            else
            {
                // Trả về chuỗi ban đầu nếu độ dài không lớn hơn 35
                return input;
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; 
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static int PAGE_SIZE = 20;
        public static void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        public static string ToTitleCase(string str)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
            {
                var words = str.Split(' ');
                for (int index = 0; index < words.Length; index++)
                {
                    var s = words[index];
                    if (s.Length > 0)
                    {
                        words[index] = s[0].ToString().ToUpper() + s.Substring(1);
                    }
                }
                result = string.Join(" ", words);
            }
            return result;
        }
        public static bool IsInteger(string str)
        {
            Regex regex = new Regex(@"^[0-9]+$");

            try
            {
                if (String.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                if (!regex.IsMatch(str))
                {
                    return false;
                }

                return true;

            }
            catch
            {

            }
            return false;

        }
        public static string GetRandomKey(int length = 5)
        {
            //chuỗi mẫu (pattern)
            string pattern = @"0123456789zxcvbnmasdfghjklqwertyuiop[]{}:~!@#$%^&*()+";
            Random rd = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.Append(pattern[rd.Next(0, pattern.Length)]);
            }

            return sb.ToString();
        }
        public static string SEOUrl(string url)
        {
            url = url.ToLower();
            url = Regex.Replace(url, @"[áàạảãâấầậẩẫăắằặẳẵ]", "a");
            url = Regex.Replace(url, @"[éèẹẻẽêếềệểễ]", "e");
            url = Regex.Replace(url, @"[óòọỏõôốồộổỗơớờợởỡ]", "o");
            url = Regex.Replace(url, @"[íìịỉĩ]", "i");
            url = Regex.Replace(url, @"[ýỳỵỉỹ]", "y");
            url = Regex.Replace(url, @"[úùụủũưứừựửữ]", "u");
            url = Regex.Replace(url, @"[đ]", "d");

            //2. Chỉ cho phép nhận:[0-9a-z-\s]
            url = Regex.Replace(url.Trim(), @"[^0-9a-z-\s]", "").Trim();
            //xử lý nhiều hơn 1 khoảng trắng --> 1 kt
            url = Regex.Replace(url.Trim(), @"\s+", "-");
            //thay khoảng trắng bằng -
            url = Regex.Replace(url, @"\s", "-");
            while (true)
            {
                if (url.IndexOf("--") != -1)
                {
                    url = url.Replace("--", "-");
                }
                else
                {
                    break;
                }
            }
            return url;
        }
        public static async Task<string> UploadFile(Image image, string extension, string sDirectory, string newname = null)
        {
            try
            {
                if (newname == null)
                {
                    newname = "default.jpg";
                    return newname;
                };
                // Lấy đường dẫn thư mục chứa tập tin exe của ứng dụng
                string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                // Lấy thư mục gốc của dự án (thư mục chứa file .sln)
                string projectDirectory = Directory.GetParent(appDirectory).Parent.FullName;

                // Tạo đường dẫn đầy đủ đến thư mục chứa hình ảnh
                string imagePath = Path.Combine(projectDirectory, "Assets/Image", sDirectory);
                string imagePathFile = Path.Combine(projectDirectory, "Assets/Image", sDirectory, newname);
                string imagePathHd = Path.Combine(projectDirectory, "Assets/Image/FullHD", sDirectory);
                string imagePathHdFile = Path.Combine(projectDirectory, "Assets/Image/FullHD", sDirectory, newname);
                CreateIfMissing(imagePath);
                CreateIfMissing(imagePathHd);
                var supportedTypes = new[] { "jpg", "jpeg", "png"};
                if (!supportedTypes.Contains(extension.Substring(1).ToLower())) /// Khác các file định nghĩa
                {
                    return null;
                }
                else
                {
                    // Lưu hình ảnh vào thư mục
                    image.Save(imagePathFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    image.Save(imagePathHdFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return newname; // Trả về tên file mới
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
