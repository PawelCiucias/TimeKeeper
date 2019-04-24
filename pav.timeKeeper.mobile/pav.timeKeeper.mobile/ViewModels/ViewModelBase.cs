using Autofac;
using pav.timeKeeper.mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pav.timeKeeper.mobile.ViewModels
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected INavigationService navigationService;
        
        public ViewModelBase() { 
            navigationService = Bootstraper.container.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
        


        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null) {
            if (Object.Equals(backingField, value))
                return false;

            backingField = value;

            NotifyPropertyChanged(propertyName);

            return true;
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName= null)
        {
            if(!String.IsNullOrEmpty(propertyName))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
