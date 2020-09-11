using System.Threading.Tasks;
using Indicia.HubSpot.Api.Contacts;
using Indicia.HubSpot.Core.Auth;
using Indicia.HubSpot.Support;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Indicia.HubSpot.Example
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services, args);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            // entry to run app
            await serviceProvider.GetService<App>()
                .RunAsync(args);
        }

        private static void ConfigureServices(IServiceCollection services, string[] args)
        {
            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Debug);
            });

            // build config
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            // add services
            services.AddHubSpot(options =>
            {
                options.Auth = new HubSpotApiKeyClientAuth(configuration["HUBSPOT_API_KEY"]);
                options.UseHttpLogging = true;
            });
            
            // register custom object implementation
            services.RegisterHubSpotObjectApi<HubSpotContact, HubSpotContactApi<HubSpotContact>>();

            // add app
            services.AddTransient<App>();
        }
    }
}