using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Core.Batch;
using Indicia.HubSpot.Core.Batch.Dto;
using RestSharp;

namespace Indicia.HubSpot.Core
{
    public abstract partial class HubSpotObjectApi<T>
        where T : class, IHubSpotObject, new()
    {
        public Task<BatchCreateResult<T>> BatchCreateAsync(IEnumerable<T> objects, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>("batch", "create");
            var request = new BatchCreateRequest(objects);
            return _client.ExecuteAsync<BatchCreateResult<T>, BatchCreateRequest>(path, request, Method.POST, cancellationToken);
        }
        
        public Task<BatchReadResult<T>> BatchReadAsync(IEnumerable<string> objectIds, BatchReadParameters ctx = null, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>("batch", "read");
            var request = new BatchReadRequest(objectIds, ctx);
            return _client.ExecuteAsync<BatchReadResult<T>, BatchReadRequest>(path, request, Method.POST, cancellationToken);
        }

        public Task<BatchUpdateResult<T>> BatchUpdateAsync(IEnumerable<T> objects, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>("batch", "update");
            var request = new BatchUpdateRequest(objects);
            return _client.ExecuteAsync<BatchUpdateResult<T>, BatchUpdateRequest>(path, request, Method.POST, cancellationToken);
        }

        public Task BatchArchiveAsync(IEnumerable<string> objectIds, CancellationToken cancellationToken = default)
        {
            var path = GetRoute<T>("batch", "archive");
            var request = new BatchArchiveRequest(objectIds);
            return _client.ExecuteOnlyAsync(path, request, Method.POST, cancellationToken);
        }
    }
}