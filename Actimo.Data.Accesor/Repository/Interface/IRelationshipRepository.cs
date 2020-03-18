using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Actimo.Data.Accesor.Repository.Interface
{
    public interface IRelationshipRepository
    {
        Task PushContactsManagerAsync(int clientId, int contactId, DataTable contactsManager);
    }
}
