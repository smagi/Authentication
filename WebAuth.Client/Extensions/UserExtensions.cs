using WebAuth.Api.Contracts.Dtos.Login;
using WebAuth.Api.Contracts.Dtos.Register;
using WebAuth.Client.Models.Login;
using WebAuth.Client.Models.Register;

namespace WebAuth.Client.Extensions;

public static class UserExtensions
{
    public static UserTokenDto MapToDto(this UserToken userToken)
    {
        return new UserTokenDto
        { 
            Expiration = userToken.Expiration,
            Token = userToken.Token
        };
    }
    public static UserToken MapToModel(this UserTokenDto userTokenDto)
    {
        return new UserToken
        { 
            Expiration = userTokenDto.Expiration!.Value,
            Token = userTokenDto.Token
        };
    }
    public static UserLoginDto MapToDto(this UserLogin userLogin)
    {
        return new UserLoginDto
        { 
            Email = userLogin.Email,
            Password = userLogin.Password
        };
    }
    public static UserLogin MapToModel(this UserLoginDto userLoginDto)
    {
        return new UserLogin
        { 
            Email = userLoginDto.Email,
            Password = userLoginDto.Password
        };
    }
    public static UserLoginResultDto MapToDto(this UserLoginResult userLogin)
    {
        return new UserLoginResultDto
        { 
            Succeeded = userLogin.Succeeded,
            Message = userLogin.Message
        };
    }
    public static UserLoginResult MapToModel(this UserLoginResultDto userLoginResultDto)
    {
        var tokenDto = userLoginResultDto.Token;

        var token = tokenDto is null ? null : tokenDto.MapToModel();

        return new UserLoginResult
        { 
            Message = userLoginResultDto.Message,
            Succeeded = userLoginResultDto.Succeeded,
            Token = token
        };
    }
    public static UserRegisterDto MapToDto(this UserRegister userLogin)
    {
        return new UserRegisterDto
        { 
            Email = userLogin.Email,
            Password = userLogin.Password
        };
    }
    public static UserRegisterResultDto MapToDto(this UserRegisterResult userRegisterResult)
    {
        return new UserRegisterResultDto
        { 
            Errors = userRegisterResult.Errors,
            Succeesed = userRegisterResult.Succeesed
        };
    }
    public static UserRegister MapToModel(this UserRegisterDto userLoginDto)
    {
        return new UserRegister
        { 
            Email = userLoginDto.Email,
            Password = userLoginDto.Password
        };
    }
    public static UserRegisterResult MapToModel(this UserRegisterResultDto userRegisterResultDto)
    {
        return new UserRegisterResult
        {
            Succeesed = userRegisterResultDto.Succeesed,
            Errors = userRegisterResultDto.Errors
        };
    }
}
