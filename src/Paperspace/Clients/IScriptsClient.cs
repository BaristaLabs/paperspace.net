namespace Paperspace
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a Paperspace Scripts client. See https://paperspace.github.io/paperspace-node/scripts.html`
    /// </summary>
    public interface IScriptsClient
    {
        /// <summary>
        /// Creates a new startup script. Optionally specify a machine to use this startup script.
        /// </summary>
        /// <remarks>
        /// For Linux machines the script should be a bash script. For Windows machines the script should be a powershell script. See the samples directory for sample startup scripts for Windows. Note: script data is limited to 16KB per script. See the Script Guide for more info on using scripts.
        /// </remarks>
        /// <returns></returns>
        Task<Script> Create(CreateScriptRequest request, Stream scriptStream = null);

        /// <summary>
        /// Destroys the starup script with the given id. When this action is performed, the script is immediately disassociated from any machines it is assigned to as well.
        /// </summary>
        /// <param name="scriptId"></param>
        /// <returns></returns>
        Task Destroy(string scriptId);

        /// <summary>
        /// List information about all scripts assigned to either the current authenticated user or the team, if the user belongs to a team. The list method takes an optional first argument to limit the returned script objects.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IList<Script>> List(ScriptFilter filter = null);

        /// <summary>
        /// Show information for the script with the given id, except for the script text. Use the scripts text method retrieve the script text.
        /// </summary>
        /// <param name="scriptId"></param>
        /// <returns></returns>
        Task<Script> Show(string scriptId);

        /// <summary>
        /// Gets the text of the script with the given id.
        /// </summary>
        /// <param name="scriptId"></param>
        /// <returns></returns>
        Task<string> Text(string scriptId);
    }
}
