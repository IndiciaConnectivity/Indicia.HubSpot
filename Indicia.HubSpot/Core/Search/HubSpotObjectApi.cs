using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Core.Search.Dto;
using RestSharp;

namespace Indicia.HubSpot.Core
{
    public abstract partial class HubSpotObjectApi<T>
        where T : class, IHubSpotObject, new()
    {
        public Task<SearchResult<T>> SearchAsync(SearchParameters parameters, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>("search");
            return _client.ExecuteAsync<SearchResult<T>, SearchParameters>(path, parameters, Method.POST, cancellationToken);
        }


    }
}