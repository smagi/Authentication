

using System.Net.Http.Json;
using WebAuth.Api.Contracts.Dtos.Login;
using WebAuth.Api.Contracts.Dtos.Register;

namespace WebAuth.Client.Clients;

public class AuthenticationHttpClient
{
    private readonly ILogger<AuthenticationHttpClient> _logger;
    private readonly HttpClient _httpClient;
    private readonly ITokenService _tokenService;

    public AuthenticationHttpClient(ILogger<AuthenticationHttpClient> logger, HttpClient httpClient, ITokenService tokenService)
    {
        _logger = logger;
        _httpClient = httpClient;
        _tokenService = tokenService;
    }

    public async Task<UserRegisterResultDto> RegisterUser(UserRegisterDto userRegisterDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("user/register", userRegisterDto);
            var result = await response.Content.ReadFromJsonAsync<UserRegisterResultDto>();

            return result!;

        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);

            return new UserRegisterResultDto
            {
                Succeesed = false,
                Errors = new List<string>()
                { 
                    "Registration error"
                }
            };
        }
    }

    public async Task<UserLoginResultDto?> LoginUser(UserLoginDto userLoginDto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("user/login", userLoginDto);
            var result = await response.Content.ReadFromJsonAsync<UserLoginResultDto>();
            
            await _tokenService.SetToken(result.Token);

            return result!;
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);

            return new UserLoginResultDto
            {
                Succeeded = false,
                Message = "Login error"
            };
        }
    }
    public async Task LogoutUser()
    {
        await _tokenService.RemoveToken();
        
    }
}


