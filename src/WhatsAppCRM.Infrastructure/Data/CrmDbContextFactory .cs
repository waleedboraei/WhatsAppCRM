using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WhatsAppCRM.Infrastructure.Data
{
    public class CrmDbContextFactory : IDesignTimeDbContextFactory<CrmDbContext>
    {
        public CrmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CrmDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=WhatsAppCRM;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CrmDbContext(optionsBuilder.Options);
        }
    }
}