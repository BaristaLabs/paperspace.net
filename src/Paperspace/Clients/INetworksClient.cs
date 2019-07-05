namespace Paperspace
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INetworksClient
    {
        /// <summary>
        /// List information about all networks available to either the current authenticated user or the team, if the user belongs to a team. The list method takes an optional first argument to limit the returned network objects.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IList<Network>> List(NetworkFilter filter = null);
    }
}
