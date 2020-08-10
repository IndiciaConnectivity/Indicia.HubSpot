using System.Collections.Generic;

namespace Indicia.HubSpot.Core.Parameters
{
    public abstract class CrudParametersBase : IPropertiesParameters, IAssociationsParameters, IArchivedParameters, IQueryParameters
    {
        public IEnumerable<string> Properties { get; set; } = new List<string>();
        
        public IEnumerable<string> Associations { get; set; } = new List<string>();
        
        public bool Archived { get; set; }
    }
}