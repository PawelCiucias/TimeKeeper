using System;
using System.Collections.Generic;
using System.Text;

namespace pav.timeKeeper.mobile.Models.Interfaces
{
    interface IProjectTask
    { 
        string Name { get; set; }
        bool Billable { get; set; }
    }
}
