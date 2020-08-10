using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Parameters
{
    public interface IIdPropertyParameters
    {
        /// <summary>
        /// The name of a property whose values are unique for this object type. Defaults to "id".
        /// </summary>
        [DataMember(Name = "idProperty")]
        string IdProperty { get; set; }
    }
}