using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace Indicia.HubSpot.Core
{
    public interface IHubSpotClient
    {
        Task<TResponse> ExecuteAsync<TResponse>(string absoluteUriPath, Method method = Method.GET, CancellationToken cancellationToken = default, IDictionary<string,string> queryParameters = null, bool notFoundReturnsNull = false)
            where TResponse : new();
        
        Task<TResponse> ExecuteAsync<TResponse, TRequest>(string absoluteUriPath, TRequest entity, Method method = Method.GET, CancellationToken cancellationToken = default, IDictionary<string,string> queryParameters = null, bool notFoundReturnsNull = false)
            where TResponse : new();        
        
        Task ExecuteOnlyAsync(string absoluteUriPath, Method method = Method.GET, CancellationToken cancellationToken = default, IDictionary<string,string> queryParameters = null);
        
        Task ExecuteOnlyAsync<TRequest>(string absoluteUriPath, TRequest entity, Method method = Method.GET, CancellationToken cancellationToken = default, IDictionary<string,string> queryParameters = null);
    }
}