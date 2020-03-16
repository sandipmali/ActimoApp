using Actimo.Data.Accesor.Entities;
using Actimo.Data.Accesor.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actimo.Data.Accesor.Repository
{
    public class EngagementRepository : RepositoryBase<Engagement>, IEngagementRepository
    {
        public EngagementRepository(DWContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
