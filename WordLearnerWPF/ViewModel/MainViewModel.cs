using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Services.Abstract;

namespace WordLearnerWPF.ViewModel
{   
    public class MainViewModel : CoreViewModel
    {
        private ICoreNavigationServie _navigationServie;
        public MainViewModel(ICoreNavigationServie coreNavigationServie)
        {
            _navigationServie = coreNavigationServie;
        }

        public ICommand SettingsCommand => new RelayCommand(()=>
        {
            _navigationServie.NavigateTo("HomeView");
        });

        public override Task Initialize()
        {
            return Task.FromResult(1);
        }
    }
}