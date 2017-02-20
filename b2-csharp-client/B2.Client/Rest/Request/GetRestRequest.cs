using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Represents an HTTP GET request. These support URL parameters, headers, and query parameters.
    /// </summary>
    public abstract class GetRestRequest : RestRequest
    {
        /// <summary>
        /// Create a new GetRequest.
        /// </summary>
        /// <param name="urlParams">Template replacements for an API's URL.</param>
        /// <param name="headers">HTTP headers to add to the request.</param>
        /// <param name="query">Parameters for the query string.</param>
        protected GetRestRequest(UrlParams urlParams, HeaderParams headers, QueryParams query) :
            base(HttpMethod.Get, headers, query, urlParams, BodyParams.Empty, DataParams.Empty) { }

        /// <summary>
        /// Convert the Request for a given URL to an HttpClient HttpRequestMessage.
        /// <param name="urlSegments">The segments that make up the URL for the request.</param>
        /// </summary>
        /// <returns>An HttpClient HttpRequestMessage.</returns>
        protected override string BuildHttpUrl(IList<UrlSegment> urlSegments) => base.BuildHttpUrl(urlSegments) + AsQueryString();

        /// <summary>
        /// Convert a series of RestParam objects into a single query string.
        /// </summary>
        /// <returns>The RestParam objects converted to a single query string.</returns>
        private string AsQueryString()
        {
            return QueryParameters.Any() ?
                "?" + string.Join("&", QueryParameters.Select(p => $"{Uri.EscapeUriString(p.Name)}={Uri.EscapeUriString(p.Value)}")) :
                "";
        }
    }
}