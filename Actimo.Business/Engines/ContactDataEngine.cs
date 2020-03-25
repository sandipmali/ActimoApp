using Actimo.Business.DataProvider;
using Actimo.Business.Engines.Interfaces;
using Actimo.Business.Models;
using Actimo.Business.Services;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace Actimo.Business.Engines
{
    public class ContactDataEngine : IContactDataEngine
    {
        private readonly IRestClientService restClientService;
        private readonly ILogger<ContactDataEngine> logger;
        private readonly IContactRepository contactRepository;

        public DataType dataType => DataType.Contacts;

        public ContactDataEngine(IRestClientService restClientService,
            ILogger<ContactDataEngine> logger,
            IContactRepository contactRepository)
        {
            this.restClientService = restClientService;
            this.logger = logger;
            this.contactRepository = contactRepository;
        }

        public List<ContactModel> GetContacts(ApiUriService apiService, string actimoApikey)
        {
            var response = restClientService.ExecuteAsync(apiService.BaseUri,
                    apiService.ContactApiUri, actimoApikey,
                    Method.GET)
                    .GetAwaiter()
                    .GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Request issue -> HTTP code:" + response.StatusCode);

            return ObjectConversionService.ToObject<ContactRoot>(response.Content)?.data
                ?? new List<ContactModel>();

        }

        public void FeedData(IInputDataProvider inputDataProvider)
        {
            try
            {
                var apiService = inputDataProvider.ApiUriService;

                var contacts = GetContacts(apiService, inputDataProvider.Client.ActimoApikey);

                var dtContacts = ObjectConversionService.ToDataTable(contacts);

                if (dtContacts?.Rows.Count > 0)
                    PushContacts(inputDataProvider.Client.ClientId, dtContacts);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw new Exception("Error occured in Contact Engine!", ex);
            }
        }

        public void PushContacts(int clientId, DataTable contacts)
        {
            contactRepository.PushContactsAsync(clientId, contacts)
                  .GetAwaiter().GetResult();
        }
    }
}
