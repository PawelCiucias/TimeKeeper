using pav.timeKeeper.mobile.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace pav.timeKeeper.mobile.ViewModels.Interfaces
{
    interface IProjectPageViewModel
    {
        IProject Project { get; set; }
        string TaskName { get; set; }

        ICommand AddTaskCommand { get; }
        ICommand SaveProjectCommand { get; }
        ICommand DeleteTaskCommand { get;  }
    }
}
