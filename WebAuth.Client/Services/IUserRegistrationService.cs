using WebAuth.Client.Models;

namespace WebAuth.Client.Services;

public interface IRegistrationService
{
    Task<RegistrationResult> Register(RegistrationService registration);
}
