using MahApps.Metro.Controls;
using System.Windows.Controls;
using WordLearnerWPF.Core.Abstract;

namespace WordLearnerWPF.Pages
{

    public partial class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
            Loaded += HomeView_Loaded;
        }

        private void HomeView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is CoreViewModel cvm)
            {
                cvm.Initialize();
            }
        }
       
    }
}
