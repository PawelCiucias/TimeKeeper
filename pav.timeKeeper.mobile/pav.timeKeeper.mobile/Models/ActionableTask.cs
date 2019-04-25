using pav.timeKeeper.mobile.Core;
using pav.timeKeeper.mobile.Models.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace pav.timeKeeper.mobile.Models
{
    [Table(nameof(Constants.table_ActionableTask))]
    class ActionableTask : BaseModel, IActionableTask
    {
        [PrimaryKey, Unique]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Guid TaskId { get; set; }
        public Guid ProjectId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public int Day { get; set; } = DateTime.Now.DayOfYear;

        public ActionableTask() => this.Start = DateTime.Now;

        public ActionableTask(Guid projectId, Guid taskId) : this()
        {
            this.ProjectId = projectId;
            this.TaskId = taskId;
        }
        public ActionableTask(Guid projectId, Guid taskId, Guid actionId) : this(projectId, taskId)
        {
            
        }
    }
}
