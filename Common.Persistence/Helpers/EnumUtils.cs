using System;
using System.ComponentModel;

namespace Common.Persistence.Helpers
{
    public static class EnumUtils
    {
        public static string GetEnumDescription(this Enum value)
        {
            // variables  
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            if (field == null)
                return string.Empty;
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // return  
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
