using System.Collections.Generic;

using B2.Client.Rest;
using B2.Client.Rest.Api;


namespace B2.Client.Apis.CreateBucketV1
{
    /// <summary>
    /// The 'b2_create_bucket' version 1 API.
    /// </summary>
    public sealed class CreateBucketV1Api : IAuthenticatedApi<CreateBucketV1Request, CreateBucketV1Response>
    {
        ///<inheritdoc/>
        public IEnumerable<UrlSegment> ResourceUrl { get; } = new List<UrlSegment> {
            UrlSegment.Literal("b2api"),
            UrlSegment.Literal("v1"),
            UrlSegment.Literal("b2_create_bucket")
        };
    }
}