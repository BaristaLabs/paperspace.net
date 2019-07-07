namespace Paperspace
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMachinesClient
    {
        /// <summary>
        /// Get machine availability for the given region and machine type. Note: availability is only provided for the dedicated GPU machine types. Also, not all machine types are available in all regions.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<MachineAvailability> Availability(Region region, MachineType type);

        /// <summary>
        /// Create a new Paperspace virtual machine.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Machine> Create(CreateMachineRequest request);

        /// <summary>
        /// Destroy the machine with the given id.
        /// </summary>
        /// <remarks>
        /// When this action is performed, the machine is immediately shut down and marked for deletion from the datacenter. Any snapshots that were derived from the machine are also deleted. Access to the machine is terminated immediately and billing for the machine is prorated to the hour. This action can only be performed by the user who owns the machine, or in the case of a team, the team administrator.
        /// </remarks>
        /// <param name="machineId">The id of the machine to destroy</param>
        /// <param name="releasePublicIp">Releases any assigned public ip address for the machine; defaults to false</param>
        Task Destroy(string machineId, bool releasePublicIp = false);

        /// <summary>
        /// List information about all machines available to either the current authenticated user or the team, if the user belongs to a team. The list method takes an optional first argument to limit the returned machine objects.
        /// </summary>
        /// <returns>A collection of Machines</returns>
        Task<IList<Machine>> List(MachineFilter filter = null);

        /// <summary>
        /// Restart an individual machine. If the machine is already restarting, this action will request the machine be restarted again. This action can only be performed by the user who owns the machine.
        /// </summary>
        /// <param name="machineId">Id of the machine to restart</param>
        /// <returns></returns>
        Task Restart(string machineId);

        /// <summary>
        /// Show machine information for the machine with the given id.
        /// </summary>
        /// <returns></returns>
        Task<Machine> Show(string machineId);

        /// <summary>
        /// Start up an individual machine. If the machine is already started, this action is a no-op. If the machine is off, it will be booted up. This action can only be performed by the user who owns the machine.
        /// </summary>
        /// <param name="machineId">Id of the machine to start</param>
        /// <returns></returns>
        Task Start(string machineId);

        /// <summary>
        /// Stop an individual machine. If the machine is already stopped or has been shut down, this action is a no-op. If the machine is running, it will be stopped and any users logged in will be immediately kicked out. This action can only be performed by the user who owns the machine.
        /// </summary>
        /// <param name="machineId">Id of the machine to stop</param>
        /// <returns></returns>
        Task Stop(string machineId);

        /// <summary>
        /// Update attributes of a machine.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task Update(string machineId, UpdateMachineRequest request);

        /// <summary>
        /// Get machine utilization data for the machine with the given id. Machine upgrades are not represented in utilization data.
        /// </summary>
        /// <param name="machineId">Id of the machine to get utilization data for</param>
        /// <param name="billingMonth">Billing period to query in YYYY-MM format</param>
        /// <returns></returns>
        Task<MachineUtilization> Utilization(string machineId, string billingMonth);

        /// <summary>
        /// Wait for the machine with the given id to enter a certain machine state.
        /// </summary>
        /// <remarks>
        /// This action polls the server and returns only when we detect that the machine has transitioned into the given state. States available to check for are:
        ///   off
        ///   serviceready - services are running on the machine but the Paperspace agent is not yet available
        ///   ready - services are running on machine and the Paperspace agent is ready to stream or accept logins
        /// </remarks>
        /// <param name="machineId">Id of the machine to wait for</param>
        /// <param name="state">Name of the state to wait for, either 'off', 'serviceready', 'ready'</param>
        /// <param name="pollIntervalMS"></param>
        /// <param name="maxWaitMS"></param>
        /// <param name="pollResultCallback">Optional action that, if supplied, is called on each poll result.</param>
        /// <returns></returns>
        Task<Machine> Waitfor(string machineId, MachineState state, int pollIntervalMS = 5000, int maxWaitMS = 0, Action<Machine> pollResultCallback = null);
    }
}
