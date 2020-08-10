using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Parameters
{
    public interface IArchivedParameters
    {
        /// <summary>
        /// Whether to return only results that have been archived. Defaults to false.
        /// </summary>
        [DataMember(Name = "archived")]
        bool Archived { get; set; }
    }
}