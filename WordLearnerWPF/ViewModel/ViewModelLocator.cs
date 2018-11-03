using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using WordLearnerWPF.Pages;
using WordLearnerWPF.Params.Abstract;
using WordLearnerWPF.Params.Impl;
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
            navigationService.Configure(nameof(MainWindow),new Uri("./MainWindow.xaml", UriKind.Relative));
            RegisteTypes();
            SimpleIoc.Default.Register<ICoreNavigationServie>(() => navigationService);
        }

        private static void RegisteTypes()
        {
            var staticParams = new StaticParams();
            var ioService = new IOService(staticParams);

            SimpleIoc.Default.Register<IStaticParams>(() => staticParams);
            SimpleIoc.Default.Register<IIOService>(()=> ioService);
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();
        
        public static void Cleanup()
        {
        }
    }
}