using Actimo.Business.DataProvider;
using Actimo.Business.Engines.Interfaces;
using Actimo.Business.Services;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.Engines
{
    public class EngagementDataEngine : IEngagementDataEngine
    {
        private readonly IRestClientService restClientService;
        private readonly ILogger<EngagementDataEngine> logger;
        private readonly IEngagementRepository engagementRepository;

        public DataType dataType => DataType.Engagement;

        public EngagementDataEngine(IRestClientService restClientService,
            ILogger<EngagementDataEngine> logger,
             IEngagementRepository engagementRepository)
        {
            this.restClientService = restClientService;
            this.logger = logger;
            this.engagementRepository = engagementRepository;
        }

        public void FeedData(IInputDataProvider inputDataProvider)
        {
            try
            {
                //var apiService = inputDataProvider.ApiUriService;

                //var contacts = GetContactLink(apiService, inputDataProvider.Client.ActimoApikey);

                //var dtContacts = ObjectConversionService.ToDataTable(contacts);

                //if (dtContacts?.Rows.Count > 0)
                //    PushContacts(inputDataProvider.Client.ClientId, dtContacts);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw new Exception("Error occured in Enagement Data Engine!", ex);
            }
        }

        public string GetContactAuthContact(string keyCode)
        {
            throw new NotImplementedException();
        }

        public string GetContactLink(int messageId, int sourceId)
        {
            throw new NotImplementedException();
        }

        public void GetEngagementData(int targetId, int sourceId, string authCode)
        {
            throw new NotImplementedException();
        }
    }
}
