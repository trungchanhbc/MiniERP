using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniERP.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand LanguageChangedCmd { get; set; }
        public SettingsViewModel()
        {
            LanguageChangedCmd = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                bool isEN = Properties.Settings.Default.Language == 0 ? true : false;
                LanguageManager.SetLanguageDictionary(isEN ? ELanguage.English : ELanguage.Vietnamese);
                Properties.Settings.Default.Save();
            });
        }
    }
}
