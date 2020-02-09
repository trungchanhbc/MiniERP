using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniERP.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Language
        #endregion

        public ICommand LoadSettingsWindowCmd { get; set; }
        public SettingsViewModel()
        {
            LoadSettingsWindowCmd = new RelayCommand<ComboBox>((p) => { return true; }, (p) => {
                string LangCode = Properties.Settings.Default.Language;
                switch (LangCode)
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
            });
        }
    }
}
