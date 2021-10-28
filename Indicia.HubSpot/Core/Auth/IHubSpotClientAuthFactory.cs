using System.Threading;
using System.Threading.Tasks;

namespace Indicia.HubSpot.Core.Auth
{
    public interface IHubSpotClientAuthFactory
    {
        Task<IHubSpotClientAuth> CreateAsync(CancellationToken cancellationToken = default);
    }
}