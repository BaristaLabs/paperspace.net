namespace Paperspace.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PaperspaceClientTests
    {
        [TestMethod]
        public void Can_Construct_Paperspace_Client()
        {
            var connection = new Mock<IConnection>();
            var client = new PaperspaceClient(connection.Object);
            Assert.IsNotNull(client);


            client = new PaperspaceClient("12345");
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void Can_Access_Properties()
        {
            var connection = new Mock<IConnection>();
            var client = new PaperspaceClient(connection.Object);
            Assert.ReferenceEquals(connection, client.Connection);
            Assert.IsNotNull(client.Machines);
            Assert.IsNotNull(client.Networks);
            Assert.IsNotNull(client.Scripts);
            Assert.IsNotNull(client.Templates);

            // Not Implemented Yet:
            Assert.IsNull(client.Jobs);
            Assert.IsNull(client.Project);
            Assert.IsNull(client.ResourceDelegations);
            Assert.IsNull(client.Users);
        }
    }
}
