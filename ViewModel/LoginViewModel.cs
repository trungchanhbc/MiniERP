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
using System.Windows.Input;
using System.Xml.Linq;

namespace MiniERP.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        /// <summary>
        /// Registration Checking
        /// </summary>
        private string ApplicationKey;
        private string RegistrationKey;

        /// <summary>
        /// Commands
        /// </summary>
        public ICommand LoadedCMD { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand LoadMainWindowCMD { get; set; }
        public ICommand CloseCMD { get; set; }
        public ICommand LanguageChangeCMD { get; set; }

        public LoginViewModel()
        {
            // Create Language List
            LanguageList = new ObservableCollection<string>
            {
                "English",
                "Tiếng việt",
                "Français"
            };

            LoadedCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                // Get Hard Drive Serial Number
                string HDDSerialNumber = GetHDDSerialNumber();
                // Get Application Key
                ApplicationKey = HashString(HDDSerialNumber + SecrectKey);
                // Get Registration Key
                RegistrationKey = GetRegistrationKey();
                // Verified Key
                RegistrationVerified = BCrypt.Net.BCrypt.Verify(ApplicationKey, RegistrationKey, true, BCrypt.Net.HashType.SHA512);

                if (RegistrationVerified)
                {
                    MessageBox.Show("Registered!");
                }
                else
                {
                    MessageBox.Show("Un-Registered!");
                }
            });

            LoadMainWindowCMD = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                View.MainWindow mainWindow = new View.MainWindow();
                mainWindow.Show();
                p.Close();
            });

            CloseCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            { 
                Environment.Exit(0); 
            });

            LanguageChangeCMD = new RelayCommand<System.Windows.Controls.ComboBox>((p) => { return true; }, (p) => 
            {
                int LanguageIndex = Properties.Settings.Default.Language;
                p.SelectedIndex = LanguageIndex;
                bool isEn = LanguageIndex == 0 ? true : false;
                LanguageManager.SetLanguageDictionary(isEn ? ELanguage.English : ELanguage.Vietnamese);
                Properties.Settings.Default.Save();
            });
        }

        private string GetHDDSerialNumber()
        {
            using (ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia"))
            {
                string serial = null;
                foreach (ManagementObject hdd in search.Get())
                {
                    serial += hdd["SerialNumber"];
                }
                return serial;
            }

        }
        private string GetRegistrationKey()
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
        private string HashString(string inputString)
        {
            using (System.Security.Cryptography.SHA512 sha512 = System.Security.Cryptography.SHA512.Create())
            {
                sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(inputString));
                return BitConverter.ToString(sha512.Hash).Replace("-", "");
            }
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
