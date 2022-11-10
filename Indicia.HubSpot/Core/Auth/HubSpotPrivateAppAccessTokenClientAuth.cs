using RestSharp;
using System.Threading;
using System.Threading.Tasks;

namespace Indicia.HubSpot.Core.Auth
{
    public class HubSpotPrivateAppAccessTokenClientAuth : IHubSpotClientAuth
    {
        private const string headerName = "authorization";
        private readonly string _privateAppAccessToken;

        private string headerValue => $"Bearer {_privateAppAccessToken}";

        public HubSpotPrivateAppAccessTokenClientAuth(string privateAppAccessToken)
        {
            _privateAppAccessToken = privateAppAccessToken;
        }
        public Task ConfigureAuthAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            request.AddHeader(headerName, headerValue);
            return Task.CompletedTask;
        }

        public string AnonymizeUrl(string url)
        {
            return url;
        }
    }
}
