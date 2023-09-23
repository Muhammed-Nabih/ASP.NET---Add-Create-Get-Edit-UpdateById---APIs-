using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sallaty.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Create Reader and Writer

            var readerRoledId = "7f09f4a3-4e8d-43de-9daa-3490e7ac9f1a";
            var WriterRoledId = "e61c4017-13d2-45fd-86b5-56d4fdf60d3b";
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoledId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoledId
                },
                new IdentityRole()
                {
                    Id = WriterRoledId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = WriterRoledId
                }
            };


            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Create An Admin user
            var adminUserId = "cfac213e-81bc-455f-b7f6-bd20709b7f96";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@Sallaty.com",
                Email = "admin@Sallaty.com",
                NormalizedEmail = "admin@Sallaty.com".ToUpper(),
                NormalizedUserName = "admin@Sallaty.com".ToUpper(),

            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            //Give Roles To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoledId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = WriterRoledId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
