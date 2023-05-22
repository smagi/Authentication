using WebAuth.Api.Contracts.Dtos.Login;

namespace WebAuth.Client.Services;

public interface ITokenService
{
    Task<TokenDto> GetToken();
    Task RemoveToken();
    Task SetToken(TokenDto tokenDto);
}
