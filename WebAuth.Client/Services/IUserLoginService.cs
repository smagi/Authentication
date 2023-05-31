using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public interface IUserLoginService
{
    Task<UserLoginResult> Login(UserLogin login);
    Task Logout();
}