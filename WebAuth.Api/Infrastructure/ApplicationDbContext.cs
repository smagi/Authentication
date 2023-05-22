using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebAuth.Api.Entities;

namespace WebAuth.Api.Infrasturcture
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    { 

    }
}