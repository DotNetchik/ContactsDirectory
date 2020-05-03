using Microsoft.EntityFrameworkCore.Design;

namespace ContactsDirectory.Infastructure
{
    public class ContactContextFactory : IDesignTimeDbContextFactory<ContactContext>
    {
        public ContactContext CreateDbContext(string[] args)
            =>  new ContactContext("Data Source=Contacts.db");
        
    }
}
