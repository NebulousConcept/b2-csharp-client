using System.Collections.Generic;
using System.Runtime.Serialization;
using B2.Client.Rest.Response;


namespace B2.Client.Apis.ListBucketsV1
{
    /// <summary>
    /// Response object for the 'b2_list_buckets' version 1 API.
    /// </summary>
    [DataContract]
    public sealed class ListBucketsV1Response : IResponse
    {
        /// <summary>
        /// The buckets present in the account.
        /// </summary>
        [DataMember(Name = "buckets", IsRequired = true)]
        public List<B2Bucket> Buckets { get; }


        /// <summary>
        /// Create a new <see cref="ListBucketsV1Response"/>.
        /// </summary>
        /// <param name="Buckets"></param>
        public ListBucketsV1Response(List<B2Bucket> Buckets)
        {
            this.Buckets = Buckets;
        }


        /// <summary>
        /// Represents an individual B2 bucket.
        /// </summary>
        [DataContract]
        public sealed class B2Bucket
        {
            /// <summary>
            /// The ID of the account the bucket belongs to.
            /// </summary>
            [DataMember(Name = "accountId", IsRequired = true)]
            public string AccountId { get; }

            /// <summary>
            /// The ID of the bucket.
            /// </summary>
            [DataMember(Name = "bucketId", IsRequired = true)]
            public string BucketId { get; }

            /// <summary>
            /// The name of the bucket.
            /// </summary>
            [DataMember(Name = "bucketName", IsRequired = true)]
            public string BucketName { get; }

            /// <summary>
            /// The type of the bucket.
            /// </summary>
            [DataMember(Name = "bucketType", IsRequired = true)]
            public string BucketType { get; }

            /// <summary>
            /// The revision number of the bucket, which increments every time it is changed.
            /// </summary>
            [DataMember(Name = "revision", IsRequired = true)]
            public uint Revision { get; }


            /// <summary>
            /// Create a new <see cref="B2Bucket"/>.
            /// </summary>
            /// <param name="AccountId">The ID of the account the bucket belongs to.</param>
            /// <param name="BucketId">The ID of the bucket.</param>
            /// <param name="BucketName">The name of the bucket.</param>
            /// <param name="BucketType">The type of the bucket.</param>
            /// <param name="Revision">The revision number of the bucket, which increments every time it is changed.</param>
            public B2Bucket(string AccountId, string BucketId, string BucketName, string BucketType, uint Revision)
            {
                this.AccountId = AccountId;
                this.BucketId = BucketId;
                this.BucketName = BucketName;
                this.BucketType = BucketType;
                this.Revision = Revision;
            }
        }
    }
}