using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.OleDb;
using System.Data;
using MiniERP.Model;
using System.Collections.ObjectModel;

namespace MiniERP.ViewModel
{
    public class TestViewModel : BaseViewModel
    {
        //private static ObservableCollection<RM> _RMList;
        //public ObservableCollection<RM> RMList
        //{
        //    get { return _RMList; }
        //    set { _RMList = value; OnPropertyChanged(); }
        //}

        public ICommand TestLoadedCmd { get; set; }

        public TestViewModel()
        {
            TestLoadedCmd = new RelayCommand<ListView>((p) => { return true; }, (p) => 
            {
                TransferData();
                //Task task = Task.Run(() => oldDatabase_Get());
                //oldDatabase_Get();
            });
        }
    }
}
