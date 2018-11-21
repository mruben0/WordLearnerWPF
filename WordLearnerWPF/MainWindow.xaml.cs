using MahApps.Metro.Controls;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Pages.Impl;

namespace WordLearnerWPF
{    
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
    
        private void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is CoreViewModel vm)
            {
                vm.Initialize(Parameter);
            }
        }
        public object Parameter { get; set; }

        private MetroWindow settingsView;

    }
}
