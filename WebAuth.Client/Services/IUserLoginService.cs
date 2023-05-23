using WebAuth.Client.Models;

namespace WebAuth.Client.Services;

public interface ILoginService
{
    Task<LoginResult> Login(Login login);
}