using Autofac;
using pav.timeKeeper.mobile.Data;
using pav.timeKeeper.mobile.Services;
using pav.timeKeeper.mobile.Services.Interfaces;
using pav.timeKeeper.mobile.ViewModels;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile
{
    internal static class Bootstraper
    {
        internal static IContainer container;

        internal static void Intit(string databasePath) {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainPageViewModel>().As<IMainPageViewModel>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<ProjectPageViewModel>().As<IProjectPageViewModel>();
            builder.RegisterType<Database>().As<IDataRepository>().SingleInstance().WithParameter(new TypedParameter(typeof(string), databasePath));

            container = builder.Build();
        }


        #region Auto wire view models
        public static readonly BindableProperty AutoWireViewModelProperty =
         BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(Bootstraper), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) => (bool)bindable.GetValue(Bootstraper.AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) => bindable.SetValue(Bootstraper.AutoWireViewModelProperty, value);

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
                return;

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.Interfaces.I");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
                return;

            var viewModel = Bootstraper.container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        } 
        #endregion
    }
}
