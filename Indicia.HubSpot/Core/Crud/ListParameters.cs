using Indicia.HubSpot.Core.Parameters;

namespace Indicia.HubSpot.Core.Crud
{
    public class ListParameters : CrudParametersBase, IPagingParameters
    {
        public int? Limit { get; set; }
        
        public string After { get; set; }
    }
}