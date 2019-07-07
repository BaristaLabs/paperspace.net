namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    [TestClass]
    public class MachinesClientTests
    {

        [TestMethod]
        public async Task MachinesClient_Availability_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<MachineAvailability>(ApiUrls.MachinesAvailability(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_Availability.json");
                    return JsonConvert.DeserializeObject<MachineAvailability>(json);
                });

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.Availability(Region.EastCoast_NY2, MachineType.Air);

            Assert.AreEqual(true, result.Available);
        }

        [TestMethod]
        public async Task MachinesClient_List_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Machine>>(ApiUrls.MachinesList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_ListMachines.json");
                    return JsonConvert.DeserializeObject<IList<Machine>>(json);
                });

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.List();

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public async Task MachinesClient_Show_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesShow("pslwpsvsx"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_GetMachinePublic.json");
                    return JsonConvert.DeserializeObject<Machine>(json);
                });

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.Show("pslwpsvsx");

            Assert.AreEqual("pslwpsvsx", result.Id);
        }

        [TestMethod]
        public async Task MachinesClient_Show_FullLifecycle()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesShow("psxs9sp8u"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_FullLifecycle.json");
                    return JsonConvert.DeserializeObject<Machine>(json);
                });

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.Show("psxs9sp8u");

            Assert.AreEqual("psxs9sp8u", result.Id);
            Assert.AreEqual(7, result.Events.Count);
        }

        [TestMethod]
        public async Task MachinesClient_Create_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post<Machine>(ApiUrls.MachinesCreate(), null, It.IsAny<CreateMachineRequest>(), null, null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_CreateMachine.json");
                    return JsonConvert.DeserializeObject<Machine>(json);
                });

            connection.Setup(c => c.Get<IList<Template>>(ApiUrls.TemplatesList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Templates_ListTemplates.json");
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

        [TestMethod]
        public async Task MachinesClient_Start_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesStart("pslwpsvsx"), null));

            var machinesClient = new MachinesClient(connection.Object);
            await machinesClient.Start("pslwpsvsx");
        }

        [TestMethod]
        public async Task MachinesClient_Stop_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesStop("pslwpsvsx"), null));

            var machinesClient = new MachinesClient(connection.Object);
            await machinesClient.Stop("pslwpsvsx");
        }

        [TestMethod]
        public async Task MachinesClient_Restart_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesRestart("pslwpsvsx"), null));

            var machinesClient = new MachinesClient(connection.Object);
            await machinesClient.Restart("pslwpsvsx");
        }

        [TestMethod]
        public async Task MachinesClient_Destroy_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesDestroy("pslwpsvsx", false), null));

            var machinesClient = new MachinesClient(connection.Object);
            await machinesClient.Destroy("pslwpsvsx", false);
        }

        [TestMethod]
        public async Task MachinesClient_Update_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post(ApiUrls.MachinesUpdate("psxs9sp8u"), It.IsAny<Dictionary<string, string>>(), It.IsAny<object>()))
                .Returns(() =>
                {
                    return Task.CompletedTask;
                });

            var machinesClient = new MachinesClient(connection.Object);
            await machinesClient.Update("psxs9sp8u", new UpdateMachineRequest()
            {
                MachineName = "foo, bar"
            });

            connection.Verify(
                c => c.Post(ApiUrls.MachinesUpdate("psxs9sp8u"), It.IsAny<Dictionary<string, string>>(), It.IsAny<object>()),
                Times.Exactly(1)
                );
        }

        [TestMethod]
        public async Task MachinesClient_Utilization_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<MachineUtilization>(ApiUrls.MachinesUtilization(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_Utilization.json");
                    return JsonConvert.DeserializeObject<MachineUtilization>(json);
                });

            var machinesClient = new MachinesClient(connection.Object);
            var result = await machinesClient.Utilization("psxs9sp8u", "2019-02");

            Assert.AreEqual("ps123abc", result.MachineId);
            Assert.IsNotNull(result.Utilization);
            Assert.IsNotNull(result.StorageUtilization);
        }

        [TestMethod]
        public async Task MachinesClient_WaitFor_HappyPath()
        {
            var i = 0;
            var j = 0;
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesShow("psxs9sp8u"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_GetMachine_Start_InProgress.json");
                    var result = JsonConvert.DeserializeObject<Machine>(json);

                    if (i >= 0 && i < 4)
                    {
                        result.State = MachineState.Provisioning;
                    }
                    else if (i >= 4 && i < 9)
                    {
                        result.State = MachineState.ServiceReady;
                    } else if (i >= 9)
                    {
                        result.State = MachineState.Ready;
                    }

                    i++;
                    return result;
                });

            var machinesClient = new MachinesClient(connection.Object);
            var machine = await machinesClient.Waitfor("psxs9sp8u", MachineState.Ready, pollIntervalMS: 1, maxWaitMS: 0, (m) => {
                j++;
            });

            Assert.AreEqual(MachineState.Ready, machine.State);
            Assert.AreEqual(10, i);
            Assert.AreEqual(10, j);
        }

        [TestMethod]
        public async Task MachinesClient_WaitFor_Stops_After_MaxWait()
        {
            var i = 0;
            var j = 0;
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Machine>(ApiUrls.MachinesShow("psxs9sp8u"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Machines_GetMachine_Start_InProgress.json");
                    var result = JsonConvert.DeserializeObject<Machine>(json);
                    result.State = MachineState.Provisioning;
                    Thread.Sleep(101);
                    i++;
                    return result;
                });

            var machinesClient = new MachinesClient(connection.Object);
            Machine machine = null;
            await Assert.ThrowsExceptionAsync<TimeoutException>(async () =>
            {
                await machinesClient.Waitfor("psxs9sp8u", MachineState.Ready, pollIntervalMS: 10, maxWaitMS: 200, (m) => {
                    machine = m;
                    j++;
                });
            });
            Assert.AreEqual(MachineState.Provisioning, machine.State);
            Assert.AreEqual(2, i);
            Assert.AreEqual(2, j);
        }

        [TestMethod]
        public async Task MachinesClient_WaitFor_Throws_If_Invalid_Target_State()
        {
            var connection = new Mock<IConnection>();
            var machinesClient = new MachinesClient(connection.Object);
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await machinesClient.Waitfor("psxs9sp8u", MachineState.Restarting);
            });
        }
    }
}
