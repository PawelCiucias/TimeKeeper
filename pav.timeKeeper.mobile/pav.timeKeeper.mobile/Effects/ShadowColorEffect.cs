using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Effects
{
    public class ShadowColorEffect : RoutingEffect
    {
        public static BindableProperty ShadowColorProperty = BindableProperty.Create(nameof(ShadowColorProperty), typeof(Color), typeof(Color), null);

        public static Color GetShadowColor(BindableObject view) => (Color)view.GetValue(ShadowColorProperty);
        public static void SetShadowColor(BindableObject view, Color color) => view.SetValue(ShadowColorProperty, color);

        public ShadowColorEffect() : base("pav.ShadowColorEffect") { }
    }
}
