using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Effects
{
    public class FocusEffect : RoutingEffect
    {
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.CreateAttached("BackgroundColor", typeof(Color), typeof(Color), Color.Accent, propertyChanged: OnFocusChanged);

        public static Color GetBackgroundColor(BindableObject view) => (Color)view.GetValue(BackgroundColorProperty);
        public static void SetBackgorundColor(BindableObject view, Color color) => view.SetValue(BackgroundColorProperty, color);


        public FocusEffect() : base("pav.FocusEffect") { }

        private static void OnFocusChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
                return;

            var backgroundColor = (Color)newValue;
            var effect = view.Effects.OfType<FocusEffect>().FirstOrDefault();

            if (backgroundColor != null && effect == null)
                view.Effects.Add(new FocusEffect());

            if (backgroundColor == null && effect != null)
                view.Effects.Remove(effect);
        }
    }
}
