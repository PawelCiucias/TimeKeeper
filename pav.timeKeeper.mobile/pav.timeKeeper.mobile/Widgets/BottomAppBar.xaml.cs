using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pav.timeKeeper.mobile.Widgets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BottomAppBar : ContentView, IDisposable
	{
        public EventHandler HeroButtonClicked;

        #region HeroSource Bindable property
        public static readonly BindableProperty HeroSourceProperty = BindableProperty.Create(nameof(HeroSource), typeof(ImageSource), typeof(BottomAppBar), default(ImageSource));
        public ImageSource HeroSource
        {
            get => (ImageSource)base.GetValue(HeroSourceProperty);
            set => base.SetValue(HeroSourceProperty, value);
        }
        #endregion

        public static readonly BindableProperty HeroCommandProperty = BindableProperty.Create(nameof(HeroCommand), typeof(ICommand), typeof(BottomAppBar), null);

        public ICommand HeroCommand {
            get => (ICommand)base.GetValue(HeroCommandProperty);
            set => base.SetValue(HeroCommandProperty, value);
        }

        public BottomAppBar ()
		{
			InitializeComponent ();
            
            Hero_IMAGEBUTTON.SetBinding(ImageButton.SourceProperty, new Binding(nameof(HeroSource), source: this));
            Hero_IMAGEBUTTON.SetBinding(ImageButton.CommandProperty, new Binding(nameof(HeroCommand), source: this));

            Hero_IMAGEBUTTON.Clicked += Hero_BUTTON_Clicked;
        }

        private void Hero_BUTTON_Clicked(object sender, EventArgs e)
        {
            if (HeroButtonClicked != null)
                HeroButtonClicked.Invoke(this, new EventArgs());
        }

        public void Dispose()
        {
            Hero_IMAGEBUTTON.Clicked -= Hero_BUTTON_Clicked;
        }
    }
}