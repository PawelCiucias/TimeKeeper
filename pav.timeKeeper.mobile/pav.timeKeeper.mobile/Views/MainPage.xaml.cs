using pav.timeKeeper.mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var pageVm = this.BindingContext as MainPageViewModel;

            if (pageVm != null)
            {
              await  pageVm.PopulateProjects();
            }
        }

        private void Task_DDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Task_DDL_Focused(object sender, FocusEventArgs e)
        {

        }
    }
}
