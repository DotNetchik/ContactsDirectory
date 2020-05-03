using ContactsDirectory.Domain.Application;
using ContactsDirectory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContactsDirectory.Infastructure
{
    public class ContactContext : DbContext
    {
        private readonly string connectionString;

        public DbSet<Contact> Contacts { get; set; }

        public ContactContext(string connectionString) : base()
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: add default entitys
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id =1,
                   Name = "aaa"
                },
                          new Contact
                          {
                              Id =5,
                              Name = "bbbb"
                          }
            );
        }
    }
}
