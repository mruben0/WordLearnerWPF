using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Services.Abstract;

namespace WordLearnerWPF.ViewModel
{
    public class HomeViewModel : CoreViewModel
    {
        private ICoreNavigationServie _navigationServie;

        public HomeViewModel(ICoreNavigationServie navigationServie)
        {
            _navigationServie = navigationServie ?? throw new ArgumentNullException(nameof(navigationServie));
        }

        public string Test => "Test";
        public override Task Initialize()
        {
            return Task.FromResult(0);
        }
    }
}
