using Actimo.Business.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IEngagementDataEngine : IDataEngine
    {
        string GetContactLink(int messageId, int sourceId);
        string GetContactAuthContact(string keyCode);
        void GetEngagementData(int targetId, int sourceId, string authCode);

    }
}
