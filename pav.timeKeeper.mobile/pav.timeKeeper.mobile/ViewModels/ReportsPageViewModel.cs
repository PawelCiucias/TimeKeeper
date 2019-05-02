using pav.timeKeeper.mobile.Core;
using pav.timeKeeper.mobile.Data;
using pav.timeKeeper.mobile.Models.Interfaces;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.ViewModels
{
    class ReportsPageViewModel : ViewModelBase, IReportsPageViewModel
    {
        DateTime startDate;
        public DateTime StartDate
        {
            get => startDate;
            set => base.SetProperty(ref startDate, value);
        }


        DateTime? endDate;
        public DateTime? EndDate
        {
            get => endDate;
            set => base.SetProperty(ref endDate, value);
        }


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

        private ICommand currentDayCommand;
        public ICommand CurrentDayCommand
        {
            get => currentDayCommand = currentDayCommand ?? (currentDayCommand = new Command(() =>
            {
                StartDate = DateTime.Now;
                EndDate = null;
            }));
        }

        ICommand currentWeekCommand;
        public ICommand CurrentWeekCommand
        {
            get => currentWeekCommand = currentWeekCommand ?? (currentWeekCommand = new Command(() =>
            {
                StartDate = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                EndDate = DateTime.Now.EndOfWeek(DayOfWeek.Monday);
            }));
        }

        private ICommand currentMonthCommand;

        public ICommand CurrentMonthCommand
        {
            get => currentMonthCommand = currentMonthCommand ?? (currentMonthCommand = new Command(() => {
                StartDate = DateTime.Now.FirstOfMonth();
                EndDate = DateTime.Now.LastOfMonth();

            }));
        }

    }
}
