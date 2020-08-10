using System.Collections.Generic;

namespace Indicia.HubSpot.Core.Serializers
{
    internal static class QueryParameterSerializer
    {
        public static string Serialize<T>(T obj)
        {
            if (obj is bool b)
            {
                return b ? "true" : "false";
            }

            if (obj is IEnumerable<object> en)
            {
                return string.Join(",", en);
            }

            return obj.ToString();
        }
    }
}