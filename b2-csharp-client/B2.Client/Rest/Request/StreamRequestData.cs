using System.Collections.Generic;
using System.Net.Http;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// A RequestData object that contains a reference to a file on a local disk.
    /// </summary>
    internal sealed class StreamRequestData : RequestData
    {
        private readonly DataSource source;

        /// <summary>
        /// Create a new RequestData wrapping a local file on disk.
        /// </summary>
        /// <param name="paramName">The name of the REST parameter.</param>
        /// <param name="source">The stream supplier.</param>
        internal StreamRequestData(string paramName, DataSource source) : base(paramName)
        {
            this.source = source.ThrowIfNull(nameof(source));
        }

        /// <summary>
        /// A multipart form-data content disposition header for a body file.
        /// </summary>
        private sealed class FileRequestDataContentDispositionHeaderValue : MultipartContentDispositionHeaderValue
        {
            internal FileRequestDataContentDispositionHeaderValue(string name, string fileName)
            {
                Name = $"\"{name}\"";
                FileName = $"\"{fileName}\"";
            }
        }

        /// <summary>
        /// StreamContent that is configured for multipart form-data.
        /// </summary>
        private sealed class RequestDataStreamContent : StreamContent
        {
            internal RequestDataStreamContent(DataSource source, MultipartContentDispositionHeaderValue headers) 
                : base(source.GetStream())
            {
                Headers.ContentDisposition = headers;
            }
        }

        /// <summary>
        /// Return the <see cref="RequestData" /> as HttpContent for use in multipart data.
        /// </summary>
        /// <returns>An object which wraps the file on local disk, with the Name and FileName form-data headers both set.</returns>
        public override HttpContent GetAsHttpContent() =>
            new RequestDataStreamContent(source, new FileRequestDataContentDispositionHeaderValue(Name, source.StreamName));

        /// <summary>
        /// This method will read the entire stream into the value of the KeyValuePair. Should only be utilized with small files.
        /// </summary>
        /// <returns>This RequestData REST parameter as a KeyValuePair, suitable for form encoding or similar.</returns>
        public override KeyValuePair<string, string> GetAsKeyValuePair() => new KeyValuePair<string, string>(Name, source.GetAsString());
    }
}
