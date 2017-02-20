namespace B2.Client.Rest
{
    /// <summary>
    /// A response from an authentication API call, which contains an authentication token to use when sending subsequent requests.
    /// </summary>
    public interface IAuthenticationResponse : IResponse
    {
        IAuthenticationToken GetAuthenticationToken();
    }
}