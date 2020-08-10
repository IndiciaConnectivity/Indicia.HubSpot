using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Core.Search.Dto;

namespace Indicia.HubSpot.Core.Search
{
    public interface IHubSpotApiSearchable<T>
        where T : IHubSpotObject, new()
    {
        Task<SearchResult<T>> SearchAsync(SearchParameters parameters, CancellationToken cancellationToken = default);
    }
}