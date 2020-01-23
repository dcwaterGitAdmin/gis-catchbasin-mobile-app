using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Command
{
    class CreateAssetOnMapCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        WorkOrderDetailVM WorkOrderDetailVM;

        public CreateAssetOnMapCommand(WorkOrderDetailVM workOrderDetailVM)
        {
            WorkOrderDetailVM = workOrderDetailVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                WorkOrderDetailVM.MapVM.MapView.GeoViewTapped -= WorkOrderDetailVM.MapVM.MapTappedForSelectAsset;
            }
            catch (Exception e)
            {

            }
           WorkOrderDetailVM.MapVM.MapTappedForCreateAsset();
        }

    }
}
