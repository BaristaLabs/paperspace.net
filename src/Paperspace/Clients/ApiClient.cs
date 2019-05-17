namespace Paperspace
{
    /// <summary>
    /// Base class for an API client.
    /// </summary>
    public abstract class ApiClient
    {
        /// <summary>
        /// Initializes a new API client.
        /// </summary>
        /// <param name="apiConnection">The client's connection</param>
        protected ApiClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, nameof(connection));

            Connection = connection;
        }

        /// <summary>
        /// Returns the underlying <see cref="IConnection"/> used by the <see cref="ApiClient"/>. This is useful
        /// for requests that need to access the HTTP response and not just the response model.
        /// </summary>
        protected IConnection Connection { get; }
    }
}
