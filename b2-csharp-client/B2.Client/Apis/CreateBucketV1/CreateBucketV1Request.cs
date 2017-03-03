using B2.Client.Rest;
using B2.Client.Rest.Request;
using B2.Client.Rest.Request.Param;


namespace B2.Client.Apis.CreateBucketV1
{
    /// <summary>
    /// The request object for the 'b2_create_bucket' version 1 API.
    /// </summary>
    public sealed class CreateBucketV1Request : JsonPostRestRequest
    {
        /// <summary>
        /// Creawte a new request object.
        /// </summary>
        /// <param name="accountId">The account ID.</param>
        /// <param name="bucketName">The bucket name.</param>
        /// <param name="bucketType">The bucket type.</param>
        public CreateBucketV1Request(string accountId, string bucketName, BucketType bucketType)
            : base(UrlParams.Empty,
                   HeaderParams.Empty,
                   new BodyParams(
                        RequiredParam.Of("accountId", accountId),
                        RequiredParam.Of("bucketName", bucketName),
                        RequiredParam.Of("bucketType", bucketType)
                   )
            ) { }
    }
}