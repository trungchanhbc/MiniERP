using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniERP.ViewModel
{

    public class LoginViewModel : BaseViewModel
    {
        public ObservableCollection<string> LanguageList { get; set; }

        /// <summary>
        /// Commands
        /// </summary>
        
        public ICommand LoadCommand { get; set; }
        public ICommand LoadMainWindowCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand LanguageChangedCommand { get; set; }

        public LoginViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => { return true; }, (p)=> 
            {
                bool isEn = Properties.Settings.Default.Language == 0 ? true : false;
                LanguageManager.SetLanguageDictionary(isEn ? ELanguage.English : ELanguage.Vietnamese);
            });

            LoadMainWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                View.MainWindow mainWindow = new View.MainWindow();
                mainWindow.Show();
                p.Close();
            });

            CloseCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            { 
                Environment.Exit(0); 
            });

            LanguageChangedCommand = new RelayCommand<System.Windows.Controls.ComboBox>((p) => { return true; }, (p) => 
            {
                Properties.Settings.Default.Save();
                if (p.SelectedItem == null)
                    return;
                bool isEN = p.SelectedItem.ToString().Equals("English") ? false : true;
                LanguageManager.SetLanguageDictionary(isEN ? ELanguage.English : ELanguage.Vietnamese);

                //FrameworkElement window = GetWindowParent(p);
                //var w = window as Window;
                //if (w != null)
                //{
                //    w.DataContext = this;
                //}
            });

            LanguageList = new ObservableCollection<string>()
            {
                "English",
                "Tiếng việt",
                "Français"
            };
        }

        public FrameworkElement GetWindowParent(System.Windows.Controls.Control p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }

        public static class LanguageManager
        {
            public static void SetLanguageDictionary(ELanguage lang)
            {
                ResourceDictionary dict = new ResourceDictionary();
                switch (lang)
                {
                    case ELanguage.English:
                        dict.Source = new Uri("../ResourceXAML/MainResource-EN.xaml", UriKind.Relative);
                        break;
                    case ELanguage.Vietnamese:
                        dict.Source = new Uri("../ResourceXAML/MainResource-VN.xaml", UriKind.Relative);
                        break;
                    case ELanguage.Francais:
                        dict.Source = new Uri("..\\Resource\\Language\\Language.fr-FR.xaml", UriKind.Relative);
                        break;
                    default:
                        break;
                }
                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }

        public enum ELanguage
        { 
            English,
            Vietnamese,
            Francais
        }

    }
}
