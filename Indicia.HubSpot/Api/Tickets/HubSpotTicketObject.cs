﻿using System.Runtime.Serialization;
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
        /// The last time a note, call, email, meeting, or task was logged for a ticket. This is updated automatically by HubSpot.
        /// </summary>
        [DataMember(Name = "hs_lastactivitydate")]
        public string LastActivityDate { get; set; }
        
        /// <summary>
        /// Most recent timestamp of any property update for this ticket. This includes HubSpot internal properties, which can be visible or hidden. This property is updated automatically.
        /// </summary>
        [DataMember(Name = "hs_lastmodifieddate")]
        public string LastModifiedDate { get; set; }
        
        /// <summary>
        /// The date the ticket was closed
        /// </summary>
        [DataMember(Name = "closed_date")]
        public string CloseDate { get; set; }
        
        /// <summary>
        /// Short summary of ticket
        /// </summary>
        [DataMember(Name = "subject")]
        public string TicketName { get; set; }
        
        /// <summary>
        /// Description of the ticket
        /// </summary>
        [DataMember(Name = "content")]
        public string Content { get; set; }
        
        /// <summary>
        /// The level of attention needed on the ticket
        /// </summary>
        [DataMember(Name = "hs_ticket_priority")]
        public string Priority { get; set; }
        
        /// <summary>
        /// Channel where ticket was originally submitted
        /// </summary>
        [DataMember(Name = "source_type")]
        public string Source { get; set; }
        
        /// <summary>
        /// The user IDs of all owners of this object
        /// </summary>
        [DataMember(Name = "hs_user_ids_of_all_owners")]
        public string UserIdsOfAllOwners { get; set; }

        [IgnoreDataMember] public string ObjectType => "ticket";
    }
}