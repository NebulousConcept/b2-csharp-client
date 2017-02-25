using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;


namespace B2.Client.Rest.Response
{
    /// <summary>
    /// A response returned by the REST service when an error occurs.
    /// </summary>
    [DataContract]
    public class ErrorResponse : IResponse
    {
        /// <summary>
        /// The HTTP status code of the error.
        /// </summary>
        [DataMember(Name = "status", IsRequired = true)]
        public uint StatusCode { get; }

        /// <summary>
        /// The code for the error.
        /// </summary>
        [DataMember(Name = "code", IsRequired = true)]
        public string ErrorCode { get; }

        /// <summary>
        /// A human-readable message describing the error.
        /// </summary>
        [DataMember(Name = "message", IsRequired = true)]
        public string Message { get; }

        /// <summary>
        /// Create a new <see cref="ErrorResponse"/>.
        /// </summary>
        /// <param name="StatusCode">The HTTP status code.</param>
        /// <param name="ErrorCode">The code.</param>
        /// <param name="Message">The human-readable message.</param>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public ErrorResponse(uint StatusCode, string ErrorCode, string Message)
        {
            this.StatusCode = StatusCode;
            this.ErrorCode = ErrorCode;
            this.Message = Message;
        }
    }
}