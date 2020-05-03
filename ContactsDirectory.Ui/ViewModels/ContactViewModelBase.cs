using System.Threading.Tasks;
using System.Windows.Input;
using CommonServiceLocator;
using ContactsDirectory.Domain.Application;
using ContactsDirectory.Domain.Models;
using ContactsDirectory.Ui.Helpers;

namespace ContactsDirectory.Ui.ViewModels
{
    public abstract class ContactViewModelBase:DialogViewModelBase
    {

        #region Fields

        protected readonly IContactRepository ContactRepository;
        private Contact _contact;
        private ICommand _closeCommand;
        private ICommand _deleteCommand;
        private ICommand _saveCommand;

        #endregion

        #region Properties
        public ICommand FlipCommand { get; set; }
        public string Title { get; set; }
        public Contact Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChange(nameof(Contact));
            }
        }

        #endregion

        #region Constructors

        protected ContactViewModelBase()
        {
            ContactRepository = ServiceLocator.Current.GetInstance<IContactRepository>();
        }

        #endregion

        #region Methods

        protected abstract Task SaveMethod();
        protected  bool IsSaveAvailable()
            => !(string.IsNullOrEmpty(Contact.Surname) &&
                string.IsNullOrEmpty(Contact.Name) &&
                string.IsNullOrEmpty(Contact.Email) &&
                string.IsNullOrEmpty(Contact.PhoneNumber));
        #endregion

        #region Commands

        public ICommand CloseCommand
        => _closeCommand ??= new SimpleCommand
        {
            CanExecuteDelegate = _ => true,
            ExecuteDelegate = _ => { CloseDialogView(""); }
        };
        public ICommand DeleteCommand
            => _deleteCommand ??= new SimpleCommand
            {
                CanExecuteDelegate = _ => true,
                ExecuteDelegate = async _ =>
                {
                    await ContactRepository.Delete(Contact);
                    CloseDialogView("delete");
                }
            };

        public ICommand SaveCommand
            => _saveCommand ??= new SimpleCommand
            {
                CanExecuteDelegate = _ => IsSaveAvailable(),
                ExecuteDelegate = async _ =>
                {
                    await SaveMethod();
                }
            };

        #endregion

    }
}