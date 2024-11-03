using Landing.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;

namespace Landing.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var UserId = Guid.NewGuid().ToString();
            var AdminId = Guid.NewGuid().ToString();
            var SuperAdminId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = UserId, Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = AdminId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = SuperAdminId, Name = "superAdmin", NormalizedName = "SUPERADMIN" }
            );

            var User = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "User@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Email = "User@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM"
            };
            var Admin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM"
            };
            var SuperAdmin = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "superadmin@gmail.com",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM"
            };
            builder.Entity<ApplicationUser>().HasData(User, Admin, SuperAdmin);

            var hasher = new PasswordHasher<ApplicationUser>();
            User.PasswordHash = hasher.HashPassword(User, "Saif@1234");
            Admin.PasswordHash = hasher.HashPassword(Admin, "Saif@1234");
            SuperAdmin.PasswordHash = hasher.HashPassword(SuperAdmin, "Saif@1234");
            builder.Entity<IdentityUserRole<string>>().HasData(
                  new IdentityUserRole<string>
                  {
                      UserId = User.Id,
                      RoleId = UserId
                  },
                  new IdentityUserRole<string>
                  {
                      UserId = Admin.Id,
                      RoleId = AdminId
                  },
                  new IdentityUserRole<string>
                  {
                      UserId = SuperAdmin.Id,
                      RoleId = SuperAdminId
                  }
                );
        }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
