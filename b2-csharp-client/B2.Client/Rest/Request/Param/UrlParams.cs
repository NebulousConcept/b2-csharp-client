using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request.Param
{
    /// <summary>
    /// A parameter collection representing parameters which go in the resource URL directly.
    /// </summary>
    public sealed class UrlParams : RequestCollection<RestParam>
    {
        /// <summary>
        /// An <see cref="UrlParams" /> instance with no parameters.
        /// </summary>
        public static readonly UrlParams Empty = new UrlParams(Enumerable.Empty<RestParam>());

        /// <summary>
        /// Create a new <see cref="UrlParams" /> instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        public UrlParams(params IEnumerable<RestParam>[] parameters) : base(parameters) { }
    }
}