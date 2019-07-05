﻿namespace Paperspace
{
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ScriptsClient : ApiClient, IScriptsClient
    {
        /// <summary>
        /// Instantiates a new Paperspace Scripts API client.
        /// </summary>
        /// <param name="connection">A connection</param>
        public ScriptsClient(IConnection connection)
            : base(connection)
        {
        }

        public Task<Script> Create(CreateScriptRequest request)
        {
            return Connection.Post<Script>(ApiUrls.ScriptsCreate(), null, request);
        }

        public Task Destroy(string scriptId)
        {
            return Connection.Post<Script>(ApiUrls.ScriptsDestroy(scriptId), null);
        }

        public Task<IList<Script>> List(ScriptFilter filter = null)
        {
            if (filter == null)
            {
                return Connection.Get<IList<Script>>(ApiUrls.ScriptsList());
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

                return Connection.Get<IList<Script>>(ApiUrls.ScriptsList(), parameters);
            }
        }

        public Task<Script> Show(string scriptId)
        {
            return Connection.Get<Script>(ApiUrls.ScriptsShow(scriptId), null);
        }

        public Task<string> Text(string scriptId)
        {
            return Connection.Get<string>(ApiUrls.ScriptsText(scriptId), null);
        }
    }
}