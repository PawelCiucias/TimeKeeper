using pav.timeKeeper.mobile.Data;
using pav.timeKeeper.mobile.Models.Interfaces;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace pav.timeKeeper.mobile.ViewModels
{
    class ReportsPageViewModel : ViewModelBase, IReportsPageViewModel
    {
        public ICollection<IActionableTask> ActionableTasks { get; set; }
        IDataRepository repo;
        public ReportsPageViewModel(IDataRepository repo)
        {
            this.repo = repo;
        }

        public async Task PopulateActionableTasks()
        {

            this.ActionableTasks = new ObservableCollection<IActionableTask>(await repo.ReadAllActionableTasksAsync());
            base.NotifyPropertyChanged(nameof(ActionableTasks));
        }
    }
}
