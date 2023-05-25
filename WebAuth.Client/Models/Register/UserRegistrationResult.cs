namespace WebAuth.Client.Models.Register;

public class UserRegisterResult
{
        public bool Succeesed { get; init; }
        public IEnumerable<string>? Errors { get; init; }
}
