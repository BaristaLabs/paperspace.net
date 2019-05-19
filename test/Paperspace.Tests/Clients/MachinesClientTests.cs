namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class MachinesClientTests
    {
        [TestMethod]
        public async Task MachinesClient_List_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Machine>>(ApiUrls.MachinesList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/ListMachines.json");
                    return JsonConvert.DeserializeObject<IList<Machine>>(json);
                });

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.List();

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public async Task MachinesClient_Show_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesShow("pslwpsvsx"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/GetMachinePublic.json");
                    return JsonConvert.DeserializeObject<Machine>(json);
                });

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.Show("pslwpsvsx");

            Assert.AreEqual(result.Id, "pslwpsvsx");
        }

        [TestMethod]
        public async Task MachinesClient_Create_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post<Machine>(ApiUrls.MachinesCreate(), null, It.IsAny<CreateMachineRequest>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/CreateMachine.json");
                    return JsonConvert.DeserializeObject<Machine>(json);
                });

            connection.Setup(c => c.Get<IList<Template>>(ApiUrls.TemplatesList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/ListTemplates.json");
                    return JsonConvert.DeserializeObject<IList<Template>>(json);
                });

            var templateClient = new TemplatesClient(connection.Object);
            var templates = await templateClient.List();
            var template = templates.FirstOrDefault(t => t.OS == "Windows 10 (Server 2016) - Licensed");

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.Create(new CreateMachineRequest()
            {
                Region = Region.EastCoast_NY2,
                MachineType = MachineType.Air,
                Size = 50,
                BillingType = BillingType.Hourly,
                MachineName = "My Machine 1",
                TemplateId = template.Id,
            });

            Assert.AreEqual(result.Id, "pslwpsvsx");
        }
    }
}
