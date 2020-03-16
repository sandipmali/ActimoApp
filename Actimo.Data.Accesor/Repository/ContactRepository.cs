using Actimo.Data.Accesor.Entities;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Actimo.Data.Accesor.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        private readonly DWContext repositoryContext;

        public ContactRepository(DWContext repositoryContext)
            : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task<IEnumerable<Contact>> GetContacts(int clientId)
        {
            return await FindByConditionAsync(c => c.ClientId == clientId);

        }

        public async Task PushContactsAsync(int clientId, DataTable contacts)
        {
            try
            {
                var clientidParameter = new SqlParameter("@clientId", SqlDbType.Int)
                {
                    Value = clientId
                };

                var parameter = new SqlParameter("@contacts", SqlDbType.Structured)
                {
                    Value = contacts,
                    TypeName = "Mirror.Contact_TableType"
                };

                await repositoryContext.Database.OpenConnectionAsync();
                await repositoryContext.Database.ExecuteSqlRawAsync("EXEC [dbo].[InsertToMirror_ActimoContact] @clientId, @contacts", clientidParameter, parameter);

            }
            catch (Exception ex)
            {
                throw new Exception("Sql exception occured!", ex);
            }
        }
    }
}
