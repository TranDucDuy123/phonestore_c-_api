using System.Reflection;

namespace WatchWinform.Helpers
{
    public static class AutoMapperCF
    {
        public static T MapperNotNull<T>(T obj, T des) where T : class
        {
            if (obj != null && des != null)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(obj);
                    if (value != null)
                    {
                        PropertyInfo desProperty = des.GetType().GetProperty(property.Name);
                        if (desProperty != null && desProperty.PropertyType == property.PropertyType)
                        {
                            desProperty.SetValue(des, value);
                        }
                    }
                }
            }

            return des;
        }
    }

}
