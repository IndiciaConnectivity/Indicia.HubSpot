using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Core.Crud.Dto;

namespace Indicia.HubSpot.Core.Crud
{
    public interface IHubSpotApiCrudable<T>
        where T : IHubSpotObject, new()
    {

        Task<T> CreateAsync(T obj, CancellationToken cancellationToken = default);
        
        Task<T> UpdateAsync(T obj, CancellationToken cancellationToken = default);
        
        Task ArchiveAsync(T obj, CancellationToken cancellationToken = default);
        
        Task ArchiveAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Read an Object identified by {id}.
        /// {id} refers to the internal object ID by default, or optionally any unique property value as specified by the IdProperty property of the ReadContext.
        /// Control what is returned via the properties param.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> ReadAsync(string id, ReadParameters parameters = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Read a page of objects.
        /// Control what is returned via the Properties property of the ListContext.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<ListResult<T>> ListAsync(ListParameters parameters = null, CancellationToken cancellationToken = default);
        
    }
}