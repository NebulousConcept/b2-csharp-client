using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Contains Param objects for use in the query string of REST calls.
    /// </summary>
    public sealed class QueryParams : RequestCollection<Param>
    {
        /// <summary>
        /// A QueryParams instance with no parameters.
        /// </summary>
        public static readonly QueryParams Empty = new QueryParams(Enumerable.Empty<Param>());

        /// <summary>
        /// Create a new QueryParams instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        public QueryParams(params IEnumerable<Param>[] parameters) : base(parameters) { }
    }
}