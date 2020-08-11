using System;
using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Api;
using Indicia.HubSpot.Api.Companies;
using Indicia.HubSpot.Api.Contacts;
using Indicia.HubSpot.Api.Deals;
using Indicia.HubSpot.Api.Tickets;
using Indicia.HubSpot.Core.Crud;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Indicia.HubSpot.Example
{
    public class App
    {
        private readonly IHubSpotApi _hubSpotApi;
        private readonly ILogger<App> _logger;

        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public App(IHubSpotApi hubSpotApi, ILogger<App> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hubSpotApi = hubSpotApi;
        }

        public async Task RunAsync(string[] args, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Starting...");

            // Company examples
            var companies = await _hubSpotApi.GetCompanyApi().ListAsync(new ListParameters
            {
                Properties = _hubSpotApi.GetCompanyApi().AllProperties,
                Limit = 10
            }, cancellationToken);
            LogResult("Companies: {companies}", companies);

            // Contact examples (with custom contact type)
            var contacts = await _hubSpotApi.GetObjectApi<HubSpotContact>().ListAsync(new ListParameters
            {
                Properties = _hubSpotApi.GetContactApi().AllProperties,
                Limit = 10
            }, cancellationToken);
            LogResult("Contacts: {contacts}", contacts);
            
            // Deal examples
            var deals = await _hubSpotApi.GetDealApi().ListAsync(new ListParameters
            {
                Properties = _hubSpotApi.GetDealApi().AllProperties,
                Limit = 10
            }, cancellationToken);
            LogResult("Deals: {deals}", deals);
            
            // Ticket examples
            var tickets = await _hubSpotApi.GetTicketApi().ListAsync(new ListParameters
            {
                Properties = _hubSpotApi.GetTicketApi().AllProperties,
                Limit = 10
            }, cancellationToken);
            LogResult("Tickets: {tickets}", tickets);

            _logger.LogInformation("Finished!");

            await Task.CompletedTask;
        }

        private void LogResult(string template, object result)
        {
            _logger.LogInformation(template, JsonConvert.SerializeObject(result, _jsonSerializerSettings));
        }
    }
}