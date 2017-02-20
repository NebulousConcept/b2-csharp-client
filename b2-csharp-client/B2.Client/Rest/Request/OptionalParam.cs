using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Represents an optional parameter, specifically a parameter that may or may not have a value.
    /// </summary>
    public sealed class OptionalParam : IEnumerable<Param>
    {
        private IEnumerable<Param> Items { get; }

        private OptionalParam(string name, string value) : this(name, value?.Yield()) { }

        private OptionalParam(string name, IEnumerable<string> values)
        {
            name.ThrowIfNull(nameof(name));
            Items = values?.Select(v => new Param(name, v)) ?? Enumerable.Empty<Param>();
        }

        /// <summary>
        /// Create an OptionalParam from a string value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, string value) => new OptionalParam(name, value);
        /// <summary>
        /// Create an OptionalParam from an <see cref="INameable"/> object.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The <see cref="INameable"/> object, can be null.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, INameable value) => new OptionalParam(name, value?.Name);
        /// <summary>
        /// Create an OptionalParam from a long value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, int? value) => new OptionalParam(name, value?.ToString());
        /// <summary>
        /// Create an OptionalParam from a uint value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, uint? value) => new OptionalParam(name, value?.ToString());
        /// <summary>
        /// Create an OptionalParam from a long value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, long? value) => new OptionalParam(name, value?.ToString());
        /// <summary>
        /// Create an OptionalParam from a ulong value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, ulong? value) => new OptionalParam(name, value?.ToString());
        /// <summary>
        /// Create an OptionalParam from a double value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, double? value) => new OptionalParam(name, value?.ToString());
        /// <summary>
        /// Create an OptionalParam from a bool value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, bool? value) => new OptionalParam(name, value?.ToString());
        /// <summary>
        /// Create an OptionalParam from an enumeration of strings.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<string> values) => new OptionalParam(name, values);
        /// <summary>
        /// Create an OptionalParam from an enumeration of <see cref="INameable"/> objects.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<INameable> values) => new OptionalParam(name, values?.Select(x => x.Name));
        /// <summary>
        /// Create an OptionalParam from an enumeration of ints.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<int> values) => new OptionalParam(name, values?.Select(x => x.ToString()));
        /// <summary>
        /// Create an OptionalParam from an enumeration of uints.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<uint> values) => new OptionalParam(name, values?.Select(x => x.ToString()));
        /// <summary>
        /// Create an OptionalParam from an enumeration of longs.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<long> values) => new OptionalParam(name, values?.Select(x => x.ToString()));
        /// <summary>
        /// Create an OptionalParam from an enumeration of ulongs.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<ulong> values) => new OptionalParam(name, values?.Select(x => x.ToString()));
        /// <summary>
        /// Create an OptionalParam from an enumeration of doubles.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<double> values) => new OptionalParam(name, values?.Select(x => x.ToString()));
        /// <summary>
        /// Create an OptionalParam from an enumeration of bools.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter, or null if not set.</param>
        /// <returns>An OptionalParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<bool> values) => new OptionalParam(name, values?.Select(x => x.ToString()));

        /// <summary>
        /// Enumerate over this parameter.
        /// </summary>
        /// <returns>This parameter as an enumeration of zero or more values.</returns>
        public IEnumerator<Param> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
    }
}