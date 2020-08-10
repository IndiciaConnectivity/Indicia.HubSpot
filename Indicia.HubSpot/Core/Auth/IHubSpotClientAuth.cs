using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Indicia.HubSpot.Core.Auth
{
    public interface IHubSpotClientAuth
    {
        Task ConfigureAuthAsync(IRestRequest request, CancellationToken cancellationToken = default);

        string AnonymizeUrl(string url);
    }
}