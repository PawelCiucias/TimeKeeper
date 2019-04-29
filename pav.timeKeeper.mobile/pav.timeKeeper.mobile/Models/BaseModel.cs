using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace pav.timeKeeper.mobile.Models
{
    abstract class BaseModel : INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null) {
            if (Object.Equals(backingField, value))
                return false;

            backingField = value;

            NotifyPropertyChanged(propertyName);

            return true;
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (!String.IsNullOrEmpty(propertyName))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
