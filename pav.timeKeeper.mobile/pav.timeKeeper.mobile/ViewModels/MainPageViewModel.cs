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
        public IProject ActiveProject { get; set; }
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

                    base.NotifyPropertyChanged(nameof(SelectedClientName));
                    base.NotifyPropertyChanged(nameof(SelectedProjectName));
                    base.NotifyPropertyChanged(nameof(SelectedTasks));
                }));
            }
        }

        ICommand startActiveProjectCommand;
        public ICommand StartActiveProjectCommand {
            get => startActiveProjectCommand = startActiveProjectCommand ?? 
                new Command(execute: ()=> { }, 
                    canExecute: ()=> SelectedTaskIndex > -1);
        }

        public MainPageViewModel()
        {
           repo = Bootstraper.container.Resolve<IDataRepository>();
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
