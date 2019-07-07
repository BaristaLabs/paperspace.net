namespace Paperspace
{
    using Newtonsoft.Json.Linq;
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

        public Task<IList<Template>> List(TemplateFilter filter = null)
        {
            if (filter == null)
            {
                return Connection.Get<IList<Template>>(ApiUrls.TemplatesList());
            }

            var parameters = filter.ToQueryStringDictionary();
            return Connection.Get<IList<Template>>(ApiUrls.TemplatesList(), parameters);
        }
    }
}
