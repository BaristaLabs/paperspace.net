namespace Paperspace
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IConnection
    {
        /// <summary>
        /// Gets the HttpClient associated with the connection.
        /// </summary>
        HttpClient HttpClient
        {
            get;
        }

        /// <summary>
        /// Gets the resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">Type of the resource to get.</typeparam>
        /// <param name="uri">URI of the resource to get</param>
        /// <param name="parameters">Parameters to add to the request url</param>
        /// <returns>The response object</returns>
        /// <exception cref="HttpRequestException">Thrown when an API error occurs.</exception>
        Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters = null);

        /// <summary>
        /// Creates a new resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">The resource's type.</typeparam>
        /// <param name="uri">URI of the resource to POST</param>
        /// <param name="parameters">Parameters to add to the request url</param>
        /// <param name="body">Object that describes the new API resource. The value will be serialized to a JSON body.</param>
        /// <exception cref="HttpRequestException">Thrown when an API error occurs.</exception>
        Task Post(Uri uri, IDictionary<string, string> parameters = null, object body = null);

        /// <summary>
        /// Creates a new resource at the specified URI.
        /// </summary>
        /// <typeparam name="T">The resource's type.</typeparam>
        /// <param name="uri">URI of the resource to POST</param>
        /// <param name="parameters">Parameters to add to the request url</param>
        /// <param name="body">Object that describes the new API resource. The value will be serialized to a JSON body.</param>
        /// <returns>The created API resource.</returns>
        /// <exception cref="HttpRequestException">Thrown when an API error occurs.</exception>
        Task<T> Post<T>(Uri uri, IDictionary<string, string> parameters = null, object body = null);
    }
}
