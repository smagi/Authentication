using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebAuth.Api.Services
{
    public interface IJwtTokenService
    {
        JwtSecurityToken GetUserClaimsAsync(List<Claim> userClaims);
    }
}