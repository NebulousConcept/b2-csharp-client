using System;
using System.IO;
using System.Text;


namespace B2.Client.Rest
{
    /// <summary>
    /// Represents an arbitrary data source which can be streamed or returned as a string or bytes.
    /// It is assumed the underlying data source will not change during the lifetime of this object.
    /// </summary>
    public sealed class DataSource
    {
        /// <summary>
        /// The named identity of the stream.
        /// </summary>
        public string StreamName { get; }
        private readonly Func<Stream> streamSupplier;

        /// <summary>
        /// Create a new data source.
        /// </summary>
        /// <param name="streamName">The name to identify this stream of data, eg. a file name.</param>
        /// <param name="streamSupplier">A supplier that returns a stream to the data.</param>
        public DataSource(string streamName, Func<Stream> streamSupplier)
        {
            if (streamName == null) {
                throw new ArgumentNullException(nameof(streamName));
            }
            if (streamSupplier == null) {
                throw new ArgumentNullException(nameof(streamSupplier));
            }
            StreamName = streamName;
            this.streamSupplier = streamSupplier;
        }

        /// <summary>
        /// Acquire the stream that represents the data. The caller should close the stream.
        /// </summary>
        /// <returns>The stream that represents the data.</returns>
        public Stream GetStream() => streamSupplier.Invoke();

        /// <summary>
        /// Read the entire stream that represents the data and return it as a UTF-8 string.
        /// </summary>
        /// <returns>The data represented by this object.</returns>
        public string GetAsString()
        {
            using (Stream s = GetStream())
            using (StreamReader sr = new StreamReader(s, Encoding.UTF8)) {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Read the entire stream that represents the data and return it as raw bytes.
        /// </summary>
        /// <returns>The data represented by this object.</returns>
        public byte[] GetBytes()
        {
            byte[] buffer = new byte[16 * 1024];
            using (Stream s = GetStream())
            using (MemoryStream ms = new MemoryStream()) {
                int read;
                while ((read = s.Read(buffer, 0, buffer.Length)) > 0) {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
