using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request.Param
{
    /// <summary>
    /// Abstract class representing a collection of objects for a Request.
    /// </summary>
    public abstract class RequestCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Returns the parameters assigned to this object.
        /// </summary>
        private IEnumerable<T> Items { get; }

        /// <summary>
        /// The number of parameters in the collection.
        /// </summary>
        public long Count => Items.Count();

        /// <summary>
        /// Create a new ParamCollection instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        protected RequestCollection(IEnumerable<T> parameters)
        {
            Items = parameters.ThrowIfNull(nameof(parameters));
        }

        /// <summary>
        /// Create a new ParamCollection instance.
        /// </summary>
        /// <param name="parameters">Parameters to be part of this collection.</param>
        protected RequestCollection(params IEnumerable<T>[] parameters) : this(parameters.SelectMany(x => x)) { }

        /// <summary>
        /// Enumerate over the parameters in this request collection.
        /// </summary>
        /// <returns>An enumeration of the parameters in this collection.</returns>
        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
    }
}