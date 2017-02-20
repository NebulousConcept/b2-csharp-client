using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Contains Param objects for use in REST calls for HTTP headers.
    /// </summary>
    public sealed class HeaderParams : RequestCollection<Param>
    {
        /// <summary>
        /// A HeaderParams instance with no parameters.
        /// </summary>
        public static readonly HeaderParams Empty = new HeaderParams(Enumerable.Empty<Param>());

        /// <summary>
        /// Create a new HeaderParams instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        public HeaderParams(params IEnumerable<Param>[] parameters) : base(parameters) { }
    }
}