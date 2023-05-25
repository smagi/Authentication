using WebAuth.Client.Models.Register;

namespace WebAuth.Client.Services;

public interface IUserRegistrationService
{
    Task<UserRegisterResult> Register(UserRegister userRegister);
}
