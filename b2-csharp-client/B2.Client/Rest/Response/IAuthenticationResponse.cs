namespace B2.Client.Rest.Response
{
    /// <summary>
    /// A response from an authentication API call, which contains an authentication token to use when sending subsequent requests.
    /// </summary>
    public interface IAuthenticationResponse : IResponse
    {
        IAuthenticationToken GetAuthenticationToken();
    }
}