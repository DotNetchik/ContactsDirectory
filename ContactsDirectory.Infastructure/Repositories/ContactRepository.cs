using ContactsDirectory.Domain.Application;
using ContactsDirectory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsDirectory.Infastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactContext _contactContext;

        public ContactRepository(ContactContext contactContext)
        {
            _contactContext = contactContext ?? throw new ArgumentNullException(nameof(contactContext));
        }

        public async Task<Contact> Add(Contact entity)
        {
            await _contactContext.Contacts.AddAsync(entity);
            await _contactContext.SaveChangesAsync();
            return entity;
        }

        public Task Delete(Contact entity)
        {
            _contactContext.Contacts.Remove(entity);
            return _contactContext.SaveChangesAsync();
        }

        public Task<Contact> Get(int id)
            => _contactContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);

        public Task<List<Contact>> GetAll()
        => _contactContext.Contacts.OrderBy(x=>x.Surname).ToListAsync();

        public IQueryable<Contact> Search()
         => _contactContext.Contacts;

        public Task Update(Contact entity)
        {
            _contactContext.Contacts.Update(entity);
            return _contactContext.SaveChangesAsync();
        }
    }
}
