using System.Collections.Generic;
using Indicia.HubSpot.Core.Parameters;

namespace Indicia.HubSpot.Core.Batch
{
    public class BatchReadParameters : IPropertiesParameters, IIdPropertyParameters
    {
        public IEnumerable<string> Properties { get; set; } = new List<string>();

        public string IdProperty { get; set; } = "id";

    }
}