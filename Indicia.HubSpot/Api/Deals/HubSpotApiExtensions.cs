using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Deals
{
    public static class HubSpotApiExtensions
    {
        public static IHubSpotObjectApi<HubSpotDealObject> GetDealApi(this IHubSpotApi api)
            => api.GetObjectApi<HubSpotDealObject>();

        public static IHubSpotObjectApi<T> GetDealApi<T>(this IHubSpotApi api)
            where T : HubSpotDealObject, new()
            => api.GetObjectApi<T>();
    }
}