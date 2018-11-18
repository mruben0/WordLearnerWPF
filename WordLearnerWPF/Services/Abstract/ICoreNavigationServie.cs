using GalaSoft.MvvmLight.Views;
using System;

namespace WordLearnerWPF.Services.Abstract
{
    public interface ICoreNavigationServie : INavigationService
    {
        void Navigate(Type viewModel, object parameter);
        object Parameter { get; }
        bool CanGoBack { get; }
    }
}
