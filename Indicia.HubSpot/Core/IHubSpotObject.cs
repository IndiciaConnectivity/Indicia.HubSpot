namespace Indicia.HubSpot.Core
{
    public interface IHubSpotObject
    {
        /// <summary>
        /// The object type, needed for associations
        /// </summary>
        string ObjectType { get; }
        
        string Id { get; set; }
    }
}