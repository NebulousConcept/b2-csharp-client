using System;


namespace B2.Client.Rest.Request.Param
{
    /// <summary>
    /// Class representing a REST parameter for API calls.
    /// </summary>
    public sealed class RestParam : IEquatable<RestParam>
    {
        /// <summary>
        /// The name (key) of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The converted string value of the parameter.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Create a new escaped string parameter for use in a REST request.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The string value of the parameter.</param>
        internal RestParam(string name, string value)
        {
            Name = name.ThrowIfNull(nameof(name));
            Value = value.ThrowIfNull(nameof(value));
        }

        /// <inheritdoc/>
        public bool Equals(RestParam other)
        {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return string.Equals(Name, other.Name) && string.Equals(Value, other.Value);
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
            var a = obj as RestParam;
            return a != null && Equals(a);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked {
                return (Name.GetHashCode() * 397) ^ Value.GetHashCode();
            }
        }
    }
}
