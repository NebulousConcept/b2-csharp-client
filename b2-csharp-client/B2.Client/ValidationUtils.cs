using System;


namespace B2.Client
{
    /// <summary>
    /// Extension methods for doing common method parameter validation.
    /// </summary>
    public static class ValidationUtils
    {
        /// <summary>
        /// Validate that a value is non-null. This method is intended for simple parameter validation in method calls.
        /// </summary>
        /// <example>
        /// This sample shows the expected usage of this method.
        /// <code>
        /// public void DoStuff(string value)
        /// {
        ///     var safeValue = value.ThrowIfNull(nameof(value));
        ///     //...
        /// }
        /// </code>
        /// </example>
        /// <param name="input">The value to assert non-nullity on.</param>
        /// <param name="name">The name of the input value.</param>
        /// <typeparam name="T">The type of the input value.</typeparam>
        /// <returns>The input value, if it is non-null.</returns>
        /// <exception cref="ArgumentNullException">If the input is null.</exception>
        public static T ThrowIfNull<T>(this T input, string name)
            where T : class
        {
            if (input == null) {
                throw new ArgumentNullException(name);
            }
            return input;
        }
    }
}