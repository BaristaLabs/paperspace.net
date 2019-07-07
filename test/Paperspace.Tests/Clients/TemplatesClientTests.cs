namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class TemplatesClientTests
    {
        [TestMethod]
        public async Task TemplatesClient_List_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Template>>(ApiUrls.TemplatesList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Templates_ListTemplates.json");
                    return JsonConvert.DeserializeObject<IList<Template>>(json);
                });

            var templateClient = new TemplatesClient(connection.Object);
            var result = await templateClient.List();

            Assert.AreEqual(14, result.Count);
        }

        [TestMethod]
        public async Task TemplatesClient_List_With_Filter()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Template>>(ApiUrls.TemplatesList(), It.IsAny<IDictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Templates_ListTemplates.json");
                    return JsonConvert.DeserializeObject<IList<Template>>(json);
                });

            var templateClient = new TemplatesClient(connection.Object);
            var result = await templateClient.List(new TemplateFilter()
            {
                Id = "1234",
                Label = "Windows 10",
                OS = "Windows 10 (Server 2019) - Licensed",
                Region = "",
                Name = "paperspace/tk9izniv",
                DTCreated = new System.DateTime(),
                UserId = "12345",
                TeamId = "12354"
            });

            Assert.AreEqual(14, result.Count);
        }
    }
}
