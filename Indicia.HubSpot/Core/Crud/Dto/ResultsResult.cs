using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Indicia.HubSpot.Core.Crud.Dto
{
    [DataContract]
    public class ResultsResult<T>
        where T : IHubSpotObject, new()
    {
        [DataMember(Name = "results")]
        public List<ObjectApiResult> InternalResults { internal get; set; } = new List<ObjectApiResult>();

        [JsonProperty] // This is mainly for the use of serialization for debugging purposes
        public IEnumerable<T> Results => InternalResults.Select(r => r.ToHubSpotObject<T>());

        public bool ShouldSerializeInternalResults() => false;  // This is mainly for the use of serialization for debugging purposes
    }
}