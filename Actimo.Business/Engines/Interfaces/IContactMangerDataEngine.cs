using Actimo.Business.Models;
using Actimo.Business.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IContactMangerDataEngine : IDataEngine
    {
        List<ContactMangerModel> GetContactManagerList(ApiUriService apiUriService, string actimoApikey, int contactId);
        void PushContactsManager(int clientId, int contactId, DataTable contactsManager);

    }
}
