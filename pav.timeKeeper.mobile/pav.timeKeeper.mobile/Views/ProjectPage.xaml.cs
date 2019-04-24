using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pav.timeKeeper.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectPage : ContentPage
    {
        public ProjectPage() => InitializeComponent();
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ClientName_ENTRY.Completed += ClientName_ENTRY_Completed;
            ProjectName_ENTRY.Completed += ProjectName_ENTRY_Completed;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ClientName_ENTRY.Completed -= ClientName_ENTRY_Completed;
            ProjectName_ENTRY.Completed -= ProjectName_ENTRY_Completed;
        }

        private void ClientName_ENTRY_Completed(object sender, EventArgs e) => ProjectName_ENTRY.Focus();
        private void ProjectName_ENTRY_Completed(object sender, EventArgs e) => TaskName_ENTRY.Focus();
    }
}