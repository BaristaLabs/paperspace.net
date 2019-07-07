namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class UsersClientTests
    {
        [TestMethod]
        public async Task UsersClient_List_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<User>>(ApiUrls.UsersList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Users_GetUsers.json");
                    return JsonConvert.DeserializeObject<IList<User>>(json);
                });

            var usersClient = new UsersClient(connection.Object);
            var result = await usersClient.List();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task UsersClient_List_With_Filter()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<User>>(ApiUrls.UsersList(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Users_GetUsers.json");
                    return JsonConvert.DeserializeObject<IList<User>>(json);
                });

            var usersClient = new UsersClient(connection.Object);
            var result = await usersClient.List(new UserFilter()
            {
                Id = "1234",
                Email = "asdf@asdf.com",
                FirstName = "asdf",
                LastName = "asdf",
                DTCreated = DateTime.Now,
                TeamId = "asdf"
            });

            Assert.AreEqual(2, result.Count);
        }
    }
}
