namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class NetworksClientTests
    {
        [TestMethod]
        public async Task NetworksClient_List_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Network>>(ApiUrls.NetworksList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Networks_ListNetworks.json");
                    return JsonConvert.DeserializeObject<IList<Network>>(json);
                });

            var networksClient = new NetworksClient(connection.Object);
            var result = await networksClient.List();

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public async Task NetworksClient_List_With_Filter()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Network>>(ApiUrls.NetworksList(), It.IsAny<IDictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Networks_ListNetworks.json");
                    return JsonConvert.DeserializeObject<IList<Network>>(json);
                });

            var networksClient = new NetworksClient(connection.Object);
            var result = await networksClient.List(new NetworkFilter()
            {
                Id = "1234",
                DTCreated = DateTime.Now,
                Name = "asdf",
                Netmask = "255.255.255.0",
                IP = "192.168.1.1",
                Region = Region.EastCoast_NY2,
                TeamId = "asdf"
            });

            Assert.AreEqual(result.Count, 1);
        }
    }
}
