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
using System.Linq;
using System.Net;

namespace Actimo.Business.Engines
{
    public class ContactMangerDataEngine : IContactMangerDataEngine
    {
        private readonly IRestClientService restClientService;
        private readonly ILogger<ContactMangerDataEngine> logger;
        private readonly IContactRepository contactRepository;
        private readonly IContactManagerRepository contactManagerRepository;

        public DataType dataType => DataType.ContactManager;

        public ContactMangerDataEngine(IRestClientService restClientService,
            ILogger<ContactMangerDataEngine> logger,
            IContactRepository contactRepository,
            IContactManagerRepository contactManagerRepository)
        {
            this.restClientService = restClientService;
            this.logger = logger;
            this.contactRepository = contactRepository;
            this.contactManagerRepository = contactManagerRepository;
        }

        public List<ContactMangerModel> GetContactManagerList(ApiUriService apiService, string actimoApikey, int contactId)
        {
            var response = restClientService.ExecuteAsync(apiService.BaseUri,
                    string.Format(apiService.ContactManagerApiUri, contactId), actimoApikey,
                     Method.GET)
                    .GetAwaiter()
                    .GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Request issue -> HTTP code:" + response.StatusCode);

            return ObjectConversionService.ToObject<ContactMangerRoot>(response.Content)?.data
                ?? new List<ContactMangerModel>();
        }

        public void FeedData(IInputDataProvider inputDataProvider)
        {
            try
            {
                var getContacts = contactRepository.
                                GetContacts(inputDataProvider.Client.ClientId)
                                .GetAwaiter().GetResult()?.ToList();

                if (getContacts?.Any() == false)
                    throw new Exception("No Contacts Data Found!!");

                foreach (var contact in getContacts)
                {
                    var contactManagerList = GetContactManagerList(inputDataProvider.ApiUriService,
                        inputDataProvider.Client.ActimoApikey, contact.Id);

                    var contactsManager = ObjectConversionService.ToDataTable(contactManagerList);

                    if (contactsManager?.Rows.Count > 0)
                        PushContactsManager(inputDataProvider.Client.ClientId, contact.Id, contactsManager);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
            }
        }

        public void PushContactsManager(int clientId, int contactId, DataTable contactsManager)
        {
            contactManagerRepository.PushContactsManagerAsync(clientId, contactId, contactsManager)
                .GetAwaiter().GetResult();
        }
    }
}
