using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CatchBasin.ViewModel
{
	class ToolVM:BaseVM, Helper.IDetailVM
	{

		private Command.CancelCommand<ToolVM> cancelCommand;

		public Command.CancelCommand<ToolVM> CancelCommand
		{
			get { return cancelCommand; }
			set { cancelCommand = value; }
		}

		private Command.SaveCommand<ToolVM> saveCommand;

		public Command.SaveCommand<ToolVM> SaveCommand
		{
			get { return saveCommand; }
			set { saveCommand = value; }
		}

		private string tool;

		public string Tool
		{
			get { return tool; }
			set { tool = value; }
		}
		private string quantity;

		public string Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}
		private DateTime duration;

		public DateTime Duration
		{
			get { return duration; }
			set { duration = value; }
		}


		bool isDirty { get; set; }
		WorkOrderDetailVM WorkOrderDetailVM { get; set; }
		
		public ToolVM(WorkOrderDetailVM workOrderDetailVM)
		{
			WorkOrderDetailVM = workOrderDetailVM;
			CancelCommand = new Command.CancelCommand<ToolVM>(this);
			SaveCommand = new Command.SaveCommand<ToolVM>(this);
		}

		public void Save()
		{
			
			MaximoToolTrans tool = new MaximoToolTrans();
			tool.transdate = DateTime.Now;
			tool.toolrate = 0;
			tool.toolqty = Convert.ToInt32(Quantity);
			//tool.toolhrs
			List<MaximoToolItem> tools = new List<MaximoToolItem>();
			MaximoToolItem _tool = new MaximoToolItem();
			_tool.itemnum = Tool;
			tool.toolitem = tools;

			tool.itemsetid = "IDC_WASA";
			tool.enterdate = DateTime.Now;
			tool.enterby = ((App)Application.Current).MaximoServiceLibraryBeanConfiguration.maximoService.mxuser.personId;
			tool.langcode = "EN";

			WorkOrderDetailVM.Actuals.Add(tool);
			

		}

		public void Cancel()
		{


			foreach (var window in ((App)Application.Current).Windows)
			{
				if(window is View.Tool)
				{
					((View.Tool)window).Close();
				}
			}
		}
	}
}
