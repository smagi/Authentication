using WebAuth.Client.Clients;
using WebAuth.Client.Models.Register;

namespace WebAuth.Client.Services;

public class UserRegistrationService : IUserRegistrationService
{
    private readonly ILogger<AuthenticationHttpClient> _logger;
    private readonly  AuthenticationHttpClient _authenticationHttpClient;
    public UserRegistrationService(ILogger<AuthenticationHttpClient> logger, AuthenticationHttpClient authenticationHttpClient)
    {
        _logger = logger;
        _authenticationHttpClient = authenticationHttpClient;
    }
    public async Task<UserRegisterResult> Register(UserRegister userRegister)
    {
        try
        {
            return await _authenticationHttpClient.RegisterUser(userRegister);
        }
        catch(Exception exception)
        {
            _logger.LogError(exception.Message);

            return new UserRegisterResult
            {
                Succeesed = false,
                Errors = new List<string>{ "Registration error" }
            };
        }
    }
}
