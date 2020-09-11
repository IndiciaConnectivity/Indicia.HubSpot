namespace Indicia.HubSpot.Core
{
    public interface IHubSpotObject
    {
        /// <summary>
        /// The object type, needed for associations
        /// </summary>
        string ObjectType { get; }
        
        /// <summary>
        /// The HubSpot object identifier
        /// </summary>
        string Id { get; set; }
    }
}