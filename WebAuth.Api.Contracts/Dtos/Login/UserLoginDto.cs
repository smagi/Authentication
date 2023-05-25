using System.ComponentModel.DataAnnotations;

namespace WebAuth.Api.Contracts.Dtos.Login
{
    public class UserLoginDto
    { 
        [Required]
        [EmailAddress]
        public string? Email { get; init; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; init; }
    }
}