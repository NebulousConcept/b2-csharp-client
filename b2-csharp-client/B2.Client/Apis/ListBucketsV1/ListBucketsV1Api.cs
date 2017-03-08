using System.Collections.Generic;
using B2.Client.Rest;
using B2.Client.Rest.Api;


namespace B2.Client.Apis.ListBucketsV1
{
    /// <summary>
    /// The 'b2_list_buckets' version 1 API.
    /// </summary>
    public sealed class ListBucketsV1Api : IAuthenticatedApi<ListBucketsV1Request, ListBucketsV1Response>
    {
        /// <inheritdoc />
        public IEnumerable<UrlSegment> ResourceUrl { get; } = new List<UrlSegment> {
            UrlSegment.B2Api,
            UrlSegment.V1,
            UrlSegment.Literal("b2_list_buckets")
        };
    }
}