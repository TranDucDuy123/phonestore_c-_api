namespace WatchWinform.Utils
{
    public static class BaseConst
    {
        public static class RoleCode
        {
            public const string ADMIN = "Admin"; //Quản trị hệ thống (toàn quyền trong hệ thống)
            public const string USER = "User"; //Cán bộ vận hành (gồm: Lãnh đạo sở, Lãnh đạo phòng, Chuyên viên sở, Chuyên viên ngoài sở thuộc UBND huyện, Doanh nghiệp)
        }

        public static class Route
        {
            public const string ID = "{id}";
        }
        
        public static class QueryKey
        {
            public const string PAGE_INDEX = "pageIndex";
            public const string PAGE_SIZE = "pageSize";
            public const string SORT_BY = "sortBy";
            public const string SORT_ORDER = "sortOrder";
            public const string SEARCH_KEY = "searchKey";
            public const string SHOW_COLUMNS = "showColumns";
            public const string CODE = "code";
            public const string OBJ_CLASS_CODE = "objClassCode";
            public const string OBJ_CLASS_SUB_CODE = "objClassSubCode";
            public const string DISTRICT_CODE = "districtCode";
            public const string WARD_CODE = "wardCode";
            public const string YEAR = "year";
            public const string MONTH = "month";
            public const string QUARTER = "quarter";
            public const string FROM_DATE = "fromDate";
            public const string TO_DATE = "toDate";
            public const string ELASTIC_SEARCH = "es";
            public const string SECTOR = "sector";
            public const string DEPARTMENT_ID = "departmentId";
            public const string PARENT_OBJ_CLASS_CODE = "parentObjClassCode";
        }

        public static class DefaultVal
        {
            public const int PAGE_INDEX = 1;
            public const int PAGE_SIZE = 10;
            public const string SORT_BY = "id";
            public const string SORT_ORDER = "asc";
        }

        public static class ModelStatus
        {
            public const int LOCKED = 0;
            public const int ACTIVE = 1;
        }

        public static class Formatter
        {
            public const string YMD = "yyyy-MM-dd";
            public const string DMY = "dd/MM/yyyy";
            public const string HMS = "HH:mm:ss";
            public const string YMDHMS = "yyyy-MM-dd HH:mm:ss";
            public const string DMYHMS = "dd/MM/yyyy HH:mm:ss";
        }

        public static class Header
        {
            public const string TOKEN = "Authorization";
        }
    }
}
