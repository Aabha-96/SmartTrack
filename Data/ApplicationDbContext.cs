using Microsoft.EntityFrameworkCore;
using SmartTrack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SmartTrack.Data
{
    public class ApplicationUser : IdentityUser 
    {
        public string?FullName { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID=1,
                    FirstName="Anagha",
                    MiddleName="S",
                    LastName="Chandran",
                    EmailAddress="anagha123@gmail.com",
                    PhoneNumber="413-987-657",
                    Address="N2W-5Y7,Kitchener",
                    DateofBirth=new DateTime(1996,10,13),
                    Department="IT",
                    Designation="Analyst",
                    HireDate=new DateTime(2024,09,21),
                    IsActive=true}
                );
            // --- Seed Admin Role ---
            const string ADMIN_ROLE_ID = "b27a8f28-0b9b-4d4d-8c5b-12ab34cd56ef";
            const string ADMIN_USER_ID = "a12c3d45-678e-9fab-bc12-3456de7890ff";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // --- Seed Admin User ---
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_USER_ID,
                UserName = "admin@demo.com",
                NormalizedUserName = "ADMIN@DEMO.COM",
                Email = "admin@demo.com",
                NormalizedEmail = "ADMIN@DEMO.COM",
                EmailConfirmed = true,
                FullName = "Default Admin",
                PasswordHash = hasher.HashPassword( null , "Password123!") // default password
            });

            // --- Assign user to Role ---
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = ADMIN_USER_ID,
                RoleId = ADMIN_ROLE_ID
            });


        }
    }
}
