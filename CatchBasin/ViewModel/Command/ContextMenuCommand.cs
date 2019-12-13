//using Microsoft.Win32;
using MaximoServiceLibrary.model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Command
{

	class FlashCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		MapVM MapVM;
		public FlashCommand(MapVM mapVM)
		{
			MapVM = mapVM;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

			MaximoWorkOrder wo = (MaximoWorkOrder)parameter;
			MapVM.FlashAsync(wo);
		}
	}

	class ZoomToCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		MapVM MapVM;
		public ZoomToCommand(MapVM mapVM)
		{
			MapVM = mapVM;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

			MaximoWorkOrder wo = (MaximoWorkOrder)parameter;
			MapVM.ZoomToWoAsync(wo);
		}
	}

	class PanToCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		MapVM MapVM;
		public PanToCommand(MapVM mapVM)
		{
			MapVM = mapVM;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

			MaximoWorkOrder wo = (MaximoWorkOrder)parameter;
			MapVM.PanToWoAsync(wo);
		}
	}
}
