using System;


namespace B2.Client.Rest
{
    /// <summary>
    /// Class representing a REST parameter for API calls.
    /// </summary>
    public sealed class Param
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
        internal Param(string name, string value)
        {
            if (name == null) {
                throw new ArgumentNullException(nameof(name));
            }
            if (value == null) {
                throw new ArgumentNullException(nameof(name));
            }
        }
    }
}
