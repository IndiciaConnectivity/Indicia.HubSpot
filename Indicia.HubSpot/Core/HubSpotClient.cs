using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Indicia.HubSpot.Core.Serializers;
using Indicia.HubSpot.Support;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace Indicia.HubSpot.Core
{
    internal class HubSpotClient : IHubSpotClient
    {
        private readonly IOptions<HubSpotOptions> _options;
        private readonly RestClient _client;
        private readonly ILogger _logger;

        private static string BaseUrl => "https://api.hubapi.com";
        
        public string BasePath { get => BaseUrl; }

        /// <summary>
        /// Creates a HubSpot client. 
        /// </summary>
        public HubSpotClient(IOptions<HubSpotOptions> options, IServiceProvider serviceProvider)
        {
            _options = options;
            _client = new RestClient(BaseUrl);
            _logger = _options.Value.UseHttpLogging ? serviceProvider.GetService<ILogger>() : null;

            if (_options.Value.Auth == null)
            {
                throw new NotSupportedException($"The 'Auth' option is required.");
            }
        }

        public Task<TResponse> ExecuteAsync<TResponse>(string path, Method method = Method.GET,
            CancellationToken cancellationToken = default, IDictionary<string, string> queryParameters = null,
            bool notFoundReturnsNull = false)
            where TResponse : new()
            => SendReceiveRequestAsync<TResponse>(path, method, queryParameters, notFoundReturnsNull,
                cancellationToken);

        public Task<TResponse> ExecuteAsync<TResponse, TRequest>(string absoluteUriPath, TRequest entity,
            Method method = Method.GET, CancellationToken cancellationToken = default,
            IDictionary<string, string> queryParameters = null, bool notFoundReturnsNull = false)
            where TResponse : new()
            => SendReceiveRequestAsync<TResponse, TRequest>(absoluteUriPath, method, entity, queryParameters,
                notFoundReturnsNull, cancellationToken);

        public Task ExecuteOnlyAsync(string absoluteUriPath, Method method = Method.GET,
            CancellationToken cancellationToken = default, IDictionary<string, string> queryParameters = null)
            => SendOnlyRequestAsync(absoluteUriPath, method, queryParameters, cancellationToken);

        public Task ExecuteOnlyAsync<TRequest>(string absoluteUriPath, TRequest entity, Method method = Method.GET,
            CancellationToken cancellationToken = default, IDictionary<string, string> queryParameters = null)
            => SendOnlyRequestAsync(absoluteUriPath, method, entity, queryParameters, cancellationToken);

        /// <summary>
        /// Sends requests to the given endpoint and returns an entity object of T.
        /// </summary>
        /// <typeparam name="TResponse">The expected return entity type.</typeparam>
        /// <param name="path">The path to the endpoint.</param>
        /// <param name="method">The REST method used.</param>
        /// <param name="queryParameters">The (optional) query parameters.</param>
        /// <param name="notFoundReturnsNull">Flag which can be used to return null for 404 (Not Found) responses (instead of throwing an exception).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An entity of type T returned from the request.</returns>
        private async Task<TResponse> SendReceiveRequestAsync<TResponse>(string path, Method method,
            IDictionary<string, string> queryParameters = null, bool notFoundReturnsNull = false,
            CancellationToken cancellationToken = default)
            where TResponse : new()
        {
            var request = await ConfigureRequestAuthenticationAsync(path, method, cancellationToken);
            request.AddQueryParameters(queryParameters);
            request.OnBeforeRequest += OnBeforeRequest(request);

            var response = await _client.ExecuteAsync<TResponse>(request, cancellationToken);
            LogResponse(response);

            if (response.IsSuccessful == false)
            {
                if (response.StatusCode == HttpStatusCode.NotFound && notFoundReturnsNull)
                {
                    return default;
                }

                throw new HubSpotException("Error from HubSpot",
                    new HubSpotError(response.StatusCode, response.StatusDescription), response.Content);
            }

            return JsonConvert.DeserializeObject<TResponse>(response.Content);
        }


        /// <summary>
        /// Sends requests with a given entity JSON body to the target endpoint and returns a result object.
        /// </summary>
        /// <typeparam name="TResponse">The type for the return object.</typeparam>
        /// <typeparam name="TRequest">The type of the sending object.</typeparam>
        /// <param name="path">The path to the endpoint.</param>
        /// <param name="method">The REST method used.</param>
        /// <param name="entity">The entity being sent in the request.</param>
        /// <param name="queryParameters">The (optional) query parameters.</param>
        /// <param name="notFoundReturnsNull">Flag which can be used to return null for 404 (Not Found) responses (instead of throwing an exception).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An entity of type T returned from the request.</returns>
        private async Task<TResponse> SendReceiveRequestAsync<TResponse, TRequest>(string path, Method method,
            TRequest entity, IDictionary<string, string> queryParameters = null, bool notFoundReturnsNull = false,
            CancellationToken cancellationToken = default)
            where TResponse : new()
        {
            var request = await ConfigureRequestAuthenticationAsync(path, method, cancellationToken);
            request.AddQueryParameters(queryParameters);
            request.OnBeforeRequest += OnBeforeRequest(request);

            if (entity != null)
            {
                request.AddJsonBody(entity);
            }

            var response = await _client.ExecuteAsync<TResponse>(request, cancellationToken);
            LogResponse(response);

            if (response.IsSuccessful == false)
            {
                if (response.StatusCode == HttpStatusCode.NotFound && notFoundReturnsNull)
                {
                    return default;
                }

                throw new HubSpotException("Error from HubSpot",
                    new HubSpotError(response.StatusCode, response.StatusDescription), response.Content);
            }


            return JsonConvert.DeserializeObject<TResponse>(response.Content);
        }

        /// <summary>
        /// Sends a one way request to the server with no return data.
        /// </summary>
        /// <typeparam name="T">The outbound entity type.</typeparam>
        /// <param name="path">The endpoint target.</param>
        /// <param name="method">The REST method to use.</param>
        /// <param name="entity">The entity being sent to the endpoint.</param>
        /// <param name="queryParameters">The (optional) query parameters.</param>
        /// <param name="cancellationToken"></param>
        private async Task SendOnlyRequestAsync<T>(string path, Method method, T entity,
            IDictionary<string, string> queryParameters = null, CancellationToken cancellationToken = default)
        {
            var request = await ConfigureRequestAuthenticationAsync(path, method, cancellationToken);
            request.AddQueryParameters(queryParameters);
            request.OnBeforeRequest += OnBeforeRequest(request);

            if (entity != null)
            {
                request.AddJsonBody(entity);
            }

            var response = await _client.ExecuteAsync(request, cancellationToken);
            LogResponse(response);

            if (!response.IsSuccessful)
                throw new HubSpotException("Error from HubSpot",
                    new HubSpotError(response.StatusCode, response.StatusDescription), response.Content);
        }

        /// <summary>
        /// Sends a one way request to the server with no return data.
        /// </summary>
        /// <param name="path">The endpoint target.</param>
        /// <param name="method">The REST method to use.</param>
        /// <param name="queryParameters">The (optional) query parameters.</param>
        /// <param name="cancellationToken"></param>
        private async Task SendOnlyRequestAsync(string path, Method method,
            IDictionary<string, string> queryParameters = null, CancellationToken cancellationToken = default)
        {
            var request = await ConfigureRequestAuthenticationAsync(path, method, cancellationToken);
            request.AddQueryParameters(queryParameters);
            request.OnBeforeRequest += OnBeforeRequest(request);

            var response = await _client.ExecuteAsync(request, cancellationToken);
            LogResponse(response);

            if (!response.IsSuccessful)
                throw new HubSpotException("Error from HubSpot",
                    new HubSpotError(response.StatusCode, response.StatusDescription), response.Content);
        }

        /// <summary>
        /// Configures a RestRequest based on the authentication scheme detected and configures the endpoint path relative to the base path.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="method"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<RestRequest> ConfigureRequestAuthenticationAsync(string path, Method method,
            CancellationToken cancellationToken)
        {
            var fullPath = $"{BasePath.TrimEnd('/')}/{path.Trim('/')}";
            var request = new RestRequest(fullPath, method, DataFormat.Json);
            await _options.Value.Auth.ConfigureAuthAsync(request, cancellationToken);
            request.JsonSerializer = new NewtonsoftRestSharpSerializer();
            return request;
        }

        private Action<IHttp> OnBeforeRequest(IRestRequest request)
        {
            return http =>
            {
                var body = http.RequestBody;
                _logger?.LogTrace("HubSpot {method} request to {resource}{body}",
                    request.Method, _options.Value.Auth.AnonymizeUrl(http.Url.ToString()),
                    string.IsNullOrEmpty(body) ? string.Empty : $": {body}");
            };
        }

        private void LogResponse(IRestResponse response)
        {
            _logger?.LogDebug("HubSpot {method} request to {resource} resulted in {statusCode} {statusResponse}",
                response.Request.Method, _options.Value.Auth.AnonymizeUrl(response.ResponseUri.ToString()),
                (int) response.StatusCode, response.StatusDescription);
        }
    }
}