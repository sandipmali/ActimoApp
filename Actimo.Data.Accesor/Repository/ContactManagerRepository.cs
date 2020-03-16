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
    public class ContactManagerRepository : RepositoryBase<ContactManager>, IContactManagerRepository
    {
        private readonly DWContext repositoryContext;

        public ContactManagerRepository(DWContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task PushContactsManagerAsync(int clientId, int contactId, DataTable contactsManager)
        {
            try
            {
                var clientidParameter = new SqlParameter("@clientId", SqlDbType.Int)
                {
                    Value = clientId
                };

                var contactIdParameter = new SqlParameter("@ContactID", SqlDbType.Int)
                {
                    Value = contactId
                };

                var parameter = new SqlParameter("@Relationship", SqlDbType.Structured)
                {
                    Value = contactsManager,
                    TypeName = "Mirror.Relationship_TableType"
                };

                await repositoryContext.Database.OpenConnectionAsync();
                await repositoryContext.Database.ExecuteSqlRawAsync("EXEC InsertToMirror_ActimoRelationship @clientId, @ContactID, @Relationship", clientidParameter, contactIdParameter, parameter);

            }
            catch (Exception ex)
            {
                throw new Exception("Sql exception occured!", ex);
            }
        }
    }
}
