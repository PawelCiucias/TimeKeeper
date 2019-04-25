using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.View;
using Android.Support.V7.Widget;
using Xamarin.Forms;

using Android.Graphics;
using Android.Content;
using Android.Widget;

[assembly: ExportRenderer(typeof(pav.timeKeeper.mobile.Controls.FlatButton), typeof(pav.timeKeeper.mobile.Droid.Renderers.FlatButtonRenderer))]
namespace pav.timeKeeper.mobile.Droid.Renderers
{
    public class FlatButtonRenderer : ButtonRenderer
    {
        public FlatButtonRenderer(Context context) : base(context) {}

        protected override Android.Widget.Button CreateNativeControl()
        {
            var context = new ContextThemeWrapper(Context, Resource.Style.Widget_AppCompat_ActionButton);
            var button = new Android.Widget.Button(context, null, Resource.Style.Widget_AppCompat_ActionButton);
            
            return button;
        }
    }
}