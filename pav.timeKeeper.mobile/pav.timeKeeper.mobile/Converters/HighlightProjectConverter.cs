using pav.timeKeeper.mobile.ViewModels;
using pav.timeKeeper.mobile.Views;
using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Converters
{
public class HighlightProjectConverter : IValueConverter
{
    public Color ContrastColor { get; set; }
    public Color NormalColor { get; set; }
        
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
         Guid projectId;

         if(Guid.TryParse(value.ToString(), out projectId) && parameter is ContentPage page && page.BindingContext is MainPageViewModel bc)
                return bc.ActiveTask?.ProjectId == projectId ? ContrastColor : NormalColor;

        return NormalColor;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
}
