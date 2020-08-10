using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Contacts
{
    public class HubSpotContactApi<T> : HubSpotObjectApi<T> 
        where T : HubSpotContactObject, new()
    {
        protected override string EntityRoute => "/contacts";

        public HubSpotContactApi(IHubSpotClient client) : base(client)
        {
        }
    }
}