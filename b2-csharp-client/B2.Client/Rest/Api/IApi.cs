using System.Collections.Generic;

using B2.Client.Rest.Request;
using B2.Client.Rest.Response;


namespace B2.Client.Rest.Api
{
    /// <summary>
    /// Base interface for all APIs.
    /// 
    /// The generic typing is to provide a compile-time check that the correct request/response types are being passed
    /// to the correct APIs.
    /// </summary>
    /// <typeparam name="TReq">The API Request type.</typeparam>
    /// <typeparam name="TRes">The API Response type.</typeparam>
    public interface IApi<TReq, TRes>
        where TReq : IRestRequest
        where TRes : IResponse
    {
        /// <summary>
        /// The segments which make up the API-specific resource portion of the URL.
        /// </summary>
        IEnumerable<UrlSegment> ResourceUrl { get; }
    }
}
