namespace WebAuth.Api.Contracts.Dtos.Login
{
    public class UserTokenDto
    { 
        public string? Token { get; init; }
        public DateTime? Expiration { get; init; }
    }
}