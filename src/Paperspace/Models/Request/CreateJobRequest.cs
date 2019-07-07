namespace Paperspace
{
    using Newtonsoft.Json;

    /// <summary>
    /// Job creation parameters
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CreateJobRequest
    {
        /// <summary>
        /// A reference to a docker image in a public or private docker registry, or a container name provided by Paperspace.
        /// </summary>
        /// <remarks>
        /// Docker image repository references must be in lowercase and may include a tag and a hostname prefix followed by a slash; if ommitted the hostname defaults to that of the public Docker Hub registry. An example docker image reference: 'docker.io/mynamespace/myimage:mytag'. A container name may be mixed case. (Designated container names are currently only provided as part of various Gradient tutorials and samples.)
        /// </remarks>
        [JsonProperty("container")]
        public string Container
        {
            get;
            set;
        }

        /// <summary>
        /// An optional cluster name of a cluster to run the job on. Only one of cluster or clusterId may be specified.
        /// </summary>
        [JsonProperty("cluster")]
        public string Cluster
        {
            get;
            set;
        }

        /// <summary>
        /// An optional cluster id of a cluster to run the job on. Only one of cluster or clusterId may be specified.
        /// </summary>
        [JsonProperty("clusterId")]
        public string ClusterId
        {
            get;
            set;
        }

        /// <summary>
        /// An optional machine type to run the job on: either 'GPU+', 'P4000', 'P5000', 'P6000', 'V100', 'K80', 'P100', 'TPU', or 'GradientNode'.
        /// </summary>
        /// <remarks>
        /// Defaults to 'K80'.
        /// 
        /// Note: the 'K80', 'P100', and 'TPU' machineTypes run on Google Cloud Platform (GCP). The other machineTypes run on the Paperspace Cloud. Google Cloud platform and Paperspace Cloud have distict Job Storage spaces; Job storage is not currently shared between these two cloud environments.
        /// </remarks>
        [JsonProperty("machineType")]
        public MachineType MachineType
        {
            get;
            set;
        }

        /// <summary>
        /// An optional name or description for this job. If ommitted, the job name defaults to 'job N' where N represents the Nth job instance for the given project.
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the project for this job.
        /// </summary>
        [JsonProperty("project")]
        public string Project
        {
            get;
            set;
        }

        /// <summary>
        /// The poject id of an existing project for this job. Note: if projectId is specified, the project parameter cannot be specified.
        /// </summary>
        [JsonProperty("projectId")]
        public string ProjectId
        {
            get;
            set;
        }

        /// <summary>
        /// An optional command to run within the workspace or container.
        /// </summary>
        [JsonProperty("command")]
        public string Command
        {
            get;
            set;
        }

        /// <summary>
        /// Link to a git repository to upload and merge with the container.
        /// </summary>
        /// <remarks>
        /// If the workspace is 'none', no workspace is merged and the container is run as-is. To download a git repository provide an https repository link and optionally prefix it with 'git+', e.g. 'https://github.com/MyProjects/MyRepo.git'. If the 'git+' prefix is not specified, it is added at the time of download to the job runner machine. S3 links are also supported using the schema 's3://bucketname/objectname'.
        /// </remarks>
        [JsonProperty("workspace")]
        public string Workspace
        {
            get;
            set;
        }

        /// <summary>
        /// An optional reference to git commit hash if local workspace is a git repository. Found at runtime.
        /// </summary>
        [JsonProperty("codeCommit")]
        public string CodeCommit
        {
            get;
            set;
        }

        /// <summary>
        /// An optional reference to a dataset to be merged with the container.
        /// </summary>
        [JsonProperty("dataset")]
        public string Dataset
        {
            get;
            set;
        }

        /// <summary>
        /// An optional username for accessing an image hosted on a private container registry. Note: you must specify this option every time a private image is specified for the container.
        /// </summary>
        [JsonProperty("registryUsername")]
        public string RegistryUsername
        {
            get;
            set;
        }

        /// <summary>
        /// An optional password for accessing an image hosted on a private container registry. Note: you must specify this option every time a private image is specified for the container.
        /// </summary>
        [JsonProperty("registryPassword")]
        public string RegistryPassword
        {
            get;
            set;
        }

        /// <summary>
        /// An optional username for accessing a private git repository. Note: you must specify this option every time a private git repository is specified for the workspace.
        /// </summary>
        [JsonProperty("workspaceUsername")]
        public string WorkspaceUsername
        {
            get;
            set;
        }

        /// <summary>
        /// An optional password for accessing a private git repository. We recommned using an OAuth token (GitHub instructions can be found here). Note: you must specify this option every time a private git repository is specified for the workspace.
        /// </summary>
        [JsonProperty("workspacePassword")]
        public string WorkspacePassword
        {
            get;
            set;
        }

        /// <summary>
        /// An optional list of port mappings to open on the job cluster machine while the job is running.
        /// </summary>
        /// <remarks>
        /// The port mappings are specified as 'XXXX:YYYY' where XXXX is an external port number and YYYY is an internal port number. Mulitple port mappings can be provided as a comma separated list. Port numbers must be greater than 1023. Note: only /tcp protocol usage is supported.
        /// </remarks>
        [JsonProperty("ports")]
        public string Ports
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; shared memory size for the job container in megabytes (1 megabyte = 1024 * 1024 bytes). Cannot exceed total memory size for the given machine type.
        /// </summary>
        [JsonProperty("sharedMemMBytes")]
        public long SharedMemMBytes
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; a JSON expression describing the node attributes for a compatible GradientNode machine to run this job. See the Gradient-Node documentation for more info.
        /// </summary>
        [JsonProperty("nodeAttrs")]
        public string NodeAttrs
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; if true job will be sent to a preemptible VM only. Defaults to false.
        /// </summary>
        [JsonProperty("isPreemptible")]
        public bool IsPreemptible
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; if true the job will use the Dockerfile provided in the workspace to build a docker image and optionally run the resulting image as a container
        /// </summary>
        [JsonProperty("useDockerfile")]
        public bool UseDockerfile
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; if this option is selected the job will build the Dockerfile and push to a selected remote registry only, without actually running the container. A registry target must be provided.
        /// </summary>
        [JsonProperty("buildOnly")]
        public bool BuildOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; a location to push docker images built from a Dockerfile. Must be included with a buildOnly flag. If useDockerfile is true and registryTarget is false the built container will be run but not pushed to a remote registry.
        /// </summary>
        [JsonProperty("registryTarget")]
        public string RegistryTarget
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; username credential for remote registry target
        /// </summary>
        [JsonProperty("registryTargetUsername")]
        public string RegistryTargetUsername
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; password credential for remote registry target
        /// </summary>
        [JsonProperty("registryTargetPassword")]
        public string RegistryTargetPassword
        {
            get;
            set;
        }

        /// <summary>
        /// Optional; relative location of Dockefile in the workspace. Defaults to the top level "./Dockerfile" if not specified.
        /// </summary>
        [JsonProperty("relDockerfilePath")]
        public string RelDockerfilePath
        {
            get;
            set;
        }
    }
}
