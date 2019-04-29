using pav.timeKeeper.mobile.Core;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                var startColor = btn.TextColor;
                await Task.WhenAll(
                    btn.ColorTo(startColor, Color.White, c => btn.TextColor = c,100),
                    btn.ColorTo(Color.White, startColor, c => btn.TextColor = c,100));
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Settings_BTN.Clicked += Button_Clicked;
            Graphs_BTN.Clicked += Button_Clicked;
            var pageVm = this.BindingContext as MainPageViewModel;

            if (pageVm != null)
            {
                await  pageVm.PopulateProjects();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Settings_BTN.Clicked -= Button_Clicked;
            Graphs_BTN.Clicked -= Button_Clicked;
        }

    }
}
