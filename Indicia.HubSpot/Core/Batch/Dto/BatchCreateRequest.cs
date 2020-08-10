using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Indicia.HubSpot.Core.Crud.Dto;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    internal class BatchCreateRequest : BatchRequest<CreateRequest>
    {
        public BatchCreateRequest(IEnumerable<IHubSpotObject> objects)
        {
            Inputs = objects.Select(o => new CreateRequest(o));
        }
    }
}