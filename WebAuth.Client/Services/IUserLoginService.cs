using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public interface ILoginService
{
    Task<UserLoginResult> Login(UserLogin login);
    Task Logout();
}