using pav.timeKeeper.mobile.Services.Interfaces;
using pav.timeKeeper.mobile.ViewModels;
using pav.timeKeeper.mobile.ViewModels.Interfaces;
using pav.timeKeeper.mobile.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace pav.timeKeeper.mobile.Services
{
    class NavigationService : INavigationService
    {
        public ViewModelBase PreviousPageViewModel => throw new NotImplementedException();

        public Task GoBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task InitializeAsync()
        {
            //if (string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            //    return NavigateToAsync<LoginViewModel>();
            //else

         
                return NavigateToAsync<MainPageViewModel>();
   
        }
    

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task RemoveBackStackAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);
            
            var navigationPage = Application.Current.MainPage as CustomNavigationView;

            if (navigationPage != null)
                await navigationPage.PushAsync(page);
            else
                Application.Current.MainPage = new CustomNavigationView(page);
            
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewModelName = viewModelType.FullName;
            var viewName = viewModelName.Replace("Model", string.Empty).Remove(viewModelName.Length-14);

            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
                throw new Exception($"Cannot locate page type for {viewModelType}");

            return Activator.CreateInstance(pageType) as Page;
        }
    }
}
