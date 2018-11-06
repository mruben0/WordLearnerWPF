using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordLearnerWPF.Core.Abstract;

namespace WordLearnerWPF.ViewModel
{
    public class GameViewModel : CoreViewModel
    {  

        public override Task Initialize<T>(T param)
        {
            Text = param.ToString();
            RaisePropertyChanged(nameof(Text));
            return Task.FromResult(0);
        }

        public string Text { get; set; }
    }
}
