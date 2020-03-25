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
    public class RelationshipDataEngine : IRelationshipDataEngine
    {
        private readonly IRestClientService restClientService;
        private readonly ILogger<RelationshipDataEngine> logger;
        private readonly IContactRepository contactRepository;
        private readonly IRelationshipRepository relationshipRepository;

        public DataType dataType => DataType.Relationship;

        public RelationshipDataEngine(IRestClientService restClientService,
            ILogger<RelationshipDataEngine> logger,
            IContactRepository contactRepository,
            IRelationshipRepository relationshipRepository)
        {
            this.restClientService = restClientService;
            this.logger = logger;
            this.contactRepository = contactRepository;
            this.relationshipRepository = relationshipRepository;
        }

        public List<RelationshipModel> GetRelationshipList(ApiUriService apiService, string actimoApikey, int contactId)
        {
            var response = restClientService.ExecuteAsync(apiService.BaseUri,
                    string.Format(apiService.ContactManagerApiUri, contactId), actimoApikey,
                     Method.GET)
                    .GetAwaiter()
                    .GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Request issue -> HTTP code:" + response.StatusCode);

            return ObjectConversionService.ToObject<RelationshipRoot>(response.Content)?.data
                ?? new List<RelationshipModel>();
        }

        public void FeedData(IInputDataProvider inputDataProvider)
        {
            try
            {
                var getContacts = contactRepository.
                                GetContacts(inputDataProvider.Client.ClientId)
                                .GetAwaiter().GetResult()?.ToList();

                if (getContacts != null)

                    foreach (var contact in getContacts)
                    {
                        var relationshipList = GetRelationshipList(inputDataProvider.ApiUriService,
                            inputDataProvider.Client.ActimoApikey, contact.Id);

                        var relationshipDataTable = ObjectConversionService.ToDataTable(relationshipList);

                        if (relationshipDataTable?.Rows.Count > 0)
                            PushRelationship(inputDataProvider.Client.ClientId, contact.Id, relationshipDataTable);
                    }

                else
                    throw new Exception("No Contacts Data Found!!");

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
            }
        }

        public void PushRelationship(int clientId, int contactId, DataTable relationshipDataTable)
        {
            relationshipRepository.PushRelationshipAsync(clientId, contactId, relationshipDataTable)
                .GetAwaiter().GetResult();
        }
    }
}
