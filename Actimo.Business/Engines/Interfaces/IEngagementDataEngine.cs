using Actimo.Business.Engines.Interfaces;
using Actimo.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IEngagementDataEngine : IDataEngine
    {
        string GetContactLink(ApiUriService apiService, string actimoApikey, int messageId, int sourceId);
        string GetContactAuthContact(ApiUriService apiService, string actimoApikey, string keyCode);
        void GetEngagementData(ApiUriService apiService, string actimoApikey, int targetId, int sourceId, string authCode);

    }
}
