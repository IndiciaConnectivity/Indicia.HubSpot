using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    internal class BatchRequest<T>
    {
        [DataMember(Name = "inputs")]
        public IEnumerable<T> Inputs { get; set; } = new List<T>();
    }
}