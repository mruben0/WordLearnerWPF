using MahApps.Metro.Controls;
using WordLearnerWPF.Pages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro;
using WordLearnerWPF.Themes;
using WordLearnerWPF.ViewModel;

namespace WordLearnerWPF.Pages.Impl
{
    public partial class SettingsView  : IParametrizedView<object>
    {
        public SettingsView()
        {
            InitializeComponent();
            Loaded += SettingsView_Loaded;
        }

        private void SettingsView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is SettingsViewModel vm)
            {
                vm.Initialize(Parameter);
            }
        }

        public object Parameter { get; set; }
    }
}
