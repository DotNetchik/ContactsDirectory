using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ContactsDirectory.Ui.Helpers
{
    public class Command<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public Command(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
         => canExecute != null ? canExecute((T)parameter) : true;

        public void Execute(object parameter)
         => execute((T)parameter);
    }
}
