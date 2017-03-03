using B2.Client.Apis.AuthorizeAccountV1;
using B2.Client.Apis.CreateBucketV1;
using B2.Client.Apis.DeleteBucketV1;
using B2.Client.Apis.ListBucketsV1;


namespace B2.Client.Apis
{
    /// <summary>
    /// Helper class containing pre-declared instances of the various B2 APIs.
    /// </summary>
    public static class B2Apis
    {
        /// <summary>
        /// The 'b2_authorize_account' version 1 API.
        /// </summary>
        public static readonly AuthorizeAccountV1Api AuthorizeAccountV1 = new AuthorizeAccountV1Api();

        /// <summary>
        /// The 'b2_create_bucket' version 1 API.
        /// </summary>
        public static readonly CreateBucketV1Api CreateBucketV1 = new CreateBucketV1Api();

        /// <summary>
        /// The 'b2_delete_bucket' version 1 API.
        /// </summary>
        public static readonly DeleteBucketV1Api DeleteBucketV1 = new DeleteBucketV1Api();

        /// <summary>
        /// The 'b2_list_buckets' version 1 API.
        /// </summary>
        public static readonly ListBucketsV1Api ListBucketsV1 = new ListBucketsV1Api();
    }
}