namespace OfiCondo.Management.Identity
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using OfiCondo.Management.Identity.Models;

    public class OfiCondoIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public OfiCondoIdentityDbContext(DbContextOptions<OfiCondoIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Initialize Users/Roles
            DbIdentityInitializer.Initialize(modelBuilder);
        }
    }
}
