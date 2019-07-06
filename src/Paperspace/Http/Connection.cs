namespace Paperspace
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// A connection for making HTTP requests against URI endpoints.
    /// </summary>
    public class Connection : IConnection
    {
        private static readonly Uri s_defaultPaperspaceApiUrl = PaperspaceClient.PaperspaceApiUrl;
        private static readonly HttpClient s_defaultPaperspaceHttpClient = new HttpClient();

        public Connection(string apiKey)
            : this(apiKey, s_defaultPaperspaceApiUrl, s_defaultPaperspaceHttpClient)
        {

        }

        public Connection(string apiKey, Uri baseAddress, HttpClient httpClient)
        {
            httpClient.BaseAddress = baseAddress;
            httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            HttpClient = httpClient;
        }

        public HttpClient HttpClient
        {
            get;
        }

        public async Task<T> Get<T>(Uri uri, IDictionary<string, string> parameters = null)
        {
            Ensure.ArgumentNotNull(uri, nameof(uri));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = uri.ExtendQuery(parameters),
            };
            
            var response = await HttpClient.SendAsync(request);
            await EnsureSuccessStatusCode(response);

            string content = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
        }

        public async Task Post(Uri uri, IDictionary<string, string> parameters = null, object body = null)
        {
            var response = await PostInternal(uri, parameters, body);
            await EnsureSuccessStatusCode(response);
        }

        public async Task<T> Post<T>(Uri uri, IDictionary<string, string> parameters = null, object body = null, Stream stream = null, string fileName = null)
        {
            HttpResponseMessage response;
            if (stream == null)
            {
                response = await PostInternal(uri, parameters, body);
            }
            else
            {
                var multipartContent = new MultipartFormDataContent();

                // An interesting design decision, for multipart content, the payload is set as query string parameters. yuk.
                if (parameters == null)
                {
                    parameters = new Dictionary<string, string>();
                }

                var jObj = JObject.FromObject(body);
                foreach (var property in jObj)
                {
                    if (property.Value != null)
                    {
                        parameters.Add(property.Key, property.Value.ToString());
                    }
                }

                multipartContent.Add(new StreamContent(stream), "file", fileName);
                response = await PostInternal(uri, parameters, multipartContent);
            }

            await EnsureSuccessStatusCode(response);

            string content = await response.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(content));
        }

        private async Task<HttpResponseMessage> PostInternal(Uri uri, IDictionary<string, string> parameters = null, object body = null)
        {
            HttpContent content = null;
            if (body != null)
            {
                var requestContent = await Task.Run(() => JsonConvert.SerializeObject(body));
                content = new StringContent(requestContent, System.Text.Encoding.UTF8, "application/json");
            }

            return await PostInternal(uri, parameters, content);
        }

        private async Task<HttpResponseMessage> PostInternal(Uri uri, IDictionary<string, string> parameters = null, HttpContent content = null)
        {
            Ensure.ArgumentNotNull(uri, nameof(uri));

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = uri.ExtendQuery(parameters),
            };

            if (content != null)
            {
                request.Content = content;
            }

            return await HttpClient.SendAsync(request);
        }

        /// <summary>
        /// Ensures that the response returned a 4xx. If not, throws an exception with the error body.
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        static async Task EnsureSuccessStatusCode(HttpResponseMessage response)
        {
            if ((int)response.StatusCode >= 400)
            {
                string content = await response.Content.ReadAsStringAsync();
                var wrapper = await Task.Run(() => JsonConvert.DeserializeObject<PaperspaceErrorWrapper>(content));
                throw new PaperspaceException(wrapper.Error);
            }
        }
    }
}
