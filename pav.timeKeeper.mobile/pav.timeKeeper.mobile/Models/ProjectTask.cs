using pav.timeKeeper.mobile.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Models
{
    class ProjectTask : BaseModel, IProjectTask
    {
        public string Name { get; set; }

        bool billable;
        public bool Billable {
            get => billable;
            set => base.SetProperty(ref billable, value);
        }

        public ProjectTask(){}
        public ProjectTask(string name) : this()
        {
            this.Name = name;
            this.Billable = true;
        }
    }
}
