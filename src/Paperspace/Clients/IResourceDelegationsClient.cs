namespace Paperspace
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IResourceDelegationsClient
    {
        /// <summary>
        /// Create resourceDelegation with limited access, e.g. for users who needs to stream a machine you created. The create method takes a delegation object as the only argument with resource name as key and an object with ids to list resource ids to give access to.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IList<ResourceDelegation>> Create(CreateResourceDelegationRequest request);
    }
}
