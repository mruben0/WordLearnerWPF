using GalaSoft.MvvmLight.Command;
using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WordLearnerWPF.Core.Abstract;
using WordLearnerWPF.Params.Abstract;
using WordLearnerWPF.Themes;

namespace WordLearnerWPF.ViewModel
{
    public class SettingsViewModel : CoreViewModel
    {
        private IStaticParams _staticParams;
        private KeyValuePair<string, Color> _color;
        private List<KeyValuePair<string, Color>> _colors;
        private List<Accent> _accents;
        private Accent _accent;
        private string _version;

        public SettingsViewModel(IStaticParams staticParams)
        {
            _staticParams = staticParams ?? throw new ArgumentNullException(nameof(staticParams));
            var versionNumber = Assembly.GetExecutingAssembly().GetName().Version.ToString() ?? "0";
            Version = "Application " + versionNumber;
        }
        public override Task Initialize<T>(T param)
        {
            Colors = typeof(Colors)
               .GetProperties()
               .Where(prop => typeof(Color).IsAssignableFrom(prop.PropertyType))
               .Select(prop => new KeyValuePair<String, Color>(prop.Name, (Color)prop.GetValue(null)))
               .ToList();
            Accents = ThemeManager.Accents.ToList();
            return Task.FromResult(0);
        }

        public KeyValuePair<string,Color> Color
        {
            get { return _color; }
            set { _color = value;
                RaisePropertyChanged(nameof(Color));
            }
        }

        public List<KeyValuePair<string, Color>> Colors
        {
            get { return _colors; }
            set { _colors = value;
                RaisePropertyChanged(nameof(Colors));

            }
        }

        public ICommand ChangeAppTheme => new RelayCommand(() =>
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            //ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("Base" + ((Button)sender).Content));
        });

        public ICommand ChangeAppAccent => new RelayCommand(() =>
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            //ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("Base" + ((Button)sender).Content));
        });

        public ICommand ApplyTheme => new RelayCommand(() =>
        {
            var selectedColor = this.Color as KeyValuePair<string, Color>?;
            if (selectedColor.HasValue)
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                ThemeManagerHelper.CreateAppStyleBy(selectedColor.Value.Value, true);
                Accent = null;
                Application.Current.MainWindow.Activate();
            }
        });

        public ICommand ApplyAccent => new RelayCommand(() =>
        {
            if (Accent != null)
            {
                ThemeManager.ChangeAppStyle(Application.Current,
                                                   ThemeManager.GetAccent(Accent.Name),
                                                   ThemeManager.GetAppTheme("BaseLight"));
            }
        });

        public ICommand ConfirmTheme => new RelayCommand(() =>
        {
            SaveTheme();
        });

        private void CustomThemeAppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("CustomTheme"));
        }

        private void CustomAccent1AppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent1"), theme.Item1);
        }

        private void CustomAccent2AppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent2"), theme.Item1);
        }

        public List<Accent> Accents
        {
            get { return _accents; }
            set { _accents = value;
                RaisePropertyChanged(nameof(Accents));
            }
        }

        public Accent Accent
        {
            get { return _accent; }
            set { _accent = value;
                RaisePropertyChanged(nameof(Accent));
            }
        }

        private void SaveTheme()
        {
            if (Accent == null)
            {
                var selectedColor = this.Color as KeyValuePair<string, Color>?;
                if (selectedColor.HasValue)
                {
                    var settingsFIle = _staticParams.SettingsFile;
                    File.WriteAllLines(settingsFIle, new string[] { Color.Value.ToString() });
                }
            }
            else
            {
                var settingsFIle = _staticParams.SettingsFile;
                File.WriteAllLines(settingsFIle, new string[] { Accent.Name });
            }
        }
    
        public string Version
        {
            get { return _version; }
            set { _version = value;
                RaisePropertyChanged(nameof(Version));

            }
        }

    }
}
