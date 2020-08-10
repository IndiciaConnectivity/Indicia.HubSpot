using System;
using Indicia.HubSpot.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Indicia.HubSpot.Api
{
    /// <summary>
    /// Starting point for using Indicia.HubSpot.NET
    /// </summary>
    public class HubSpotApi : IHubSpotApi
    {
        private readonly IServiceProvider _serviceProvider;
        
        public IHubSpotClient Client { get; }

        /// <summary>
        /// Creates a HubSpotApi
        /// </summary>
        /// <param name="serviceProvider"></param>
        public HubSpotApi(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            Client = _serviceProvider.GetRequiredService(typeof(IHubSpotClient)) as IHubSpotClient;
        }

        public IHubSpotObjectApi<T> GetObjectApi<T>()
            where T : class, IHubSpotObject, new()
        {
            return _serviceProvider.GetService<IHubSpotObjectApi<T>>();
        }
    }
}
