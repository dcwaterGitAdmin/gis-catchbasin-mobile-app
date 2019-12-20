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
    class ShowLaborCommand : ICommand
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

        public ShowLaborCommand(WorkOrderDetailVM workOrderDetailVM)
        {
            WorkOrderDetailVM = workOrderDetailVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

			
			Labor Labor = new Labor();
            Labor.DataContext = new LaborVM(WorkOrderDetailVM,(MaximoLabTrans)parameter);
            Labor.ShowInTaskbar = false;
            try
            {
                Labor.Owner = ((App)Application.Current).MainWindow;
            }
            catch(Exception e)
            {

            }
            Labor.ShowDialog();
		}

    }
}
