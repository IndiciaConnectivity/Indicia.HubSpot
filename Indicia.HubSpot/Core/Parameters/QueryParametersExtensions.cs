using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Indicia.HubSpot.Core.Serializers;

namespace Indicia.HubSpot.Core.Parameters
{
    public static class QueryParametersExtensions
    {
        public static IDictionary<string, string> GetQueryParameters(this IQueryParameters parameters)
        {
            var queryParameters = new Dictionary<string, string>();

            var queryParameterLookup = parameters.GetType().GetInterfaces()
                .SelectMany(i => i.GetProperties())
                .Select(p => new {PropertyName = p.Name, DataMemberAttribute = p.GetCustomAttribute<DataMemberAttribute>()})
                .Where(a => a.DataMemberAttribute != null)
                .ToDictionary(a => a.PropertyName, a => a.DataMemberAttribute.Name);

            var props = parameters.GetType().GetProperties()
                .Where(p => queryParameterLookup.ContainsKey(p.Name))
                .Where(p => p.GetValue(parameters, null) != null)
                .ToDictionary(p => queryParameterLookup[p.Name], p => p.GetValue(parameters));

            foreach (var prop in props)
            {
                var val = QueryParameterSerializer.Serialize(prop.Value);

                if (!string.IsNullOrEmpty(val))
                {
                    queryParameters[prop.Key] = val;
                }
            }

            return queryParameters;
        }
    }
}