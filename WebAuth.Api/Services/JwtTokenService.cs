using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebAuth.Api.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtTokenSettings _jwtTokenSettings;
        public JwtTokenService(IOptions<JwtTokenSettings> jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings.Value;
        }
        public JwtSecurityToken GetUserClaimsAsync(List<Claim> userClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_jwtTokenSettings.Secret!));

            var token = new JwtSecurityToken(
                issuer: _jwtTokenSettings.ValidIssuer,
                audience: _jwtTokenSettings.ValidAudience,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(_jwtTokenSettings.ExpiryInMinutes),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }
    }
}