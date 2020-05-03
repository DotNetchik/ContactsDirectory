using ContactsDirectory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactsDirectory.Infastructure
{
    public class ContactContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Contact> Contacts { get; set; }

        public ContactContext(string connectionString) : base()
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Name = "Grisha",
                    Surname = "Grigoriev",
                    Email = null,
                    PhoneNumber = "+3759379992"
                },
                new Contact
                {
                    Id = 2,
                    Name = "Misha",
                    Surname = "Mikhailov",
                    Email = null,
                    PhoneNumber = "+3759111233212"
                },
                new Contact
                {
                    Id = 3,
                    Name = "Gena",
                    Surname = "Genadiev",
                    Email = "Gena@gmail.com",
                    PhoneNumber = null
                },
                new Contact
                {
                    Id = 4,
                    Name = "Vitya",
                    Surname = "Vityushev",
                    Email = "Vitalya@gmail.com",
                    PhoneNumber = "+3759323423423"
                },
                new Contact
                {
                    Id = 5,
                    Name = "Larisa",
                    Surname = "Dolina",
                    Email = "Lora@mail.ru",
                    PhoneNumber = "+37523423423423"
                },new Contact
                {
                    Id = 6,
                    Name = "Arapityan",
                    Surname = "Arapityanovich",
                    Email = "Ara@mail.ru",
                    PhoneNumber = "+37523423423423"
                });
        }
    }
}
