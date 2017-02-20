using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// A parameter collection representing parameters that go in the request body.
    /// </summary>
    public sealed class BodyParams : RequestCollection<Param>
    {
        /// <summary>
        /// A <see cref="BodyParams" /> instance with no parameters.
        /// </summary>
        public static readonly BodyParams Empty = new BodyParams(Enumerable.Empty<Param>());

        /// <summary>
        /// Create a new <see cref="BodyParams" /> instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        public BodyParams(params IEnumerable<Param>[] parameters) : base(parameters) { }
    }
}