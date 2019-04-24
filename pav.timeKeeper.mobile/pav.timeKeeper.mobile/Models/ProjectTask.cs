using pav.timeKeeper.mobile.Models.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Models
{
    [Table("table_tasks")]
    class ProjectTask : BaseModel, IProjectTask
    {
        [PrimaryKey, Unique]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ProjectId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        
        bool billable;
        public bool Billable {
            get => billable;
            set => base.SetProperty(ref billable, value);
        }

        public ProjectTask(){}
        public ProjectTask(string name, Guid projectId) : this()
        {
            this.ProjectId = projectId;
            this.Name = name;
            this.Billable = true;
        }
    }
}
