namespace WebAuth.Api.Contracts.Dtos.Register
{
    public class UserRegisterResultDto
    { 
        public bool Succeesed { get; init; }
        public IEnumerable<string>? Errors { get; init; }
    }
}