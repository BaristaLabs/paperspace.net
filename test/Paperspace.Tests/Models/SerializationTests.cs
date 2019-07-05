namespace Paperspace.Tests.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

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
        public void Can_Serialize_Template()
        {
            var json = System.IO.File.ReadAllText("./Fixtures/Templates_TeamTemplate.json");
            var template = JsonConvert.DeserializeObject<Template>(json);
            JsonConvert.SerializeObject(template);
        }
    }
}
