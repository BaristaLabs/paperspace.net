namespace Paperspace
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJobsClient
    {
        /// <summary>
        /// Destroy artifact files of the job with the given id. The name of a particular file, or directory can be specified, and can include a wildcard character at the end, e.g., "myfiles*". If no specifc file or directory is specified all artifact files will be destroyed.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        Task ArtifactsDestroy(string jobId, DestroyArtifactsParameters parameters = null);

        /// <summary>
        /// Get the artifacts files for the job with the given id. The name of a particular file, or directory can be specified, and can include a wildcard character at the end, e.g., "myfiles"*. If no specifc file or directory is specified all artifact files will be retrieved.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<Artifact> ArtifactsGet(string jobId, GetArtifactsParameters parameters = null);

        /// <summary>
        /// List job artifact files for the specified job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<IList<Artifact>> ArtifactsList(string jobId, ListArtifactsParameters parameters = null);

        /// <summary>
        /// Clone an exiting job and queue the cloned copy to run.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<Job> Clone(string jobId);

        /// <summary>
        /// Create a new Paperspace job, and tail its log output if run at the command line. To disable the tailing behavior specify '--tail false'. Note: if a project is not defined for the current working directory, and you are running in command line mode, a project configuration settings file will be created. Use '--init false' or specify '--project [projectname]' to override this behavior.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Job> Create(CreateJobRequest request);

        /// <summary>
        /// Destroy the job with the given id. When this action is performed, the job is immediately stopped and marked for deletion. Access to the job is terminated immediately and billing for the job is prorated to the minute.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task Destroy(string jobId);

        /// <summary>
        /// List information about all jobs available to either the current authenticated user or the team, if the user belongs to a team. The list method takes an optional first argument to limit the returned job objects.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IList<Job>> List(JobFilter filter = null);

        /// <summary>
        /// Stream the logs for the job with the given id, while the job is running or after it has stopped.
        /// </summary>
        Task<IList<JobLog>> Logs(string jobId);

        /// <summary>
        /// Return a list of available cluster machine types. If the isBusy property is true then all machines of the specified type and cluster are currently running jobs. The machineTypes method takes an optional first argument to limit the returned cluster machine type objects.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IList<JobMachine>> MachineTypes(MachineTypeFilter filter = null);

        /// <summary>
        /// Show job information for the job with the given id.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<Job> Show(string jobId);

        /// <summary>
        /// Stop an individual job. If the job is already stopped, this action is a no-op. If the job is running, it will be stopped.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task Stop(string jobId);

        /// <summary>
        /// Wait for the job with the given id to enter a certain job state.
        /// </summary>
        /// <remarks>
        /// This action polls the server and returns only when we detect that the job has transitioned into the given state, or to the 'Error' state. States available to query for are:
        /// - Pending - the job has not started setting up on a machine yet
        /// - Running - the job is setting up on a machine, running, or tearing down
        /// - Stopped - the job finished with a job command exit code of 0
        /// - Error - the job was unable to setup or run to normal completion
        /// - Failed - the job finished but the job command exit code was non-zero
        /// - Cancelled - the job was manual stopped before completion
        /// </remarks>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<Job> Waitfor(string jobId, JobState state, int pollIntervalMS = 5000, int maxWaitMS = 0, Action<Job> pollResultCallback = null);
    }
}
