namespace WebAuth.Client.Models.Login;

public class UserToken
{
        public string? Token { get; init; }
        public DateTime Expiration { get; init; }
}