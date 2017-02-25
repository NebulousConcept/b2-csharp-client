using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;


namespace B2.Client.Rest.Request
{
    /// <summary>
    /// Represents a named piece of data for a REST request.
    /// </summary>
    public abstract class RequestData : IEnumerable<RequestData>
    {
        /// <summary>
        /// Return this <see cref="RequestData" /> as an IEnumerable.
        /// </summary>
        public IEnumerable<RequestData> Items => this.Yield();
        /// <summary>
        /// The name of this parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Return the <see cref="RequestData" /> as HttpContent for use in multipart data.
        /// </summary>
        /// <returns>A StreamContent object ready to be used as multipart form-data.</returns>
        public abstract HttpContent GetAsHttpContent();

        /// <summary>
        /// Returns this RequestData REST parameter as a KeyValuePair, suitable for form encoding or similar.
        /// </summary>
        /// <returns>This RequestData REST parameter as a KeyValuePair, with the key and value both strings.</returns>
        public abstract KeyValuePair<string, string> GetAsKeyValuePair();

        /// <summary>
        /// Enumerate over this <see cref="RequestData" />.
        /// </summary>
        /// <returns>An enumerator over this <see cref="RequestData" />.</returns>
        public IEnumerator<RequestData> GetEnumerator() => Items.GetEnumerator();

        /// <summary>
        /// Create a new RequestData from a reference to a file on local disk.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="source">The data source supplier.</param>
        /// <returns>A RequestData representing a named parameter wrapping a file on the local disk.</returns>
        public static RequestData Of(string name, DataSource source) => new StreamRequestData(name, source);

        /// <summary>
        /// Create a new RequestData from a URL.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="url">The public URL referring to the data.</param>
        /// <returns>A RequestData representing a named parameter wrapping data accessible from the URL.</returns>
        public static RequestData Of(string name, Uri url) => new FieldRequestData(name, url.ToString());

        /// <summary>
        /// Create a new RequestData from string data.
        /// </summary>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="data"></param>
        /// <returns>A RequestData representing a named parameter wrapping UTF-8 string data.</returns>
        public static RequestData Of(string name, string data) => new FieldRequestData(name, data);

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
        
        /// <summary>
        /// Create a new RequestData object.
        /// </summary>
        /// <param name="paramName">The name of the REST parameter.</param>
        protected RequestData(string paramName)
        {
            Name = paramName.ThrowIfNull(nameof(paramName));
        }

        /// <summary>
        /// A content disposition header for form-data.
        /// </summary>
        protected abstract class MultipartContentDispositionHeaderValue : ContentDispositionHeaderValue
        {
            /// <summary>
            /// Create a new MultipartContentDispositionHeaderValue.
            /// </summary>
            protected MultipartContentDispositionHeaderValue() : base("form-data") { }
        }
    }
}
