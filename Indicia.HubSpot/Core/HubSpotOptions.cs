using Indicia.HubSpot.Core.Auth;

namespace Indicia.HubSpot.Core
{
    public class HubSpotOptions
    {
        public IHubSpotClientAuth Auth { get; set; }
        public bool UseHttpLogging { get; set; }
    }
}