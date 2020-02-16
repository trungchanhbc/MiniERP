using MiniERP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiniERP.View
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();

            //const string strConOld = @"Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=..\\..\\Database\\OldDatabase.accdb;JET OLEDB:DATABASE PASSWORD=1234567890";
            //OleDbConnection dbOld = new OleDbConnection(strConOld);
            //dbOld.Open();

            //const string strConNew = @"Provider=Microsoft.ACE.OLEDB.12.0;DATA SOURCE=..\\..\\Database\\Database.accdb;JET OLEDB:DATABASE PASSWORD=1234567890";
            //OleDbConnection dbNew = new OleDbConnection(strConNew);
            //dbNew.Open();

            //DataSet ds = new DataSet();

            //OleDbCommand cmdOld = new OleDbCommand("SELECT RM.RMCode, MAX(RM.RMName) AS RMName, MAX(RM.HSCode) AS HSCode, MAX(BoM.Unit) AS Unit FROM RM, BoM WHERE RM.RMCode=BoM.RMCode GROUP BY RM.RMCode", dbOld);
            //OleDbDataAdapter daOld = new OleDbDataAdapter(cmdOld);
            //daOld.Fill(ds, "RawMaterialInfo");

            //ObservableCollection<RawMaterialInfo> rawMaterialInfos = new ObservableCollection<RawMaterialInfo>();

            //using (OleDbCommand cmd = new OleDbCommand("DELETE * FROM RawMaterialInfo", dbNew))
            //    cmd.ExecuteNonQuery();

            //foreach (DataRow dr in ds.Tables["RawMaterialInfo"].Rows)
            //{
            //    // Check and fix Unit by ID 
            //    string strUnit = dr["Unit"].ToString().Replace(" ", "").ToLower();
            //    int idUnit = 0;
            //    switch (strUnit)
            //    {
            //        case "kg":
            //            idUnit = 1;
            //            break;
            //        case "cái":
            //            idUnit = 2;
            //            break;
            //        default:
            //            idUnit = 9999;
            //            break;
            //    }


            //    string strQuery = "INSERT INTO RawMaterialInfo (Code, Name, HSCode, UnitID) VALUES (?,?,?,?);";
            //    using (OleDbCommand cmd = new OleDbCommand(strQuery, dbNew))
            //    {

            //        cmd.Parameters.AddWithValue("Code", dr["RMCode"].ToString());
            //        cmd.Parameters.AddWithValue("Name", dr["RMName"].ToString());
            //        cmd.Parameters.AddWithValue("HSCode", dr["HSCode"].ToString());
            //        cmd.Parameters.AddWithValue("UnitID", idUnit);

            //        if (dbNew.State == ConnectionState.Closed)
            //            dbNew.Open();

            //        cmd.ExecuteNonQuery();
            //    }
            //}

            //MessageBox.Show("Done!!!");
        }
    }
}
