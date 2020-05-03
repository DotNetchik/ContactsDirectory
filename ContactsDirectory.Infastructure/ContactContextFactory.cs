using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDirectory.Infastructure
{
    public class ContactContextFactory : IDesignTimeDbContextFactory<ContactContext>
    {
        public ContactContext CreateDbContext(string[] args)
            =>  new ContactContext("Data Source=Contacts.db");
        
    }
}
