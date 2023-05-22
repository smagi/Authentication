namespace WebAuth.Api.Contracts.Dtos.Login
{
    public class TokenDto
    { 
        public string? Token { get; init; }
        public DateTime Expiration { get; init; }
    }
}