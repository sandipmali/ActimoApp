using Actimo.Business.Engines.Interfaces;
using Actimo.Business.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Actimo.Business.Models;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IEngagementDataEngine : IDataEngine
    {
        string GetContactLink(ApiUriService apiService, string actimoApikey, int messageId, int sourceId);
        string GetContactAuthContact(ApiUriService apiService, string actimoApikey, string keyCode);
        List<EnagementModel> GetEngagementData(ApiUriService apiService, string actimoApikey, int targetId, int sourceId, string authCode);
        void PushEngagementData(int clientId, DataTable engagementTable);

    }
}
