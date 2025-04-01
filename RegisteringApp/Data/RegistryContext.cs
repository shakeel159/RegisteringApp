using Microsoft.EntityFrameworkCore;
using RegisteringApp.Models;

namespace RegisteringApp.Data
{
    public class RegistryContext : DbContext
    {
        public RegistryContext(DbContextOptions<RegistryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstName = "FirstName", LastName = "LastName", Email = "YourEmail@gmail.com", PublicID = 2 }
                );
            modelBuilder.Entity<ID>().HasData(
                new ID { Id = 2, LastName = "Client_LastName", ClientId = 1 }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ID> _ID { get; set; }
    }
}
