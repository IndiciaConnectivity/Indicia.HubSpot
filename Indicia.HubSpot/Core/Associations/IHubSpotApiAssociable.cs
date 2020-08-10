using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Indicia.HubSpot.Core.Associations
{
    public interface IHubSpotApiAssociable<T>
        where T : IHubSpotObject, new()
    {
        Task AssociateAsync(IHubSpotObject fromObject, IHubSpotObject toObject, CancellationToken cancellationToken = default);
        
        Task UnassociateAsync(IHubSpotObject fromObject, IHubSpotObject toObject, CancellationToken cancellationToken = default);

        Task<IEnumerable<TTo>> ListAssociationsAsync<TTo>(IHubSpotObject fromObject, CancellationToken cancellationToken = default)
            where TTo : IHubSpotObject, new();
    }
}