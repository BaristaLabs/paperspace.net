namespace Paperspace
{
    public interface IPaperspaceClient
    {
        /// <summary>
        /// Gets the client connection used to make REST requests to Paperspace endpoints.
        /// </summary>C:\Projects\paperspace.net\src\Paperspace\PaperspaceClient.cs
        IConnection Connection { get; }

        /// <summary>
        /// Access Paperspace's Jobs API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/jobs.html
        /// </remarks>
        IJobsClient Jobs { get; }

        /// <summary>
        /// Access Paperspace's Machines API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/machines.html
        /// </remarks>
        IMachinesClient Machines { get; }

        /// <summary>
        /// Access Paperspace's Networks API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/networks.html
        /// </remarks>
        INetworksClient Networks { get; }

        /// <summary>
        /// Access Paperspace's Resource Delegations API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/resourceDelegations.html
        /// </remarks>
        IResourceDelegationsClient ResourceDelegations { get; }

        /// <summary>
        /// Access Paperspace's Scripts API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/scripts.html
        /// </remarks>
        IScriptsClient Scripts { get; }

        /// <summary>
        /// Access Paperspace's Templates API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/templates.html
        /// </remarks>
        ITemplatesClient Templates { get; }

        /// <summary>
        /// Access Paperspace's Users API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://paperspace.github.io/paperspace-node/users.html
        /// </remarks>
        IUsersClient Users { get; }
    }
}
