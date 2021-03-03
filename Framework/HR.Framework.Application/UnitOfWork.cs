using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Core.ApplicationService;
using HR.Framework.Core.Persistence;

namespace HR.Framework.Application
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly IDbContext dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void RollBack()
        {
            dbContext.Dispose();
        }
    }
}
