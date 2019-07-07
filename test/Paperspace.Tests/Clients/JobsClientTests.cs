namespace Paperspace.Tests.Clients
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    [TestClass]
    public class JobsClientTests
    {
        [TestMethod]
        public void JobsClient_Can_Construct()
        {
            var connection = new Mock<IConnection>();
            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);

            Assert.IsNotNull(jobsClient);
        }

        [TestMethod]
        public async Task JobsClient_ArtifactsList_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Artifact>>(ApiUrls.JobsArtifactsList("j123abc"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_ArtifactsList.json");
                    return JsonConvert.DeserializeObject<IList<Artifact>>(json);
                });
            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.ArtifactsList("j123abc");

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task JobsClient_ArtifactsList_With_Parameters()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Artifact>>(ApiUrls.JobsArtifactsList("j123abc"), It.IsAny<IDictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_ArtifactsList.json");
                    return JsonConvert.DeserializeObject<IList<Artifact>>(json);
                });
            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.ArtifactsList("j123abc", new ListArtifactsParameters()
            {
                Files = "myfiles*",
                Size = true,
                Links = true,
            });

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public async Task JobsClient_ArtifactsGet_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<JObject>(ApiUrls.JobsArtifactsGet("j123abc"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_ArtifactsGet.json");
                    return JObject.Parse(json);
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.ArtifactsGet("j123abc");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task JobsClient_ArtifactsGet_With_Parameters()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<JObject>(ApiUrls.JobsArtifactsGet("j123abc"), It.IsAny<IDictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_ArtifactsGet.json");
                    return JObject.Parse(json);
                });
            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.ArtifactsGet("j123abc", new GetArtifactsParameters()
            {
                Files = "myfiles*"
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task JobsClient_ArtifactsDestroy_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post(ApiUrls.JobsArtifactsDestroy("j123abc"), null, null))
                .Returns(() =>
                {
                    return Task.CompletedTask;
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            await jobsClient.ArtifactsDestroy("j123abc");

            connection.Verify(
                c => c.Post(ApiUrls.JobsArtifactsDestroy("j123abc"), null, null),
                 Times.Exactly(1)
                );
        }

        [TestMethod]
        public async Task JobsClient_ArtifactsDestroy_With_Parameters()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post(ApiUrls.JobsArtifactsDestroy("j123abc"), It.IsAny<IDictionary<string, string>>(), null))
                .Returns(() =>
                {
                    return Task.CompletedTask;
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            await jobsClient.ArtifactsDestroy("j123abc", new DestroyArtifactsParameters()
            {
                Files = "myfiles*"
            });

            connection.Verify(
                c => c.Post(ApiUrls.JobsArtifactsDestroy("j123abc"), It.IsAny<IDictionary<string, string>>(), null),
                 Times.Exactly(1)
                );
        }

        [TestMethod]
        public async Task JobsClient_List_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Job>>(ApiUrls.JobsList(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_List.json");
                    return JsonConvert.DeserializeObject<IList<Job>>(json);
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.List();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public async Task JobsClient_List_With_Filter()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<Job>>(ApiUrls.JobsList(), It.IsAny<IDictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_List.json");
                    return JsonConvert.DeserializeObject<IList<Job>>(json);
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.List(new JobFilter()
            {
                Command = "foo",
                Container = "bar",
                Dataset = "foo",
                MachineType = MachineType.Advanced,
                Name = "foo",
                Project = "foo",
                ProjectId = "foobar",
                State = JobState.Pending,
                Workspace = "asdf"
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public async Task JobsClient_MachineTypes_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<JobMachine>>(ApiUrls.JobsMachineTypes(), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_MachineTypes.json");
                    return JsonConvert.DeserializeObject<IList<JobMachine>>(json);
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.MachineTypes();

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public async Task JobsClient_MachineTypes_With_Filter()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<IList<JobMachine>>(ApiUrls.JobsMachineTypes(), It.IsAny<IDictionary<string, string>>()))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_MachineTypes.json");
                    return JsonConvert.DeserializeObject<IList<JobMachine>>(json);
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.MachineTypes(new MachineTypeFilter()
            {
                Cluster = "1sdf",
                MachineType = MachineType.K80,
                Region = Region.Europe_AMS1,
                IsBusy = false
            });

            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public async Task JobsClient_Clone_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post<Job>(ApiUrls.JobsClone("j123abc"), null, null, null, null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_Show.json");
                    return JsonConvert.DeserializeObject<Job>(json);
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.Clone("j123abc");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task JobsClient_Create_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post<Job>(ApiUrls.JobsCreate(), null, It.IsAny<object>(), null, null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_Create.json");
                    return JsonConvert.DeserializeObject<Job>(json);
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var result = await jobsClient.Create(new CreateJobRequest()
            {
                Container = "http://dockerhub.com/mycontainer",
                MachineType = MachineType.P5000
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task JobsClient_Destroy_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post(ApiUrls.JobsDestroy("j123abc"), null, null))
                .Returns(() =>
                {
                    return Task.CompletedTask;
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            await jobsClient.Destroy("j123abc");

            connection.Verify(
                c => c.Post(ApiUrls.JobsDestroy("j123abc"), null, null),
                Times.Exactly(1)
                );
        }

        [TestMethod]
        public async Task JobsClient_Logs_HappyPath()
        {
            var connection = new Mock<IConnection>();
            var logsConnection = new Mock<IConnection>();
            logsConnection.Setup(c => c.Get<IList<JobLog>>(ApiUrls.JobsLogs("j123abc"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_Logs.json");
                    return JsonConvert.DeserializeObject<IList<JobLog>>(json);
                });

            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var logs = await jobsClient.Logs("j123abc");

            Assert.IsNotNull(logs);
        }

        [TestMethod]
        public async Task JobsClient_Stop_HappyPath()
        {
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Post(ApiUrls.JobsStop("j123abc"), null, null))
                .Returns(() =>
                {
                    return Task.CompletedTask;
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            await jobsClient.Stop("j123abc");

            connection.Verify(
                c => c.Post(ApiUrls.JobsStop("j123abc"), null, null),
                Times.Exactly(1)
                );
        }

        [TestMethod]
        public async Task JobsClient_WaitFor_HappyPath()
        {
            var i = 0;
            var j = 0;
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Job>(ApiUrls.JobsShow("j123abc"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_Show.json");
                    var result = JsonConvert.DeserializeObject<Job>(json);

                    if (i >= 0 && i < 4)
                    {
                        result.State = JobState.Pending;
                    }
                    else if (i >= 4 && i < 9)
                    {
                        result.State = JobState.Running;
                    }
                    else if (i >= 9)
                    {
                        result.State = JobState.Stopped;
                    }

                    i++;
                    return result;
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            var machine = await jobsClient.Waitfor("j123abc", JobState.Stopped, pollIntervalMS: 1, maxWaitMS: 0, (m) =>
            {
                j++;
            });

            Assert.AreEqual(JobState.Stopped, machine.State);
            Assert.AreEqual(10, i);
            Assert.AreEqual(10, j);
        }

        [TestMethod]
        public async Task JobsClient_WaitFor_Stops_After_MaxWait()
        {
            var i = 0;
            var j = 0;
            var connection = new Mock<IConnection>();
            connection.Setup(c => c.Get<Job>(ApiUrls.JobsShow("j123abc"), null))
                .ReturnsAsync(() =>
                {
                    var json = System.IO.File.ReadAllText("./Fixtures/Jobs_Show.json");
                    var result = JsonConvert.DeserializeObject<Job>(json);
                    result.State = JobState.Pending;
                    Thread.Sleep(101);
                    i++;
                    return result;
                });

            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            Job job = null;
            await Assert.ThrowsExceptionAsync<TimeoutException>(async () =>
            {
                await jobsClient.Waitfor("j123abc", JobState.Running, pollIntervalMS: 10, maxWaitMS: 200, (m) =>
                {
                    job = m;
                    j++;
                });
            });
            Assert.AreEqual(JobState.Pending, job.State);
            Assert.AreEqual(2, i);
            Assert.AreEqual(2, j);
        }

        [TestMethod]
        public async Task JobsClient_WaitFor_Throws_If_Invalid_Target_State()
        {
            var connection = new Mock<IConnection>();
            var logsConnection = new Mock<IConnection>();
            var jobsClient = new JobsClient(connection.Object, logsConnection.Object);
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await jobsClient.Waitfor("j123abc", JobState.Cancelled);
            });
        }
    }
}
