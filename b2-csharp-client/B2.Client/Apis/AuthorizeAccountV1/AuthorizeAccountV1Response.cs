using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using B2.Client.Rest;
using B2.Client.Rest.Response;


namespace B2.Client.Apis.AuthorizeAccountV1
{
    /// <summary>
    /// Response object for the 'b2_authorize_account' version 1 API.
    /// </summary>
    [DataContract]
    public sealed class AuthorizeAccountV1Response : IAuthenticationResponse
    {
        /// <summary>
        /// The account identifier.
        /// </summary>
        [DataMember(Name = "accountId", IsRequired = true)]
        public string AccountId { get; }

        /// <summary>
        /// The authorization token to use in subsequent API calls.
        /// </summary>
        [DataMember(Name = "authorizationToken", IsRequired = true)]
        public string AuthorizationToken { get; }

        /// <summary>
        /// The URL to use in subsequent API calls (except for file downloads).
        /// </summary>
        [DataMember(Name = "apiUrl", IsRequired = true)]
        public string ApiUrl { get; }

        /// <summary>
        /// The URL to use in subsequent file downloads.
        /// </summary>
        [DataMember(Name = "downloadUrl", IsRequired = true)]
        public string DownloadUrl { get; }

        /// <summary>
        /// The minimum size for parts of large files (apart from the last part).
        /// </summary>
        [DataMember(Name = "minimumPartSize", IsRequired = true)]
        public ulong MinimumPartSize { get; }

        //parameter names have to match property names for deserializer to tie them together
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public AuthorizeAccountV1Response(string AccountId, string AuthorizationToken, string ApiUrl, string DownloadUrl,
                                           ulong MinimumPartSize)
        {
            this.AccountId = AccountId;
            this.AuthorizationToken = AuthorizationToken;
            this.ApiUrl = ApiUrl;
            this.DownloadUrl = DownloadUrl;
            this.MinimumPartSize = MinimumPartSize;
        }

        /// <inheritDoc />
        public IAuthenticationToken GetAuthenticationToken()
            => new B2AuthenticationToken(AuthorizationToken);
    }
}