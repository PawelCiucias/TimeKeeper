using Autofac;
using pav.timeKeeper.mobile.Data;
using pav.timeKeeper.mobile.Models;
using pav.timeKeeper.mobile.Models.Interfaces;
using pav.timeKeeper.mobile.Services.Interfaces;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.ViewModels
{
    class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        IDataRepository repo;
        public ObservableCollection<IProject> Projects { get; set; }
        public IActionableTask ActiveTask { get; set; }
        public Guid ActiveProjectId { get => ActiveTask.ProjectId; }

        public IProject SelectedProject { get; set; }

        public string SelectedClientName
        {
            get => SelectedProject?.ClientName ?? "Select a project";
        }
        public string SelectedProjectName
        {
            get => SelectedProject?.ProjectName;
        }

        int selectedIndex = -1;
        public int SelectedTaskIndex {
            get => selectedIndex;
            set {
                base.SetProperty(ref selectedIndex, value);
                ((Command)StartActiveProjectCommand).ChangeCanExecute();
            }
        }


        public IList<string> SelectedTasks {
            get => SelectedProject?.Tasks.Select(t => t.Name).ToList();
        }


        ICommand createProjectCommand;
        public ICommand CreateProjectCommand  {
            get {
                createProjectCommand = createProjectCommand ??
                    new Command(async () => await base.navigationService.NavigateToAsync<ProjectPageViewModel>());
                return createProjectCommand;
            }
        }

        ICommand selectActiveProjectCommand;
        public ICommand SelectActiveProjectCommand
        {
            get {
                return (selectActiveProjectCommand = selectActiveProjectCommand ?? new Command(async()=> {

                    var tasks = await repo.ReadProjectTasks(SelectedProject.Id);

                    if(tasks != null)
                        SelectedProject.Tasks = tasks.ToList();

                    base.NotifyPropertyChanged(nameof(SelectedProject));
                    base.NotifyPropertyChanged(nameof(SelectedClientName));
                    base.NotifyPropertyChanged(nameof(SelectedProjectName));
                    base.NotifyPropertyChanged(nameof(SelectedTasks));
                    base.NotifyPropertyChanged(nameof(ActiveTask));

                    if(ActiveTask?.ProjectId == SelectedProject.Id)
                    {

                        for (var index = 0; index < SelectedProject.Tasks.Count; index++)
                            if (SelectedProject.Tasks[index].Id == ActiveTask.TaskId) {
                                SelectedTaskIndex = index;
                                return;
                            }
                            

                    }

                }));
            }
        }

        ICommand startActiveProjectCommand;
        public ICommand StartActiveProjectCommand {
            get => startActiveProjectCommand = startActiveProjectCommand ?? 
                new Command(
                    execute: async ()=> {
                        Guid? OldTaskId = ActiveTask?.ProjectId;

                        if(ActiveTask != null)
                        {
                            ActiveTask.End = DateTime.Now;
                            await  repo.UpdateActionableTaskAsync(ActiveTask);
                        }

                        if (Projects.FirstOrDefault(p => p.Id == SelectedProject.Id) is Project selectedProject)
                        {
                            selectedProject.NotifyPropertyChanged(nameof(IProject.Id));
                            ActiveTask = new ActionableTask(SelectedProject.Id, SelectedProject.Tasks[SelectedTaskIndex].Id);
                        }

                        if (OldTaskId.HasValue)
                        {
                            var oldProject = Projects.FirstOrDefault(p => p.Id == OldTaskId.Value) as Project;
                            oldProject.NotifyPropertyChanged(nameof(IProject.Id));
                        }

                        await repo.CreateActionableTaskAsync(ActiveTask);
                    }, 
                    canExecute: ()=> SelectedTaskIndex > -1);
        }


        private ICommand viewReportsCommand;
        public ICommand ViewReportsCommand
        {
            get => viewReportsCommand = viewReportsCommand ?? new Command(async ()=>  await base.navigationService.NavigateToAsync<ReportsPageViewModel>());
        }

        private ICommand settingsCommand;

        public ICommand SettingsCommand
        {
            get => settingsCommand = settingsCommand ?? new Command(() => base.navigationService.NavigateToAsync<SettingsPageViewModel>());
        }



        public MainPageViewModel()
        {
           repo = Core.Bootstraper.container.Resolve<IDataRepository>();
        }

        public async Task PopulateProjects() {

            var projects = await repo.ReadProjectsAsync();
            if (projects != null)
            {
                Projects = new ObservableCollection<IProject>(projects);
                base.NotifyPropertyChanged(nameof(Projects));
            }
        }
    }
}
