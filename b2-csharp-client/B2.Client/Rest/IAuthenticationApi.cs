﻿namespace B2.Client.Rest
{
    /// <summary>
    /// More specific interface type to indicate an API which performs authentication.
    /// </summary>
    /// <typeparam name="TReq">The type of the request.</typeparam>
    /// <typeparam name="TRes">The type of the response.</typeparam>
    public interface IAuthenticationApi<TReq, TRes> : IApi<TReq, TRes>
        where TReq : IRestRequest
        where TRes : IAuthenticationResponse
    {

    }
}