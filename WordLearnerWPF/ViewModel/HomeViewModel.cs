using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Pages;
using WordLearnerWPF.Params.Abstract;
using WordLearnerWPF.Params.Impl;
using WordLearnerWPF.Services.Abstract;
using WordLearnerWPF.Services.Impl;

namespace WordLearnerWPF.ViewModel
{
    public class HomeViewModel : CoreViewModel
    {
        private ICoreNavigationServie _navigationServie;
        private IStaticParams _staticParams;
        private IIOService _iOService { get; set; }
        private ObservableCollection<FileDto> _files;
        private FileDto _Selectedfile;

        public HomeViewModel(ICoreNavigationServie navigationServie, IStaticParams staticParams, IIOService iOService)
        {
            _navigationServie = navigationServie ?? throw new ArgumentNullException(nameof(navigationServie));
            _staticParams = staticParams ?? throw new ArgumentNullException(nameof(staticParams));
            _iOService = iOService ?? throw new ArgumentNullException(nameof(iOService));
        }

        public override Task Initialize<T>( T param)
        {
            UpdateFiles();
            return Task.FromResult(0);
        }

        public ICommand StartCommand => new RelayCommand(() =>
        {
           _navigationServie.Navigate(typeof(GameViewModel), "sjdsf");
        });

        public ICommand AddFileCommand => new RelayCommand(() =>
        {
            string newFilePath = _iOService.AddFile();
            if (newFilePath != null)
            {
                Files.Add(new FileDto(Path.GetFileName(newFilePath), newFilePath));
            }
        });

        public ICommand DownloadCommand => new RelayCommand(() =>
        {
            if (SelectedFile != null)
            {
                var dlg = new SaveFileDialog();
                dlg.Title = "Choose folder";
                dlg.FileName = SelectedFile.Name;
                if (dlg.ShowDialog() ?? false)
                {
                    File.Copy(SelectedFile.Path, dlg.FileName, true);
                }
            }
        });

        public ICommand OpenCommand => new RelayCommand(() =>
        {
            if (SelectedFile != null)
            {
                System.Diagnostics.Process.Start(SelectedFile.Path);
            }
        });

        public ICommand DeleteCommand => new RelayCommand(() =>
        {
            if (SelectedFile != null)
            {
                File.Delete(SelectedFile.Path);
                UpdateFiles();
            }
        });

        private void UpdateFiles()
        {
            if (Directory.Exists(_staticParams.AppFolderPath))
            {
                Files = new ObservableCollection<FileDto>
                    (Directory.GetFiles(_staticParams.DocumentFolderPath)
                    .ToList().Select(e =>
                    new FileDto(Path.GetFileName(e), Path.Combine(_staticParams.DocumentFolderPath, e))));
            }
            RaisePropertyChanged(nameof(Files));
        }

        public ObservableCollection<FileDto> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        public FileDto SelectedFile
        {
            get { return _Selectedfile; }
            set { _Selectedfile = value;
                RaisePropertyChanged(nameof(SelectedFile));
            }
        }
    }
}
