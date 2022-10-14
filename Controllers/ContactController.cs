using ContactList.Domain;
using ContactList.Persistance.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{

    [Authorize(Roles = "User")]
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger, IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IList<Contact>> GetContacts()
        {
            var x =  await _contactRepository.GetAllAsync();

            return x;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Contact> GetContact(int id)
        {
            var x = await _contactRepository.GetByIdAsync(id);

            return x;

        }
    }
}