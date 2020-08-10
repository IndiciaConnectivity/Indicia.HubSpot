using System.Runtime.Serialization;
using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Companies
{
    [DataContract(Name = "company")]
    public class HubSpotCompanyObject : IHubSpotObject
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }
        
        [IgnoreDataMember] public string ObjectType => "company";
    }
}