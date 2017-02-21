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
        public AuthorizeAccountV1Request(string authorization)
            : base(UrlParams.Empty,
                   new HeaderParams(
                       RequiredParam.Of("Authorization", authorization)
                   ),
                   BodyParams.Empty,
                   DataParams.Empty) { }
    }
}