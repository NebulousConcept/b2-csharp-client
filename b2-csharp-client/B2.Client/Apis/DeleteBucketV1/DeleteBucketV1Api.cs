using System.Collections.Generic;

using B2.Client.Rest;
using B2.Client.Rest.Api;


namespace B2.Client.Apis.DeleteBucketV1
{
    /// <summary>
    /// The 'b2_delete_bucket' version 1 API.
    /// </summary>
    public sealed class DeleteBucketV1Api : IAuthenticatedApi<DeleteBucketV1Request, DeleteBucketV1Response>
    {
        /// <inheritdoc />
        public IEnumerable<UrlSegment> ResourceUrl { get; } = new List<UrlSegment> {
            UrlSegment.Literal("b2api"),
            UrlSegment.Literal("v1"),
            UrlSegment.Literal("b2_delete_bucket")
        };
    }
}