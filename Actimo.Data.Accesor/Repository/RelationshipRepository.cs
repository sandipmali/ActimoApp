﻿using Actimo.Data.Accesor.Entities;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Actimo.Data.Accesor.Repository
{
    public class RelationshipRepository : RepositoryBase<Relationship>, IRelationshipRepository
    {
        private readonly DWContext repositoryContext;

        public RelationshipRepository(DWContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task PushRelationshipAsync(int clientId, int contactId, DataTable relationshipDataTable)
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
                    Value = relationshipDataTable,
                    TypeName = "Mirror.Relationship_TableType"
                };

                await repositoryContext.Database.OpenConnectionAsync();
                await repositoryContext.Database.ExecuteSqlRawAsync("EXEC [Mirror].[InsertToMirror_ActimoRelationship] @clientId, @ContactID, @Relationship", clientidParameter, contactIdParameter, parameter);

            }
            catch (Exception ex)
            {
                throw new Exception("Sql exception occured!", ex);
            }
        }
    }
}
