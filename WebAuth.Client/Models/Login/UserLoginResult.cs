namespace WebAuth.Client.Models.Login;

public class UserLoginResult
{
        public bool Succeeded  { get; init; }
        public string? Message { get; init; }
        public UserToken? Token { get; init; }
}
