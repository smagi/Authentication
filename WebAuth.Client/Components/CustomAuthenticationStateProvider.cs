using Microsoft.AspNetCore.Components.Authorization;

namespace WebAuth.Client.Components;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}
