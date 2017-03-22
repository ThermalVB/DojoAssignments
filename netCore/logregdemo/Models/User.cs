using System.ComponentModel.DataAnnotations;
 
namespace logregdemo.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and Password Confirmation must match")]
        public string PasswordConfirmation { get; set; }

    }
}