using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HR.Persistence
{
   public class HRDesignTimeDbContext: IDesignTimeDbContextFactory<HRDbContext>
    {
        public HRDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HRDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HR;Integrated Security=True");

            return new HRDbContext(optionsBuilder.Options);
        }
    }
}
