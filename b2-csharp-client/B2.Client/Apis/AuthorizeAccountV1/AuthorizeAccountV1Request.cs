using System;
using System.Text;

using B2.Client.Rest.Request;
using B2.Client.Rest.Request.Param;


namespace B2.Client.Apis.AuthorizeAccountV1
{
    /// <summary>
    /// Request object for the 'b2_authorize_account' version 1 API.
    /// </summary>
    public class AuthorizeAccountV1Request : MultipartPostRestRequest
    {
        /// <summary>
        /// Create a new authorization request.
        /// </summary>
        /// <param name="authorization">The authorization header value to use.</param>
        /// <param name="accountId">The identifier of the B2 account.</param>
        /// <param name="accountKey">The application key to use for the specified account.</param>
        public AuthorizeAccountV1Request(string accountId, string accountKey)
            : base(UrlParams.Empty,
                   new HeaderParams(
                       RequiredParam.Of("Authorization",
                           "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(accountId + ":" + accountKey)))
                   ),
                   BodyParams.Empty,
                   DataParams.Empty) { }
    }
}