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
                    var json = Properties.Resources.ListTemplates;
                    return JsonConvert.DeserializeObject<IList<Template>>(json);
                });

            var templateClient = new TemplatesClient(connection.Object);
            var result = await templateClient.List();

            Assert.AreEqual(result.Count, 14);
        }
    }
}
