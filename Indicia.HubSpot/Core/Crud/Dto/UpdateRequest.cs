using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Crud.Dto
{
    [DataContract]
    internal class UpdateRequest : CreateRequest
    {
        public UpdateRequest(IHubSpotObject obj) : base(obj)
        {
            Id = Properties["id"].ToString();
            Properties.Remove("id");
        }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
    
}