using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Deals
{
    public class HubSpotDealApi<T> : HubSpotObjectApi<T>
        where T : HubSpotDealObject, new()
    {
        protected override string EntityRoute => "/deals";

        public HubSpotDealApi(IHubSpotClient client) : base(client)
        {
        }
    }
}