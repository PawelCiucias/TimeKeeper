using pav.timeKeeper.mobile.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pav.timeKeeper.mobile.Data
{
    interface IDataRepository
    {
        Task<bool> CreateProjectAsync(IProject project);
        Task<bool> CreateProjectTasksAsync(IEnumerable<IProjectTask> Tasks);
        Task<IProject> ReadProjectAsync(Guid id);
        Task<IEnumerable<IProjectTask>> ReadProjectTasks(Guid projectId);
        Task<IEnumerable<IProject>> ReadProjectsAsync();
        Task<bool> UpdateProjectAsync(IProject project);
        Task<bool> DeleteProjectAsync(Guid id);
    }
}
