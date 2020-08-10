using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Companies
{
    public static class HubSpotApiExtensions
    {
        public static IHubSpotObjectApi<HubSpotCompanyObject> GetCompanyApi(this IHubSpotApi api)
            => api.GetObjectApi<HubSpotCompanyObject>();

        public static IHubSpotObjectApi<T> GetCompanyApi<T>(this IHubSpotApi api)
            where T : HubSpotCompanyObject, new()
            => api.GetObjectApi<T>();
    }
}