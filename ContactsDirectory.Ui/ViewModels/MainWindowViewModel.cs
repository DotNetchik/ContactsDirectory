using ContactsDirectory.Domain.Application;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ContactsDirectory.Domain.Models;
using ContactsDirectory.Ui.Helpers;
using ContactsDirectory.Ui.Views;

namespace ContactsDirectory.Ui.ViewModels
{
    public class MainWindowViewModel : DialogViewModelBase
    {
        #region Fields

        private readonly IContactRepository _contactRepository;
        private string _searchKeyword;
        private ObservableCollection<Contact> _filteredContacts;
        private ObservableCollection<Contact> _allContacts;
        private Contact _selectedContact;
        private ICommand _closeCommand;
        private ICommand _showEditContatViewCommand;
        private ICommand _showCreateContactViewCommand;

        #endregion

        #region Property
        public string SearchKeyword
        {
            get => _searchKeyword;
            set
            {
                _searchKeyword = value;
                FilterContacts(_searchKeyword);
            }
        }
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChange(nameof(SelectedContact));
                
            }
        }

        public ObservableCollection<Contact> FilteredContacts
        {
            get => _filteredContacts;
            set
            {
                _filteredContacts = value;
                OnPropertyChange(nameof(FilteredContacts));
            }
        }
        #endregion

        #region Construtors

        public MainWindowViewModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            
            RefreshContactsList();
        }

        #endregion

        #region Methods

        private  void RefreshContactsList()
        {
            _allContacts = new ObservableCollection<Contact>( _contactRepository.GetAll().Result);
            FilterContacts(null);
        }
        private async void ShowEditContactControl(Contact contact)
        {
            if(contact==null)
                return;

            var vm = new EditContactViewModel(contact);
            var view = new ContactDetailsControl {DataContext = vm};

            await ShowDialogView(view);

            RefreshContactsList();
        }
        private async void ShowCreateContactControl()
        {

            var vm = new CreateContactViewModel();
            var view = new ChangeContactDetailsControl {DataContext = vm};

            await ShowDialogView(view);

            RefreshContactsList();
        }

        private void FilterContacts(string keyword)
        {
            var filteredContacts =
                string.IsNullOrWhiteSpace(keyword)
                    ? _allContacts
                    : _allContacts.Where(x => x.Surname.ToUpper().Contains(keyword.ToUpper()));

            FilteredContacts = new ObservableCollection<Contact>(filteredContacts);
        }

        #endregion

        #region Commands

        public ICommand CloseCommand
            => _closeCommand ??= new SimpleCommand
            {
                CanExecuteDelegate = _ => true,
                ExecuteDelegate = _ =>
                {
                    Application.Current.Shutdown();
                }
            };
        public ICommand ShowEditContactViewCommand
            => _showEditContatViewCommand ??= new SimpleCommand
            {
                CanExecuteDelegate = _ => true,
                ExecuteDelegate = _ =>
                {
                    if (SelectedContact == null)
                        return;
                    ShowEditContactControl(SelectedContact);
                }
            };
        public ICommand ShowCreateContactViewCommand
            => _showCreateContactViewCommand ??= new SimpleCommand
            {
                CanExecuteDelegate = _ => true,
                ExecuteDelegate = _ =>
                {
                    ShowCreateContactControl();
                }
            };

        #endregion

    }
}
