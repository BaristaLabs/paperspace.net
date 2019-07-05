namespace Paperspace
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ResourceDelegationsClient : ApiClient, IResourceDelegationsClient
    {
        /// <summary>
        /// Instantiates a new Paperspace Resource Delegations API client.
        /// </summary>
        /// <param name="connection">A connection</param>
        public ResourceDelegationsClient(IConnection connection)
            : base(connection)
        {
        }

        public Task<IList<ResourceDelegation>> Create(CreateResourceDelegationRequest request)
        {
            return Connection.Post<IList<ResourceDelegation>>(ApiUrls.ResourceDelegationsCreate(), null, request);
        }
    }
}
