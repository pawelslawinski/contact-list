using Microsoft.AspNetCore.Identity;

namespace ContactList.Domain
{
    /// <summary>
    /// Class for the user entity
    /// </summary>
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }

    }
}