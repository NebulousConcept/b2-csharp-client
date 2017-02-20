using System.Collections.Generic;
using System.Linq;
using System.Net.Http;


namespace B2.Client.Rest.Request
{
    public abstract class RestRequest : IRestRequest
    {
        public HttpMethod Method { get; }
        public IList<Param> HeaderParameters { get; }
        public IList<Param> QueryParameters { get; }
        public IList<Param> UrlParameters { get; }
        public IList<RequestData> BodyParameters { get; }


        protected RestRequest(HttpMethod method, IList<Param> headerParameters, IList<Param> queryParameters, IList<Param> urlParameters,
                           IList<Param> bodyParameters, IList<RequestData> dataParameters)
        {
            Method = method;
            HeaderParameters = headerParameters.ThrowIfNull(nameof(headerParameters));
            QueryParameters = queryParameters.ThrowIfNull(nameof(queryParameters));
            UrlParameters = urlParameters.ThrowIfNull(nameof(urlParameters));
            BodyParameters = bodyParameters.ThrowIfNull(nameof(bodyParameters))
                                           .Select(p => new FieldRequestData(p.Name, p.Value))
                                           .Concat(dataParameters.ThrowIfNull(nameof(dataParameters)))
                                           .ToList();
        }


        public abstract HttpRequestMessage ToHttpRequestMessage(IList<UrlSegment> urlSegments);

        public abstract string BuildUrl(IList<UrlSegment> urlSegments);
    }
}