using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniERP.ViewModel
{
    public class FinishGoodViewModel : BaseViewModel
    {
        public ICommand FinishGoodAddItemCommand { get; set; }

        public FinishGoodViewModel()
        {
            FinishGoodAddItemCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
              {
                  View.FinishGoodAddItemWindow finishGoodAddItemWindow = new View.FinishGoodAddItemWindow();
                  finishGoodAddItemWindow.ShowDialog();
              });
        }
    }
}
