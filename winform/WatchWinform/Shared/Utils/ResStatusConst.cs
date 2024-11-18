namespace WatchWinform.Shared.Utils
{
    public static class ResStatusConst
    {
        public static class Code
        {
            public const int SUCCESS = 0;
            public const int UNAUTHORIZED = 1;
            public const int PERMISSION_DENIED = 2;
            public const int ALREADY_EXISTS = 3;
            public const int NOT_FOUND = 4;
            public const int EXPIRED = 5;
            public const int INVALID_PARAM = 6;
            public const int SYSTEM_ERROR = 7;
            public const int LOCKED = 8;
            public const int UNKNOWN = 99;
            public const int EXIST_IN_COMMON_PASS_DIC = 9;
        }
        public static class Message
        {
            public const string SUCCESS = "Thành công";
            public const string UNAUTHORIZED = "Truy cập trái phép";
            public const string PERMISSION_DENIED = "Quyền truy cập bị từ chối";
            public const string ALREADY_EXISTS = "{0} đã tồn tại";
            public const string NOT_FOUND = "{0} không tìm thấy hoặc không tồn tại";
            public const string EXPIRED = "{0} đã hết hạn";
            public const string INVALID_PARAM = "Sai thông số: {0}";
            public const string SYSTEM_ERROR = "Lỗi hệ thống";
            public const string LOCKED = "{0} đã bị khoá";
            public const string UNKNOWN = "Lỗi không xác định";
        }
    }
}
