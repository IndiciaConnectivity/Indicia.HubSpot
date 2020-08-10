using System.Runtime.Serialization;
using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Contacts
{
    [DataContract(Name = "contact")]
    public class HubSpotContactObject : IHubSpotObject
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
        
        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }
        
        [DataMember(Name = "lastname")]
        public string LastName { get; set; }
        
        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "company")]
        public string Company { set; get; }
        
        [DataMember(Name = "phone")]
        public string Phone { set; get; }
        
        [DataMember(Name = "address")]
        public string Address { set; get; }
        
        [DataMember(Name = "city")]
        public string City { set; get; }
        
        [DataMember(Name = "state")]
        public string State { set; get; }
        
        [DataMember(Name = "zip")]
        public string ZipCode { set; get; }

        [IgnoreDataMember] public string ObjectType => "contact";
    }
}