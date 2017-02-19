using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace B2.Client.Rest
{
    /// <summary>
    /// A RequestData object that wraps field-size data that can be kept in memory.
    /// </summary>
    internal sealed class FieldRequestData : RequestData
    {
        private readonly string value;

        /// <summary>
        /// Create a new <see cref="RequestData" /> object that wraps raw string data.
        /// </summary>
        /// <param name="paramName">The name of the parameter in the REST request.</param>
        /// <param name="data">The raw string data for this parameter.</param>
        internal FieldRequestData(string paramName, string data) : base(paramName)
        {
            value = data.ThrowIfNull(nameof(data));
        }

        /// <summary>
        /// Return the <see cref="RequestData" /> as HttpContent for use in multipart data.
        /// </summary>
        /// <returns>A ByteArrayContent object which wraps the data, with the Name form-data header set.</returns>
        public override HttpContent GetAsHttpContent() => 
            new RequestDataByteArrayContent(Encoding.UTF8.GetBytes(value), new FieldRequestDataContentDispositionHeaderValue(Name));

        /// <summary>
        /// Returns this RequestData REST parameter as a KeyValuePair, suitable for form encoding or similar.
        /// </summary>
        /// <returns>Both the name and value of the wrapped parameter as a KeyValuePair.</returns>
        public override KeyValuePair<string, string> GetAsKeyValuePair() => new KeyValuePair<string, string>(Name, value);

        /// <summary>
        /// A multipart form-data content disposition header for a body field.
        /// </summary>
        private sealed class FieldRequestDataContentDispositionHeaderValue : MultipartContentDispositionHeaderValue
        {
            internal FieldRequestDataContentDispositionHeaderValue(string name)
            {
                Name = $"\"{name}\"";
            }
        }

        /// <summary>
        /// StreamContent that is configured for multipart form-data.
        /// </summary>
        sealed class RequestDataByteArrayContent : ByteArrayContent
        {
            internal RequestDataByteArrayContent(byte[] source, MultipartContentDispositionHeaderValue headers) : base(source)
            {
                Headers.ContentDisposition = headers;
            }
        }
    }
}
