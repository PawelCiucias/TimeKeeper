using Autofac;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using pav.timeKeeper.mobile.Views;
using System.Threading.Tasks;
using pav.timeKeeper.mobile.Services.Interfaces;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("pav.timeKeeper.tests")]
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace pav.timeKeeper.mobile
{
    public partial class App : Application
    {
        public App(string databasePath)
        {
            InitializeComponent();
            Core.Bootstraper.Intit(databasePath);
        }
        
        private Task InitNavigation()
        {
            var navigationService = Core.Bootstraper.container.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
