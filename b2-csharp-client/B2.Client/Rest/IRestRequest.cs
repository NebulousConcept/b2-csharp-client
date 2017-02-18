using System.Collections.Generic;
using System.Net.Http;


namespace B2.Client.Rest
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
        IList<Param> HeaderParameters { get; }
        /// <summary>
        /// Request parameters that belong in the HTTP query string.
        /// </summary>
        IList<Param> QueryParameters { get; }
        /// <summary>
        /// Request parameters that belong in the URL.
        /// </summary>
        IList<Param> UrlParameters { get; }
        /// <summary>
        /// Request parameters that belong in the HTTP POST body.
        /// </summary>
        IList<RequestData> PostParameters { get; }

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
