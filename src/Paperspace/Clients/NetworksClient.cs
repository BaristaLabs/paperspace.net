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
            else
            {
                var parameters = new Dictionary<string, string>();
                var jObj = JObject.FromObject(filter);
                foreach (var property in jObj)
                {
                    if (property.Value != null)
                    {
                        parameters.Add(property.Key, property.Value.ToString());
                    }
                }

                return Connection.Get<IList<Network>>(ApiUrls.NetworksList(), parameters);
            }
        }
    }
}
