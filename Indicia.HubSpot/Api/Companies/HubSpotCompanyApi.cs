using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Companies
{
    public class HubSpotCompanyApi<T> : HubSpotObjectApi<T> 
        where T : HubSpotCompanyObject, new()
    {
        protected override string EntityRoute => "/companies";

        public HubSpotCompanyApi(IHubSpotClient client) : base(client)
        {
        }
    }
}