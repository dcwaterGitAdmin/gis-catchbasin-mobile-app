﻿using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
			set { type = value; OnPropertyChanged("Type"); }
		}



		private List<MaximoPerson> laborList;

		public List<MaximoPerson> LaborList
		{
			get { return laborList; }
			set { laborList = value; OnPropertyChanged("LaborList"); }
		}

		private string labor;

		public string Labor
		{
			get { return labor; }
			set { labor = value; OnPropertyChanged("Labor"); }
		}

		private DateTime startDate;

		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; OnPropertyChanged("StartDate"); }
		}

		private DateTime duration;

		public DateTime Duration
		{
			get { return duration; }
			set { duration = value; OnPropertyChanged("Duration"); }
		}


		private bool isDriver;

		public bool IsDriver
		{
			get { return isDriver; }
			set { isDriver = value; OnPropertyChanged("IsDriver"); }
		}
		private bool isLeadMan;

		public bool IsLeadMan
		{
			get { return isLeadMan; }
			set { isLeadMan = value; OnPropertyChanged("IsLeadMan"); }
		}
		private bool isSecondMan;

		public bool IsSecondMan
		{
			get { return isSecondMan; }
			set { isSecondMan = value; OnPropertyChanged("IsSecondMan"); }
		}

		MaximoLabTrans LabTrans { get; set; }
		public LaborVM(WorkOrderDetailVM workOrderDetailVM, MaximoLabTrans labTrans = null)
		{
			WorkOrderDetailVM = workOrderDetailVM;
			CancelCommand = new Command.CancelCommand<LaborVM>(this);
			SaveCommand = new Command.SaveCommand<LaborVM>(this);
			LabTrans = labTrans;


			List<string> craftrate;
			if (((App)Application.Current).AppType == "PM")
			{
				craftrate = new string[] { "SSWR", "SSLR", "SSWL" }.ToList();
			}
			else
			{
				craftrate = new string[] { "SSWR", "SSLR", "SSWL", "SCRW", "CNRW" }.ToList();
			}

			var labors = MaximoServiceLibrary.AppContext.laborRepository.findAll().Where(labor => labor.laborcraftrate.Where(laborcraftrate => craftrate.Contains(laborcraftrate.craft)).Count() > 0);
			LaborList = new List<MaximoPerson>();
			foreach (var labor in labors)
			{
				LaborList.AddRange(labor.person.Where(per => per.status == "ACTIVE").ToList());
			}

			if (LabTrans != null)
			{
				StartDate = LabTrans.startdateentered + LabTrans.starttimeentered.TimeOfDay;
				Duration = new DateTime(1900, 1, 1) + (LabTrans.finishdateentered + LabTrans.finishtimeentered.TimeOfDay - LabTrans.startdateentered - LabTrans.starttimeentered.TimeOfDay);
				IsDriver = LabTrans.dcw_truckdriver;
				IsSecondMan = LabTrans.dcw_trucksecond;
				IsLeadMan = LabTrans.dcw_trucklead;
				Labor = LabTrans.laborcode;
				Type = LabTrans.transtype;
			}
			else
			{
				StartDate = DateTime.Now;
				Type = "WORK";
				Labor = MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences?.setting?.leadMan;
			}
		}

		public void Save()
		{
            if (String.IsNullOrEmpty(Labor))
            {
                MessageBox.Show("Please Select Labor", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

			if(LabTrans == null)
			{
				MaximoLabTrans labTrans = new MaximoLabTrans();
				labTrans.startdateentered = StartDate.Date;
				labTrans.starttimeentered = new DateTime(1900, 1, 1) + StartDate.TimeOfDay;
				labTrans.finishdateentered = (StartDate + Duration.TimeOfDay).Date;
				labTrans.finishtimeentered = new DateTime(1900, 1, 1) + (StartDate + Duration.TimeOfDay).TimeOfDay;
				labTrans.transdate = DateTime.Now;
				labTrans.transtype = Type;


                var _labor = MaximoServiceLibrary.AppContext.laborRepository.Find("person[*].personid", Labor).FirstOrDefault();
               
                labTrans.craft = _labor?.laborcraftrate.FirstOrDefault()?.craft;
                
        
                labTrans.craft = null;
				labTrans.laborcode = null;
				labTrans.siteid = "DWS_DSS";
				labTrans.orgid = "DC_WASA";
				labTrans.dcw_truckdriver = IsDriver;
				labTrans.dcw_trucksecond = IsSecondMan;
				labTrans.dcw_trucklead = IsLeadMan;
				labTrans.dcw_trucknum = MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences?.setting?.vehiclenum;
				labTrans.enterdate = DateTime.Now;
				labTrans.laborcode = Labor;

				labTrans.enterby = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser.personId;
				labTrans.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				WorkOrderDetailVM.LabTrans.Add(labTrans);
			}
			else
			{

				var index = WorkOrderDetailVM.LabTrans.IndexOf(LabTrans);
				LabTrans.dcw_truckdriver = IsDriver;
				LabTrans.dcw_trucksecond = IsSecondMan;
				LabTrans.dcw_trucklead = IsLeadMan;
				LabTrans.transtype = Type;
				LabTrans.startdateentered = StartDate.Date;
				LabTrans.starttimeentered = new DateTime(1900, 1, 1) + StartDate.TimeOfDay;
				LabTrans.finishdateentered = (StartDate + Duration.TimeOfDay).Date;
				LabTrans.finishtimeentered = new DateTime(1900, 1, 1) + (StartDate + Duration.TimeOfDay).TimeOfDay;
				LabTrans.enterdate = DateTime.Now;
				LabTrans.laborcode = Labor;
                var _labor = MaximoServiceLibrary.AppContext.laborRepository.Find("person[*].personid", Labor).FirstOrDefault();

                LabTrans.craft = _labor?.laborcraftrate.FirstOrDefault()?.craft;

                LabTrans.enterby = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser.personId;

				if(LabTrans.syncronizationStatus != LocalDBLibrary.model.SyncronizationStatus.CREATED)
				{
					LabTrans.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
				}
				WorkOrderDetailVM.LabTrans[index] = LabTrans;

                var otherLabor =WorkOrderDetailVM.LabTrans.FirstOrDefault(lbtrns => lbtrns.startdateentered == LabTrans.startdateentered &&
                lbtrns.starttimeentered == LabTrans.starttimeentered &&
                lbtrns.finishdateentered == LabTrans.finishdateentered &&
                lbtrns.finishtimeentered == LabTrans.finishtimeentered &&
                lbtrns.laborcode != LabTrans.laborcode);

                if(otherLabor != null)
                {
                    var otherIndex = WorkOrderDetailVM.LabTrans.IndexOf(otherLabor);
                    otherLabor.transtype = Type;
                    if (otherLabor.syncronizationStatus != LocalDBLibrary.model.SyncronizationStatus.CREATED)
                    {
                        otherLabor.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
                    }
                    WorkOrderDetailVM.LabTrans[otherIndex] = otherLabor;
                }


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
				if (window is View.Labor)
				{
					((View.Labor)window).Close();
				}
			}
		}
	}
}
