using pav.timeKeeper.mobile.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace pav.timeKeeper.mobile.Models
{
    class Project : BaseModel, IProject
    {
        string clientName = null;
        public string ClientName {
            get => clientName ?? "Client Name";
            set => base.SetProperty(ref clientName, value);
        }
        string projectName = null;
        public string ProjectName {
            get => projectName ?? "Project name";
            set => base.SetProperty(ref projectName, value);
        }

        public ICollection<IProjectTask> Tasks { get; }

        public Project()
        {
            Tasks = new ObservableCollection<IProjectTask>();
        }
    }
}
