using System.Collections.Generic;

using B2.Client.Rest;
using B2.Client.Rest.Api;


namespace B2.Client.Apis.AuthorizeAccountV1
{
    /// <summary>
    /// The 'b2_authorize_account' version 1 API.
    /// </summary>
    public sealed class AuthorizeAccountV1Api : IAuthenticationApi<AuthorizeAccountV1Request, AuthorizeAccountV1Response>
    {
        /// <inheritdoc />
        public IEnumerable<UrlSegment> ResourceUrl { get; } = new List<UrlSegment> {
            UrlSegment.Literal("b2api"),
            UrlSegment.Literal("v1"),
            UrlSegment.Literal("b2_authorize_account")
        };
    }
}