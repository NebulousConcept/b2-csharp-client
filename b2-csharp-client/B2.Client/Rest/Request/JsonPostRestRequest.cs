using System.Net.Http;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// A <see cref="JsonRestRequest"/> using HTTP POST.
    /// </summary>
    public abstract class JsonPostRestRequest : JsonRestRequest
    {
        /// <summary>
        /// Create a new <see cref="JsonPostRestRequest"/>.
        /// </summary>
        /// <param name="urlParameters">The URL parameters.</param>
        /// <param name="headers">The header parameters.</param>
        /// <param name="body">The body parameters.</param>
        protected JsonPostRestRequest(UrlParams urlParameters, HeaderParams headers, BodyParams body)
            : base(HttpMethod.Post, headers, urlParameters, body) { }
    }
}