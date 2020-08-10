using System.Collections.Generic;
using Indicia.HubSpot.Core.Associations;
using Indicia.HubSpot.Core.Batch;
using Indicia.HubSpot.Core.Crud;
using Indicia.HubSpot.Core.Search;

namespace Indicia.HubSpot.Core
{
    public interface IHubSpotObjectApi<T> : IHubSpotObjectApi, IHubSpotApiCrudable<T>, IHubSpotApiAssociable<T>, IHubSpotApiSearchable<T>, IHubSpotApiBatchable<T>
        where T : class, IHubSpotObject, new()
    {
    }
    
    public interface IHubSpotObjectApi
    {
        /// <summary>
        /// Helper for multiple endpoints to easily retrieve all the object type's properties.
        /// </summary>
        IEnumerable<string> AllProperties { get; }
    }
}