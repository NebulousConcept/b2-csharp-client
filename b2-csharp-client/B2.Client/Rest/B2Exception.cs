using System;

using B2.Client.Rest.Response;


namespace B2.Client.Rest
{
    /// <summary>
    /// Base exception thrown whenever an API call to the B2 service errors.
    /// </summary>
    public class B2Exception : Exception
    {
        /// <summary>
        /// The error response from the B2 service.
        /// </summary>
        public ErrorResponse ErrorResponse { get; }

        /// <summary>
        /// Create a new <see cref="B2Exception"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="errorResponse">The error response.</param>
        public B2Exception(string message, ErrorResponse errorResponse) : base(message)
        {
            ErrorResponse = errorResponse;
        }

        /// <summary>
        /// Create a new <see cref="B2Exception"/>.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="errorResponse">The error response.</param>
        /// <param name="innerException">The exception cause.</param>
        public B2Exception(string message, ErrorResponse errorResponse, Exception innerException)
            : base(message, innerException)
        {
            ErrorResponse = errorResponse;
        }
    }
}