using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLearnerWPF.Core.Abstract
{
    public interface ICoreNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}
