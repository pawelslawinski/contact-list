using ContactList.Domain;
using ContactList.Persistance.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Persistance.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base (context)
        {
        }
        public async Task<IList<Contact>> GetWorkerByNameAsync(string name)
        {
            return await _context.Contacts.Where(c => c.Name == name).ToListAsync();   
        }
    }
}
