using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniERP.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Commands
        /// </summary>
        
        public ICommand LoginWindowLoadedCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand LoadMainWindowCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand LanguageChangedCommand { get; set; }

        public LoginViewModel()
        {
            LoginWindowLoadedCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (!isRegistered())
                {
                    MessageBox.Show("UnRegistered!");
                }
                else
                {
                    MessageBox.Show("Registered!");
                }
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
                int LanguageIndex = Properties.Settings.Default.Language;
                p.SelectedIndex = LanguageIndex;
                bool isEn = LanguageIndex == 0 ? true : false;
                LanguageManager.SetLanguageDictionary(isEn ? ELanguage.English : ELanguage.Vietnamese);
                Properties.Settings.Default.Save();
            });
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
    }
}
