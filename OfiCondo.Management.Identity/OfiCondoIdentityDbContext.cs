namespace OfiCondo.Management.Identity
{
    using OfiCondo.Management.Identity.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class OfiCondoIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public OfiCondoIdentityDbContext(DbContextOptions<OfiCondoIdentityDbContext> options) : base(options)
        {

        }
    }
}
