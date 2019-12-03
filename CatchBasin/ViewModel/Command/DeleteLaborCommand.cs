using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CatchBasin.View;
using MaximoServiceLibrary.model;

namespace CatchBasin.ViewModel.Command
{
    class DeleteLaborCommand : ICommand
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

        public DeleteLaborCommand(WorkOrderDetailVM workOrderDetailVM)
        {
            WorkOrderDetailVM = workOrderDetailVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
			WorkOrderDetailVM.LabTrans.Remove((MaximoLabTrans)parameter);
		
		}

    }
}
