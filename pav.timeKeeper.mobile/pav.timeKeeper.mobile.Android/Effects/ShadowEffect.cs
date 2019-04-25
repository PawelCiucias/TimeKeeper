using pav.timeKeeper.mobile.Droid.Effects;
using pav.timeKeeper.mobile.Effects;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ShadowEffectDroid), nameof(ShadowColorEffect))]
namespace pav.timeKeeper.mobile.Droid.Effects
{
    public class ShadowEffectDroid : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                Control.SetOutlineAmbientShadowColor(Color.Purple.ToAndroid());
                Control.SetOutlineSpotShadowColor(Color.Purple.ToAndroid());
            }
            catch (Exception ex) {

                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
          //  throw new NotImplementedException();
        }
    }
}