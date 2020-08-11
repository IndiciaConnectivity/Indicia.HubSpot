using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Tickets
{
    public class HubSpotTicketApi<T> : HubSpotObjectApi<T>
        where T : HubSpotTicketObject, new()
    {
        protected override string EntityRoute => "/tickets";

        public HubSpotTicketApi(IHubSpotClient client) : base(client)
        {
        }
    }
}