using Actimo.Business.DataProvider;
using Actimo.Business.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;

namespace LoadActimoToDW
{
    public class ActimoHttpTriggerFunction
    {
        private readonly IDataFeedManager dataFeedManager;
        private readonly IInputDataProvider inputDataProvider;
        public ActimoHttpTriggerFunction(IDataFeedManager dataFeedManager,
            IInputDataProvider inputDataProvider)
        {
            this.dataFeedManager = dataFeedManager;
            this.inputDataProvider = inputDataProvider;
        }

        [FunctionName("ActimoHttpTriggerFunction")]
        public void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation($"HttpTrigger trigger function executed at: {DateTime.Now}");

                log.LogInformation($"Begin");

                dataFeedManager.CreateFeed(inputDataProvider);

                log.LogInformation($"End");
            }
            catch (Exception ex)
            {
                log.LogError($"Error!! {ex.Message}");
                log.LogError($"{ex.InnerException?.Message}");
                log.LogError($"{ex.StackTrace}");
            }
        }
    }
}
