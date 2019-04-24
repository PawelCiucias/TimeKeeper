using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using pav.timeKeeper.mobile.Droid.Effects;
using pav.timeKeeper.mobile.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("pav")]
[assembly: ExportEffect(typeof(PaddingEffectDroid), nameof(PaddingEffect))]
namespace pav.timeKeeper.mobile.Droid.Effects
{
    public class PaddingEffectDroid : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var padding = PaddingEffect.GetPadding(Element);

                Control.SetPadding(-44, 0, 0, 0);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
            // throw new NotImplementedException();
        }
        
    }
}