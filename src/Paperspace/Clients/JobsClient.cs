namespace Paperspace
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class JobsClient : ApiClient, IJobsClient
    {
        /// <summary>
        /// Instantiates a new Paperspace Jobs API client.
        /// </summary>
        /// <param name="connection">A connection</param>
        public JobsClient(IConnection connection, IConnection logsConnection)
            : base(connection)
        {
            Ensure.ArgumentNotNull(logsConnection, nameof(logsConnection));

            LogsConnection = logsConnection;
        }

        /// <summary>
        /// Returns the underlying <see cref="IConnection"/> used by the <see cref="ApiClient"/> to access logs. This is useful
        /// for requests that need to access the HTTP response and not just the response model.
        /// </summary>
        protected IConnection LogsConnection { get; }

        public Task ArtifactsDestroy(string jobId, DestroyArtifactsParameters parameters = null)
        {
            if (parameters == null)
            {
                return Connection.Post(ApiUrls.JobsArtifactsDestroy(jobId), null);
            }
            
            var query = parameters.ToQueryStringDictionary();
            return Connection.Post(ApiUrls.JobsArtifactsDestroy(jobId), query);
        }

        public Task<Artifact> ArtifactsGet(string jobId, GetArtifactsParameters parameters = null)
        {
            if (parameters == null)
            {
                return Connection.Get<Artifact>(ApiUrls.JobsArtifactsGet(jobId), null);
            }

            var query = parameters.ToQueryStringDictionary();
            return Connection.Get<Artifact>(ApiUrls.JobsArtifactsGet(jobId), query);
        }

        public Task<IList<Artifact>> ArtifactsList(string jobId, ListArtifactsParameters parameters = null)
        {
            if (parameters == null)
            {
                return Connection.Get<IList<Artifact>>(ApiUrls.JobsArtifactsList(jobId), null);
            }

            var query = parameters.ToQueryStringDictionary();
            return Connection.Get<IList<Artifact>>(ApiUrls.JobsArtifactsList(jobId), query);
        }

        public Task<Job> Clone(string jobId)
        {
            return Connection.Post<Job>(ApiUrls.JobsClone(jobId));
        }

        public Task<Job> Create(CreateJobRequest request)
        {
            return Connection.Post<Job>(ApiUrls.JobsCreate(), null, request);
        }

        public Task Destroy(string jobId)
        {
            return Connection.Post(ApiUrls.JobsDestroy(jobId));
        }

        public Task<IList<Job>> List(JobFilter filter = null)
        {
            if (filter == null)
            {
                return Connection.Get<IList<Job>>(ApiUrls.JobsList());
            }

            var parameters = filter.ToQueryStringDictionary();
            return Connection.Get<IList<Job>>(ApiUrls.JobsList(), parameters);
        }

        public Task<IList<JobLog>> Logs(string jobId)
        {
            return LogsConnection.Get<IList<JobLog>>(ApiUrls.JobsLogs(jobId));
        }

        public Task<IList<JobMachine>> MachineTypes(MachineTypeFilter filter = null)
        {
            if (filter == null)
            {
                return Connection.Get<IList<JobMachine>>(ApiUrls.JobsMachineTypes());
            }

            var parameters = filter.ToQueryStringDictionary();
            return Connection.Get<IList<JobMachine>>(ApiUrls.JobsMachineTypes(), parameters);
        }

        public Task<Job> Show(string jobId)
        {
            return Connection.Get<Job>(ApiUrls.JobsShow(jobId));
        }

        public Task Stop(string jobId)
        {
            return Connection.Post(ApiUrls.JobsStop(jobId));
        }

        public async Task<Job> Waitfor(string jobId, JobState state, int pollIntervalMS = 5000, int maxWaitMS = 0, Action<Job> pollResultCallback = null)
        {
            JobState targetState;
            switch (state)
            {
                case JobState.Pending:
                case JobState.Running:
                case JobState.Stopped:
                case JobState.Preempted:
                case JobState.Failed:
                case JobState.Error:
                    targetState = state;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state must be either Pending, Running, Stopped, Preempted, Failed, or Error");
            }

            var cts = new CancellationTokenSource();
            if (maxWaitMS > 0)
            {
                cts.CancelAfter(maxWaitMS);
            }

            try
            {
                Job jobInfo = null;
                do
                {
                    if (jobInfo != null)
                    {
                        await Task.Delay(pollIntervalMS, cts.Token);
                    }

                    jobInfo = await Show(jobId);

                    if (pollResultCallback != null)
                    {
                        pollResultCallback.Invoke(jobInfo);
                    }
                } while (jobInfo.State != targetState);

                return jobInfo;
            }
            catch (OperationCanceledException)
            {
                throw new TimeoutException($"The maximum time to wait has been exceeded ({maxWaitMS}).");
            }
        }
    }
}
