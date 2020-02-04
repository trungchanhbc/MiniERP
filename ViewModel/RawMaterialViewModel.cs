using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniERP.ViewModel
{
    class RawMaterialViewModel : BaseViewModel
    {
        public ICommand OpenRawMaterialInputCommand { get; set; }

        public RawMaterialViewModel()
        {
            OpenRawMaterialInputCommand = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                View.RawMaterialInputWindow rawMaterialInputWindow = new View.RawMaterialInputWindow();
                rawMaterialInputWindow.ShowDialog();
            });
        }
    }
}
