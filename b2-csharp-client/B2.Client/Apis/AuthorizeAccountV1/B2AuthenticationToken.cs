using B2.Client.Rest;
using B2.Client.Rest.Request.Param;


namespace B2.Client.Apis.AuthorizeAccountV1
{
    /// <summary>
    /// Authentication token used by B2.
    /// </summary>
    public sealed class B2AuthenticationToken : IAuthenticationToken
    {
        /// <inheritDoc />
        public HeaderParams Headers { get; }


        /// <summary>
        /// Create a new <see cref="B2AuthenticationToken"/>.
        /// </summary>
        /// <param name="authString">The string representing the authorization token returned from a B2 authorize account request.</param>
        public B2AuthenticationToken(string authString)
        {
            Headers = new HeaderParams(RequiredParam.Of("Authorization", authString));
        }
    }
}