using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Contacts
{
    public static class HubSpotApiExtensions
    {
        public static IHubSpotObjectApi<HubSpotContactObject> GetContactApi(this IHubSpotApi api)
            => api.GetObjectApi<HubSpotContactObject>();

        public static IHubSpotObjectApi<T> GetContactApi<T>(this IHubSpotApi api)
            where T : HubSpotContactObject, new()
            => api.GetObjectApi<T>();
    }
}