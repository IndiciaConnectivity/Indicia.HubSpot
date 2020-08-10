using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    internal class BatchReadRequest : BatchRequest<IdRequest>
    {
        [DataMember(Name = "properties")]
        public IEnumerable<string> Properties { get; set; }

        [DataMember(Name = "idProperty")]
        public string IdProperty { get; set; }

        public BatchReadRequest(IEnumerable<string> ids, BatchReadParameters ctx)
        {
            Inputs = ids.Select(id => new IdRequest {Id = id});
            Properties = ctx?.Properties ?? new List<string> { "id" };
            IdProperty = ctx?.IdProperty;
        }
    }
}