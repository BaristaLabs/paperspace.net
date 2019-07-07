namespace Paperspace
{
    using System;

    public static class ApiUrls
    {

        public static Uri JobsArtifactsDestroy(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/{jobId}/artifactsDestroy".FormatUri();
        }

        public static Uri JobsArtifactsGet(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/artifactsGet?jobId={jobId}".FormatUri();
        }

        public static Uri JobsArtifactsList(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/artifactsList?jobId={jobId}".FormatUri();
        }

        public static Uri JobsClone(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/{jobId}/clone".FormatUri();
        }

        public static Uri JobsCreate()
        {
            return $"/jobs/createJob".FormatUri();
        }

        public static Uri JobsDestroy(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/{jobId}/destroy".FormatUri();
        }

        public static Uri JobsList()
        {
            return $"/jobs/getJobs".FormatUri();
        }

        public static Uri JobsLogs(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/logs?jobId={jobId}".FormatUri();
        }

        public static Uri JobsMachineTypes()
        {
            return $"/jobs/getClusterAvailableMachineTypes".FormatUri();
        }

        public static Uri JobsShow(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/getJob?jobId={jobId}".FormatUri();
        }

        public static Uri JobsStop(string jobId)
        {
            Ensure.ArgumentNotNullOrEmptyString(jobId, nameof(jobId));

            return $"/jobs/{jobId}/stop".FormatUri();
        }

        public static Uri MachinesAvailability()
        {
            return $"/machines/getAvailability".FormatUri();
        }

        public static Uri MachinesCreate()
        {
            return $"/machines/createSingleMachinePublic".FormatUri();
        }

        public static Uri MachinesDestroy(string machineId, bool releasePublicIp = false)
        {
            Ensure.ArgumentNotNullOrEmptyString(machineId, nameof(machineId));

            return $"/machines/{machineId}/destroyMachine?releasePublicIp={releasePublicIp}".FormatUri();
        }

        public static Uri MachinesList()
        {
            return $"/machines/getMachines".FormatUri();
        }

        public static Uri MachinesRestart(string machineId)
        {
            Ensure.ArgumentNotNullOrEmptyString(machineId, nameof(machineId));

            return $"/machines/{machineId}/restart".FormatUri();
        }

        public static Uri MachinesShow(string machineId)
        {
            Ensure.ArgumentNotNullOrEmptyString(machineId, nameof(machineId));

            return $"/machines/getMachinePublic?machineId={machineId}".FormatUri();
        }

        public static Uri MachinesStart(string machineId)
        {
            Ensure.ArgumentNotNullOrEmptyString(machineId, nameof(machineId));

            return $"/machines/{machineId}/start".FormatUri();
        }

        public static Uri MachinesStop(string machineId)
        {
            Ensure.ArgumentNotNullOrEmptyString(machineId, nameof(machineId));

            return $"/machines/{machineId}/stop".FormatUri();
        }

        public static Uri MachinesUpdate(string machineId)
        {
            Ensure.ArgumentNotNullOrEmptyString(machineId, nameof(machineId));

            return $"/machines/{machineId}/updateMachinePublic".FormatUri();
        }

        public static Uri MachinesUtilization()
        {
            return $"/machines/getUtilization".FormatUri();
        }

        public static Uri NetworksList()
        {
            return $"/networks/getNetworks".FormatUri();
        }

        public static Uri ResourceDelegationsCreate()
        {
            return $"/resourceDelegations/create".FormatUri();
        }

        public static Uri ScriptsCreate()
        {
            return $"/scripts/createScript".FormatUri();
        }

        public static Uri ScriptsDestroy(string scriptId)
        {
            Ensure.ArgumentNotNullOrEmptyString(scriptId, nameof(scriptId));

            return $"/scripts/{scriptId}/destroy".FormatUri();
        }

        public static Uri ScriptsList()
        {
            return $"/scripts/getScripts".FormatUri();
        }

        public static Uri ScriptsShow(string scriptId)
        {
            Ensure.ArgumentNotNullOrEmptyString(scriptId, nameof(scriptId));

            return $"/scripts/getScript?scriptId={scriptId}".FormatUri();
        }

        public static Uri ScriptsText(string scriptId)
        {
            Ensure.ArgumentNotNullOrEmptyString(scriptId, nameof(scriptId));

            return $"/scripts/getScriptText?scriptId={scriptId}".FormatUri();
        }

        public static Uri TemplatesList()
        {
            return $"/templates/getTemplates".FormatUri();
        }

        public static Uri UsersList()
        {
            return $"/users/getUsers".FormatUri();
        }
    }
}
