namespace Paperspace.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void Can_Serialize_Artifact()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Jobs_ArtifactsList.json");
            var artifacts = JsonConvert.DeserializeObject<IList<Artifact>>(json);
            JsonConvert.SerializeObject(artifacts[0]);
        }

        [TestMethod]
        public void Can_Serialize_CreateJobRequest()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Jobs_Create_Request.json");
            var createJobRequest = JsonConvert.DeserializeObject<CreateJobRequest>(json);
            JsonConvert.SerializeObject(createJobRequest);
        }

        [TestMethod]
        public void Can_Serialize_Job()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Jobs_Show.json");
            var job = JsonConvert.DeserializeObject<Job>(json);
            JsonConvert.SerializeObject(job);
        }

        [TestMethod]
        public void Can_Serialize_JobMachine()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Jobs_MachineTypes.json");
            var machineTypes = JsonConvert.DeserializeObject<IList<JobMachine>>(json);
            JsonConvert.SerializeObject(machineTypes[0]);
        }

        [TestMethod]
        public void Can_Serialize_CreateMachineRequest()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Machines_CreateMachine_Request.json");
            var createMachineRequest = JsonConvert.DeserializeObject<CreateMachineRequest>(json);
            JsonConvert.SerializeObject(createMachineRequest);
        }

        [TestMethod]
        public void Can_Serialize_UpdateMachineRequest()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Machines_UpdateMachine_Request.json");
            var updateMachineRequest = JsonConvert.DeserializeObject<UpdateMachineRequest>(json);
            JsonConvert.SerializeObject(updateMachineRequest);
        }

        [TestMethod]
        public void Can_Serialize_Machine()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Machines_FullLifecycle.json");
            var machine = JsonConvert.DeserializeObject<Machine>(json);
            JsonConvert.SerializeObject(machine);
        }

        [TestMethod]
        public void Can_Serialize_Machine_Availability()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Machines_Availability.json");
            var machineAvailability = JsonConvert.DeserializeObject<MachineAvailability>(json);
            JsonConvert.SerializeObject(machineAvailability);
        }

        [TestMethod]
        public void Can_Serialize_Machine_Utilization()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Machines_Utilization.json");
            var machineUtilization = JsonConvert.DeserializeObject<MachineUtilization>(json);
            JsonConvert.SerializeObject(machineUtilization);
        }

        [TestMethod]
        public void Can_Serialize_Network()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Networks_ListNetworks.json");
            var networks = JsonConvert.DeserializeObject<IList<Network>>(json);
            JsonConvert.SerializeObject(networks[0]);
        }

        [TestMethod]
        public void Can_Serialize_CreateResourceDelegationRequest()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/ResourceDelegations_CreateDelegation_Request.json");
            var createRDRequest = JsonConvert.DeserializeObject<CreateResourceDelegationRequest>(json);
            JsonConvert.SerializeObject(createRDRequest);
        }

        [TestMethod]
        public void Can_Serialize_CreateResourceDelegation()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/ResourceDelegations_CreateDelegation.json");
            var resourceDelegations = JsonConvert.DeserializeObject<IList<ResourceDelegation>>(json);
            JsonConvert.SerializeObject(resourceDelegations);
        }

        [TestMethod]
        public void Can_Serialize_CreateScriptRequest()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Scripts_CreateScript_Request.json");
            var createScriptRequest = JsonConvert.DeserializeObject<CreateScriptRequest>(json);
            JsonConvert.SerializeObject(createScriptRequest);
        }

        [TestMethod]
        public void Can_Serialize_Script()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Scripts_GetScript.json");
            var script = JsonConvert.DeserializeObject<Script>(json);
            JsonConvert.SerializeObject(script);
        }

        [TestMethod]
        public void Can_Serialize_Template()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Templates_TeamTemplate.json");
            var template = JsonConvert.DeserializeObject<Template>(json);
            JsonConvert.SerializeObject(template);
        }

        [TestMethod]
        public void Can_Serialize_User()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Users_GetUsers.json");
            var users = JsonConvert.DeserializeObject<IList<User>>(json);
            JsonConvert.SerializeObject(users[0]);
        }
    }
}
