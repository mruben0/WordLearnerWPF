using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using WordLearnerWPF.Pages;
using WordLearnerWPF.Services.Abstract;
using WordLearnerWPF.Services.Impl;

namespace WordLearnerWPF.ViewModel
{
    public class ViewModelLocator
    {
        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SetupNavigation();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
        }

        private static void SetupNavigation()
        {
            var navigationService = new CoreNavigationService();
            navigationService.Configure(nameof(HomeView), new Uri("Pages/HomeView.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<ICoreNavigationServie>(() => navigationService);
        }
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();
        
        public static void Cleanup()
        {
        }
    }
}