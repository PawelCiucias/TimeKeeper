using pav.timeKeeper.mobile.Models;
using pav.timeKeeper.mobile.Models.Interfaces;
using pav.timeKeeper.mobile.Services.Interfaces;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.ViewModels
{
    class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        public IProject ActiveProject { get; set; } = new Project();

        ICommand createProjectCommand;
        public ICommand CreateProjectCommand  {
            get {
                createProjectCommand  = createProjectCommand ?? 
                    new Command(async () => await base.navigationService.NavigateToAsync<ProjectPageViewModel>());
                return createProjectCommand;
            }
        }
    }
}
