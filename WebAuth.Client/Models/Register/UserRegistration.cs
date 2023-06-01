using System.ComponentModel.DataAnnotations;

namespace WebAuth.Client.Models.Register;

public class UserRegister
{
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm  Password doesn't match, Try again !")]
        [Required]
        public string? ConfirmPassword { get; set; }
}
