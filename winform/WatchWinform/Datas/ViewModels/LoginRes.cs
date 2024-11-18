using WatchWinform.Datas.Models;

namespace WatchWinform.Datas.ViewModels
{
    public class LoginRes
    {
        public LoginRes()
        {
        }
        public LoginRes(string accessToken, Account user)
        {
            AccessToken = accessToken;
            User = user;
        }

        /// <summary>
        /// Bearer Token dùng để truy xuất API
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Thông tin người dùng
        /// </summary>
        public Account User { get; set; }
    }
}
