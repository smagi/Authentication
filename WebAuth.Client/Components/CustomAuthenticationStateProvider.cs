using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using WebAuth.Api.Contracts.Dtos.Login;
using WebAuth.Client.Services;

namespace WebAuth.Client.Components;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string AuthenticationType = "jwt";
    private readonly ITokenService _tokenService;
    public CustomAuthenticationStateProvider(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public void StateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenDto = await _tokenService.GetToken();
        ClaimsIdentity identity = null;
        if (IsTokenInvalid(tokenDto))
        {
            identity = new ClaimsIdentity();
        }
        else 
        { 
            identity = new ClaimsIdentity(ParseClaimsFromJwt(tokenDto.Token), AuthenticationType);
        }  

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
    private static bool IsTokenInvalid(TokenDto tokenDto)
    {
        return string.IsNullOrEmpty(tokenDto?.Token) || 
        tokenDto.Expiration < DateTime.Now;
    }

    private IEnumerable<Claim> ParseClaimsFromJwt(string jwtToken)
    {
        var payload = jwtToken.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        return keyValuePairs.Select(pair => new Claim(pair.Key, pair.Value.ToString()));
    }

    private byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        { 
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }

}
