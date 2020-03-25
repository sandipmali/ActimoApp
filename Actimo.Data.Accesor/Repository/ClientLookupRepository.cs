using Actimo.Data.Accesor.Entities;
using Actimo.Data.Accesor.Repository.Interface;
using System.Collections.Generic;

namespace Actimo.Data.Accesor.Repository
{
    public class ClientLookupRepository : RepositoryBase<Client>, IClientLookupRepository
    {
        public ClientLookupRepository(DWContext repositoryContext) : base(repositoryContext)
        {
        }

        public Client GetClient(int id)
        {
            return GetByIdAsync(id);
        }

        public IEnumerable<Client> GetClients()
        {
            return FindAllAsync()
                .GetAwaiter()
                .GetResult();
        }
    }
}
