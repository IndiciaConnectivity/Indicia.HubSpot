using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Indicia.HubSpot.Core
{
    public abstract partial class HubSpotObjectApi<T>
        where T : class, IHubSpotObject, new()
    {
        public Task AssociateAsync(IHubSpotObject fromObject, IHubSpotObject toObject, CancellationToken cancellationToken = default)
        {
            var path = GetAssociationRoute<T>(fromObject, toObject);
            return _client.ExecuteOnlyAsync(path, Method.PUT, cancellationToken);
        }

        public Task UnassociateAsync(IHubSpotObject fromObject, IHubSpotObject toObject, CancellationToken cancellationToken = default)
        {
            var path = GetAssociationRoute<T>(fromObject, toObject);
            return _client.ExecuteOnlyAsync(path, Method.DELETE, cancellationToken);
        }

        public async Task<IEnumerable<TTo>> ListAssociationsAsync<TTo>(IHubSpotObject fromObject, CancellationToken cancellationToken = default)
            where TTo : IHubSpotObject, new()
        {
            var path = GetAssociationRoute<T, TTo>(fromObject);
            var result = await _client.ExecuteAsync<List<TTo>>(path, Method.GET, cancellationToken);
            return result;
        }
    }
}