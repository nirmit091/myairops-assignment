using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace APIGateway.Util
{
    public static class Utilities
    {
        public static Dictionary<string, string> ToStringDictionary(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return obj.ToDictionary().ToDictionary(x => x.Key, x => x.Value?.ToString());
        }

        public static Dictionary<string, object> ToDictionary(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null));
        }
    }
}
