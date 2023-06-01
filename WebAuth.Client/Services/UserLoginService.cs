using WebAuth.Client.Clients;
using WebAuth.Client.Components;
using WebAuth.Client.Models;
using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public class UserLoginService : IUserLoginService
{
    private readonly ILogger<AuthenticationHttpClient> _logger;
    private readonly ITokenService _tokenService;
    private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;
    private readonly AuthenticationHttpClient _authenticationHttpClient;
    public UserLoginService(
        ILogger<AuthenticationHttpClient> logger, 
        ITokenService tokenService, 
        CustomAuthenticationStateProvider customAuthenticationStateProvider, 
        AuthenticationHttpClient authenticationHttpClient)
    {
        _logger = logger;
        _tokenService = tokenService;
        _customAuthenticationStateProvider = customAuthenticationStateProvider;
        _authenticationHttpClient = authenticationHttpClient;
    }
    public async Task<UserLoginResult> Login(UserLogin login)
    {
        try
        { 
            var result =await  _authenticationHttpClient.LoginUser(login);

            if (result.Succeeded)
            {
                var token = result.Token ?? throw new ArgumentException(nameof(result.Token));

                await _tokenService.SetToken(token);

                _customAuthenticationStateProvider.StateChanged();
            }
        return result;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);

            return new  UserLoginResult
            {
                Succeeded = false,
                Message = "Login error"
            };
        }
    }
    public async Task Logout()
    {
        await _tokenService.RemoveToken();
        
        _customAuthenticationStateProvider.StateChanged();
        
    }
}