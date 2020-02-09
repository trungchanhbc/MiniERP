using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;


namespace MiniERP.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        Task tskIsRegistered;

        #region Commands
        public ICommand LoginLoadedCmd { get; set; }
        //public ICommand LoadCommand { get; set; }
        public ICommand LoadMainWindowCmd { get; set; }
        public ICommand CloseCMD { get; set; }
        public ICommand LanguageChangeCMD { get; set; }
        #endregion

        public LoginViewModel()
        {
            // Create Language List
            Language = new ObservableCollection<LanguageList>();
            Language.Add(new LanguageList { Code = "EN", DisplayName = "English" });
            Language.Add(new LanguageList { Code = "VN", DisplayName = "Tiếng việt" });
            Language.Add(new LanguageList { Code = "FR", DisplayName = "Français" });

            LoginLoadedCmd = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                string LanCode = Properties.Settings.Default.Language;
                switch (LanCode)
                {
                    case "EN":
                        p.SelectedIndex = 0;
                        break;
                    case "VN":
                        p.SelectedIndex = 1;
                        break;
                    case "FR":
                        p.SelectedIndex = 2;
                        break;
                    default:
                        p.SelectedIndex = 0;
                        break;
                }

                tskIsRegistered = Task.Run(async () => Libraries.VerifyKey());
            });
        
            LoadMainWindowCmd = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (tskIsRegistered.Status == TaskStatus.RanToCompletion && Variables.isRegistered == true)
                {
                    View.MainWindow mainWindow = new View.MainWindow();
                    mainWindow.Show();
                    p.Close();
                }
            });

            CloseCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            { 
                Environment.Exit(0); 
            });

            LanguageChangeCMD = new RelayCommand<System.Windows.Controls.ComboBox>((p) => { return true; }, (p) => 
            {
                //int LanguageIndex = Properties.Settings.Default.Language;
                //p.SelectedIndex = LanguageIndex;
                //bool isEn = LanguageIndex == 0 ? true : false;
                //LanguageManager.SetLanguageDictionary(isEn ? ELanguage.English : ELanguage.Vietnamese);
                //Properties.Settings.Default.Save();
            });
        }
    }
}
