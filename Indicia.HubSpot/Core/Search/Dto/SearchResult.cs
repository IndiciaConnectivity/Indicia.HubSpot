using System.Runtime.Serialization;
using Indicia.HubSpot.Core.Crud.Dto;

namespace Indicia.HubSpot.Core.Search.Dto
{
    [DataContract]
    public class SearchResult<T> : ListResult<T>
        where T : IHubSpotObject, new()
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }
    }
}