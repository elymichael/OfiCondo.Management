namespace OfiCondo.Management.Persistence.InterationTests.Base.Context
{
    using Microsoft.AspNetCore.Identity;
    using OfiCondo.Management.Domain.Entities;
    using OfiCondo.Management.Identity;
    using OfiCondo.Management.Identity.Models;
    using System;
    public class IdentityContextFactory
    {
        public static void Initialize(OfiCondoIdentityDbContext ofiCondoDbContext, string userAdminID)
        {            
            // Roles definition.
            var roles = (
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            );

            ofiCondoDbContext.Roles.Add(new IdentityRole
            {
                Id = roles.Item1,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });

            ofiCondoDbContext.Roles.Add(new IdentityRole
            {
                Id = roles.Item2,
                Name = "Developer",
                NormalizedName = "Developer".ToUpper()
            });

            ofiCondoDbContext.Roles.Add(new IdentityRole
            {
                Id = roles.Item3,
                Name = "Owner",
                NormalizedName = "Owner".ToUpper()
            });

            ofiCondoDbContext.Roles.Add(new IdentityRole
            {
                Id = roles.Item4,
                Name = "User",
                NormalizedName = "User".ToUpper()
            });

            var user = new ApplicationUser
            {
                Id = userAdminID,
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

            ofiCondoDbContext.Users.Add(user);

            ofiCondoDbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = roles.Item1,
                UserId = userAdminID
            });

            ofiCondoDbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = roles.Item2,
                UserId = userAdminID
            });

            ofiCondoDbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = roles.Item3,
                UserId = userAdminID
            });

            ofiCondoDbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = roles.Item4,
                UserId = userAdminID
            });
        }
        private static string PassGenerate(ApplicationUser user, string password)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, password);
        }
    }
}
