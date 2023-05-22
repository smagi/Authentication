using System.ComponentModel.DataAnnotations;

namespace WebAuth.Api.Contracts.Dtos.Register
{
    public class UserRegisterDto
    { 
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}