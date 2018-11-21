using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Pages.Abstract;

namespace WordLearnerWPF.Pages
{
    public partial class GameView : IParametrizedView<object>
    {
        public GameView()
        {
            InitializeComponent();
            Loaded += GameView_Loaded;
        }
        
        private void GameView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is CoreViewModel cvm)
            {
                cvm.Initialize(Parameter);
            }
        }
        public object Parameter { get; set; }
    }
}
