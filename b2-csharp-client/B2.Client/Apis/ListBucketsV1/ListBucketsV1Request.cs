using B2.Client.Rest.Request;
using B2.Client.Rest.Request.Param;


namespace B2.Client.Apis.ListBucketsV1
{
    /// <summary>
    /// Request object for the 'b2_list_buckets' version 1 API.
    /// </summary>
    public sealed class ListBucketsV1Request : JsonPostRestRequest
    {
        /// <summary>
        /// Create a new list buckets request.
        /// </summary>
        /// <param name="accountId">The ID of the account to list buckets for.</param>
        public ListBucketsV1Request(string accountId)
            : base(UrlParams.Empty,
                HeaderParams.Empty,
                new BodyParams(RequiredParam.Of("accountId", accountId))) { }
    }
}