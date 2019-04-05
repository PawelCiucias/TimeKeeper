using pav.timeKeeper.mobile.Models;
using pav.timeKeeper.mobile.Models.Interfaces;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.ViewModels
{
    class ProjectPageViewModel : ViewModelBase, IProjectPageViewModel
    {
        public IProject Project { get; set; } = new Project();



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
                        Project.Tasks.Add(new ProjectTask(TaskName));
                        TaskName = string.Empty; },
                    canExecute: () => !String.IsNullOrEmpty(TaskName));

                return addTaskCommand;
            }
        }

        public ICommand SaveProjectCommand => throw new NotImplementedException();

        public ICommand DeleteTaskCommand => new Command<IProjectTask>(pt => Project.Tasks.Remove(pt));


        //
    }
}
