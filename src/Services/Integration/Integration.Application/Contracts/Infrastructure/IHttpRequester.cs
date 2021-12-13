using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Application.Contracts.Infrastructure
{
    public interface IHttpRequester
    {
        Task<HttpResponseMessage> GetAsync(string clientName, string path);
        Task<HttpResponseMessage> PostAsync(string clientName, string path, object body);
    }
}
