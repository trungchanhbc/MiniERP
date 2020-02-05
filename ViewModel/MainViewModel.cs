using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MiniERP;
using MiniERP.Model;

namespace MiniERP.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Commands
        public ICommand RawMaterialCommand { get; set; }
        public ICommand FinishGoodCommand { get; set; }
        public ICommand FormulaCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        #endregion

        public MainViewModel()
        {
            RawMaterialCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (!isLoadedRawMaterial)
                {
                    isLoadedRawMaterial = true;
                    MiniERP.View.RawMaterialWindow rawMaterialWindow = new View.RawMaterialWindow();
                    rawMaterialWindow.Show();
                }
            });

            FinishGoodCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (!isLoadedFinishGood)
                {
                    isLoadedFinishGood = true;
                    MiniERP.View.FinishGoodWindow finishGoodWindow = new View.FinishGoodWindow();
                    finishGoodWindow.Show();
                }
            });

            FormulaCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (!isLoadedFormula)
                {
                    isLoadedFormula = true;
                    MiniERP.View.FormulaWindow formulaWindow = new View.FormulaWindow();
                    formulaWindow.Show();
                }
            });

            ReportCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (!isLoadedReport)
                {
                    isLoadedReport = true;
                }
            });

            SettingsCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                View.SettingsWindow settingsWindow = new View.SettingsWindow();
                settingsWindow.ShowDialog();
            });
        }
    }
}
