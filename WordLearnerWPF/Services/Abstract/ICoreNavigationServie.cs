using GalaSoft.MvvmLight.Views;

namespace WordLearnerWPF.Services.Abstract
{
    public interface ICoreNavigationServie : INavigationService
    {
        object Parameter { get; }
    }
}
