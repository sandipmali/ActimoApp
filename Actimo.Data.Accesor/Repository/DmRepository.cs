using System;
using System.Threading.Tasks;
using Actimo.Data.Accesor.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Actimo.Data.Accesor.Repository
{
    public class DmRepository : IDmRepository
    {
        private readonly DWContext repositoryContext;

        public DmRepository(DWContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task Load()
        {
            try
            {
                await repositoryContext.Database.OpenConnectionAsync();
                await repositoryContext.Database.ExecuteSqlRawAsync("EXEC [DM].[LoadDM]");
            }
            catch (Exception ex)
            {
                throw new Exception("Sql exception occured!", ex);
            }
        }
    }
}
