using ContactsDirectory.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDirectory.Domain.Application
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<List<Contact>> GetAll();

        IQueryable<Contact> Search();
    }
}
