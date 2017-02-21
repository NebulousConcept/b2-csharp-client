using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// A request which will use HTTP POST in a form-url-encoded format.
    /// </summary>
    public abstract class FormUrlEncodedRestRequest : RestRequest
    {
        /// <summary>
        /// Create a new form-url-encoded POST request.
        /// </summary>
        /// <param name="method">The HTTP method for this request.</param>
        /// <param name="urlParameters">The request parameters which should be placed in the URL.</param>
        /// <param name="headers">The request parameters which should be placed in the request headers.</param>
        /// <param name="body">The request parameters which should be placed in the body body.</param>
        /// <param name="data">The request data objects which should be placed in the body body.</param>
        protected FormUrlEncodedRestRequest(HttpMethod method, UrlParams urlParameters, HeaderParams headers, BodyParams body,
            DataParams data) : base(method, headers, QueryParams.Empty, urlParameters, body, data) { }

        /// <summary>
        /// Convert the Request for a given URL to an HttpClient HttpRequestMessage.
        /// <param name="urlSegments">The URL segments for the request URL.</param>
        /// </summary>
        /// <returns>An HttpClient HttpRequestMessage.</returns>
        public override HttpRequestMessage ToHttpRequestMessage(IEnumerable<UrlSegment> urlSegments)
        {
            var ret = base.ToHttpRequestMessage(urlSegments);
            if (BodyParameters.Any()) {
                ret.Content = new FormUrlEncodedContent(BodyParameters.Select(p => p.GetAsKeyValuePair()));
            }
            return ret;
        }
    }
}