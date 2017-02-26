using B2.Client.Rest.Request;
using B2.Client.Rest.Request.Param;


namespace B2.Client.Apis.DeleteBucketV1
{
    /// <summary>
    /// Request object for the 'b2_delete_bucket' version 1 API.
    /// </summary>
    public sealed class DeleteBucketV1Request : JsonPostRestRequest
    {
        /// <summary>
        /// Create a new request object.
        /// </summary>
        /// <param name="accountId">The B2 account ID.</param>
        /// <param name="bucketId">The ID of the bucket to delete.</param>
        public DeleteBucketV1Request(string accountId, string bucketId)
            : base(UrlParams.Empty, HeaderParams.Empty, new BodyParams(
                   RequiredParam.Of("accountId", accountId),
                   RequiredParam.Of("bucketId", bucketId)
                   )) { }
    }
}