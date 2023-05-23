using Blazored.LocalStorage;
using WebAuth.Api.Contracts.Dtos.Login;

namespace WebAuth.Client.Services;

public class TokenService : ITokenService
{
    private readonly ILocalStorageService _localStorageService;
    private const string Key = "token";
    public TokenService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<TokenDto> GetToken()
    {
        return await _localStorageService.GetItemAsync<TokenDto>(Key);
    }

    public async Task RemoveToken()
    {
        await _localStorageService.RemoveItemAsync(Key);
    }

    public async Task SetToken(TokenDto tokenDto)
    {   
        await _localStorageService.SetItemAsync(Key, tokenDto);
    }
}
