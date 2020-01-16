using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CatchBasin.View;
using MaximoServiceLibrary;
using MaximoServiceLibrary.model;

namespace CatchBasin.ViewModel.Command
{
	class CompleteCommand : ICommand
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
		public CompleteCommand(WorkOrderDetailVM workOrderDetailVM)
		{
			WorkOrderDetailVM = workOrderDetailVM;
			
		}

		public bool CanExecute(object parameter)
		{

            var values = MaximoServiceLibrary.AppContext.workOrderRepository.findNot("startTimerDate", null).ToList();
            if (values.Count > 0)
            {
                if(values.First().wonum == WorkOrderDetailVM.MaximoWorkOrder?.wonum)
                {
                    return false;
                }
            }

            if (WorkOrderDetailVM.ToolTrans.Count > 0 && WorkOrderDetailVM.LabTrans.Count > 0 && ( (WorkOrderDetailVM.MaximoWorkOrder.worktype == "CM") || (!String.IsNullOrEmpty(WorkOrderDetailVM.DebrisCondition)) || (!String.IsNullOrEmpty(WorkOrderDetailVM.DebrisConditionAC) && !String.IsNullOrEmpty(WorkOrderDetailVM.DebrisConditionPC))))
			{
				return true;
			}
			else
			{
				return false;
			}
			
			// if user didnt changed any value in workorder, can user will complete workorder?
		}

		public void Execute(object parameter)
		{
			CompleteWorkOrder CompleteWorkOrder = new CompleteWorkOrder();
			CompleteWorkOrder.DataContext = new CompleteWorkorderVM(WorkOrderDetailVM);
			CompleteWorkOrder.ShowInTaskbar = false;
			//CompleteWorkOrder.Owner = ((App)Application.Current).MainWindow;
			CompleteWorkOrder.ShowDialog();

		}
	}
}
