using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ContactList.Domain
{
    /// <summary>
    /// Class for the user entity
    /// </summary>
    public class UserLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "your password must contain at least one special character, digits, uppercases and lowercases.")]
        public string Password { get; set; }

    }
}