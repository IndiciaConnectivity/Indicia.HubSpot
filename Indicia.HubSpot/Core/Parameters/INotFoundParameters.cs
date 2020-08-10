namespace Indicia.HubSpot.Core.Parameters
{
    public interface INotFoundParameters
    {
        /// <summary>
        /// Flag which can be used to return null for 404 (Not Found) responses (instead of throwing an exception). Defaults to false.
        /// </summary>
        bool NotFoundReturnsNull { get; set; }
    }
}