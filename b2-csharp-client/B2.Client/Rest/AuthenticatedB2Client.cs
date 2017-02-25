using System.Net;
using System.Threading.Tasks;
using B2.Client.Rest.Api;
using B2.Client.Rest.Request;
using B2.Client.Rest.Response;


namespace B2.Client.Rest
{
    /// <summary>
    /// A B2 REST client that can make authenticated API calls.
    /// </summary>
    public sealed class AuthenticatedB2Client : RestClient
    {
        private readonly IAuthenticationToken token;


        /// <summary>
        /// Create a new <see cref="AuthenticatedB2Client"/>.
        /// </summary>
        /// <param name="token">The authentication/authorization token.</param>
        /// <param name="webProxy">The optional proxy to use.</param>
        public AuthenticatedB2Client(IAuthenticationToken token, IWebProxy webProxy = null) : base(token.Endpoint, webProxy)
        {
            this.token = token;
        }

        /// <summary>
        /// Perform a request to an API and get a response back.
        /// </summary>
        /// <param name="api">The API to call.</param>
        /// <param name="request">The request to pass to the API.</param>
        /// <typeparam name="TReq">The API request type.</typeparam>
        /// <typeparam name="TRes">The API response type.</typeparam>
        /// <returns>A deserialized API response.</returns>
        public async Task<TRes> PerformApiRequestAsync<TReq, TRes>(IAuthenticatedApi<TReq, TRes> api, TReq request)
            where TReq : IRestRequest
            where TRes : IResponse
        {
            var client = GetHttpClient();
            var req = request.ToHttpRequestMessage(api.ResourceUrl);
            foreach (var header in token.Headers) {
                req.Headers.Add(header.Name, header.Value);
            }
            var response = await client.SendAsync(req);
            return await HandleResponseAsync<TRes>(response);
        }
    }
}