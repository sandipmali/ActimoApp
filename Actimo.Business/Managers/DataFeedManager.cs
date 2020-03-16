using Actimo.Business.DataFactory;
using Actimo.Business.DataProvider;
using Microsoft.Extensions.Logging;
using System;

namespace Actimo.Business.Managers
{
    public class DataFeedManager : IDataFeedManager
    {
        private readonly IActimoDataFactory actimoDataFactory;
        private readonly ILogger<DataFeedManager> logger;

        public DataFeedManager(IActimoDataFactory actimoDataFactory, ILogger<DataFeedManager> logger)
        {
            this.actimoDataFactory = actimoDataFactory;
            this.logger = logger;
        }
        public void CreateFeed(IInputDataProvider inputDataProvider)
        {
            //Execute Feed
            try
            {
                ExecuteFeed(inputDataProvider);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                throw ex;
            }

        }

        private void ExecuteFeed(IInputDataProvider inputDataProvider)
        {
            foreach (var dataEngine in actimoDataFactory.GetAllDataEngines())
            {
                logger.LogInformation($"{dataEngine.dataType} Data Loading...");

                dataEngine.FeedData(inputDataProvider);
            }
        }
    }
}
