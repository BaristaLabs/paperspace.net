namespace Paperspace
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class MachinesClient : ApiClient, IMachinesClient
    {
        /// <summary>
        /// Instantiates a new Paperspace Machines API client.
        /// </summary>
        /// <param name="connection">A connection</param>
        public MachinesClient(IConnection connection)
            : base(connection)
        {
        }

        public Task<Machine> Create(CreateMachineRequest request)
        {
            return Connection.Post<Machine>(ApiUrls.MachinesCreate(), null, request);
        }

        public Task Destroy(string machineId, bool releasePublicIp = false)
        {
            return Connection.Post<Machine>(ApiUrls.MachinesDestroy(machineId, releasePublicIp));
        }

        public Task<IList<Machine>> List()
        {
            return Connection.Get<IList<Machine>>(ApiUrls.MachinesList());
        }

        public Task Restart(string machineId)
        {
            return Connection.Post(ApiUrls.MachinesRestart(machineId));
        }

        public Task<Machine> Show(string machineId)
        {
            return Connection.Get<Machine>(ApiUrls.MachinesShow(machineId));
        }

        public Task Start(string machineId)
        {
            return Connection.Post(ApiUrls.MachinesStart(machineId));
        }

        public Task Stop(string machineId)
        {
            return Connection.Post(ApiUrls.MachinesStop(machineId));
        }

        public async Task<Machine> Waitfor(string machineId, MachineState state, int pollIntervalMS = 5000, int maxWaitMS = 0, Action<Machine> pollResultCallback = null)
        {
            MachineState targetState;
            switch (state)
            {
                case MachineState.Ready:
                case MachineState.ServiceReady:
                case MachineState.Off:
                    targetState = state;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state must be either off, serviceready, or ready");
            }

            var sw = new Stopwatch();
            sw.Start();

            Machine machineInfo = null;
            do
            {
                if (machineInfo != null)
                {
                    await Task.Delay(pollIntervalMS);
                }

                machineInfo = await Show(machineId);

                pollResultCallback?.Invoke(machineInfo);

            } while (machineInfo.State != targetState || maxWaitMS > 0 ? sw.ElapsedMilliseconds >= maxWaitMS : false);

            sw.Stop();

            return machineInfo;
        }
    }
}
