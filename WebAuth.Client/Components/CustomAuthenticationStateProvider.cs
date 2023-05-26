using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using WebAuth.Client.Services;

namespace WebAuth.Client.Components;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ITokenService _tokenService;
    private readonly TokenValidatorServcie _tokenValidatorServcie;
    public CustomAuthenticationStateProvider(ITokenService tokenService, TokenValidatorServcie tokenValidatorServcie)
    {
        _tokenService = tokenService;
        _tokenValidatorServcie = tokenValidatorServcie;
    }
    public void StateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _tokenService.GetToken();

        ClaimsIdentity identity = _tokenValidatorServcie.Validate(token);

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
   
}