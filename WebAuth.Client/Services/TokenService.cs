using Blazored.LocalStorage;
using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public class TokenService : ITokenService
{
    private readonly ILocalStorageService _localStorageService;
    private const string Key = "token";
    public TokenService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }
    public async Task<UserToken> GetToken()
    {
        return await _localStorageService.GetItemAsync<UserToken>(Key);
    }
    public async Task RemoveToken()
    {
        await _localStorageService.RemoveItemAsync(Key);
    }
    public async Task SetToken(UserToken token)
    {   
        await _localStorageService.SetItemAsync(Key, token);
    }
}
