namespace Paperspace
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsersClient
    {
        /// <summary>
        /// List information about all users available to either the current authenticated user or the team, if the user belongs to a team. The list method takes an optional first argument to limit the returned user objects.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IList<User>> List(UserFilter filter = null);
    }
}
