using System.Collections.Generic;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;

namespace ContactsDirectory.Ui.ViewModels
{
    public abstract class DialogViewModelBase : ViewModelBase
    {
        private static DialogSession Session { get; set; }
        private static Stack<object> ModelsStack { get; set; } = new Stack<object>();
        private const string DialogHostId = "RootDialogHostId";
        protected Task<object> ShowDialogView(object content)
        {
            ModelsStack.Push(content);
            return DialogHost.Show(ModelsStack.Peek(), DialogHostId, new DialogOpenedEventHandler(
                (sender, args) => { Session = args.Session; }));
        }
        protected void CloseDialogView()
        {
            ModelsStack.Clear();
            Session.Close(null);
        }
    }
}