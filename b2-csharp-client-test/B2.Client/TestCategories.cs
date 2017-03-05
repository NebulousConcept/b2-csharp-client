namespace B2.Client.Test
{
    /// <summary>
    /// String constants for categorizing tests.
    /// </summary>
    public static class TestCategories
    {
        /// <summary>
        /// Unit tests, which have no external dependencies and can be run on any machine once the project is built.
        /// </summary>
        public const string Unit = "unit";

        /// <summary>
        /// Authentication integration tests, which represent tests for functionality that must be working before any
        /// other integration tests can be run. If authentication tests fail there is no point in running the normal
        /// integration tests.
        /// </summary>
        public const string Authentication = "auth";

        /// <summary>
        /// Integration tests, which will call out to the B2 endpoint and require credentials to be set via
        /// environment variables.
        /// </summary>
        public const string Integration = "integration";
    }
}