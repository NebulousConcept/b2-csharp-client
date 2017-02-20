using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request.Param
{
    /// <summary>
    /// Contains RestParam objects for use in REST calls for HTTP headers.
    /// </summary>
    public sealed class HeaderParams : RequestCollection<RestParam>
    {
        /// <summary>
        /// A HeaderParams instance with no parameters.
        /// </summary>
        public static readonly HeaderParams Empty = new HeaderParams(Enumerable.Empty<RestParam>());

        /// <summary>
        /// Create a new HeaderParams instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        public HeaderParams(params IEnumerable<RestParam>[] parameters) : base(parameters) { }
    }
}