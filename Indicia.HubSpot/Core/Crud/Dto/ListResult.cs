using System.Runtime.Serialization;
using Indicia.HubSpot.Core.Paging;

namespace Indicia.HubSpot.Core.Crud.Dto
{
    [DataContract]
    public class ListResult<T> : ResultsResult<T>
        where T : IHubSpotObject, new()
    {
        [DataMember(Name = "paging")]
        public HubSpotPaging Paging { get; set; }
    }
}