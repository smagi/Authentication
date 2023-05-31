using System.Security.Claims;
using WebAuth.Client.Models.Login;

namespace WebAuth.Client.Services;

public interface ITokenValidationService
{
    ClaimsIdentity Validate(UserToken userToken);
}