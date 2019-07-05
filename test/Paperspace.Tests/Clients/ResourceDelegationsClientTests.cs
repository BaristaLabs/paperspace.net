namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class ResourceDelegationsClientTests
    {
        [TestMethod]
        public async Task ResourceDelegations_Create_Delegation_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post<IList<ResourceDelegation>>(ApiUrls.ResourceDelegationsCreate(), null, It.IsAny<object>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/ResourceDelegations_CreateDelegation.json");
                    return JsonConvert.DeserializeObject<IList<ResourceDelegation>>(json);
                });

            var rdClient = new ResourceDelegationsClient(connection.Object);
            var result = await rdClient.Create(new CreateResourceDelegationRequest()
            {
                Machine = new CreateResourceDelegationMachine()
                {
                    Ids = new List<string>() { "m123abc", "m456def" }
                }
            });

            Assert.AreEqual(result.Count, 1);
        }
    }
}
