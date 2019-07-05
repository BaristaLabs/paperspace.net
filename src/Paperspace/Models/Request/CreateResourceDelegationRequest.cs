namespace Paperspace
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// A delegation object to grant access to reources
    /// </summary>
    public class CreateResourceDelegationRequest
    {
        /// <summary>
        /// Optional resource 'machine' to grant access to.
        /// </summary>
        [JsonProperty("machine")]
        public CreateResourceDelegationMachine Machine
        {
            get;
            set;
        }
    }

    public class CreateResourceDelegationMachine
    {
        /// <summary>
        /// Optional list of machine ids to grant access to.
        /// </summary>
        [JsonProperty("ids")]
        public IList<string> Ids
        {
            get;
            set;
        }
    }
}
