using Microsoft.EntityFrameworkCore;
using RegisteringApp.Models;

namespace RegisteringApp.Data
{
    public class RegistryContext : DbContext
    {
        public RegistryContext(DbContextOptions<RegistryContext> options) : base(options){ }

        public DbSet<Client> Clients { get; set; }
    }
}
