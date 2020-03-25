using Actimo.Business.Models;
using Actimo.Business.Services;
using System.Collections.Generic;
using System.Data;

namespace Actimo.Business.Engines.Interfaces
{
    public interface IRelationshipDataEngine : IDataEngine
    {
        List<RelationshipModel> GetRelationshipList(ApiUriService apiUriService, string actimoApikey, int contactId);
        void PushRelationship(int clientId, int contactId, DataTable relationshipDataTable);
    }
}
