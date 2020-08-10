using System;
using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Core.Crud;
using Indicia.HubSpot.Core.Crud.Dto;
using Indicia.HubSpot.Core.Parameters;
using RestSharp;

namespace Indicia.HubSpot.Core
{
    public abstract partial class HubSpotObjectApi<T>
        where T : class, IHubSpotObject, new()
    {
        public async Task<T> CreateAsync(T obj, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>();
            var request = new CreateRequest(obj);
            var result = await _client.ExecuteAsync<ObjectApiResult, CreateRequest>(path, request, Method.POST, cancellationToken);
            return result.ToHubSpotObject<T>();
        }

        public async Task<T> UpdateAsync(T obj, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(obj.Id))
            {
                throw new ArgumentNullException($"{nameof(obj.Id)}");
            }
            
            var path = GetRoute<T>(obj.Id);
            var request = new UpdateRequest(obj);
            var result = await _client.ExecuteAsync<ObjectApiResult, UpdateRequest>(path, request, Method.PATCH, cancellationToken);
            return result.ToHubSpotObject<T>();
        }

        public Task ArchiveAsync(T obj, CancellationToken cancellationToken = default)
        {
            return ArchiveAsync(obj.Id, cancellationToken);
        }

        public Task ArchiveAsync(string id, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>(id);
            return _client.ExecuteOnlyAsync(path, Method.DELETE, cancellationToken);
        }

        public async Task<T> ReadAsync(string id, ReadParameters parameters = null, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>(id);

            parameters = parameters ?? new ReadParameters();

            var queryParameters = parameters.GetQueryParameters();

            var result =  await _client.ExecuteAsync<ObjectApiResult>(path, Method.GET, cancellationToken, queryParameters, parameters.NotFoundReturnsNull);

            return result?.ToHubSpotObject<T>();
        }

        public Task<ListResult<T>> ListAsync(ListParameters parameters = null, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>();

            parameters = parameters ?? new ListParameters();

            var queryParameters = parameters.GetQueryParameters();

            return _client.ExecuteAsync<ListResult<T>>(path, Method.GET, cancellationToken, queryParameters);
        }

    }
}