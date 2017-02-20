using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Represents a general HTTP request with a multipart body. A MultipartRequest supports URL parameters,
    /// headers, post parameters, and files/data.
    /// </summary>
    public abstract class MultipartRestRequest : RestRequest
    {
        /// <summary>
        /// Create a new MultipartRequest.
        /// </summary>
        /// <param name="method">The HTTP method for this request.</param>
        /// <param name="urlParams">Template replacements for an API's URL.</param>
        /// <param name="headers">HTTP headers to add to the request.</param>
        /// <param name="post">Parameters for the body.</param>
        /// <param name="data">File references to be sent as part of the request.</param>
        protected MultipartRestRequest(HttpMethod method, UrlParams urlParams, HeaderParams headers, BodyParams post, DataParams data) :
            base(method, headers, QueryParams.Empty, urlParams, post, data) { }

        /// <summary>
        /// Convert the Request for a given URL to an HttpClient HttpRequestMessage.
        /// <param name="urlSegments">The URL segments for the request.</param>
        /// </summary>
        /// <returns>An HttpClient HttpRequestMessage.</returns>
        public override HttpRequestMessage ToHttpRequestMessage(IList<UrlSegment> urlSegments)
        {
            var ret = base.ToHttpRequestMessage(urlSegments);
            if (BodyParameters.Any()) {
                var content = new MultipartFormDataContent();
                foreach (var param in BodyParameters) {
                    content.Add(param.GetAsHttpContent());
                }
                ret.Content = content;
            }
            return ret;
        }
    }
}