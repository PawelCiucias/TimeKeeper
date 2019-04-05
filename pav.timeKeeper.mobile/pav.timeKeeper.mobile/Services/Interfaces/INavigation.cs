using pav.timeKeeper.mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pav.timeKeeper.mobile.Services.Interfaces
{
    interface INavigationService
    {
        ViewModelBase PreviousPageViewModel { get; }

        Task GoBackAsync();
        Task InitializeAsync();
        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync();
    }
}