using pav.timeKeeper.mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pav.timeKeeper.mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportsPage : ContentPage
	{
		public ReportsPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (this.BindingContext is ReportsPageViewModel bc) {
                await bc.PopulateActionableTasks();

            }
        }
    }
}