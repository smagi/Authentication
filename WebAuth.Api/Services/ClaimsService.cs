using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using WebAuth.Api.Entities;

namespace WebAuth.Api.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimsService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<Claim>> GetUserClaims(ApplicationUser user)
        {
            List<Claim> userClaims = new()
            {
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return userClaims;
        }
    }
}