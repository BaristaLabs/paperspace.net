namespace Paperspace
{
    using Newtonsoft.Json;

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateMachineRequest
    {
        /// <summary>
        /// Name of the region: either 'East Coast (NY2)', 'West Coast (CA1)', or 'Europe (AMS1)'
        /// </summary>
        [JsonProperty("region")]
        public Region Region
        {
            get;
            set;
        }

        /// <summary>
        /// Machine type: either 'Air', 'Standard', 'Pro', 'Advanced', 'GPU+', 'P4000', 'P5000', 'P6000', 'V100', 'C1', 'C2', 'C3', 'C4', 'C5', 'C6', 'C7', 'C8', 'C9', or 'C10'
        /// </summary>
        /// <remarks>
        /// Note:
        /// Windows os templates cannot be used to create CPU-only machine types 'C1' - 'C10'.
        /// Ubuntu os templates cannot be used to create GRID GPU machine types: 'Air', 'Standard', 'Pro', or 'Advanced'.
        /// </remarks>
        [JsonProperty("machineType")]
        public MachineType MachineType
        {
            get;
            set;
        }

        /// <summary>
        /// Storage size for the machine in GB
        /// </summary>
        [JsonProperty("size")]
        public int Size
        {
            get;
            set;
        }

        /// <summary>
        /// Either 'monthly' or 'hourly' billing
        /// </summary>
        [JsonProperty("billingType")]
        public BillingType BillingType
        {
            get;
            set;
        }

        /// <summary>
        /// A memorable name for this machine
        /// </summary>
        [JsonProperty("machineName")]
        public string MachineName
        {
            get;
            set;
        }

        /// <summary>
        /// Template id of the template to use for creating this machine
        /// </summary>
        [JsonProperty("templateId")]
        public string TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// (optional) Assign a new public ip address on machine creation.Cannot be used with dynamicPublicIp.
        /// </summary>
        [JsonProperty("assignPublicIp")]
        public bool AssignPublicIp
        {
            get;
            set;
        }

        /// <summary>
        /// (optional) Assigns a new public ip address on machine start and releases it from the account on machine stop. Cannot be used with assignPublicIp.
        /// </summary>
        [JsonProperty("dynamicPublicIp")]
        public bool DynamicPublicIp
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) If creating on a specific network, specify its id
        /// </summary>
        [JsonProperty("networkId")]
        public string NetworkId
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) If creating the machine for a team, specify the team id
        /// </summary>
        [JsonProperty("teamId")]
        public string TeamId
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) If assigning to an existing user other than yourself, specify the user id (mutually exclusive with email, password, firstName, lastName)
        /// </summary>
        [JsonProperty("userId")]
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) If creating a new user for this machine, specify their email address (mutually exclusive with userId)
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) If creating a new user, specify their password (mutually exclusive with userId)
        /// </summary>
        [JsonProperty("password")]
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) If creating a new user, specify their first name (mutually exclusive with userId)
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) If creating a new user, specify their last name (mutually exclusive with userId)
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) Send a notification to this email address when complete
        /// </summary>
        [JsonProperty("notificationEmail")]
        public string NotificationEmail
        {
            get;
            set;
        }

        /// <summary>
        /// (Optional) The script id of a script to be run on startup. See the Script Guide for more info on using scripts.
        /// </summary>
        [JsonProperty("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
    }
}
