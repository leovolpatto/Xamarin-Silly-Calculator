using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calculadora.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string pName)
        {
            var changed = this.PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
            }
        }
    }
}
