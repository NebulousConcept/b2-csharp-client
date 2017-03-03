using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

using B2.Client.Rest;
using B2.Client.Rest.Response;


namespace B2.Client.Apis.CreateBucketV1
{
    /// <summary>
    /// Response object for the 'b2_create_bucket' version 1 API.
    /// </summary>
    [DataContract]
    public sealed class CreateBucketV1Response : IResponse
    {
        /// <summary>
        /// The account ID.
        /// </summary>
        [DataMember(Name = "accountId", IsRequired = true)]
        public string AccountId { get; }

        /// <summary>
        /// The bucket ID.
        /// </summary>
        [DataMember(Name = "bucketid", IsRequired = true)]
        public string BucketId { get; }

        /// <summary>
        /// The bucket name.
        /// </summary>
        [DataMember(Name = "bucketName", IsRequired = true)]
        public string BucketName { get; }

        /// <summary>
        /// The bucket type.
        /// </summary>
        [DataMember(Name = "bucketType", IsRequired = true)]
        public BucketType BucketType { get; }

        /// <summary>
        /// The bucket lifecycle rules.
        /// </summary>
        [DataMember(Name = "lifecycleRules", IsRequired = true)]
        public List<B2LifecycleRule> LifecycleRules { get; }

        /// <summary>
        /// The bucket revision.
        /// </summary>
        [DataMember(Name = "revision", IsRequired = true)]
        public ulong Revision { get; }

        /// <summary>
        /// Create a new response object.
        /// </summary>
        /// <param name="AccountId">The account ID.</param>
        /// <param name="BucketId">The bucket ID.</param>
        /// <param name="BucketName">The bucket name.</param>
        /// <param name="BucketType">The bucket type.</param>
        /// <param name="LifecycleRules">The bucket lifecycle rules.</param>
        /// <param name="Revision">The bucket revision.</param>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public CreateBucketV1Response(string AccountId, string BucketId, string BucketName, BucketType BucketType, List<B2LifecycleRule> LifecycleRules, ulong Revision)
        {
            this.AccountId = AccountId;
            this.BucketId = BucketId;
            this.BucketName = BucketName;
            this.BucketType = BucketType;
            this.LifecycleRules = LifecycleRules;
            this.Revision = Revision;
        }
    }
}