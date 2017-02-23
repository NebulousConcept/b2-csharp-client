using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using Newtonsoft.Json.Linq;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// A REST request whose body is a JSON object containing the parameters.
    /// </summary>
    public abstract class JsonRestRequest : RestRequest
    {
        /// <summary>
        /// Create a new REST request whose body is a JSON object containing the parameters.
        /// </summary>
        /// <param name="method">The method to use.</param>
        /// <param name="headers">The header parameters.</param>
        /// <param name="urlParameters">The URL parameters.</param>
        /// <param name="body">The body parameters.</param>
        protected JsonRestRequest(HttpMethod method, HeaderParams headers, UrlParams urlParameters, BodyParams body)
            : base(method, headers, QueryParams.Empty, urlParameters, body, DataParams.Empty) { }


        /// <inheritdoc/>
        public override HttpRequestMessage ToHttpRequestMessage(IEnumerable<UrlSegment> urlSegments)
        {
            var ret = base.ToHttpRequestMessage(urlSegments);

            var json = new JObject();
            foreach (var param in BodyParameters) {
                foreach (var item in param.Items) {
                    var pair = item.GetAsKeyValuePair();
                    json.Add(pair.Key, pair.Value);
                }
            }

            ret.Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            return ret;
        }
    }
}