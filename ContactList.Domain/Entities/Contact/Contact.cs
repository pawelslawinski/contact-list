using ContactList.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Domain
{
    /// <summary>
    /// Class for the contact entity
    /// </summary>
    public class Contact : BaseEntity
    {
        public string Name { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

    }
}