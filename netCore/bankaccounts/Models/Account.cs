using System;
using System.ComponentModel.DataAnnotations;
 
namespace bankaccounts.Models
{
    public class Account : BaseEntity
    {
        [Key]
        public int AccountId { get; set; }
        
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
        public decimal Balance { get; set; }
    }
}