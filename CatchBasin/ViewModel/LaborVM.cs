using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchBasin.ViewModel
{
	class LaborVM : BaseVM, Helper.IDetailVM
	{
		WorkOrderDetailVM WorkOrderDetailVM { get; set; }

		private Command.CancelCommand<LaborVM> cancelCommand;

		public Command.CancelCommand<LaborVM> CancelCommand
		{
			get { return cancelCommand; }
			set { cancelCommand = value; }
		}

		private Command.SaveCommand<LaborVM> saveCommand;

		public Command.SaveCommand<LaborVM> SaveCommand
		{
			get { return saveCommand; }
			set { saveCommand = value; }
		}

		private string type;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}



		private List<MaximoUser> laborList;

		public List<MaximoUser> LaborList
		{
			get { return laborList; }
			set { laborList = value; }
		}

		private string labor;

		public string Labor
		{
			get { return labor; }
			set { labor = value; }
		}


		private bool isDriver;

		public bool IsDriver
		{
			get { return isDriver; }
			set { isDriver = value; }
		}
		private bool isLeadMan;

		public bool IsLeadMan
		{
			get { return isLeadMan; }
			set { isLeadMan = value; }
		}
		private bool isSecondMan;

		public bool IsSecondMan
		{
			get { return isSecondMan; }
			set { isSecondMan = value; }
		}


		public LaborVM(WorkOrderDetailVM workOrderDetailVM)
		{
			WorkOrderDetailVM = workOrderDetailVM;
		}

		public void Save()
		{
			
		}

		public void Cancel()
		{
			
		}
	}
}
