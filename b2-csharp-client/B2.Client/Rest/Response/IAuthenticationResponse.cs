namespace B2.Client.Rest.Response
{
    /// <summary>
    /// A response from an authentication API call, which contains an authentication token to use when sending subsequent requests.
    /// </summary>
    public interface IAuthenticationResponse : IResponse
    {
        /// <summary>
        /// Retrieve the authentication token from the response. The token will contain information to use for authorizing or
        /// signing subsequent requests.
        /// </summary>
        /// <returns>An authentication token.</returns>
        IAuthenticationToken GetAuthenticationToken();
    }
}