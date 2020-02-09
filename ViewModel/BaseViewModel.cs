using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Management;
using System.IO;
using System.Reflection;
using System.Xml.Linq;


namespace MiniERP.ViewModel
{


    #region BaseViewModel

    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Application Language
        private static ObservableCollection<LanguageList> _Language;
        public ObservableCollection<LanguageList> Language
        {
            get { return _Language; }
            set { _Language = value; OnPropertyChanged(); }
        }

        private LanguageList _SelectedLanguage;
        public LanguageList SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set
            {
                _SelectedLanguage = value;
                OnPropertyChanged();
                if (SelectedLanguage != null)
                {
                    LanguageManager.SetLanguageDictionary(value.Code);
                    Properties.Settings.Default.Language = value.Code;
                    Properties.Settings.Default.Save();
                   
                }
            }
        }
        #endregion

        public BaseViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Variables
        public class Variables
        {
            public static string SecretKey = "a973baad1982333ee84d0f7afd636a4869dfe60de33631ebf2cc50501364d028" +
                               "f7be9d78eddea7e0190375644d7bacffe1e25d2d4b38aee30ca3a682f0d76b84";

            public static string DisplayKey = null;
            public static string ApplicationKey = null;
            public static string RegistrationKey = null;
            public static bool isRegistered = false;

            //private 
            //public ObservableCollection<string> LanguageList { get; set ; }

        }
        #endregion

        #region Libraries
        public class Libraries
        {
            /// <summary>
            /// Verify Keys
            /// </summary>
            public static bool VerifyKey()
            {
                string hddSerial = GetHDDSerialNumber();
                string hashAppKey = Security.HashString(hddSerial + Variables.SecretKey);

                Variables.DisplayKey = Security.HashString(hddSerial);
                Variables.ApplicationKey = Security.HashString(hashAppKey);
                Variables.RegistrationKey = GetRegistrationKey();

                var temp = BCrypt.Net.BCrypt.HashPassword(Variables.ApplicationKey, BCrypt.Net.BCrypt.GenerateSalt(15), true, BCrypt.Net.HashType.SHA512);
                bool result = BCrypt.Net.BCrypt.Verify(Variables.ApplicationKey,
                                                       Variables.RegistrationKey,
                                                       true, BCrypt.Net.HashType.SHA512);
                Variables.isRegistered = result;
                return result;
            }
            /// <summary>
            /// Get Hard drive serial number
            /// </summary>
            /// <returns></returns>
            private static string GetHDDSerialNumber()
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia"))
                {
                    string serial = null;
                    foreach (ManagementObject hdd in searcher.Get())
                    {
                        serial += hdd["SerialNumber"].ToString().Replace(" ", "");
                    }
                    return serial;
                }
            }

            /// <summary>
            /// Read the Key from XML Registration file 
            /// </summary>
            /// <returns></returns>
            private static string GetRegistrationKey()
            {
                string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string xmlFile = Path.Combine(currentDirectory, @"Registration\RegistrationKey.xml");
                if (File.Exists(xmlFile))
                {
                    XElement xmlElement = XElement.Load(xmlFile);
                    return xmlElement.Element("Key").Value.ToString();
                }
                return null;
            }
        }
        #endregion

        #region Security
        public class Security
        {
            /// <summary>
            /// Hash the string with SHA-512
            /// </summary>
            /// <param name="InputString"></param>
            public static string HashString(string InputString)
            {
                using (System.Security.Cryptography.SHA512 hashTool = System.Security.Cryptography.SHA512.Create())
                {
                    hashTool.ComputeHash(System.Text.Encoding.UTF8.GetBytes(InputString));
                    return BitConverter.ToString(hashTool.Hash).Replace("-", "");
                }
            }


        }
        #endregion
    }

    #endregion

    #region RelayCommand<T>
    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }
            catch
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    #endregion

    #region GetWindowParent
    //public FrameworkElement GetWindowParent(System.Windows.Controls.Control p)
    //{
    //    FrameworkElement parent = p;
    //    while (parent.Parent != null)
    //    {
    //        parent = parent.Parent as FrameworkElement;
    //    }

    //    return parent;
    //}

    #endregion

    #region Language Class

    public class LanguageList
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }

        public LanguageList()
        {
            Code = null;
            DisplayName = null;
        }
    }

    static class LanguageManager
    {
        public static void SetLanguageDictionary(string LanguageCode)
        {
            ResourceDictionary Dict = new ResourceDictionary();
            switch (LanguageCode)
            {
                case "EN":
                    Dict.Source = new Uri("../ResourceXAML/MainResource-EN.xaml", UriKind.Relative);
                    break;
                case "VN":
                    Dict.Source = new Uri("../ResourceXAML/MainResource-VN.xaml", UriKind.Relative);
                    break;
                case "FR":
                    Dict.Source = new Uri("../ResourceXAML/MainResource-FR.xaml", UriKind.Relative);
                    break;
                default:
                    Dict.Source = new Uri("../ResourceXAML/MainResource-EN.xaml", UriKind.Relative);
                    break;
            }
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(Dict);
        }
    }

    #endregion
}
