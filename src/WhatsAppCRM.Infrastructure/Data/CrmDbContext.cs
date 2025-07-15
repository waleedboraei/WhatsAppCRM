using Microsoft.EntityFrameworkCore;
using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Infrastructure.Data
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Template> Templates => Set<Template>();
        public DbSet<Setting> Settings => Set<Setting>();

    }
}