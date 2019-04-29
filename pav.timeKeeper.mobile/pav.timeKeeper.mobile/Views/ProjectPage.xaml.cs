using pav.timeKeeper.mobile.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pav.timeKeeper.mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectPage : ContentPage
    {
        public ProjectPage()
        {
            InitializeComponent();
            BottomeAppBar.HeroButtonClicked += (s, e) =>
           {
               var parentAnimation = new Animation();
               var w = Content.Width;

               //contract
               var contract_clientName = new Animation(d => ClientName_ENTRY.WidthRequest = d, w, 0,null,()=> ClientName_ENTRY.Text = String.Empty);
               var contract_projectName = new Animation(d => ProjectName_ENTRY.WidthRequest = d, w, 0, null, ()=> ProjectName_ENTRY.Text = String.Empty);
               var contract_taskEntry = new Animation(d => TaskName_STACKLAYOUT.WidthRequest = d, w, 0,null, () => TaskName_ENTRY.Text = String.Empty);
               var contract_taskList = new Animation(d => Tasks_LISTVIEW.WidthRequest = d, w, 0);

               parentAnimation.Add(0, .5, contract_clientName);
               parentAnimation.Add(0, .5, contract_projectName);
               parentAnimation.Add(0, .5, contract_taskEntry);
               parentAnimation.Add(0, .5, contract_taskList);

               //expand
               var expand_clientName = new Animation(d => ClientName_ENTRY.WidthRequest = d, 0, w);
               var expand_proejctName = new Animation(d => ProjectName_ENTRY.WidthRequest = d, 0, w);
               var expand_taskEntry = new Animation(d => TaskName_STACKLAYOUT.WidthRequest = d, 0, w);
               var expand_taskList = new Animation(d => Tasks_LISTVIEW.WidthRequest = d, 0, w);

               parentAnimation.Add(.5,1, expand_clientName);
               parentAnimation.Add(.5,1, expand_proejctName);
               parentAnimation.Add(.5,1, expand_taskEntry);
               parentAnimation.Add(.5,1, expand_taskList);
          

               parentAnimation.Commit(this, "contract", 16, 1000);
           };
        }

        private void ClearProject()
        {
            if (this.BindingContext is ProjectPageViewModel bc)
                bc.Project.Clear();
        }

        public Task BeginInvokeOnMainThreadAsync(Action action)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();

            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(null);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });
            return tcs.Task;
        }


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
            BottomeAppBar.Dispose();
        }

        private void ClientName_ENTRY_Completed(object sender, EventArgs e) => ProjectName_ENTRY.Focus();
        private void ProjectName_ENTRY_Completed(object sender, EventArgs e) => TaskName_ENTRY.Focus();
    }
}