using System.Collections.Generic;
using System.Net.Http;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Represents a REST client request.
    /// </summary>
    public interface IRestRequest
    {
        /// <summary>
        /// The HTTP method to be used for this request.
        /// </summary>
        HttpMethod Method { get; }
        /// <summary>
        /// Request parameters that belong in the HTTP header.
        /// </summary>
        IList<RestParam> HeaderParameters { get; }
        /// <summary>
        /// Request parameters that belong in the HTTP query string.
        /// </summary>
        IList<RestParam> QueryParameters { get; }
        /// <summary>
        /// Request parameters that belong in the URL.
        /// </summary>
        IList<RestParam> UrlParameters { get; }
        /// <summary>
        /// Request parameters that belong in the HTTP body.
        /// </summary>
        IList<RequestData> BodyParameters { get; }

        /// <summary>
        /// Convert the Request for a given URL to an HttpClient HttpRequestMessage.
        /// <param name="urlSegments">The URL segments for the request.</param>
        /// </summary>
        /// <returns>An HttpClient HttpRequestMessage.</returns>
        HttpRequestMessage ToHttpRequestMessage(IList<UrlSegment> urlSegments);

        /// <summary>
        /// Form a complete URL for an API from components.
        /// </summary>
        /// <param name="urlSegments">The segments that make up the URL for the request.</param>
        /// <returns>An URL (excluding endpoint) to the API.</returns>
        string BuildUrl(IList<UrlSegment> urlSegments);
    }
}
