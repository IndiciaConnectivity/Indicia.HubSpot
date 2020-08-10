using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    internal class BatchArchiveRequest : BatchRequest<IdRequest>
    {
        public BatchArchiveRequest(IEnumerable<string> ids)
        {
            Inputs = ids.Select(id => new IdRequest {Id = id});
        }
    }
}