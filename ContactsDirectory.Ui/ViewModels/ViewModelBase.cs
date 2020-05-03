using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactsDirectory.Ui.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            this?.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
