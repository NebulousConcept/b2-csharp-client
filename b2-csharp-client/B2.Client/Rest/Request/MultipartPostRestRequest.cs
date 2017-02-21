using System.Net.Http;

using B2.Client.Rest.Request.Param;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// A multipart REST request using HTTP POST.
    /// </summary>
    public class MultipartPostRestRequest : MultipartRestRequest
    {
        /// <summary>
        /// Create a new multipart POST request.
        /// </summary>
        /// <param name="urlParams">The parameters in the URL.</param>
        /// <param name="headerParams">The parameters in the HTTP headerParams.</param>
        /// <param name="bodyParams">The parameters in the HTTP body.</param>
        /// <param name="dataParams">The data parameters.</param>
        public MultipartPostRestRequest(UrlParams urlParams, HeaderParams headerParams, BodyParams bodyParams, DataParams dataParams)
            : base(HttpMethod.Post, urlParams, headerParams, bodyParams, dataParams) { }
    }
}