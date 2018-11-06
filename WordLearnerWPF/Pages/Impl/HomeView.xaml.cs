using MahApps.Metro.Controls;
using System.Windows.Controls;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Pages.Abstract;

namespace WordLearnerWPF.Pages
{

    public partial class HomeView : IParametrizedView<object>
    {
        public HomeView()
        {
            InitializeComponent();
            Loaded += HomeView_Loaded;
        }

        public object Parameter { get; set; }

        private void HomeView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is CoreViewModel cvm)
            {
                cvm.Initialize(Parameter);
            }
        }
       
    }
}
