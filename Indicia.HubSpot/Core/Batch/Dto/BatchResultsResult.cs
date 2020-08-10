using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Indicia.HubSpot.Core.Crud.Dto;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    public class BatchResultsResult<T> : ResultsResult<T>
        where T : IHubSpotObject, new()
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        
        [DataMember(Name = "requestedAt")]
        public DateTimeOffset RequestedAt { get; set; }
        
        [DataMember(Name = "startedAt")]
        public DateTimeOffset? StartedAt { get; set; }
        
        [DataMember(Name = "completedAt")]
        public DateTimeOffset? CompletedAt { get; set; }
        
        [DataMember(Name = "links")]
        public Dictionary<string, object> Links { get; set; } = new Dictionary<string, object>(); // Not an IDictionary, since the deserialization does not like that.

    }
}