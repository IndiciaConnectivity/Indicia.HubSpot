using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace Indicia.HubSpot.Support
{
    internal static class RestRequestExtensions
    {
        public static void AddQueryParameters(this RestRequest request, IDictionary<string, string> queryParameters)
        {
            if (queryParameters == null || !queryParameters.Any())
            {
                return;
            }

            foreach (var queryParameter in queryParameters)
            {
                request.AddQueryParameter(queryParameter.Key, queryParameter.Value);
            }
        }
    }
}