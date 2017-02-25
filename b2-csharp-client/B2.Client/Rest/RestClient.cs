using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using B2.Client.Rest.Response;


namespace B2.Client.Rest
{
    public abstract class RestClient
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
        /// Create a new <see cref="RestClient"/>.
        /// </summary>
        /// <param name="endpoint">The REST endpoint.</param>
        /// <param name="webProxy">The (optional) proxy to use.</param>
        protected RestClient(Uri endpoint, IWebProxy webProxy = null)
        {
            Endpoint = endpoint.ThrowIfNull(nameof(endpoint));
            WebProxy = webProxy;
        }

        protected HttpClient GetHttpClient()
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

        protected async Task<TRes> HandleResponseAsync<TRes>(HttpResponseMessage apiResponse)
            where TRes : IResponse
        {
            var content = await apiResponse.Content.ReadAsStringAsync();
            if (apiResponse.IsSuccessStatusCode) {
                return JsonConvert.DeserializeObject<TRes>(content);
            }
            var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
            throw new B2Exception("API call failed", error);
        }
    }
}