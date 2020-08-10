using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Core.Batch.Dto;

namespace Indicia.HubSpot.Core.Batch
{
    public interface IHubSpotApiBatchable<T>
        where T : IHubSpotObject, new()
    {
        Task<BatchCreateResult<T>> BatchCreateAsync(IEnumerable<T> objects, CancellationToken cancellationToken = default);
        Task<BatchUpdateResult<T>> BatchUpdateAsync(IEnumerable<T> objects, CancellationToken cancellationToken = default);
        Task BatchArchiveAsync(IEnumerable<string> objectIds, CancellationToken cancellationToken = default);
        Task<BatchReadResult<T>> BatchReadAsync(IEnumerable<string> objectIds, BatchReadParameters parameters = null, CancellationToken cancellationToken = default);
    }
}