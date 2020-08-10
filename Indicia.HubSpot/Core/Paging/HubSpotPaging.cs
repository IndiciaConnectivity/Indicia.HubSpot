using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Paging
{
    [DataContract]
    public class HubSpotPaging
    {
        [DataMember(Name = "next")]
        public HubSpotPagingNext Next { get; set; }
    }
}