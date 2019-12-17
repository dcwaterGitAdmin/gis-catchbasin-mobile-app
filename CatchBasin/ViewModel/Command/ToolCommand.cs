using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CatchBasin.View;
namespace CatchBasin.ViewModel.Command
{
	class ToolCommand : ICommand
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
		public ToolCommand(WorkOrderDetailVM workOrderDetailVM)
		{
			WorkOrderDetailVM = workOrderDetailVM;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			Tool Tool = new Tool();
			Tool.DataContext = new ToolVM(WorkOrderDetailVM);
			Tool.ShowInTaskbar = false;
			//Tool.Owner = ((App)Application.Current).MainWindow;
			Tool.ShowDialog();
		}
	}
}
