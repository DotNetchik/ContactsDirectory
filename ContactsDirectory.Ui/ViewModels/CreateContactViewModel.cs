using System.Threading.Tasks;
using ContactsDirectory.Domain.Models;
using ContactsDirectory.Ui.Helpers;

namespace ContactsDirectory.Ui.ViewModels
{
    public class CreateContactViewModel : ContactViewModelBase
    {
        public CreateContactViewModel()
        {
            Contact = new Contact();
            Title = "Create new contact";
            FlipCommand=new SimpleCommand{ExecuteDelegate = _=>
            {
                CloseDialogView();
            }};
        }
        protected override async Task SaveMethod()
        {
            await ContactRepository.Add(Contact);
            CloseDialogView();
        }
    }
}