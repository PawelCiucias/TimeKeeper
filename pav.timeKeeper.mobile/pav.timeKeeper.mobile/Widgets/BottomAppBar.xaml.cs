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
        #region Toggle
        public bool AreButtonToggle { get; set; }

        #endregion
        #region Button One
        public static readonly BindableProperty ButtonOneTextProperty = BindableProperty.Create(nameof(ButtonOneText), typeof(string), typeof(BottomAppBar));
        public string ButtonOneText
        {
            get => base.GetValue(ButtonOneTextProperty)?.ToString();
            set => base.SetValue(ButtonOneTextProperty, value);
        }

        public static readonly BindableProperty ButtonOneCommandProperty = BindableProperty.Create(nameof(ButtonOneCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand ButtonOneCommand
        {
            get => (ICommand)base.GetValue(ButtonOneCommandProperty);
            set => base.SetValue(ButtonOneCommandProperty, value);
        }
        #endregion

        #region Button two
        public static readonly BindableProperty ButtonTwoTextProperty = BindableProperty.Create(nameof(ButtonTwoText), typeof(string), typeof(BottomAppBar));
        public string ButtonTwoText
        {
            get => base.GetValue(ButtonTwoTextProperty)?.ToString();
            set => base.SetValue(ButtonTwoTextProperty, value);
        }

        public static readonly BindableProperty ButtonTwoCommandCommandProperty = BindableProperty.Create(nameof(ButtonTwoCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand ButtonTwoCommand
        {
            get => (ICommand)base.GetValue(ButtonTwoCommandCommandProperty);
            set => base.SetValue(ButtonTwoCommandCommandProperty, value);
        }
        #endregion
        
        #region Button three
        public static readonly BindableProperty ButtonThreeTextProperty = BindableProperty.Create(nameof(ButtonThreeText), typeof(string), typeof(BottomAppBar));
        public string ButtonThreeText
        {
            get => base.GetValue(ButtonThreeTextProperty)?.ToString();
            set => base.SetValue(ButtonThreeTextProperty, value);
        }

        public static readonly BindableProperty ButtonThreeCommandCommandProperty = BindableProperty.Create(nameof(ButtonThreeCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand ButtonThreeCommand
        {
            get => (ICommand)base.GetValue(ButtonThreeCommandCommandProperty);
            set => base.SetValue(ButtonThreeCommandCommandProperty, value);
        }
        #endregion

        #region Button Four
        public static readonly BindableProperty ButtonFourTextProperty = BindableProperty.Create(nameof(ButtonFourText), typeof(string), typeof(BottomAppBar));
        public string ButtonFourText
        {
            get => base.GetValue(ButtonFourTextProperty)?.ToString();
            set => base.SetValue(ButtonFourTextProperty, value);
        }

        public static readonly BindableProperty ButtonFourCommandCommandProperty = BindableProperty.Create(nameof(ButtonFourCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand ButtonFourCommand
        {
            get => (ICommand)base.GetValue(ButtonFourCommandCommandProperty);
            set => base.SetValue(ButtonFourCommandCommandProperty, value);
        }
        #endregion

        #region Hero button
        public EventHandler HeroButtonClicked;

        public static readonly BindableProperty HeroTextProperty = BindableProperty.Create(nameof(HeroText), typeof(string), typeof(BottomAppBar));

        public string HeroText
        {
            get => base.GetValue(HeroTextProperty) as string;
            set => base.SetValue(HeroTextProperty, value);
        }

        public static readonly BindableProperty HeroCommandProperty = BindableProperty.Create(nameof(HeroCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand HeroCommand
        {
            get => (ICommand)base.GetValue(HeroCommandProperty);
            set => base.SetValue(HeroCommandProperty, value);
        }

        #endregion

        public BottomAppBar()
        {
            InitializeComponent();


            Hero_BUTTON.SetBinding(Button.TextProperty, new Binding(nameof(HeroText), source: this));

            Hero_BUTTON.Clicked += Hero_BUTTON_Clicked;
            Hero_BUTTON.SetBinding(Button.CommandProperty, new Binding(nameof(HeroCommand), source: this));


            ButtonOne_FLATBUTTON.SetBinding(Button.TextProperty, new Binding(nameof(ButtonOneText), source: this));
            ButtonOne_FLATBUTTON.SetBinding(Button.CommandProperty, new Binding(nameof(ButtonOneCommand), source: this));


            ButtonTwo_FLATBUTTON.SetBinding(Button.TextProperty, new Binding(nameof(ButtonTwoText), source: this));
            ButtonThree_FLATBUTTON.SetBinding(Button.TextProperty, new Binding(nameof(ButtonThreeText), source: this));
            ButtonFour_FLATBUTTON.SetBinding(Button.TextProperty, new Binding(nameof(ButtonFourText), source: this));

        }

        private void Hero_BUTTON_Clicked(object sender, EventArgs e)
        {
            if (HeroButtonClicked != null)
                HeroButtonClicked.Invoke(this, new EventArgs());
        }

        public void Dispose()
        {
            Hero_BUTTON.Clicked -= Hero_BUTTON_Clicked;
        }
    }
}