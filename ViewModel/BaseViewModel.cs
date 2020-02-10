using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Management;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Data;

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

        #region Variables

        public static string SecretKey = "a973baad1982333ee84d0f7afd636a4869dfe60de33631ebf2cc50501364d028" +
                                         "f7be9d78eddea7e0190375644d7bacffe1e25d2d4b38aee30ca3a682f0d76b84";

        public static string DisplayKey = null;
        public static string ApplicationKey = null;
        public static string RegistrationKey = null;
        public static bool isRegistered = false;

        // Database Connection
        string strCon = @"Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=Database\\OldDatabase.accdb;JET OLEDB:DATABASE PASSWORD=1234567890";
        OleDbConnection db = new OleDbConnection();
        DataSet ds = new DataSet();

        /// <summary>
        ///     OLD DATABASE
        /// </summary>
        // RM
        private static ObservableCollection<Model.RM> _RMList;
        public ObservableCollection<Model.RM> RMList
        {
            get { return _RMList; }
            set { _RMList = value; OnPropertyChanged(); }
        }

        //FG
        private ObservableCollection<Model.FG> _FGList;
        public ObservableCollection<Model.FG> FGList
        {
            get { return _FGList; }
            set { _FGList = value; OnPropertyChanged(); }
        }

        //BoM
        private ObservableCollection<Model.BoM> _BoMList    ;
        public ObservableCollection<Model.BoM> BoMList
        {
            get { return _BoMList; }
            set { _BoMList = value; OnPropertyChanged(); }
        }

        //RMOutputLog
        private ObservableCollection<Model.RMOutputLog> _RMOutputLog;
        public ObservableCollection<Model.RMOutputLog> RMOutputLog
        {
            get { return _RMOutputLog; }
            set { _RMOutputLog = value; OnPropertyChanged(); }
        }

        #endregion

        public BaseViewModel()
        {
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Database
        public void oldDatabase_Get()
        {
            db = new OleDbConnection(strCon);
            db.Open();

            //Task tskRM = Task.Run(() => RM_Load());
            //Task tskFG = Task.Run(() => FG_Load());
            //Task tskBoM = Task.Run(() => BoM_Load());
            BoM_Load();
        }

        public async Task RM_Load()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM RM", db);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            await Task.Run(() => da.Fill(ds, "RM"));

            RMList = new ObservableCollection<Model.RM>();

            foreach (DataRow dr in ds.Tables["RM"].Rows)
            {
                RMList.Add(new Model.RM()
                {
                    InputDate = (DateTime)dr["InputDate"],
                    CusDecNo = (string)dr["CusDecNo"].ToString(),
                    OpenDate = (DateTime)dr["OpenDate"],
                    ReceivedDate = (DateTime)dr["ReceivedDate"],
                    RMCode = (string)dr["RMCode"].ToString(),
                    RMName = (string)dr["RMName"].ToString(),
                    HSCode = (string)dr["HSCode"].ToString(),
                    Price = (decimal)dr["Price"],
                    ExRate = (decimal)dr["ExRate"],
                    TaxRate = (decimal)dr["TaxRate"],
                    Tax = (decimal)dr["Tax"],
                    PriceOutput = (decimal)dr["PriceOutput"],
                    Input = (decimal)dr["Input"],
                    Output = (decimal)dr["Output"]
                });
            }
        }
        public async Task FG_Load()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM FG", db);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            await Task.Run(() => da.Fill(ds, "FG"));

            FGList = new ObservableCollection<Model.FG>();

            foreach (DataRow dr in ds.Tables["FG"].Rows)
            {
                FGList.Add(new Model.FG()
                {
                    ItemCode = (string)dr["ItemCode"].ToString(),
                    FGName = (string)dr["FGName"].ToString(),
                    HSCode = (string)dr["HSCode"].ToString(),
                    FGCode = (string)dr["FGCode"].ToString(),
                    Qty = decimal.TryParse(dr["Qty"].ToString(), out decimal decResult) ? decResult : 0,
                    Customer = (string)dr["Customer"].ToString(),
                    PO = (string)dr["PO"].ToString(),
                    Invoice = (string)dr["Invoice"].ToString(),
                    Date = DateTime.TryParse(dr["Date"].ToString(), out DateTime dtResult) ? dtResult : new DateTime(),
                    LogCode = (string)dr["LogCode"].ToString()
                });
            }
        }

        private void BoM_Load()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM BoM", db);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds, "BoM");

            BoMList = new ObservableCollection<Model.BoM>();

            foreach(DataRow dr in ds.Tables["BoM"].Rows)
            {
                BoMList.Add(new Model.BoM()
                {
                    FGCode = (string)dr["FGCode"].ToString(),
                    RMCode = (string)dr["RMCode"].ToString(),
                    RMName = (string)dr["RMName"].ToString(),
                    Unit = (string)dr["Unit"].ToString(),
                    //BoMQty = decimal.TryParse(dr["BoM"].ToString(), out decimal Result1) ? Result1 : 0
                    BoMQty = (decimal)dr["BoM"]
                    //Rate = decimal.TryParse(dr["BoMQty"].ToString(), out decimal Result2) ? Result2 : 0,
                    //BoMTotal = decimal.TryParse(dr["BoMQty"].ToString(), out decimal Result3) ? Result3 : 0,
                    //Supplier = (string)dr["Supplier"].ToString()
                });
            }

        }
        #endregion

        #region Libraries
        /// <summary>
        /// Check Registration status and set new Window Title
        /// </summary>
        /// <param name="p">Window for set new Title</param>
        public void CheckRegistered()
        {
            var LangCode = Properties.Settings.Default.Language;
            var title = Application.Current.Resources["Main_Title"];

            if (LangCode == "EN")
            {
                Application.Current.Resources["Main_Title"] = title + " - Un-Registerd";
            }
            else if (LangCode == "VN")
            {
                Application.Current.Resources["Main_Title"] = title + " - Chưa đăng ký";
            }
        }
        /// <summary>
        /// Verify Keys
        /// </summary>
        public static bool VerifyKey()
        {
            string hddSerial = GetHDDSerialNumber();
            string hashAppKey = HashString(hddSerial + SecretKey);

            DisplayKey = HashString(hddSerial);
            ApplicationKey = HashString(hashAppKey);
            RegistrationKey = GetRegistrationKey();

            //var temp = BCrypt.Net.BCrypt.HashPassword(ApplicationKey, BCrypt.Net.BCrypt.GenerateSalt(15), true, BCrypt.Net.HashType.SHA512);
            bool result = BCrypt.Net.BCrypt.Verify(ApplicationKey,
                                                    RegistrationKey,
                                                    true, BCrypt.Net.HashType.SHA512);
            isRegistered = result;
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
        #endregion

        #region Security
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


///
/// SAMPLE
///
//<TextBlock>
//    <TextBlock.Text>    
//        <MultiBinding StringFormat = "{}{0} + {1}" >
//            < Binding Path="Name" />
//            <Binding Path = "ID" />
//        </ MultiBinding >
//    </ TextBlock.Text >
//</ TextBlock >

  //    <TextBlock>
  //        <Run Text = "Page" />
  //        < Run Text="{Binding PageNo}" />
  //    </TextBlock>


}
