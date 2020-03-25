using Actimo.Business.Services;
using Actimo.Data.Accesor.Entities;
using System;

namespace Actimo.Business.DataProvider
{
    public class InputDataProvider : IInputDataProvider
    {

        public ApiUriService ApiUriService => GetResourceApiUris();

        private ApiUriService GetResourceApiUris() => new ApiUriService(Environment.GetEnvironmentVariable("baseUri"),
            Environment.GetEnvironmentVariable("contactApiUri"),
            Environment.GetEnvironmentVariable("contactManagerApiUri"),
            Environment.GetEnvironmentVariable("contactLinkApiUri"),
            Environment.GetEnvironmentVariable("contactAuthApiUri"),
            Environment.GetEnvironmentVariable("enagementApiUri"));

        public Client Client { get; set; }
    }
}
