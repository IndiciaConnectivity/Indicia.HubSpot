using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Parameters
{
    public interface IPropertiesParameters
    {
        /// <summary>
        /// A list of the properties to be returned in the response. If any of the specified properties are not present on the requested object(s), they will be ignored.
        /// </summary>
        [DataMember(Name = "properties")]
        IEnumerable<string> Properties { get; set; }
    }
}