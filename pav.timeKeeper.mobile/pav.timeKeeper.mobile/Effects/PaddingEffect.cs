using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Effects
{
    public class PaddingEffect : RoutingEffect
    {
        public static BindableProperty PaddingProperty = BindableProperty.Create(nameof(PaddingProperty), typeof(string), typeof(string), null, propertyChanged: OnPaddingChnaged);

        public static string GetPadding(BindableObject view) => (string)view.GetValue(PaddingProperty);
        public static void SetPadding(BindableObject view, string padding) => view.SetValue(PaddingProperty, padding);

        private static void OnPaddingChnaged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is View view && newValue is String padding)
            {
                var effect = view.Effects.OfType<PaddingEffect>().FirstOrDefault();

                if (String.IsNullOrEmpty(padding))
                {
                    if (effect != null)
                        view.Effects.Remove(effect);
                }
                else if(effect == null)
                    view.Effects.Add(new PaddingEffect());
            }
        }

        public PaddingEffect() : base("pav.PaddingEffect")
        {
        }
    }
}
