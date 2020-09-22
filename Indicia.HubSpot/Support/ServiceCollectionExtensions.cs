using System;
using Indicia.HubSpot.Api;
using Indicia.HubSpot.Api.Companies;
using Indicia.HubSpot.Api.Contacts;
using Indicia.HubSpot.Api.Deals;
using Indicia.HubSpot.Api.Tickets;
using Indicia.HubSpot.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RestSharp;

namespace Indicia.HubSpot.Support
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHubSpot(this IServiceCollection services, Action<HubSpotOptions> hubSpotOptionsAction = null)
        {
            if (hubSpotOptionsAction != null)
            {
                services.Configure(hubSpotOptionsAction);
            }

            services.TryAddSingleton<IRestClient, RestClient>();
            services.TryAddSingleton<IHubSpotApi, HubSpotApi>();
            services.TryAddSingleton<IHubSpotClient, HubSpotClient>();

            services.TryAddSingleton<IHubSpotObjectApi<HubSpotCompanyObject>, HubSpotCompanyApi<HubSpotCompanyObject>>();
            services.TryAddSingleton<IHubSpotObjectApi<HubSpotContactObject>, HubSpotContactApi<HubSpotContactObject>>();
            services.TryAddSingleton<IHubSpotObjectApi<HubSpotDealObject>, HubSpotDealApi<HubSpotDealObject>>();
            services.TryAddSingleton<IHubSpotObjectApi<HubSpotTicketObject>, HubSpotTicketApi<HubSpotTicketObject>>();
        }

        public static void RegisterHubSpotObjectApi<T, TImpl>(this IServiceCollection services)
            where T : class, IHubSpotObject, new()
            where TImpl : class, IHubSpotObjectApi<T>
        {
            services.RemoveAll<IHubSpotObjectApi<T>>();
            services.AddSingleton<IHubSpotObjectApi<T>, TImpl>();
        }
        
    }
}