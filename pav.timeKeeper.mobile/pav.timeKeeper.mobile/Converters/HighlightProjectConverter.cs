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
        var ProjectID = Guid.Parse(value.ToString());
        var bc = ((ContentPage)parameter).BindingContext as MainPageViewModel;
        return bc.ActiveTask?.ProjectId == ProjectID ? ContrastColor : NormalColor;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
}
