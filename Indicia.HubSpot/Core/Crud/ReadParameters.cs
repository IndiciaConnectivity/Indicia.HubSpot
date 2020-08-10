using Indicia.HubSpot.Core.Parameters;

namespace Indicia.HubSpot.Core.Crud
{
    public class ReadParameters : CrudParametersBase, IIdPropertyParameters, INotFoundParameters, IQueryParameters
    {
        public string IdProperty { get; set; } = "id";
        
        public bool NotFoundReturnsNull { get; set; }
    }
}