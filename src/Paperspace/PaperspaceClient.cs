namespace Paperspace
{
    using System;

    /// <summary>
    /// A client for the Paperspace Client. You can read more about the api here: https://paperspace.github.io/paperspace-node/index.html
    /// </summary>
    public class PaperspaceClient : IPaperspaceClient
    {
        /// <summary>
        /// The base address for the Paperspace API
        /// </summary>
        public static readonly Uri PaperspaceApiUrl = new Uri("https://api.paperspace.io/");

        /// <summary>
        /// The Base address for the Paperspace Logs API
        /// </summary>
        public static readonly Uri PaperspaceLogApiUrl = new Uri("https://logs.paperspace.io/");

        /// <summary>
        /// Create a new instance of the Paperspace APIclient pointing to
        /// https://api.paperspace.io/
        /// </summary>
        /// <param name="apiKey">
        /// The API key created from within the API section of the Paperspace console. 
        /// </param>
        public PaperspaceClient(string apiKey)
            : this(new Connection(apiKey, PaperspaceApiUrl, new System.Net.Http.HttpClient()), new Connection(apiKey, PaperspaceLogApiUrl, new System.Net.Http.HttpClient()))
        {
        }

        /// <summary>
        /// Create a new instance of the Paperspace client using the specified connection.
        /// </summary>
        /// <param name="connection">The underlying <seealso cref="IConnection"/> used to make requests</param>
        public PaperspaceClient(IConnection connection, IConnection logsConnection)
        {
            Ensure.ArgumentNotNull(connection, nameof(connection));
            Ensure.ArgumentNotNull(logsConnection, nameof(logsConnection));

            Connection = connection;
            LogsConnection = logsConnection;

            // Initialize Clients
            Machines = new MachinesClient(connection);
            Networks = new NetworksClient(connection);
            Scripts = new ScriptsClient(connection);
            ResourceDelegations = new ResourceDelegationsClient(connection);
            Templates = new TemplatesClient(connection);
            Users = new UsersClient(connection);
        }

        /// <summary>
        /// Gets the client connection used to make REST requests to Paperspace endpoints.
        /// </summary>C:\Projects\paperspace.net\src\Paperspace\PaperspaceClient.cs
        public IConnection Connection { get; }

        /// <summary>
        /// Gets the client connection used to make REST requests to Paperspace Logs endpoints.
        /// </summary>C:\Projects\paperspace.net\src\Paperspace\PaperspaceClient.cs
        public IConnection LogsConnection { get; }

        /// <summary>
        /// Access Paperspace's Jobs API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/jobs.html
        /// </remarks>
        public IJobsClient Jobs { get; }

        /// <summary>
        /// Access Paperspace's Machines API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/machines.html
        /// </remarks>
        public IMachinesClient Machines { get; }

        /// <summary>
        /// Access Paperspace's Networks API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/networks.html
        /// </remarks>
        public INetworksClient Networks { get; }

        /// <summary>
        /// Access Paperspace's Resource Delegations API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/resourceDelegations.html
        /// </remarks>
        public IResourceDelegationsClient ResourceDelegations { get; }

        /// <summary>
        /// Access Paperspace's Scripts API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/scripts.html
        /// </remarks>
        public IScriptsClient Scripts { get; }

        /// <summary>
        /// Access Paperspace's Templates API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/templates.html
        /// </remarks>
        public ITemplatesClient Templates { get; }

        /// <summary>
        /// Access Paperspace's Users API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/users.html
        /// </remarks>
        public IUsersClient Users { get; }
    }
}
