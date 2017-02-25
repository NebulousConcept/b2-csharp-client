using System;
using System.Net;
using System.Threading.Tasks;

using B2.Client.Rest.Api;
using B2.Client.Rest.Request;
using B2.Client.Rest.Response;


namespace B2.Client.Rest
{
    /// <summary>
    /// A basic REST client that can make unauthenticated API calls. Typically the only calls it can make are calls to
    /// <see cref="IAuthenticationApi{TReq,TRes}"/>s.
    /// </summary>
    public sealed class UnauthenticatedB2Client : RestClient
    {
        /// <summary>
        /// Create a new <see cref="UnauthenticatedB2Client"/>.
        /// </summary>
        /// <param name="endpoint">The REST endpoint.</param>
        /// <param name="webProxy">The (optional) proxy to use.</param>
        public UnauthenticatedB2Client(Uri endpoint, IWebProxy webProxy = null) : base(endpoint, webProxy) { }

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

        /// <summary>
        /// Associate a valid authentication response with a B2 client.
        /// </summary>
        /// <param name="response">A valid authentication response.</param>
        /// <returns>An authenticated B2 client.</returns>
        public AuthenticatedB2Client AuthenticateWithResponse(IAuthenticationResponse response)
            => new AuthenticatedB2Client(response.GetAuthenticationToken(), Endpoint, WebProxy);
    }
}