using System.Threading.Tasks;
using ContactsDirectory.Domain.Models;
using MaterialDesignThemes.Wpf;

namespace ContactsDirectory.Ui.ViewModels
{
    public class EditContactViewModel:ContactViewModelBase
    {
        public EditContactViewModel(Contact contact)
        {
            Contact = contact;
            Title = "Change contact";
            FlipCommand = Flipper.FlipCommand;
        }
        protected override async Task SaveMethod()
        {
            await ContactRepository.Update(Contact);
            CloseDialogView();
        }
    }
}