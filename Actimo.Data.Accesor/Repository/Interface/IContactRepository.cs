using Actimo.Data.Accesor.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Actimo.Data.Accesor.Repository.Interface
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts(int clientId);
        Task PushContactsAsync(int clientId, DataTable contacts);
    }
}
