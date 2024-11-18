using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchWinform.API
{
    public static class ApiSettings
    {
        public static string BaseAddress { get; set; } = "https://localhost:7087/api/";
        public static string BearerToken { get; set; }
    }

}
