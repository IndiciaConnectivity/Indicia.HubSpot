using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Parameters
{
    public interface IPagingParameters
    {
        [DataMember(Name = "limit")]
        int? Limit { get; set; }
        
        [DataMember(Name = "after")]
        string After { get; set; }
    }
}