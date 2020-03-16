using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actimo.Business.Services
{
    public interface IRestClientService
    {
        Task<IRestResponse> ExecuteAsync(string baseUri, string resource, string apiKey, Method method);
    }
}
