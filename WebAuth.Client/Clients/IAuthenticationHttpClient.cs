using WebAuth.Client.Models.Login;
using WebAuth.Client.Models.Register;

namespace WebAuth.Client.Clients;

public interface IAuthenticationHttpClient
{
    Task<UserRegisterResult> RegisterUser(UserRegister userRegister);
    Task<UserLoginResult> LoginUser(UserLogin userLogin);

}
