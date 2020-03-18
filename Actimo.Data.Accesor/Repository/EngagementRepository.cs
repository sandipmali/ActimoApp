using Actimo.Data.Accesor.Entities;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Actimo.Data.Accesor.Repository
{
    public class EngagementRepository : RepositoryBase<Engagement>, IEngagementRepository
    {
        private readonly DWContext repositoryContext;

        public EngagementRepository(DWContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task PushEngagementDataAsync(int clientId, DataTable engagementTable)
        {
            try
            {
                var clientidParameter = new SqlParameter("@clientId", SqlDbType.Int)
                {
                    Value = clientId
                };

                var parameter = new SqlParameter("@engagement", SqlDbType.Structured)
                {
                    Value = engagementTable,
                    TypeName = "Mirror.Engagement_TableType"
                };

                await repositoryContext.Database.OpenConnectionAsync();
                await repositoryContext.Database.ExecuteSqlRawAsync("EXEC [dbo].[InsertToMirror_ActimoEngagement] @clientId, @engagement", clientidParameter, parameter);

            }
            catch (Exception ex)
            {
                throw new Exception("Sql exception occured!", ex);
            }
        }
    }
}
