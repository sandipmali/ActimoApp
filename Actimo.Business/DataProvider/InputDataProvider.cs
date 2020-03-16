using Actimo.Business.Services;
using Actimo.Data.Accesor.Entities;
using Actimo.Data.Accesor.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.DataProvider
{
    public class InputDataProvider : IInputDataProvider
    {
        private readonly IClientLookupRepository clientLookupRepository;

        public InputDataProvider(IClientLookupRepository clientLookupRepository)
        {            
            this.clientLookupRepository = clientLookupRepository;
        }

        public ApiUriService ApiUriService => GetResourceApiUris();

        private ApiUriService GetResourceApiUris()
        {
            return new ApiUriService(Environment.GetEnvironmentVariable("baseUri"),
            Environment.GetEnvironmentVariable("contactApiUri"),
            Environment.GetEnvironmentVariable("contactManagerApiUri"));
        }

        public Client Client => GetClient();

        private Client GetClient()
        {
            if (!int.TryParse(Environment.GetEnvironmentVariable("ClientId"), out int clientid))
                throw new Exception($"Invalid Client ID: {Environment.GetEnvironmentVariable("ClientId")}");

            return clientLookupRepository.GetClient(clientid);
        }
    }
}
