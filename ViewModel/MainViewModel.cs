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
        private bool isLoadedRawMaterial;
        private bool isLoadedFinishGood;
        private bool isLoadedFormula;
        private bool isLoadedReport;

        #region Commands
        public ICommand RawMaterialCommand { get; set; }
        public ICommand FinishGoodCommand { get; set; }
        public ICommand FormulaCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        #endregion

        public MainViewModel()
        {
            RawMaterialCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                if (!isLoadedRawMaterial)
                {
                    isLoadedRawMaterial = true;
                    MiniERP.View.RawMaterialWindow rawmaterialWindow = new View.RawMaterialWindow();
                    rawmaterialWindow.Show();
                }
            });

            FinishGoodCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (!isLoadedFinishGood)
                {
                    isLoadedFinishGood = true;
                    MiniERP.View.FinishGoodAddWindow finishgoodWindow = new View.FinishGoodAddWindow();
                    finishgoodWindow.Show();
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
        }
    }
}
