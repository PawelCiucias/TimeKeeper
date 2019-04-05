using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace pav.timeKeeper.mobile.Models.Interfaces
{
    interface IProject
    {
        string ClientName { get; set; }
        string ProjectName { get; set; }
        ICollection<IProjectTask> Tasks { get; }
    }
}
