using pav.timeKeeper.mobile.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace pav.timeKeeper.mobile.ViewModels.Interfaces
{
    interface IReportsPageViewModel
    {
        ICollection<IActionableTask> ActionableTasks { get; set; }
    }
}
