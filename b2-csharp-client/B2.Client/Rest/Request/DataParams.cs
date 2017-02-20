using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Contains data objects for use in the body of REST calls.
    /// </summary>
    public sealed class DataParams : RequestCollection<RequestData>
    {
        /// <summary>
        /// A <see cref="DataParams"/> instance with no parameters.
        /// </summary>
        public static readonly DataParams Empty = new DataParams(Enumerable.Empty<RequestData>());

        /// <summary>
        /// Create a new <see cref="DataParams"/> instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        public DataParams(params IEnumerable<RequestData>[] parameters) : base(parameters) { }
    }
}