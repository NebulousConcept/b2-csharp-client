using System;
using System.Linq;
using B2.Client.Rest;


namespace B2.Client.Apis.ListBucketsV1
{
    /// <summary>
    /// Represents the type of a bucket in a B2 account.
    /// </summary>
    public sealed class BucketType : INameable, IEquatable<BucketType>
    {
        /// <summary>
        /// Anybody can download all files in the bucket.
        /// </summary>
        public static readonly BucketType AllPublic = new BucketType("allPublic");
        /// <summary>
        /// An authorization token is required to download any file in the bucket.
        /// </summary>
        public static readonly BucketType AllPrivate = new BucketType("allPrivate");
        /// <summary>
        /// A private bucket containing snapshots alone.
        /// </summary>
        public static readonly BucketType Snapshot = new BucketType("snapshot");

        /// <inheritDoc />
        public string Name { get; }

        /// <summary>
        /// Array representing all allowable parameter values.
        /// </summary>
        public static readonly BucketType[] All = {
            AllPublic, AllPrivate, Snapshot
        };

        private BucketType(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Method to retrieve the parameter value instance for a specific name.
        /// </summary>
        /// <param name="name">The string name of the value.</param>
        /// <returns>The value instance with that string name.</returns>
        public static BucketType FromString(string name) => All.Single(f => f.Name == name);

        /// <summary>
        /// Convert a string to a value instance.
        /// </summary>
        /// <param name="bucketType">The string name of the bucket type.</param>
        /// <returns>The value instance represented by the string.</returns>
        public static explicit operator BucketType(string bucketType) => FromString(bucketType);

        /// <summary>
        /// Compare this <see cref="BucketType"/> with another object for equality.
        /// </summary>
        /// <param name="obj">The other object.</param>
        /// <returns>true if the objects are equivalent, false otherwise.</returns>
        public override bool Equals(object obj) => Equals(obj as BucketType);

        /// <summary>
        /// Compare this <see cref="BucketType"/> with another instance for equality.
        /// </summary>
        /// <param name="other">The other instance.</param>
        /// <returns>true if the instances are equivalent, false otherwise.</returns>
        public bool Equals(BucketType other) => (object)other != null && Name == other.Name;

        /// <summary>
        /// Compare two <see cref="BucketType"/> instances for equality.
        /// </summary>
        /// <param name="first">The first instance.</param>
        /// <param name="second">The second instance.</param>
        /// <returns>true if the instances are equivalent, false otherwise.</returns>
        public static bool operator ==(BucketType first, BucketType second)
            => !ReferenceEquals(first, null) && first.Equals(second);

        /// <summary>
        /// Compare two <see cref="BucketType"/> instances for inequality.
        /// </summary>
        /// <param name="first">The first instance.</param>
        /// <param name="second">The second instance.</param>
        /// <returns>false if the instances are equivalent, true otherwise.</returns>
        public static bool operator !=(BucketType first, BucketType second)
            => !ReferenceEquals(first, null) && !first.Equals(second);

        /// <summary>
        /// Compute a hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => Name.GetHashCode();
    }
}