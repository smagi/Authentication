using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using WebAuth.Client.Services;

namespace WebAuth.Client.Components;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ITokenService _tokenService;
<<<<<<< HEAD
    private readonly TokenValidatorService _tokenValidatorService;
    public CustomAuthenticationStateProvider(ITokenService tokenService, TokenValidatorService tokenValidatorServcie)
=======
    private readonly ITokenValidationService _tokenValidatorServcie;
    public CustomAuthenticationStateProvider(ITokenService tokenService, ITokenValidationService tokenValidatorServcie)
>>>>>>> 8c75642756cb4ac03af800dd7b977c7984804aa5
    {
        _tokenService = tokenService;
        _tokenValidatorService = tokenValidatorServcie;
    }
    public void StateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await _tokenService.GetToken();

        ClaimsIdentity identity = _tokenValidatorService.Validate(token);

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }
}