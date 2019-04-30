using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace pav.timeKeeper.mobile.Models.Interfaces
{
    interface IProject : IEquatable<IProject>
    {
        Guid Id { get; }
        string ClientName { get; set; }
        string ProjectName { get; set; }
        IList<IProjectTask> Tasks { get; set; }

        void Clear();
    }
}
