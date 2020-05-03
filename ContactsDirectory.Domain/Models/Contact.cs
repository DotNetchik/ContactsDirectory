using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDirectory.Domain.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
