namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
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
    }
}
