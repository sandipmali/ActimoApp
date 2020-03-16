using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actimo.Business.Services
{
    public class RestClientService : IRestClientService
    {
        public async Task<IRestResponse> ExecuteAsync(string baseUri, string resource, string apiKey, Method method)
        {
            var client = new RestClient(baseUri);
            var request = new RestRequest(resource, method);
            request.AddParameter("api-key", apiKey);
            return await client.ExecuteGetAsync(request);
        }
    }
}
