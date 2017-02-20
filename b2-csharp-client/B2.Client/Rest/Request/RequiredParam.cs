using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Represents a Param that must be set, specifically a Param that has a non-null value.
    /// </summary>
    public sealed class RequiredParam : IEnumerable<Param>
    {
        private IEnumerable<Param> Items { get; }

        private RequiredParam(string name, string value)
        {
            Items = new Param(name, value).Yield();
        }

        private RequiredParam(string name, IEnumerable<string> values)
        {
            Items = values.Select(v => new Param(name, v));
        }

        /// <summary>
        /// Create a RequiredParam from a string value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, string value) => new RequiredParam(name, value);
        /// <summary>
        /// Create a RequiredParam from an INamable object.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The INamable object.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, INameable value) => new RequiredParam(name, value.Name);
        /// <summary>
        /// Create a RequiredParam from an int value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, int value) => new RequiredParam(name, value.ToString());
        /// <summary>
        /// Create a RequiredParam from a uint value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, uint value) => new RequiredParam(name, value.ToString());
        /// <summary>
        /// Create a RequiredParam from a long value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, long value) => new RequiredParam(name, value.ToString());
        /// <summary>
        /// Create a RequiredParam from a ulong value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, ulong value) => new RequiredParam(name, value.ToString());
        /// <summary>
        /// Create a RequiredParam from a double value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, double value) => new RequiredParam(name, value.ToString());
        /// <summary>
        /// Create a RequiredParam from a bool value.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, bool value) => new RequiredParam(name, value.ToString());
        /// <summary>
        /// Create a RequiredParam from an enumeration of strings.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<string> values) => new RequiredParam(name, values);
        /// <summary>
        /// Create a RequiredParam from an enumeration of INamable objects.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<INameable> values)
            => new RequiredParam(name, values.Select(x => x.Name));
        /// <summary>
        /// Create a RequiredParam from an enumeration of ints.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<int> values)
            => new RequiredParam(name, values.Select(x => x.ToString()));
        /// <summary>
        /// Create a RequiredParam from an enumeration of uints.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<uint> values)
            => new RequiredParam(name, values.Select(x => x.ToString()));
        /// <summary>
        /// Create a RequiredParam from an enumeration of longs.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<long> values)
            => new RequiredParam(name, values.Select(x => x.ToString()));
        /// <summary>
        /// Create a RequiredParam from an enumeration of ulongs.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<ulong> values)
            => new RequiredParam(name, values.Select(x => x.ToString()));
        /// <summary>
        /// Create a RequiredParam from an enumeration of doubles.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<double> values)
            => new RequiredParam(name, values.Select(x => x.ToString()));
        /// <summary>
        /// Create a RequiredParam from an enumeration of bools.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="values">The values of the parameter.</param>
        /// <returns>A RequiredParam representing the requested parameter.</returns>
        public static IEnumerable<Param> Of(string name, IEnumerable<bool> values)
            => new RequiredParam(name, values.Select(x => x.ToString()));

        /// <summary>
        /// Enumerate over this parameter.
        /// </summary>
        /// <returns>This parameter as an enumeration of one or more values.</returns>
        public IEnumerator<Param> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
    }
}