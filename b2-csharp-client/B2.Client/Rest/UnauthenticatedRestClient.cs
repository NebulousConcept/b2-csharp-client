using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using B2.Client.Rest.Api;
using B2.Client.Rest.Request;
using B2.Client.Rest.Response;


namespace B2.Client.Rest
{
    /// <summary>
    /// A basic REST client that can make unauthenticated API calls. Typically the only calls it can make are calls to
    /// <see cref="IAuthenticationApi{TReq,TRes}"/>s.
    /// </summary>
    public class UnauthenticatedRestClient
    {
        /// <summary>
        /// The REST endpoint to make calls to.
        /// </summary>
        public Uri Endpoint { get; }

        /// <summary>
        /// The proxy to use (if any).
        /// </summary>
        public IWebProxy WebProxy { get; }

        /// <summary>
        /// Create a new <see cref="UnauthenticatedRestClient"/>.
        /// </summary>
        /// <param name="endpoint">The REST endpoint.</param>
        /// <param name="webProxy">The proxy to use (<code>null</code> to use no proxy).</param>
        public UnauthenticatedRestClient(Uri endpoint, IWebProxy webProxy)
        {
            Endpoint = endpoint.ThrowIfNull(nameof(endpoint));
            WebProxy = webProxy;
        }

        private HttpClient GetHttpClient()
        {
            var useProxy = WebProxy != null;
            var handler = new HttpClientHandler {
                Proxy = WebProxy,
                UseProxy = useProxy
            };
            return new HttpClient(handler) {
                BaseAddress = Endpoint
            };
        }

        private async Task<TRes> HandleResponseAsync<TRes>(HttpResponseMessage apiResponse)
            where TRes : IResponse
        {
            var content = await apiResponse.Content.ReadAsStringAsync();
            //assume success for now (think lucky)

            return JsonConvert.DeserializeObject<TRes>(content);
        }

        /// <summary>
        /// Perform a request to an authentication API and get an authentication response back.
        /// </summary>
        /// <param name="authApi">The authentication API to call.</param>
        /// <param name="request">The request to pass to the API.</param>
        /// <typeparam name="TReq">The API request type.</typeparam>
        /// <typeparam name="TRes">The API response type.</typeparam>
        /// <returns>A deserialized API response.</returns>
        public async Task<TRes> PerformAuthenticationRequestAsync<TReq, TRes>(IAuthenticationApi<TReq, TRes> authApi, TReq request)
            where TReq : IRestRequest
            where TRes : IAuthenticationResponse
        {
            var client = GetHttpClient();
            var response = await client.SendAsync(request.ToHttpRequestMessage(authApi.ResourceUrl));
            return await HandleResponseAsync<TRes>(response);
        }
    }
}