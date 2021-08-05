namespace OfiCondo.Management.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OfiCondo.Management.Identity.Models;
    using System;

    public static class DbIdentityInitializer
    {
        public static void Initialize(ModelBuilder modelBuilder)
        {
            // User ID
            string UserAdminID = Guid.NewGuid().ToString();
            // Roles definition.
            var roles = (
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            );

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole 
            { 
                Id = roles.Item1,
                Name = "Admin", 
                NormalizedName = "Admin".ToUpper() 
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole 
            { 
                Id = roles.Item2,
                Name = "Developer", 
                NormalizedName = "Developer".ToUpper() 
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole 
            { 
                Id = roles.Item3,
                Name = "Owner", 
                NormalizedName = "Owner".ToUpper() 
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole 
            { 
                Id = roles.Item4,
                Name = "User", 
                NormalizedName = "User".ToUpper() 
            });

            var user = new ApplicationUser
            {
                Id = UserAdminID,
                Email = "elymichael@sitcsrd.com",
                EmailConfirmed = true,
                NormalizedEmail = "elymichael@sitcsrd.com".ToUpper(),
                UserName = "administrador",
                NormalizedUserName = "administrador".ToUpper(),                
                SecurityStamp = string.Empty,
                FirstName = "Admin",
                LastName = "Admin",
            };

            user.PasswordHash = PassGenerate(user, "administrador");

            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.Item1, UserId = UserAdminID
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.Item2,
                UserId = UserAdminID
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.Item3,
                UserId = UserAdminID
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roles.Item4,
                UserId = UserAdminID
            });
        }

        private static string PassGenerate(ApplicationUser user, string password)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, password);
        }
    }
}
