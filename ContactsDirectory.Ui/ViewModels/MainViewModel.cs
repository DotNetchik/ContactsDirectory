using ContactsDirectory.Domain.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDirectory.Ui.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IContactRepository _contactRepository;

        public MainViewModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            //var tt = _contactRepository.Add(new Domain.Models.Contact { Name = "fff" }).Result;
        }


    }
}
