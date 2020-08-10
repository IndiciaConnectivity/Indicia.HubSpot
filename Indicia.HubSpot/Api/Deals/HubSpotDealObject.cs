using System.Runtime.Serialization;
using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Deals
{
    [DataContract(Name = "deal")]
    public class HubSpotDealObject : IHubSpotObject
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        
        [DataMember(Name = "dealname")]
        public string Name { get; set; }

        [DataMember(Name = "dealstage")]
        public string Stage { get; set; }

        [DataMember(Name = "pipeline")]
        public string Pipeline { get; set; }

        [DataMember(Name = "hubspot_owner_id")]
        public long? OwnerId { get; set; }

        [DataMember(Name = "closedate")]
        public string CloseDate { get; set; }

        [DataMember(Name = "amount")]
        public double? Amount { get; set; }

        [DataMember(Name = "dealtype")]
        public string DealType { get; set; }

        [IgnoreDataMember] public string ObjectType => "deal";
    }
}