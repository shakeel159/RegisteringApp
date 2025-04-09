using Microsoft.EntityFrameworkCore;
using RegisteringApp.Models;

namespace RegisteringApp.Data
{
    public class RegistryContext : DbContext
    {
        public RegistryContext(DbContextOptions<RegistryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Seeding data
            //modelBuilder.Entity<Client>().HasData(
            //    new Client { Id = 1, FirstName = "FirstName", LastName = "LastName", Email = "YourEmail@gmail.com", PublicID = 2 }
            //);

            //modelBuilder.Entity<ID>().HasData(
            //    new ID { Id = 2, LastName = "Client_LastName", ClientId = 1 }
            //);

            //// Foreign key relationship between Client and ID
            //modelBuilder.Entity<Client>()
            //    .HasOne(c => c._ID)
            //    .WithOne()
            //    .HasForeignKey<ID>(i => i.ClientId);

            //base.OnModelCreating(modelBuilder);
        }

        // Define your DbSets
        public DbSet<Client> LeadDetails { get; set; }
        public DbSet<ID> _ID { get; set; }
    }
}