using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Paging
{
    [DataContract]
    public class HubSpotPagingNext
    {
        [DataMember(Name = "after")]
        public string After { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }
    }
}