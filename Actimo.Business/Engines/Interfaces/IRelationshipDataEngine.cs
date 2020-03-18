using Actimo.Business.Models;
using Actimo.Business.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IRelationshipDataEngine : IDataEngine
    {
        List<RelationshipModel> GetContactManagerList(ApiUriService apiUriService, string actimoApikey, int contactId);
        void PushContactsManager(int clientId, int contactId, DataTable contactsManager);
    }
}
