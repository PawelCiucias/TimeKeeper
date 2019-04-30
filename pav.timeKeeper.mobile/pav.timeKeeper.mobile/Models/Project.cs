using pav.timeKeeper.mobile.Models.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace pav.timeKeeper.mobile.Models
{
    [Table("table_project")]
    class Project : BaseModel, IProject, IEquatable<IProject>
    {
        [PrimaryKey, Unique]
        public Guid Id { get; set; } = Guid.NewGuid();


        string clientName = null;
        [MaxLength(100), NotNull]
        public string ClientName
        {
            get => clientName;
            set => base.SetProperty(ref clientName, value);
        }

        string projectName = null;
        [MaxLength(100), NotNull]
        public string ProjectName
        {
            get => projectName;
            set => base.SetProperty(ref projectName, value);
        }

        [Ignore]
        public IList<IProjectTask> Tasks { get; set;  }

        public Project() => Tasks = new ObservableCollection<IProjectTask>();

        public void Clear()
        {
            Id = Guid.NewGuid();
            ClientName = string.Empty;
            ProjectName = string.Empty;
            Tasks.Clear();
        }

        public bool Equals(IProject other) => this.Id == other.Id;
    }
}
