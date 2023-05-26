using System.ComponentModel.DataAnnotations;

namespace WebAuth.Client.Models.Login
{
    public class UserLogin
    { 
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}