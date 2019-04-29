using Autofac;
using pav.timeKeeper.mobile.Data;
using pav.timeKeeper.mobile.Models;
using pav.timeKeeper.mobile.Models.Interfaces;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.ViewModels
{
    class ProjectPageViewModel : ViewModelBase, IProjectPageViewModel
    {
        IDataRepository repo;

        public IProject Project { get; set; } = new Project();

        string clientName;
        public string ClientName {
            get => clientName;
            set {
                if (base.SetProperty(ref clientName, value))
                {
                    Project.ClientName = clientName;
                    ((Command)SaveProjectCommand).ChangeCanExecute();
                }

            }
        }

        private string projectName;
        public string ProjectName
        {
            get => projectName;
            set {
                if (base.SetProperty(ref projectName, value))
                {
                    Project.ProjectName = projectName;
                    ((Command)SaveProjectCommand).ChangeCanExecute();
                }
            }
        }


        string taskName;
        public string TaskName
        {
            get => taskName;
            set
            {
                base.SetProperty(ref taskName, value);
                ((Command)AddTaskCommand).ChangeCanExecute();
            }
        }

        ICommand addTaskCommand;
        public ICommand AddTaskCommand
        {
            get
            {
                this.addTaskCommand = this.addTaskCommand ?? new Command(
                    execute: () => {
                        Project.Tasks.Add(new ProjectTask(TaskName, Project.Id));
                        TaskName = string.Empty; },
                    canExecute: () => !String.IsNullOrEmpty(TaskName) && TaskName.Length > 3);

                return addTaskCommand;
            }
        }

        ICommand saveProjectCommand;
        public ICommand SaveProjectCommand {
            get {

                return this.saveProjectCommand ?? (this.saveProjectCommand = new Command(
                     execute: async () => {
                         await repo.CreateProjectAsync(Project);
                         await repo.CreateProjectTasksAsync(Project.Tasks);
                     },
                     canExecute: () =>
!(String.IsNullOrEmpty(ClientName) || string.IsNullOrEmpty(ProjectName))
                    ));

                
            }
        }

        ICommand deleteTaskCommand;
        public ICommand DeleteTaskCommand => deleteTaskCommand = deleteTaskCommand ?? new Command<IProjectTask>(pt => Project.Tasks.Remove(pt));

        public ProjectPageViewModel()
        {
            repo=  Core.Bootstraper.container.Resolve<IDataRepository>();
        }
    }
}
