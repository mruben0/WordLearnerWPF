using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Pages;
using WordLearnerWPF.Pages.Abstract;
using WordLearnerWPF.Pages.Impl;
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
            SimpleIoc.Default.Register<HomeView>();
            SimpleIoc.Default.Register<GameView>();
            SimpleIoc.Default.Register<SettingsView>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<GameViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }

        private static void SetupNavigation()
        {
            var navigationService = new CoreNavigationService();
            navigationService.Configure(nameof(HomeView), new Uri("Pages/Impl/HomeView.xaml", UriKind.Relative));
            navigationService.Configure(nameof(MainWindow), new Uri("./MainWindow.xaml", UriKind.Relative));
            navigationService.Configure(nameof(GameView), new Uri("Pages/Impl/GameView.xaml", UriKind.Relative));
            navigationService.Configure(nameof(SettingsView), new Uri("Pages/Impl/SettingsView.xaml", UriKind.Relative));
            RegisteTypes();
            SimpleIoc.Default.Register<ICoreNavigationServie>(() => navigationService);
        }

        private static void RegisteTypes()
        {
            var staticParams = new StaticParams();
            var ioService = new IOService(staticParams);
            var documentService = new DocumentService();

            SimpleIoc.Default.Register<IStaticParams>(() => staticParams);
            SimpleIoc.Default.Register<IIOService>(() => ioService);
            SimpleIoc.Default.Register<IDocumentService>(() => documentService);

        }

        public static IParametrizedView<object> TryGetViewType(Type vmType)
        {
            if (VVMictionary.ContainsKey(vmType))
            {
                return VVMictionary[vmType];
            }
            else return null;
        }

        private static Dictionary<Type, IParametrizedView<object>> VVMictionary => new Dictionary<Type, IParametrizedView<object>>()
        {
            {typeof(HomeViewModel), ServiceLocator.Current.GetInstance<HomeView>() },
            {typeof(GameViewModel), new GameView() },
            {typeof(SettingsViewModel), ServiceLocator.Current.GetInstance<SettingsView>() },
        };

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public HomeViewModel Home => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public GameViewModel GameVM => ServiceLocator.Current.GetInstance<GameViewModel>();
        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public static void Cleanup()
        {
        }
    }
}