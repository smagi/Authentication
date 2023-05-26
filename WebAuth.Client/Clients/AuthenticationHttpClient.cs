using System.Net.Http.Json;
using WebAuth.Api.Contracts.Dtos.Login;
using WebAuth.Api.Contracts.Dtos.Register;
using WebAuth.Client.Extensions;
using WebAuth.Client.Models;
using WebAuth.Client.Models.Login;
using WebAuth.Client.Models.Register;

namespace WebAuth.Client.Clients;
public class AuthenticationHttpClient: IAuthenticationHttpClient
{
    private readonly HttpClient _httpClient;
    public AuthenticationHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<UserRegisterResult> RegisterUser(UserRegister userRegister)
    {
        var userRegisterDto = userRegister.MapToDto();

        var response = await _httpClient.PostAsJsonAsync("user/register", userRegisterDto);
        var resultDto = await response.Content.ReadFromJsonAsync<UserRegisterResultDto>();

        var result = resultDto!.MapToModel();
        return result!;
    }

    public async Task<UserLoginResult> LoginUser(UserLogin userLogin)
    {
        var userLoginDto = userLogin.MapToDto();

        var response = await _httpClient.PostAsJsonAsync<UserLoginDto>("User/login", userLoginDto);
        var resultDto = await response.Content.ReadFromJsonAsync<UserLoginResultDto>();

        var result = resultDto!.MapToModel();
        return result!;
    }
}


