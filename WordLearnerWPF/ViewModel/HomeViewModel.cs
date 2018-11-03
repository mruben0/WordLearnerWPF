using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using WordLearnerWPF.Core.Abstract;
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

        public HomeViewModel(ICoreNavigationServie navigationServie, IStaticParams staticParams, IIOService iOService)
        {
            _navigationServie = navigationServie ?? throw new ArgumentNullException(nameof(navigationServie));
            _staticParams = staticParams ?? throw new ArgumentNullException(nameof(staticParams));
            _iOService = iOService ?? throw new ArgumentNullException(nameof(iOService));
            Files = new ObservableCollection<FileDto>();
        }

        public override Task Initialize()
        {
          return Task.FromResult(0);
        }

        public ICommand AddFileCommand => new RelayCommand(()=> 
        {
            string newFilePath = _iOService.AddFile();
            if (newFilePath != null)
            {
                Files.Add(new FileDto(Path.GetFileName(newFilePath), newFilePath));
            }
        });

        public ObservableCollection<FileDto> Files
        {
            get { return _files; }
            set { _files = value; }
        }

    }
}
