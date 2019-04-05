using Autofac;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using pav.timeKeeper.mobile.Views;
using System.Threading.Tasks;
using pav.timeKeeper.mobile.Services.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace pav.timeKeeper.mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Bootstraper.Intit();
        }

        private Task InitNavigation()
        {
            var navigationService = Bootstraper.container.Resolve<INavigationService>();
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
