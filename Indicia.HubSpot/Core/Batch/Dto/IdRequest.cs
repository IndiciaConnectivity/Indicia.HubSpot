using System.Runtime.Serialization;

namespace Indicia.HubSpot.Core.Batch.Dto
{
    [DataContract]
    public class IdRequest
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}