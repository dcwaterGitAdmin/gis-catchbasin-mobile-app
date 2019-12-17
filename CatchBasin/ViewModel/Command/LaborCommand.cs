using CatchBasin.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Command
{
	class LaborCommand : ICommand
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
		public LaborCommand(WorkOrderDetailVM workOrderDetailVM)
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
			Labor.DataContext = new LaborVM(WorkOrderDetailVM);
			Labor.ShowInTaskbar = false;
			//Labor.Owner = ((App)Application.Current).MainWindow;
			Labor.ShowDialog();


		}
	}
}
