using System;
using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest
{
    /// <summary>
    /// An authentication token returned from an authentication API call, which will be used to authenticate or sign subsequent requests.
    /// </summary>
    public interface IAuthenticationToken
    {
        /// <summary>
        /// The headers to use for authentication.
        /// </summary>
        HeaderParams Headers { get; }

        /// <summary>
        /// The endpoint to use for authenticated API calls.
        /// </summary>
        Uri Endpoint { get; }
    }
}