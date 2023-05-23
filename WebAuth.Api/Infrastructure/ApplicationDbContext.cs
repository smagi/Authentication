using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAuth.Api.Entities;

namespace WebAuth.Api.Infrasturcture
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Roles.Add(new ApplicationRole() { Id = Guid.NewGuid(), Name = "USER", NormalizedName = "USER" });
            Roles.Add(new ApplicationRole() { Id = Guid.NewGuid(), Name = "Admin" });

            SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }
    }
}