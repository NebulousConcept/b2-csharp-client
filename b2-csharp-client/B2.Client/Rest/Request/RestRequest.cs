﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest.Request
{
    public abstract class RestRequest : IRestRequest
    {
        public HttpMethod Method { get; }
        public IList<RestParam> HeaderParameters { get; }
        public IList<RestParam> QueryParameters { get; }
        public IList<RestParam> UrlParameters { get; }
        public IList<RequestData> BodyParameters { get; }


        protected RestRequest(HttpMethod method, UrlParams urlParameters, HeaderParams headerParameters, QueryParams queryParameters,
               BodyParams bodyParameters, DataParams dataParameters)
        {
            Method = method;
            UrlParameters = urlParameters.ThrowIfNull(nameof(urlParameters)).ToList();
            HeaderParameters = headerParameters.ThrowIfNull(nameof(headerParameters)).ToList();
            QueryParameters = queryParameters.ThrowIfNull(nameof(queryParameters)).ToList();
            BodyParameters = bodyParameters.ThrowIfNull(nameof(bodyParameters))
                                           .Select(p => new FieldRequestData(p.Name, p.Value))
                                           .Concat(dataParameters.ThrowIfNull(nameof(dataParameters)))
                                           .ToList();
        }

        /// <inheritDoc />
        public virtual HttpRequestMessage ToHttpRequestMessage(IEnumerable<UrlSegment> urlSegments)
        {
            var ret = new HttpRequestMessage(Method, BuildHttpUrl(urlSegments));
            foreach (var param in HeaderParameters) {
                ret.Headers.Add(param.Name, param.Value);
            }
            return ret;
        }

        /// <inheritDoc />
        public string BuildUrl(IEnumerable<UrlSegment> urlSegments)
            => string.Join("/", urlSegments.Select(s => s.Transform(UrlParameters)));

        /// <summary>
        /// Form a complete URL that is used for the HttpRequestMessage.
        /// This may differ from the API URL as it will include any query parameters.
        /// </summary>
        /// <param name="urlSegments">The segments that make up the URL for the request.</param>
        /// <returns>An URL to the API, excluding endpoint, but including any additional query that forms the HTTP request.</returns>
        protected virtual string BuildHttpUrl(IEnumerable<UrlSegment> urlSegments) => BuildUrl(urlSegments);
    }
}