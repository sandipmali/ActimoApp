using Actimo.Business.DataProvider;
using Actimo.Business.Engines.Interfaces;
using Actimo.Business.Models;
using Actimo.Business.Services;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
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
                var contactLink = GetContactLink(inputDataProvider.ApiUriService,
                    inputDataProvider.Client.ActimoApikey,
                    inputDataProvider.Client.ActimoDummyMessageId, inputDataProvider.Client.ActimoManagerContactId);

                var keyCode = new Uri(contactLink).AbsolutePath;

                GetContactAuthContact(inputDataProvider.ApiUriService, inputDataProvider.Client.ActimoApikey, keyCode);
                //var auth = GetContactAuthContact(inputDataProvider.ApiUriService, inputDataProvider.Client.ActimoApikey, contactLink);

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

        public string GetContactAuthContact(ApiUriService apiService, string actimoApikey, string keyCode)
        {
            var response = restClientService.ExecuteAsync(apiService.BaseUri,
                    string.Format(apiService.ContactAuthApiUri, keyCode), actimoApikey,
                     Method.GET)
                    .GetAwaiter()
                    .GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Request issue -> HTTP code:" + response.StatusCode);

            var data = ObjectConversionService.ToObject<JObject>(response.Content);
            return data["contactAuthCode"].Value<string>();
        }

        public string GetContactLink(ApiUriService apiService, string actimoApikey, int messageId, int sourceId)
        {
            var response = restClientService.ExecuteAsync(apiService.BaseUri,
                    string.Format(apiService.ContactLinkApiUri, messageId, sourceId), actimoApikey,
                     Method.GET)
                    .GetAwaiter()
                    .GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Request issue -> HTTP code:" + response.StatusCode);

            return ObjectConversionService.ToObject<ContactLinkModel>(response.Content)?.link;
        }

        public void GetEngagementData(ApiUriService apiService, string actimoApikey, int targetId, int sourceId, string authCode)
        {
            throw new NotImplementedException();
        }
    }
}
