using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public interface ITokenService
{
    Task<UserToken> GetToken();
    Task RemoveToken();
    Task SetToken(UserToken tokenDto);
}
