using Actimo.Business.DataFactory;
using Actimo.Business.DataProvider;
using Microsoft.Extensions.Logging;
using System;
using Actimo.Data.Accesor.Repository.Interface;

namespace Actimo.Business.Managers
{
    public class DataFeedManager : IDataFeedManager
    {
        private readonly IActimoDataFactory actimoDataFactory;
        private readonly ILogger<DataFeedManager> logger;
        private readonly IClientLookupRepository clientLookupRepository;

        public DataFeedManager(IActimoDataFactory actimoDataFactory,
            ILogger<DataFeedManager> logger,
            IClientLookupRepository clientLookupRepository)
        {
            this.actimoDataFactory = actimoDataFactory;
            this.logger = logger;
            this.clientLookupRepository = clientLookupRepository;
        }

        public void CreateFeed(IInputDataProvider inputDataProvider)
        {
            //Execute Feed per client
            try
            {
                var clients = clientLookupRepository.GetClients();

                foreach (var client in clients)
                {
                    inputDataProvider.Client = client;
                    ExecuteFeed(inputDataProvider);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                throw;
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
