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
        private readonly IDmRepository dmRepository;

        public DataFeedManager(IActimoDataFactory actimoDataFactory,
            ILogger<DataFeedManager> logger,
            IClientLookupRepository clientLookupRepository,
            IDmRepository dmRepository)
        {
            this.actimoDataFactory = actimoDataFactory;
            this.logger = logger;
            this.clientLookupRepository = clientLookupRepository;
            this.dmRepository = dmRepository;
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

                //Exec DM.LoadDM Sp
                dmRepository.Load();
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
