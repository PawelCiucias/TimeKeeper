using pav.timeKeeper.mobile.Models.Interfaces;
using pav.timeKeeper.mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Converters
{
    class PlayOrPauseConverter : IValueConverter
    {
        static string play = (string)Application.Current.Resources["awesome.play"];
        static string pause = (string)Application.Current.Resources["awesome.pause"];

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IActionableTask actionableTask &&
                parameter is ContentPage cp && 
                cp.BindingContext is MainPageViewModel vm &&
                vm.SelectedTaskIndex > -1)
            {
                var selectedTaskId = vm.SelectedProject.Tasks[vm.SelectedTaskIndex].Id;
                if(selectedTaskId == actionableTask.TaskId)
                return pause;
            }

            return play;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
