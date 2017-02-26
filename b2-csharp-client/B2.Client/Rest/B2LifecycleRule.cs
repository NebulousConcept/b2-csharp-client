using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


namespace B2.Client.Rest
{
    /// <summary>
    /// A lifecycle rule controlling the behavior of files uploaded to a bucket.
    /// </summary>
    [DataContract]
    public sealed class B2LifecycleRule : IEquatable<B2LifecycleRule>
    {
        /// <summary>
        /// Predefined rule for keeping only the most recent version of a file.
        /// </summary>
        public static readonly B2LifecycleRule OnlyLastVersion = new B2LifecycleRule(string.Empty, null, 1);

        /// <summary>
        /// The prefix determining which files this rule applies to.
        /// </summary>
        [DataMember(Name = "fileNamePrefix", IsRequired = true)]
        public string FilenamePrefix { get; }

        /// <summary>
        /// The number of days after being uploading that a file should be hidden.
        /// </summary>
        [DataMember(Name = "daysFromUploadingToHiding")]
        public ulong? DaysFromUploadingToHiding { get; }

        /// <summary>
        /// The number of days after being hidden that a file should be deleted.
        /// </summary>
        [DataMember(Name = "daysFromHidingToDeleting")]
        public ulong? DaysFromHidingToDeleting { get; }

        /// <summary>
        /// Create a new <see cref="B2LifecycleRule"/>.
        /// </summary>
        /// <param name="FilenamePrefix">The filename prefix.</param>
        /// <param name="DaysFromUploadingToHiding">The number of days until hiding.</param>
        /// <param name="DaysFromHidingToDeleting">The number of days until deleting.</param>
        /// <exception cref="ArgumentException">If both durations are null, or if either is 0.</exception>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public B2LifecycleRule(string FilenamePrefix, ulong? DaysFromUploadingToHiding, ulong? DaysFromHidingToDeleting)
        {
            if (DaysFromHidingToDeleting == null && DaysFromUploadingToHiding == null) {
                //should this be an ArgumentNullException instead?
                throw new ArgumentException("Cannot specify null for both duration options");
            }
            if (DaysFromHidingToDeleting == 0) {
                throw new ArgumentException($"{nameof(DaysFromHidingToDeleting)} cannot be 0");
            }
            if (DaysFromUploadingToHiding == 0) {
                throw new ArgumentException($"{nameof(DaysFromUploadingToHiding)} cannot be 0");
            }

            this.FilenamePrefix = FilenamePrefix.ThrowIfNull(nameof(FilenamePrefix));
            this.DaysFromUploadingToHiding = DaysFromUploadingToHiding;
            this.DaysFromHidingToDeleting = DaysFromHidingToDeleting;
        }

        /// <inheritdoc/>
        public bool Equals(B2LifecycleRule other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return FilenamePrefix.Equals(other.FilenamePrefix)
                   && DaysFromUploadingToHiding == other.DaysFromUploadingToHiding
                   && DaysFromHidingToDeleting == other.DaysFromHidingToDeleting;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            var a = obj as B2LifecycleRule;
            return a != null && Equals(a);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked {
                var hashCode = FilenamePrefix.GetHashCode();
                hashCode = (hashCode * 397) ^ DaysFromUploadingToHiding.GetHashCode();
                hashCode = (hashCode * 397) ^ DaysFromHidingToDeleting.GetHashCode();
                return hashCode;
            }
        }
    }
}