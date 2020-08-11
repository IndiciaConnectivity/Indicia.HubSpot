using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Tickets
{
    public static class HubSpotApiExtensions
    {
        public static IHubSpotObjectApi<HubSpotTicketObject> GetTicketApi(this IHubSpotApi api)
            => api.GetObjectApi<HubSpotTicketObject>();

        public static IHubSpotObjectApi<T> GetTicketApi<T>(this IHubSpotApi api)
            where T : HubSpotTicketObject, new()
            => api.GetObjectApi<T>();
    }
}