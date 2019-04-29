using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.ViewModels
{
    class SettingsPageViewModel : ViewModelBase
    {
        private ICommand dropDatabaseCommand;

        public ICommand DropDataBaseCommand
        {
            get => dropDatabaseCommand = dropDatabaseCommand ?? new Command(
                execute: () => { });
  
        }

    }
}
