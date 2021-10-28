using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Indicia.HubSpot.Core.Auth
{
    public class HubSpotApiKeyClientAuth : IHubSpotClientAuth
    {
        private const string ApiKeyName = "hapikey";
        private readonly string _apiKey;

        public HubSpotApiKeyClientAuth(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Task ConfigureAuthAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            request.AddQueryParameter(ApiKeyName, _apiKey);

            return Task.CompletedTask;
        }

        public string AnonymizeUrl(string url)
        {
            return url?.Replace(_apiKey, "****");
        }
    } 
}