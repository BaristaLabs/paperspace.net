namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [TestClass]
    public class ScriptsClientTests
    {
        [TestMethod]
        public async Task ScriptsClient_Create_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post<Script>(ApiUrls.ScriptsCreate(), null, It.IsAny<object>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Scripts_GetScript.json");
                    return JsonConvert.DeserializeObject<Script>(json);
                });

            var scriptsClient = new ScriptsClient(connection.Object);
            var result = await scriptsClient.Create(new CreateScriptRequest()
            {
                ScriptName = "foo",
                MachineId = "test12345",
                ScriptFile = "test123"
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ScriptsClient_Destroy_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post<Script>(ApiUrls.ScriptsDestroy("test1234"), null, It.IsAny<object>()))
                .ReturnsAsync(() =>
                {
                    return null;
                });

            var scriptsClient = new ScriptsClient(connection.Object);
            await scriptsClient.Destroy("test1234");
        }

        [TestMethod]
        public async Task ScriptsClient_List_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Script>>(ApiUrls.ScriptsList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Scripts_GetScripts.json");
                    return JsonConvert.DeserializeObject<IList<Script>>(json);
                });

            var scriptsClient = new ScriptsClient(connection.Object);
            var result = await scriptsClient.List();

            Assert.AreEqual(result.Count, 1);
        }

        [TestMethod]
        public async Task ScriptsClient_List_With_Filter()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Script>>(ApiUrls.ScriptsList(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Scripts_GetScripts.json");
                    return JsonConvert.DeserializeObject<IList<Script>>(json);
                });

            var scriptsClient = new ScriptsClient(connection.Object);
            var result = await scriptsClient.List(new ScriptFilter()
            {
                Id = "1234",
                Description = "asdf",
                DTCreated = DateTime.Now,
                IsEnabled = true,
                Name = "asdf",
                OwnerId = "12345asdf",
                OwnerType = ScriptOwnerType.Team,
                RunOnce = true
            });

            Assert.AreEqual(result.Count, 1);
        }


        [TestMethod]
        public async Task ScriptsClient_Show_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Script>(ApiUrls.ScriptsShow("test12345"), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Scripts_GetScript.json");
                    return JsonConvert.DeserializeObject<Script>(json);
                });

            var scriptsClient = new ScriptsClient(connection.Object);
            var script = await scriptsClient.Show("test12345");

            Assert.IsNotNull(script);
            Assert.IsNotNull(script.Machines);
            Assert.IsNotNull(script.Machines[0].MachineId);
        }

        [TestMethod]
        public async Task ScriptsClient_Text_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<string>(ApiUrls.ScriptsText("test12345"), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Scripts_GetScriptText.json");
                    return JsonConvert.DeserializeObject<string>(json);
                });

            var scriptsClient = new ScriptsClient(connection.Object);
            var script = await scriptsClient.Text("test12345");

            Assert.IsNotNull(script);
        }
    }
}
