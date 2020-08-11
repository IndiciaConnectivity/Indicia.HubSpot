using System.Runtime.Serialization;
using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api.Tickets
{
    [DataContract(Name = "ticket")]
    public class HubSpotTicketObject : IHubSpotObject
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Main reason customer reached out for help
        /// </summary>
        [DataMember(Name = "hs_ticket_category")]
        public string Category { get; set; }
        
        /// <summary>
        /// The pipeline that contains this ticket
        /// </summary>
        [DataMember(Name = "hs_pipeline")]
        public string Pipeline { get; set; }
        
        /// <summary>
        /// The pipeline stage that contains this ticket
        /// </summary>
        [DataMember(Name = "hs_pipeline_stage")]
        public string TicketStatus { get; set; }
        
        /// <summary>
        /// The date the ticket was created
        /// </summary>
        [DataMember(Name = "createdate")]
        public string CreateDate { get; set; }
        
        /// <summary>
        /// The level of attention needed on the ticket
        /// </summary>
        [DataMember(Name = "hs_ticket_priority")]
        public string Priority { get; set; }

        [IgnoreDataMember] public string ObjectType => "ticket";
    }
}