﻿using System;
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
        public ICommand MainWindowLoaded { get; set; }
        public ICommand RawMaterialCommand { get; set; }
        public ICommand FinishGoodCommand { get; set; }
        public ICommand FormulaCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand SettingsCMD { get; set; }
        public ICommand RegistrationCMD { get; set; }
        #endregion

        public MainViewModel()
        {
            MainWindowLoaded = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Task tskCheckRegistered = Task.Run(async () => CheckRegistered());
            });

            RawMaterialCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                MiniERP.View.RawMaterialWindow rawMaterialWindow = new View.RawMaterialWindow();
                rawMaterialWindow.Show();
            });

            FinishGoodCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MiniERP.View.FinishGoodWindow finishGoodWindow = new View.FinishGoodWindow();
                finishGoodWindow.Show();
            });

            FormulaCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                MiniERP.View.FormulaWindow formulaWindow = new View.FormulaWindow();
                formulaWindow.Show();
            });

            ReportCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            });

            SettingsCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                View.SettingsWindow settingsWindow = new View.SettingsWindow();
                settingsWindow.ShowDialog();
            });

            RegistrationCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                View.RegistrationWindow registrationWindow = new View.RegistrationWindow();
                registrationWindow.ShowDialog();
            });
        }

       
    }
}
