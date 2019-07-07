namespace Paperspace
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsersClient : ApiClient, IUsersClient
    {
        /// <summary>
        /// Instantiates a new Paperspace Users API client.
        /// </summary>
        /// <param name="connection">A connection</param>
        public UsersClient(IConnection connection)
            : base(connection)
        {
        }

        public Task<IList<User>> List(UserFilter filter = null)
        {
            if (filter == null)
            {
                return Connection.Get<IList<User>>(ApiUrls.UsersList());
            }

            var parameters = filter.ToQueryStringDictionary();
            return Connection.Get<IList<User>>(ApiUrls.UsersList(), parameters);
        }
    }
}
