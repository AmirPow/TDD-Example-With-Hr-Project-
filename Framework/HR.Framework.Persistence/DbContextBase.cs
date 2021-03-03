using HR.Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HR.Framework.Persistence
{
    public class DbContextBase : DbContext , IDbContext
    {
        public DbContextBase(DbContextOptions options):base(options)
        {

        }

        public void Migrate()
        {
            base.Database.Migrate();
        }
    }
}
