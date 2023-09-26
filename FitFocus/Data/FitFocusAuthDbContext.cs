using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitFocus.Data
{
    public class FitFocusAuthDbContext : IdentityDbContext
    {
        public FitFocusAuthDbContext(DbContextOptions<FitFocusAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed the roles (user, admin, super admin)

            var adminRoleId = "30d283d1-d27c-44a8-9f2f-68b62a89a9ef";
            var superAdminRoleId = "c897809a-6f9c-42df-b2a0-dadd5dd7500e";
            var userRoleId = "ba9635b7-88cd-4f86-8d1d-2473e5767d61";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed superAdminUser
            var userName = "superadmin@sa.com";
            var superAdminId = "9b8de756-ab7e-4424-b9ec-b380802e54d8";
            var superAdminUser = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                NormalizedEmail = userName.ToUpper(),
                NormalizedUserName = userName.ToUpper(),
                Id = superAdminId,
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Champion12$");

            builder.Entity<IdentityUser>().HasData(superAdminUser);


            // add all roles to superAdmin
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
