using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight.Command;
using MahApps.Metro;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Pages;
using WordLearnerWPF.Pages.Impl;
using WordLearnerWPF.Params.Abstract;
using WordLearnerWPF.Services.Abstract;
using WordLearnerWPF.Themes;

namespace WordLearnerWPF.ViewModel
{
    public class MainViewModel : CoreViewModel
    {
        private ICoreNavigationServie _navigationServie { get; }
        private IStaticParams _staticParams;
        public MainViewModel(ICoreNavigationServie coreNavigationServie, IStaticParams staticParams)
        {
            _navigationServie = coreNavigationServie ?? throw new ArgumentNullException(nameof(coreNavigationServie));
            _staticParams = staticParams ?? throw new ArgumentNullException(nameof(staticParams));
        }

        public override Task Initialize<T>(T param)
        {
            CreateFolders();
            CreateFiles();
            GetSavedTheme();
            _navigationServie.NavigateTo(nameof(HomeView));
            return Task.FromResult(1);
        }

        public ICommand SettingsCommand => new RelayCommand(() =>
        {
            _navigationServie.NavigateTo(nameof(SettingsView));
        });

        public ICommand GoBack => new RelayCommand(() =>
        {
            _navigationServie.GoBack();
        });

        private void CreateFolders()
        {
            var folders = _staticParams.FoldersToCreate;
            foreach (var folder in folders)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
        }

        private void CreateFiles()
        {
            var files = _staticParams.FilesToCeate;
            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    File.Create(file).Dispose();
                }
            }
        }


        private void GetSavedTheme()
        {
            var settingsFIle = _staticParams.SettingsFile;
            var color = File.ReadLines(settingsFIle).FirstOrDefault();
            if (ThemeManager.Accents.Any(a=> a.Name == color))
            {
                ThemeManager.ChangeAppStyle(Application.Current,
                                                   ThemeManager.GetAccent(color),
                                                   ThemeManager.GetAppTheme("BaseLight"));
            }
            else if (color != null)
            {
                var themeColor = (Color)ColorConverter.ConvertFromString(color);
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                ThemeManagerHelper.CreateAppStyleBy(themeColor, true);
                Application.Current.MainWindow.Activate();
            }
        }
    }
}