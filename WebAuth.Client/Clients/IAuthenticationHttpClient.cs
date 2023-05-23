using WebAuth.Api.Contracts.Dtos.Login;
using WebAuth.Api.Contracts.Dtos.Register;

namespace WebAuth.Client.Clients;

public interface IAuthenticationHttpClient
{
    Task<UserRegisterResultDto> RegisterUser(UserRegisterDto userRegisterDto);
    Task<UserLoginResultDto?> LoginUser(UserLoginDto userLoginDto);

}
