namespace Paperspace.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void Can_Serialize_CreateMachineRequest()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Machines_CreateMachine_Request.json");
            var createMachineRequest = JsonConvert.DeserializeObject<CreateMachineRequest>(json);
            JsonConvert.SerializeObject(createMachineRequest);
        }

        [TestMethod]
        public void Can_Serialize_Machine()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Machines_FullLifecycle.json");
            var machine = JsonConvert.DeserializeObject<Machine>(json);
            JsonConvert.SerializeObject(machine);
        }

        [TestMethod]
        public void Can_Serialize_Network()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Networks_ListNetworks.json");
            var networks = JsonConvert.DeserializeObject<IList<Network>>(json);
            JsonConvert.SerializeObject(networks[0]);
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
    }
}
