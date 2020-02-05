using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniERP.ViewModel
{
    public class FormulaViewModel : BaseViewModel
    {
        public ICommand FormulaAddItemCommand { get; set; }

        public FormulaViewModel()
        {
            FormulaAddItemCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
             {
                 View.FormulaAddItemWindow formulaAddItemWindow = new View.FormulaAddItemWindow();
                 formulaAddItemWindow.ShowDialog();
             });
        }
    }
}
