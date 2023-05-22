using System.Security.Claims;
using WebAuth.Api.Entities;

namespace WebAuth.Api.Services
{
    public interface IClaimsService
    {
        Task<List<Claim>> GetUserClaims(ApplicationUser user);
    }
}