using Indicia.HubSpot.Core;

namespace Indicia.HubSpot.Api
{
    public interface IHubSpotApi
    {
        /// <summary>
        /// The client is exposed in order to allow implementations of new APIs.  
        /// </summary>
        IHubSpotClient Client { get; }

        IHubSpotObjectApi<T> GetObjectApi<T>()
            where T : class, IHubSpotObject, new();
    }
}