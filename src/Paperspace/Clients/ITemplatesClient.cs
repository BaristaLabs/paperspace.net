namespace Paperspace
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITemplatesClient
    {
        /// <summary>
        /// List information about all templates available to either the current authenticated user or the team, if the user belongs to a team. The list method takes an optional first argument to limit the returned template objects.
        /// </summary>
        /// <returns>A collection of Templates</returns>
        Task<IList<Template>> List();
    }
}
