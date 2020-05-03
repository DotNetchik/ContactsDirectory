using System;
using System.Windows.Input;

namespace ContactsDirectory.Ui.Helpers
{
    public class SimpleCommand: ICommand
    {
        public Action<object> ExecuteDelegate { get; set; }
        public Predicate<object> CanExecuteDelegate { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
         => CanExecuteDelegate == null|| CanExecuteDelegate(parameter);

        public void Execute(object parameter)
         => ExecuteDelegate?.Invoke(parameter);
    }
}
