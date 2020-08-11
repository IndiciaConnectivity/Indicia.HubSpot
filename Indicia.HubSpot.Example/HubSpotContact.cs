using System;
using System.Runtime.Serialization;
using Indicia.HubSpot.Api.Contacts;

namespace Indicia.HubSpot.Example
{
    public class HubSpotContact : HubSpotContactObject
    {
        /// <summary>
        /// The date that a contact entered the system
        /// </summary>
        [DataMember(Name = "createdate")]
        public DateTime CreateDate { get; set; }
    }
}