using Actimo.Business.Models;
using Actimo.Business.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IContactDataEngine : IDataEngine
    {
        List<ContactModel> GetContacts(ApiUriService apiService, string actimoApikey);
        void PushContacts(int clientID, DataTable contacts);
    }
}
