using pav.timeKeeper.mobile.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace pav.timeKeeper.mobile.ViewModels.Interfaces
{
    interface IMainPageViewModel
    {
        IProject ActiveProject { get; set; }

        ICommand CreateProjectCommand { get; }
    }
}
