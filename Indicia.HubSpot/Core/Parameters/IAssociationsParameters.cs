using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Parameters
{
    public interface IAssociationsParameters
    {
        /// <summary>
        /// A list of object types to retrieve associated IDs for. If any of the specified associations do not exist, they will be ignored.
        /// </summary>
        [DataMember(Name = "associations")]
        IEnumerable<string> Associations { get; set; }
    }
}