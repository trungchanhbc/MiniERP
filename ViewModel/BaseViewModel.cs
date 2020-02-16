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
using MiniERP.Model;

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
        const string strConOld = @"Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=..\\..\\Database\\OldDatabase.accdb;JET OLEDB:DATABASE PASSWORD=1234567890";
        OleDbConnection dbOld = new OleDbConnection();

        const string strConNew = @"Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=..\\..\\Database\\Database.accdb;JET OLEDB:DATABASE PASSWORD=1234567890";
        OleDbConnection dbNew = new OleDbConnection();

        private readonly DataSet ds = new DataSet();

        // Raw Material Info
        private ObservableCollection<RawMaterialInfo> rawMaterialInfos;
        public ObservableCollection<RawMaterialInfo> RawMaterialInfos
        {
            get { return rawMaterialInfos; }
            set { rawMaterialInfos = value; OnPropertyChanged(); }
        }



        /*
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
        */
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

        #region TransferData
        public async Task TransferData()
        {
            // Connect to Old Database and Load all Tables into DataSet
            dbOld = new OleDbConnection(strConOld);
            dbOld.Open();
            List<Task> tskLoadOldDB = new List<Task>()
            {
                Task.Run(() => Database_Load("RM", dbOld, ds)),
                Task.Run(() => Database_Load("FG", dbOld, ds)),
                Task.Run(() => Database_Load("BoM", dbOld, ds)),
                Task.Run(() => Database_Load("RMOutputLog", dbOld, ds))
            };
            await Task.WhenAll(tskLoadOldDB);

            // Connect to new Database
            dbNew = new OleDbConnection(strConNew);
            dbNew.Open();

            List<Task> tasks = new List<Task>
            {
                Task.Run(() => TransferRawMaterialInfo())
                //Task.Run(() => TransferCustomsDeclaration()),
                //Task.Run(() => TransferRawMaterialInput())
                //Task.Run(() => TransferSupplier())
            };


            dbOld.Close();
            dbNew.Close();

            MessageBox.Show("Done");
        }
        
        private async Task Database_Load(string TableName, OleDbConnection db, DataSet ds)
        {
            string strQry = "SELECT * FROM " + TableName;
            OleDbCommand cmd = new OleDbCommand(strQry, db);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            await Task.Run(() => da.Fill(ds,TableName));
        }

        public async Task TransferRawMaterialInfo()
        {
            var dataRows = (from DataRow dr in ds.Tables["RM"].Rows
                            //group dr by dr["RMCode"] into r
                            select new 
                            { 
                                RMCode = dr["RMCode"], 
                                RMName = dr["RMName"],
                                HSCode = dr["HSCode"]
                            }).Distinct();

            OleDbCommand cmd = new OleDbCommand("INSERT INTO RawMaterialInfo VALUES(@Code, @Name, @HSCode, @UnitID)", dbNew);
            foreach (DataRow dr in ds.Tables["RawMaterialInfo"].Rows)
            {
                // Check and fix Unit by ID 
                string strUnit = dr["Unit"].ToString().Replace(" ","").ToLower();
                int idUnit = 0;
                switch(strUnit)
                {
                    case "kg":
                        idUnit = 1;
                        break;
                    case "cái":
                        idUnit = 2;
                        break;
                    default:
                        idUnit = 9999;
                        break;
                }
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OleDbParameter("@Code", dr["RMCode"].ToString()));
                cmd.Parameters.Add(new OleDbParameter("@Name", dr["RMName"].ToString()));
                cmd.Parameters.Add(new OleDbParameter("@HSCode", dr["HSCode"].ToString()));
                cmd.Parameters.Add(new OleDbParameter("@UnitID", idUnit));
                await Task.Run(() => cmd.ExecuteNonQuery());
            }
        }
        // ..... Raw Material Input => not finished
        public async Task TransferRawMaterialInput()
        {
            // Load Data from Old Database
            string strQry = "SELECT * FROM RM";
            OleDbCommand cmd = new OleDbCommand(strQry, dbOld);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            await Task.Run(() => da.Fill(ds, "RawMaterialInput"));

            var i = 0;

            // Clear all data in RawMaterialInput before transfer
            //strQry = "DELETE FROM RawMaterialInput";
            //cmd = new OleDbCommand(strQry, dbNew);
            //await Task.Run(() => cmd.ExecuteNonQuery());

            //strQry = "";
            //cmd = new OleDbCommand(strQry, dbNew);
            //foreach(DataRow dr in ds.Tables["RawMaterialInput"].Rows)
            //{

            //}
        }
        public async Task TransferCustomsDeclaration()
        {
            // Clear CustomsDeclaration table in new Database
            string strQry = "DELETE FROM CustomsDeclaration";
            OleDbCommand cmd = new OleDbCommand(strQry, dbNew);
            await Task.Run(() => cmd.ExecuteNonQuery());

            // Load data from old Database
            strQry = "SELECT CusDecNo, MAX(OpenDate) AS OpenDate, MAX(ReceivedDate) AS ReceivedDate, MAX(InputDate) AS InputDate FROM RM GROUP BY CusDecNo;";
            cmd = new OleDbCommand(strQry, dbOld);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            await Task.Run(() => da.Fill(ds, "CustomsDeclaration"));

            strQry = "INSERT INTO CustomsDeclaration VALUES (@Code, @OpenDate, @GoodsArrivalDate, @InputDate)";
            cmd = new OleDbCommand(strQry, dbNew);
            foreach (DataRow dr in ds.Tables["CustomsDeclaration"].Rows)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Code", dr["CusDecNo"].ToString());
                cmd.Parameters.AddWithValue("@OpenDate", DateTime.TryParse(dr["OpenDate"].ToString(), out DateTime dtOut1) ? dtOut1 : new DateTime());
                cmd.Parameters.AddWithValue("@GoodsArrivalDate", DateTime.TryParse(dr["ReceivedDate"].ToString(), out DateTime dtOut2) ? dtOut2 : new DateTime());
                cmd.Parameters.AddWithValue("@InputDate", DateTime.TryParse(dr["InputDate"].ToString(), out DateTime dtOut3) ? dtOut3 : new DateTime());
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region Database
        /*
        //public async Task OldDatabase_Get()
        //{
        //    db = new OleDbConnection(strCon);
        //    db.Open();

        //    List<Task> tasks = new List<Task>
        //    {
        //        Task.Run(() => RM_Load()),
        //        Task.Run(() => FG_Load()),
        //        Task.Run(() => BoM_Load())
        //    };

        //    //Task tskRM = Task.Run(() => RM_Load());
        //    //Task tskFG = Task.Run(() => FG_Load());
        //    //Task tskBoM = Task.Run(() => BoM_Load());


        //}

        //public async Task RM_Load()
        //{
        //    OleDbCommand cmd = new OleDbCommand("SELECT * FROM RM", db);
        //    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //    await Task.Run(() => da.Fill(ds, "RM"));

        //    RMList = new ObservableCollection<Model.RM>();

        //    foreach (DataRow dr in ds.Tables["RM"].Rows)
        //    {
        //        RMList.Add(new Model.RM()
        //        {
        //            InputDate = DateTime.TryParse(dr["InputDate"].ToString(),
        //                    out DateTime out1) ? out1 : new DateTime(),
        //            CusDecNo = dr["CusDecNo"].ToString(),
        //            OpenDate = DateTime.TryParse(dr["OpenDate"].ToString(),
        //                    out DateTime out2) ? out2 : new DateTime(),
        //            ReceivedDate = DateTime.TryParse(dr["ReceivedDate"].ToString(),
        //                    out DateTime out3) ? out3 : new DateTime(),
        //            RMCode = dr["RMCode"].ToString(),
        //            RMName = dr["RMName"].ToString(),
        //            HSCode = dr["HSCode"].ToString(),
        //            Price = decimal.TryParse(dr["Price"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out4) ? out4 : 0,
        //            ExRate = decimal.TryParse(dr["ExRate"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out5) ? out5 : 0,
        //            TaxRate = decimal.TryParse(dr["TaxRate"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out6) ? out6 : 0,
        //            Tax = decimal.TryParse(dr["Tax"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out7) ? out7 : 0,
        //            PriceOutput = decimal.TryParse(dr["PriceOutput"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out8) ? out8 : 0,
        //            Input = decimal.TryParse(dr["Input"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out9) ? out9 : 0,
        //            Output = decimal.TryParse(dr["Output"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out0) ? out0 : 0
        //        });
        //    }
        //}
        //public async Task FG_Load()
        //{
        //    OleDbCommand cmd = new OleDbCommand("SELECT * FROM FG", db);
        //    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //    await Task.Run(() => da.Fill(ds, "FG"));

        //    FGList = new ObservableCollection<Model.FG>();

        //    foreach (DataRow dr in ds.Tables["FG"].Rows)
        //    {
        //        FGList.Add(new Model.FG()
        //        {
        //            ItemCode = (string)dr["ItemCode"].ToString(),
        //            FGName = (string)dr["FGName"].ToString(),
        //            HSCode = (string)dr["HSCode"].ToString(),
        //            FGCode = (string)dr["FGCode"].ToString(),
        //            Qty = decimal.TryParse(dr["Qty"].ToString(),
        //                    System.Globalization.NumberStyles.Any, null,
        //                    out decimal out1) ? out1 : 0,
        //            Customer = (string)dr["Customer"].ToString(),
        //            PO = (string)dr["PO"].ToString(),
        //            Invoice = (string)dr["Invoice"].ToString(),
        //            Date = DateTime.TryParse(dr["Date"].ToString(), out DateTime out2) ? out2 : new DateTime(),
        //            LogCode = (string)dr["LogCode"].ToString()
        //        });
        //    }
        //}
        //private async Task BoM_Load()
        //{
        //    OleDbCommand cmd = new OleDbCommand("SELECT * FROM BoM", db);
        //    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //    await Task.Run(() => da.Fill(ds, "BoM"));

        //    BoMList = new ObservableCollection<Model.BoM>();

        //    foreach(DataRow dr in ds.Tables["BoM"].Rows)
        //    {
        //        BoMList.Add(new Model.BoM()
        //        {
        //            FGCode = (string)dr["FGCode"].ToString(),
        //            RMCode = (string)dr["RMCode"].ToString(),
        //            RMName = (string)dr["RMName"].ToString(),
        //            Unit = (string)dr["Unit"].ToString(),
        //            BoMQty = decimal.TryParse(dr["BoM"].ToString(),
        //                        System.Globalization.NumberStyles.Any, null,
        //                        out decimal Result1) ? Result1 : 0,
        //            Rate = decimal.TryParse(dr["Rate"].ToString(),
        //                        System.Globalization.NumberStyles.Any, null,
        //                        out decimal Result2) ? Result2 : 0,
        //            BoMTotal = decimal.TryParse(dr["BoMTotal"].ToString(),
        //                        System.Globalization.NumberStyles.Any, null,
        //                        out decimal Result3) ? Result3 : 0,
        //            Supplier = (string)dr["Supplier"].ToString()
        //        });
        //    }
        //}
        */
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
            _canExecute = canExecute;
            _execute = execute ?? throw new ArgumentNullException("execute");
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
