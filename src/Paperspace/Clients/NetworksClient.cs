namespace Paperspace
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NetworksClient : ApiClient, INetworksClient
    {
        /// <summary>
        /// Instantiates a new Paperspace Networks API client.
        /// </summary>
        /// <param name="connection">A connection</param>
        public NetworksClient(IConnection connection)
            : base(connection)
        {
        }

        public Task<IList<Network>> List(NetworkFilter filter = null)
        {
            if (filter == null)
            {
                return Connection.Get<IList<Network>>(ApiUrls.NetworksList());
            }

            var parameters = filter.ToQueryStringDictionary();
            return Connection.Get<IList<Network>>(ApiUrls.NetworksList(), parameters);
        }
    }
}
