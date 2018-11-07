using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Params.Abstract;
using WordLearnerWPF.Params.Impl;
using WordLearnerWPF.Services.Abstract;

namespace WordLearnerWPF.ViewModel
{
    public class GameViewModel : CoreViewModel
    {
        private ICoreNavigationServie _navigationService;
        private IStaticParams _staticParams;
        private FileDto _documetDTO;

        public GameViewModel(ICoreNavigationServie navigationService, IStaticParams staticParams)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _staticParams = staticParams ?? throw new ArgumentNullException(nameof(staticParams));
        }

        public override Task Initialize<T>(T param)
        {
            DocumentDto = param as FileDto;
            RaisePropertyChanged(nameof(DocumentDto));
            return Task.FromResult(0);
        }


        public FileDto DocumentDto
        {
            get { return _documetDTO; }
            set { _documetDTO = value;
                RaisePropertyChanged(nameof(DocumentDto));
            }
        }
    }
}
