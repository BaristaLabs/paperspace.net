namespace Paperspace
{
    using System;

    public static class ApiUrls
    {
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

            // https://api.paperspace.io/machines/stop?access_token=HdckEkqgZLVkBURdYJgbP4XXe8d0cdgqQTmkTuvD03DdakLGMmGAcdobFlFB5ngP
            return $"/machines/{machineId}/stop".FormatUri();
            
        }

        public static Uri NetworksList()
        {
            return $"/networks/getNetworks".FormatUri();
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
            return $"templates/getTemplates".FormatUri();
        }
    }
}
