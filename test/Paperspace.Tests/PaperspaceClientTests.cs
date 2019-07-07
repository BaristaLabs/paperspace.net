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
            var connectionMock = new Mock<IConnection>();
            var logsConnectionMock = new Mock<IConnection>();
            var client = new PaperspaceClient(connectionMock.Object, logsConnectionMock.Object);
            Assert.IsNotNull(client);


            client = new PaperspaceClient("12345");
            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void Can_Access_Properties()
        {
            var connectionMock = new Mock<IConnection>();
            var logsConnectionMock = new Mock<IConnection>();
            var client = new PaperspaceClient(connectionMock.Object, logsConnectionMock.Object);
            Assert.ReferenceEquals(connectionMock, client.Connection);
            Assert.ReferenceEquals(logsConnectionMock, client.LogsConnection);
            Assert.IsNotNull(client.Jobs);
            Assert.IsNotNull(client.Machines);
            Assert.IsNotNull(client.Networks);
            Assert.IsNotNull(client.Scripts);
            Assert.IsNotNull(client.ResourceDelegations);
            Assert.IsNotNull(client.Templates);
            Assert.IsNotNull(client.Users);
        }
    }
}
