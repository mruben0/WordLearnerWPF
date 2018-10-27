using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WordLearnerWPF.Core.Abstract;

namespace WordLearnerWPF.ViewModel
{   
    public class MainViewModel : CoreViewModel
    {
      
        public MainViewModel()
        {
         Test = "NoTest";  
        }

        public string Test { get; set; }

        public ICommand SettingsCommand => new RelayCommand(()=>
        {
            throw new System.Exception();
        });

        public override Task Initialize()
        {
            return Task.FromResult(1);
        }
    }
}