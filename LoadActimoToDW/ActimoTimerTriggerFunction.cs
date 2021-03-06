using System;
using Actimo.Business.DataProvider;
using Actimo.Business.Managers;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace LoadActimoToDW
{
    public class ActimoTimerTriggerFunction
    {
        private readonly IDataFeedManager dataFeedManager;
        private readonly IInputDataProvider inputDataProvider;

        public ActimoTimerTriggerFunction(IDataFeedManager dataFeedManager,
            IInputDataProvider inputDataProvider)
        {
            this.dataFeedManager = dataFeedManager;
            this.inputDataProvider = inputDataProvider;
        }

        [FunctionName("ActimoTimerTriggerFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer,
            ILogger log)
        {
            try
            {
                log.LogInformation($"Timer trigger function executed at: {DateTime.Now}");

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


