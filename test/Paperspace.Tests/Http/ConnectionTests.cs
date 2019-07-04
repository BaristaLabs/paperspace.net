namespace Paperspace.Tests.Http
{
    using Paperspace;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Moq.Protected;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        public async Task Get_HappyPath()
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(@"{""id"":1,""value"":""1""}"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object);

            var subjectUnderTest = new Connection("12345", new Uri("https://api.paperspace.io/", UriKind.Absolute), httpClient);

            // ACT
            var result = await subjectUnderTest
               .Get<MockResponse>(new Uri("api/test/whatever", UriKind.Relative));

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("https://api.paperspace.io/api/test/whatever");

            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1), // we expected a single external request
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Get  // we expected a GET request
                  && req.RequestUri == expectedUri // to this uri
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task Get_Throws_On_404()
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(() =>
               {
                   var notFoundResponse = System.IO.File.ReadAllText("./Fixtures/404Response.json");
                   return new HttpResponseMessage()
                   {
                       StatusCode = HttpStatusCode.NotFound,
                       Content = new StringContent(notFoundResponse),
                   };
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object);

            var subjectUnderTest = new Connection("12345", new Uri("https://api.paperspace.io/", UriKind.Absolute), httpClient);

            // ACT
            await Assert.ThrowsExceptionAsync<PaperspaceException>(() =>
            {
                return subjectUnderTest
                .Get<MockResponse>(new Uri("api/test/whatever", UriKind.Relative));
            });
        }

        [TestMethod]
        public async Task Post_HappyPath()
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(@"{""id"":1,""value"":""1""}"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object);

            var subjectUnderTest = new Connection("12345", new Uri("https://api.paperspace.io/", UriKind.Absolute), httpClient);

            var query = new Dictionary<string, string>
            {
                { "foo", "bar" }
            };

            var body = new MockRequest()
            {
                Id = 1234,
                Value = "foo"
            };

            // ACT
            var result = await subjectUnderTest
               .Post<MockResponse>(new Uri("api/test/whatever", UriKind.Relative), query, body);

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("https://api.paperspace.io/api/test/whatever?foo=bar");

            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1), // we expected a single external request
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Post  // we expected a GET request
                  && req.RequestUri == expectedUri // to this uri
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task Post_Untyped_HappyPath()
        {
            // ARRANGE
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(@"{""id"":1,""value"":""1""}"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object);

            var subjectUnderTest = new Connection("12345",new Uri("https://api.paperspace.io/", UriKind.Absolute), httpClient);

            var query = new Dictionary<string, string>
            {
                { "foo", "bar" }
            };

            var body = new MockRequest()
            {
                Id = 1234,
                Value = "foo"
            };

            // ACT
            await subjectUnderTest
               .Post(new Uri("api/test/whatever", UriKind.Relative), query, body);

            // ASSERT

            // also check the 'http' call was like we expected it
            var expectedUri = new Uri("https://api.paperspace.io/api/test/whatever?foo=bar");

            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(1), // we expected a single external request
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Post  // we expected a GET request
                  && req.RequestUri == expectedUri // to this uri
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        private class MockRequest
        {
            public int Id
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }
        }

        private class MockResponse
        {
            public int Id
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }
        }
    }
}
