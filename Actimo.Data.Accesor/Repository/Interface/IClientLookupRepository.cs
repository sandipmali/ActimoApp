using Actimo.Data.Accesor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Data.Accesor.Repository.Interface
{
    public interface IClientLookupRepository
    {
        Client GetClient(int id);
        IEnumerable<Client> GetClients();
    }
}
