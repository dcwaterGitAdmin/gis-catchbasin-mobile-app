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
	class StartStopTimerCommand : ICommand
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

		
		WorkOrderListVM WorkOrderListVM;
		public StartStopTimerCommand(WorkOrderListVM workOrderListVM)
		{
			WorkOrderListVM = workOrderListVM;
			
		}

		public bool CanExecute(object parameter)
		{
			if (parameter == null) return false;
			var values = MaximoServiceLibrary.AppContext.workOrderRepository.findNot("startTimerDate", null).ToList();
			if(values.Count > 0)
			{
				if(values[0].Id == ((MaximoWorkOrder)parameter).Id)
				{
					return true;
				}
				else
				{
					return false;
				}
				
			}
			else
			{
				return true;
			}
		
		}

		public void Execute(object parameter)
		{
			MaximoWorkOrder wo = ((MaximoWorkOrder)parameter);
			if(wo.startTimerDate == null)
			{
				wo.startTimerDate = DateTime.Now;
				wo.timerImageUri = "pack://application:,,,/CatchBasin;component/Resources/Images/startWatch.png";
				MaximoServiceLibrary.AppContext.workOrderRepository.upsert(wo);
				WorkOrderListVM.Update();
			}
			else
			{
				DateTime stopTimerDate = DateTime.Now;
				DateTime startTimerDate = Convert.ToDateTime(wo.startTimerDate);
				TimeSpan? time = stopTimerDate - wo.startTimerDate;
				Console.WriteLine($"time :{time}");

				var mxuser = MaximoServiceLibrary.AppContext.synchronizationService.mxuser;

				MaximoLabTrans labTrans = new MaximoLabTrans();
				MaximoLabTrans secondlabTrans = new MaximoLabTrans();


				labTrans.startdateentered = startTimerDate;
				labTrans.starttimeentered = new DateTime(1900, 1, 1) + startTimerDate.TimeOfDay;
				labTrans.finishdateentered = stopTimerDate;
				labTrans.finishtimeentered = new DateTime(1900, 1, 1) + stopTimerDate.TimeOfDay;
				labTrans.transdate = DateTime.Now;

				if(wo.worktype =="EM" || wo.worktype == "INV" || wo.worktype == "EMERG"){
					labTrans.transtype = "TRAVEL";
				}
				else
				{
					labTrans.transtype = "WORK";
				}
				
				var _labors =MaximoServiceLibrary.AppContext.laborRepository.Find("person[*].personid", mxuser.userPreferences.setting?.leadMan).ToList() ;
				try
				{
					labTrans.craft = _labors?[0].laborcraftrate?[0].craft;
				}
				catch(Exception e)
				{
					labTrans.craft = null;
				}
				
				labTrans.siteid = "DWS_DSS";
				labTrans.orgid = "DC_WASA";
				labTrans.dcw_truckdriver = mxuser.userPreferences.setting?.leadMan == mxuser.userPreferences.setting?.driverMan;
				labTrans.dcw_trucksecond = false;
				labTrans.dcw_trucklead = true;
				labTrans.dcw_trucknum = mxuser.userPreferences.setting.vehiclenum;
				labTrans.enterdate = DateTime.Now;
				labTrans.laborcode = mxuser.userPreferences.setting?.leadMan;
				labTrans.enterby = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser.personId;
				labTrans.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;



				if (((App)Application.Current).AppType == "PM")
				{
					
					secondlabTrans.startdateentered = startTimerDate;
					secondlabTrans.starttimeentered = new DateTime(1900, 1, 1) + startTimerDate.TimeOfDay;
					secondlabTrans.finishdateentered = stopTimerDate;
					secondlabTrans.finishtimeentered = new DateTime(1900, 1, 1) + stopTimerDate.TimeOfDay;
					secondlabTrans.transdate = DateTime.Now;
					if (wo.worktype == "EM" || wo.worktype == "INV" || wo.worktype == "EMERG")
					{
						secondlabTrans.transtype = "TRAVEL";
					}
					else
					{
						secondlabTrans.transtype = "WORK";
					}
					_labors = MaximoServiceLibrary.AppContext.laborRepository.Find("person[*].personid", mxuser.userPreferences.setting?.secondMan).ToList();
					try
					{
						secondlabTrans.craft = _labors?[0].laborcraftrate?[0].craft;
					}
					catch (Exception e)
					{
						secondlabTrans.craft = null;
					}
					secondlabTrans.siteid = "DWS_DSS";
					secondlabTrans.orgid = "DC_WASA";
					secondlabTrans.dcw_truckdriver = mxuser.userPreferences.setting?.secondMan == mxuser.userPreferences.setting?.driverMan;
					secondlabTrans.dcw_trucksecond = true;
					secondlabTrans.dcw_trucklead = false;
					secondlabTrans.dcw_trucknum = mxuser.userPreferences.setting.vehiclenum;
					secondlabTrans.enterdate = DateTime.Now;
					secondlabTrans.laborcode = mxuser.userPreferences.setting?.secondMan;
					secondlabTrans.enterby = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser.personId;
					secondlabTrans.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				}
				

				MaximoToolTrans tool = new MaximoToolTrans();
				tool.transdate = DateTime.Now;
				tool.toolrate = 0;
				tool.toolqty = 1;
				if (time.HasValue)
				{
					tool.toolhrs = time.Value.TotalHours;
				}
				tool.itemnum = mxuser.userPreferences.setting.vehiclenum;
				tool.itemsetid = "IDC_WASA";
				tool.enterdate = DateTime.Now;
				tool.enterby = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser.personId;
				tool.langcode = "EN";
				tool.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				



				if (WorkOrderListVM.MapVM.WorkOrderDetailIsVisible && wo == WorkOrderListVM.MapVM.WorkOrderDetailVM.MaximoWorkOrder)
				{
					WorkOrderListVM.MapVM.WorkOrderDetailVM.LabTrans.Add(labTrans);
					if (((App)Application.Current).AppType == "PM")
					{
						WorkOrderListVM.MapVM.WorkOrderDetailVM.LabTrans.Add(secondlabTrans);

					}
					WorkOrderListVM.MapVM.WorkOrderDetailVM.ToolTrans.Add(tool);
				}
				else
				{
					if(wo.labtrans == null)
					{
						wo.labtrans = new List<MaximoLabTrans>();
				
					}
					wo.labtrans.Add(labTrans);

					if (((App)Application.Current).AppType == "PM")
					{
						wo.labtrans.Add(secondlabTrans);

					}

					if (wo.tooltrans == null)
					{
						wo.tooltrans = new List<MaximoToolTrans>();
					}
					wo.tooltrans.Add(tool);
					
				}

				wo.startTimerDate = null;
				wo.timerImageUri = "pack://application:,,,/CatchBasin;component/Resources/Images/stopWatch.png";
				wo = MaximoServiceLibrary.AppContext.workOrderRepository.upsert(wo);
				WorkOrderListVM.Update();
				if (!WorkOrderListVM.MapVM.WorkOrderDetailIsVisible)
				{
					WorkOrderListVM.showWorkOrder(wo);
				}
			}
			
		}
	}
}
