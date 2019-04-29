using System;
using System.Collections.Generic;
using System.Text;

namespace pav.timeKeeper.mobile.Models.Interfaces
{
    interface IActionableTask
    {
        Guid Id { get; set; }
        DateTime Start { get; set; }
        DateTime? End { get; set; }
        int Year { get; set; }
        int Day { get; set; }
        Guid TaskId { get; set; }
        Guid ProjectId { get; set; }
    }
}
