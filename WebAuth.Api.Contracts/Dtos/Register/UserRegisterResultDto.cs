namespace WebAuth.Api.Contracts.Dtos.Register
{
    public class UserRegisterResultDto
    { 
        public bool Succeesed { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}