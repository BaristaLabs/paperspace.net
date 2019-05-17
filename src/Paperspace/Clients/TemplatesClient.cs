namespace Paperspace
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class TemplatesClient : ApiClient, ITemplatesClient
    {
        /// <summary>
        /// Instantiates a new Paperspace Templates API client.
        /// </summary>
        /// <param name="connection">A connection</param>
        public TemplatesClient(IConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// List information about all templates available to either the current authenticated user or the team, if the user belongs to a team. The list method takes an optional first argument to limit the returned template objects.
        /// </summary>
        /// <returns>A collection of Templates</returns>
        public Task<IList<Template>> List()
        {
            return Connection.Get<IList<Template>>(ApiUrls.TemplatesList());
        }
    }
}
