using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAuth.Api.Entities;

namespace WebAuth.Api.Infrasturcture
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            //Roles.Add(new ApplicationRole() { 
            //    Id = Guid.NewGuid(), 
            //    Name = WebAuth.Api.Entities.ApplicationUserRoles.User, 
            //    NormalizedName = WebAuth.Api.Entities.ApplicationUserRoles.User.ToLower() });

            //SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDb");
        }
    }
}