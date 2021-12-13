using Integration.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Integration.Infrastructure.ExternalServices
{
    public class HttpRequester : IHttpRequester
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpRequester(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> GetAsync(string clientName, string path)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            var request = new HttpRequestMessage(HttpMethod.Get, path);

            return await httpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> PostAsync(string clientName, string path, object body)
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            var request = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            return await httpClient.SendAsync(request);
        }
    }
}
