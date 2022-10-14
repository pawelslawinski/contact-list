using ContactList.Domain;
using ContactList.Persistance.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Persistance.Repositories
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IList<Contact>> GetWorkerByNameAsync(string name);
    }
}
