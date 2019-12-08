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



				MaximoLabTrans labTrans = new MaximoLabTrans();
				labTrans.startdateentered = startTimerDate;
				labTrans.starttimeentered = new DateTime(1900, 1, 1) + startTimerDate.TimeOfDay;
				labTrans.finishdateentered = stopTimerDate;
				labTrans.finishtimeentered = new DateTime(1900, 1, 1) + stopTimerDate.TimeOfDay;
				labTrans.transdate = DateTime.Now;
				labTrans.transtype = "WORK";
				labTrans.craft = null;
				labTrans.laborcode = null;
				labTrans.siteid = "DWS_DSS";
				labTrans.orgid = "DC_WASA";
				labTrans.dcw_truckdriver = true;
				labTrans.dcw_trucksecond = false;
				labTrans.dcw_trucklead = true;
				labTrans.dcw_trucknum = "";// todo getvehicle
				labTrans.enterdate = DateTime.Now;
				labTrans.laborcode = "";//todo
				labTrans.enterby = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser.personId;
				labTrans.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				



				
				
				if (WorkOrderListVM.MapVM.WorkOrderDetailIsVisible)
				{
					WorkOrderListVM.MapVM.WorkOrderDetailVM.LabTrans.Add(labTrans);
				}
				else
				{
					if(wo.labtrans == null)
					{
						wo.labtrans = new List<MaximoLabTrans>();
				
					}
					
					wo.labtrans.Add(labTrans);
				}

				wo.startTimerDate = null;
				wo.timerImageUri = "pack://application:,,,/CatchBasin;component/Resources/Images/stopWatch.png";
				wo = MaximoServiceLibrary.AppContext.workOrderRepository.upsert(wo);
				WorkOrderListVM.Update();

				WorkOrderListVM.showWorkOrder(wo);
			}
			
		}
	}
}
