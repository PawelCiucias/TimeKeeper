using pav.timeKeeper.mobile.Controls;
using pav.timeKeeper.mobile.Core;
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
        public bool DoButtonsToggle { get; set; }

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

        public static readonly BindableProperty ButtonTwoCommandProperty = BindableProperty.Create(nameof(ButtonTwoCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand ButtonTwoCommand
        {
            get => (ICommand)base.GetValue(ButtonTwoCommandProperty);
            set => base.SetValue(ButtonTwoCommandProperty, value);
        }
        #endregion

        #region Button three
        public static readonly BindableProperty ButtonThreeTextProperty = BindableProperty.Create(nameof(ButtonThreeText), typeof(string), typeof(BottomAppBar));
        public string ButtonThreeText
        {
            get => base.GetValue(ButtonThreeTextProperty)?.ToString();
            set => base.SetValue(ButtonThreeTextProperty, value);
        }

        public static readonly BindableProperty ButtonThreeCommandProperty = BindableProperty.Create(nameof(ButtonThreeCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand ButtonThreeCommand
        {
            get => (ICommand)base.GetValue(ButtonThreeCommandProperty);
            set => base.SetValue(ButtonThreeCommandProperty, value);
        }
        #endregion

        #region Button Four
        public static readonly BindableProperty ButtonFourTextProperty = BindableProperty.Create(nameof(ButtonFourText), typeof(string), typeof(BottomAppBar));
        public string ButtonFourText
        {
            get => base.GetValue(ButtonFourTextProperty)?.ToString();
            set => base.SetValue(ButtonFourTextProperty, value);
        }

        public static readonly BindableProperty ButtonFourCommandProperty = BindableProperty.Create(nameof(ButtonFourCommand), typeof(ICommand), typeof(BottomAppBar));

        public ICommand ButtonFourCommand
        {
            get => (ICommand)base.GetValue(ButtonFourCommandProperty);
            set => base.SetValue(ButtonFourCommandProperty, value);
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
            ButtonOne_FLATBUTTON.Clicked += flatButton_Clicked;

            ButtonTwo_FLATBUTTON.SetBinding(Button.TextProperty, new Binding(nameof(ButtonTwoText), source: this));
            ButtonTwo_FLATBUTTON.SetBinding(Button.CommandProperty, new Binding(nameof(ButtonTwoCommand), source: this));
            ButtonTwo_FLATBUTTON.Clicked += flatButton_Clicked;

            ButtonThree_FLATBUTTON.SetBinding(Button.TextProperty, new Binding(nameof(ButtonThreeText), source: this));
            ButtonThree_FLATBUTTON.SetBinding(Button.CommandProperty, new Binding(nameof(ButtonThreeCommand), source: this));
            ButtonThree_FLATBUTTON.Clicked += flatButton_Clicked;

            ButtonFour_FLATBUTTON.SetBinding(Button.TextProperty, new Binding(nameof(ButtonFourText), source: this));
            ButtonFour_FLATBUTTON.SetBinding(Button.CommandProperty, new Binding(nameof(ButtonFourCommand), source: this));
        }

        private void Hero_BUTTON_Clicked(object sender, EventArgs e)
        {
            if (HeroButtonClicked != null)
                HeroButtonClicked.Invoke(this, new EventArgs());
        }

        public void Dispose()
        {
            Hero_BUTTON.Clicked -= Hero_BUTTON_Clicked;
            ButtonOne_FLATBUTTON.Clicked -= flatButton_Clicked;
            ButtonTwo_FLATBUTTON.Clicked -= flatButton_Clicked;
            ButtonThree_FLATBUTTON.Clicked -= flatButton_Clicked;
        }

        private async void flatButton_Clicked(object sender, EventArgs e)
        {
            if (sender is FlatButton btn && btn.TextColor != Color.White)
            {
                Color startColor = btn.TextColor;
                var onBtn = new[] { ButtonOne_FLATBUTTON, ButtonTwo_FLATBUTTON, ButtonThree_FLATBUTTON, ButtonFour_FLATBUTTON }.FirstOrDefault(x => x.TextColor != startColor);

                if (onBtn != null)
                     onBtn.ColorTo(Color.White, startColor, c => onBtn.TextColor = c,500);
                await btn.ColorTo(startColor, Color.White, c => btn.TextColor = c,500);
            }
        }


    }
}