using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearnerWPF.Core.Abstract
{
    public abstract class CoreViewModel : ViewModelBase
    {
        public abstract Task Initialize<T>(T param);
    }
}
