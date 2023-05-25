namespace WebAuth.Api.Contracts.Dtos.Login
{
    public class UserLoginResultDto
    { 
        public bool Succeeded  { get; init; }
        public string? Message { get; init; }
        public UserTokenDto? Token { get; init; }
    }
}