using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public class TokenValidatorServcie: ITokenValidationService
{
    private const string AuthenticationType = "jwt";
    private readonly TokenValidator _userTokenValidator;
    public TokenValidatorServcie(TokenValidator userTokenValidator)
    {
        _userTokenValidator = userTokenValidator;
    }
    public ClaimsIdentity Validate(UserToken userToken)
    {
            var result = _userTokenValidator.Validate(userToken);

            ClaimsIdentity identity = result.IsValid ? GetClaimsIdentity(userToken) : new ClaimsIdentity();

            return identity;
    }
    private static ClaimsIdentity GetClaimsIdentity(UserToken token)
    {
        var jwtString = token.Token;

        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(jwtString);

        return new ClaimsIdentity(jwt.Claims, AuthenticationType);;
    }
}