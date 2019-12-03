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
			set { tool = value; OnPropertyChanged("Tool"); }
		}
		private string quantity;

		public string Quantity
		{
			get { return quantity; }
			set { quantity = value; OnPropertyChanged("Quantity"); }
		}
		private DateTime duration;

		public DateTime Duration
		{
			get { return duration; }
			set { duration = value; OnPropertyChanged("Duration"); }
		}


		bool isDirty { get; set; }
		WorkOrderDetailVM WorkOrderDetailVM { get; set; }

		MaximoToolTrans ToolTrans { get; set; }
		int Index { get; set; }
		public ToolVM(WorkOrderDetailVM workOrderDetailVM, MaximoToolTrans toolTrans= null)
		{
			WorkOrderDetailVM = workOrderDetailVM;
			CancelCommand = new Command.CancelCommand<ToolVM>(this);
			SaveCommand = new Command.SaveCommand<ToolVM>(this);
			ToolTrans = toolTrans;
			if(ToolTrans!= null)
			{
				Quantity = ToolTrans.toolqty.ToString();
				Duration =  new DateTime(1900, 1, 1).AddHours(ToolTrans.toolhrs);
				Tool = ToolTrans.itemnum;
			}
		
		}

		public void Save()
		{
			if(ToolTrans == null )
			{
				MaximoToolTrans tool = new MaximoToolTrans();
				tool.transdate = DateTime.Now;
				tool.toolrate = 0;
				tool.toolqty = Convert.ToInt32(Quantity);
				tool.toolhrs = Duration.TimeOfDay.TotalHours;
				tool.itemnum = Tool;

				tool.itemsetid = "IDC_WASA";
				tool.enterdate = DateTime.Now;
				tool.enterby = ((App)Application.Current).MaximoServiceLibraryBeanConfiguration.maximoService.mxuser.personId;
				tool.langcode = "EN";
				tool.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				WorkOrderDetailVM.ToolTrans.Add(tool);
			}
			else
			{
				Index = WorkOrderDetailVM.ToolTrans.IndexOf(ToolTrans);
	
				ToolTrans.toolqty = Convert.ToInt32(Quantity);
				ToolTrans.toolhrs = Duration.TimeOfDay.TotalHours;
				ToolTrans.itemnum = Tool;

				ToolTrans.enterdate = DateTime.Now;
				ToolTrans.enterby = ((App)Application.Current).MaximoServiceLibraryBeanConfiguration.maximoService.mxuser.personId;

				if(ToolTrans.syncronizationStatus != LocalDBLibrary.model.SyncronizationStatus.CREATED) {
					ToolTrans.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
				}
				WorkOrderDetailVM.ToolTrans[Index] = ToolTrans;


			}
			
			Close();

		}

		public void Cancel()
		{
			Close();

			
		}

		public void Close()
		{
			foreach (var window in ((App)Application.Current).Windows)
			{
				if (window is View.Tool)
				{
					((View.Tool)window).Close();
				}
			}
		}
	}
}
