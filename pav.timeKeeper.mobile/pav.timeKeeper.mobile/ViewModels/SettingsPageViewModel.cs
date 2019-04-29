using pav.timeKeeper.mobile.Data;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.ViewModels
{
    class SettingsPageViewModel : ViewModelBase, ISettingsPageViewModel
    {
        private IDataRepository repo;

        private ICommand dropDatabaseCommand;
        public ICommand DropDataBaseCommand
        {
            get => dropDatabaseCommand = dropDatabaseCommand ?? new Command(
                execute: () => { });
        }

        private ICommand clearActionableTasksCommand;


        public ICommand ClearActionableTasksCommand
        {
            get => clearActionableTasksCommand = clearActionableTasksCommand ?? new Command(
                execute: async () => await repo.ClearActionableTasksAsync());
        }


        public SettingsPageViewModel(IDataRepository repo)
        {
            this.repo = repo;
        }

    }
}
