﻿using CatchBasin.ViewModel.Helper;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI.Controls;
using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Commands
{

	class Command : ICommand
	{
		public MapVM MapVM;

		public Command(MapVM mapVM)
		{
			MapVM = mapVM;
		}

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

		public virtual bool CanExecute(object parameter)
		{
			return true;
		}

		public virtual void Execute(object parameter)
		{

		}
	}


	// Map Commands
	class IdentifyCommand : Command
	{
		public IdentifyCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.ShowIdentify();
		}
	}

	class MeasureCommand : Command
	{
		public MeasureCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.ShowMeasure();
		}

	}

	class SearchCommand : Command
	{
		public SearchCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.ShowSearch();
		}

	}

	class TOCCommand : Command
	{
		public TOCCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.ShowTOC();
		}

	}

	class SketchCommand : Command
	{
		public SketchCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.OpenSketch((Esri.ArcGISRuntime.UI.Controls.MapView)parameter);
		}

	}

	class ZoomToFullExtentCommand : Command
	{
		public ZoomToFullExtentCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.DoZoomToFullExtent((Esri.ArcGISRuntime.UI.Controls.MapView)parameter);
		}

	}


    class ZoomInCommand : Command
    {
        public ZoomInCommand(MapVM mapVM) : base(mapVM)
        {

        }

        public override void Execute(object parameter)
        {
            var viewpoint = MapVM.MapView.GetCurrentViewpoint(Esri.ArcGISRuntime.Mapping.ViewpointType.CenterAndScale);
            var mapPoint = (MapPoint)viewpoint.TargetGeometry;


            var newviewpoint =new Viewpoint(mapPoint,  viewpoint.TargetScale * 0.8, viewpoint.Rotation);
            ((MapView)parameter).SetViewpoint(newviewpoint);
        }

    }


    class ZoomOutCommand : Command
    {
        public ZoomOutCommand(MapVM mapVM) : base(mapVM)
        {

        }

        public override void Execute(object parameter)
        {
            var viewpoint = MapVM.MapView.GetCurrentViewpoint(Esri.ArcGISRuntime.Mapping.ViewpointType.CenterAndScale);
            var mapPoint = (MapPoint)viewpoint.TargetGeometry;


            var newviewpoint = new Viewpoint(mapPoint, viewpoint.TargetScale * 1.2, viewpoint.Rotation);
            ((MapView)parameter).SetViewpoint(newviewpoint);
        }

    }


    class ZoomWithDrawCommand : Command
    {
        public ZoomWithDrawCommand(MapVM mapVM) : base(mapVM)
        {

        }

        public async override void Execute(object parameter)
        {

            try
            {
                Esri.ArcGISRuntime.Geometry.Geometry newGeometry = await ((MapView)parameter).SketchEditor.StartAsync(Esri.ArcGISRuntime.UI.SketchCreationMode.Rectangle, false);
                ((MapView)parameter).SetViewpointGeometryAsync(newGeometry);
            }
            catch (Exception e)
            {

            }
            
        }

    }


    // Maximo Commands
    class SyncCommand : Command
	{
		public SyncCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.MakeSync();
		}

	}

	class WorkOrdersCommand : Command
	{
		public WorkOrdersCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.ShowWorkOrders();
		}

	}

	class CreateWorkOrderCommand : Command
	{
		public CreateWorkOrderCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override bool CanExecute(object parameter)
		{

			LocalWorkOrderType param = (LocalWorkOrderType) parameter;
			if (((App) Application.Current).AppType == "PM")
			{
				if (param == LocalWorkOrderType.INSPECTNEWLYDISCOVERED)
				{
					return false;
				}else if ((LocalWorkOrderType)parameter == LocalWorkOrderType.NOTININVENTORY || (LocalWorkOrderType)parameter == LocalWorkOrderType.EXISTING)
				{
					return MapVM.WorkOrderDetailVM.MaximoWorkOrder?.worktype == "EMERG" || MapVM.WorkOrderDetailVM?.MaximoWorkOrder?.worktype == "INV";
				}
				else
				{
                    return !(MapVM.WorkOrderDetailVM.MaximoWorkOrder?.worktype == "EMERG" || MapVM.WorkOrderDetailVM?.MaximoWorkOrder?.worktype == "INV");

                }
				
			}
			else
			{
				return param == LocalWorkOrderType.INSPECTNEWLYDISCOVERED;
			}
			
			
		}

		public override void Execute(object parameter)
		{
			var wo = new MaximoWorkOrder();
            wo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
			MaximoWorkOrderFailureReport failureProblemCode;
			MaximoWorkOrderFailureReport failureCause;
			MaximoWorkOrderFailureReport failureRemedy;
			string crew = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser?.userPreferences?.selectedPersonGroup;
			switch ((LocalWorkOrderType)parameter)
			{
				case LocalWorkOrderType.TRUCKDUMPING:
					wo.status = "DISPTCHD";
					wo.statusdate = DateTime.Now;
					wo.description = "CB Cleaning Truck Dumping";
					wo.problemcode = "TRUCKFULL";
					wo.worktype = "CM";
					wo.failurecode = "CATCHBASIN";
					wo.newchildclass = "WORKORDER";
					wo.orgid = "DC_WASA";
					wo.woclass = "WORKORDER";
					wo.wo1 = "CBDUMP";
					wo.receivedvia = "F";
					wo.origproblemtype = "SY";// or CX
					wo.persongroup = crew;
					wo.classstructureid = "1356";
					wo.service = "DSS";
					wo.siteid = "DWS_DSS";

					wo.failurereport = new List<MaximoWorkOrderFailureReport>();
					failureProblemCode = new MaximoWorkOrderFailureReport();
					failureProblemCode.failurecode = "TRUCKFULL";
                    failureProblemCode.type = "PROBLEM";
                    failureProblemCode.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureProblemCode);
					failureCause = new MaximoWorkOrderFailureReport();
					failureCause.failurecode = "FULLTRUCK";
                    failureCause.type = "CAUSE";
                    failureCause.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureCause);
					failureRemedy = new MaximoWorkOrderFailureReport();
					failureRemedy.failurecode = "EMPTYTRUCK";
                    failureRemedy.type = "REMEDY";
                    failureRemedy.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureRemedy);
                    

                    
					break;
				case LocalWorkOrderType.NEWLYDISCOVERED:
					wo.status = "DISPTCHD";
					wo.description = "Newly Discovered Asset cleaned by CB Cleaning Crew";
					wo.problemcode = "PM";
					wo.worktype = "PM";
					wo.failurecode = "CATCHBASIN";
					wo.newchildclass = "WORKORDER";
					wo.orgid = "DC_WASA";
					wo.woclass = "WORKORDER";
					wo.wo1 = "CBPMNOIDAH";
					wo.receivedvia = "F";
					wo.origproblemtype = "SY";
					wo.persongroup = crew;
					wo.classstructureid = "1356";
					wo.service = "DSS";
					wo.siteid = "DWS_DSS";

					wo.failurereport = new List<MaximoWorkOrderFailureReport>();
					failureProblemCode = new MaximoWorkOrderFailureReport();
					failureProblemCode.failurecode = "PM";
                    failureProblemCode.type = "PROBLEM";
                    failureProblemCode.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureProblemCode);
					failureCause = new MaximoWorkOrderFailureReport();
					failureCause.failurecode = "NEWASSET";
                    failureCause.type = "CAUSE";
                    failureCause.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureCause);
					failureRemedy = new MaximoWorkOrderFailureReport();
					failureRemedy.failurecode = "COMPFOLLUP";
                    failureRemedy.type = "REMEDY";
                    failureRemedy.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureRemedy);
					
                    
					break;
				case LocalWorkOrderType.EXISTING:

                   
                    wo.status = "DISPTCHD";
					wo.description = "CB cleaned by CB Cleaning Crew";
					wo.problemcode = "PM";
					wo.worktype = "PM";
					wo.failurecode = "CATCHBASIN";
					wo.newchildclass = "WORKORDER";
					wo.orgid = "DC_WASA";
					wo.woclass = "WORKORDER";
					wo.wo1 = "CBPMEXIST";
					wo.receivedvia = "F";
					wo.origproblemtype = "SY";
					wo.persongroup = crew;
					wo.classstructureid = "1356";
					wo.service = "DSS";
					wo.siteid = "DWS_DSS";
				
					wo.failurereport = new List<MaximoWorkOrderFailureReport>();
					failureProblemCode = new MaximoWorkOrderFailureReport();
					failureProblemCode.failurecode = "PM";
                    failureProblemCode.type = "PROBLEM";
                    failureProblemCode.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureProblemCode);

					wo.parent = MapVM.WorkOrderDetailVM.MaximoWorkOrder.wonum;
                    
					break;
				case LocalWorkOrderType.NOTININVENTORY:

                  
                    wo.status = "DISPTCHD";
					wo.description = "New Asset cleaned by CB Cleaning Crew";
					wo.problemcode = "PM";
					wo.worktype = "PM";
					wo.failurecode = "CATCHBASIN";
					wo.newchildclass = "WORKORDER";
					wo.orgid = "DC_WASA";
					wo.woclass = "WORKORDER";
					wo.wo1 = "CBPMNOID";
					wo.receivedvia = "F";
					wo.origproblemtype = "SY";
					wo.persongroup = crew;
					wo.classstructureid = "1356";
					wo.service = "DSS";
					wo.siteid = "DWS_DSS";
					

					wo.failurereport = new List<MaximoWorkOrderFailureReport>();
					failureProblemCode = new MaximoWorkOrderFailureReport();
					failureProblemCode.failurecode = "PM";
                    failureProblemCode.type = "PROBLEM";
                    failureProblemCode.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureProblemCode);
					failureCause = new MaximoWorkOrderFailureReport();
					failureCause.failurecode = "NEWASSET";
                    failureCause.type = "CAUSE";
                    failureCause.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureCause);
					failureRemedy = new MaximoWorkOrderFailureReport();
					failureRemedy.failurecode = "COMPFOLLUP";
                    failureRemedy.type = "REMEDY";
                    failureRemedy.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureRemedy);

					wo.parent = MapVM.WorkOrderDetailVM.MaximoWorkOrder.wonum;
                    
					break;
				case LocalWorkOrderType.INSPECTNEWLYDISCOVERED :
					
					
					wo.status = "DISPTCHD";
					wo.description = "Newly Discovered Asset Inspected by DSS";
					wo.problemcode = "PM";
					wo.worktype = "INSP";
					wo.failurecode = "CATCHBASIN";
					wo.newchildclass = "WORKORDER";
					wo.orgid = "DC_WASA";
					wo.woclass = "WORKORDER";
					wo.wo1 = "CBPMNOID";
					wo.receivedvia = "F";
					wo.origproblemtype = "SY";
					wo.persongroup = crew;
					wo.classstructureid = "1356";
					wo.service = "DSS";
					wo.siteid = "DWS_DSS";
                   

                    wo.failurereport = new List<MaximoWorkOrderFailureReport>();
					failureProblemCode = new MaximoWorkOrderFailureReport();
					failureProblemCode.failurecode = "PM";
                    failureProblemCode.type = "PROBLEM";
                    failureProblemCode.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureProblemCode);
					failureCause = new MaximoWorkOrderFailureReport();
					failureCause.failurecode = "NEWASSET";
                    failureCause.type = "CAUSE";
                    failureCause.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureCause);
					failureRemedy = new MaximoWorkOrderFailureReport();
					failureRemedy.failurecode = "COMPFOLLUP";
                    failureRemedy.type = "REMEDY";
                    failureRemedy.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
					wo.failurereport.Add(failureRemedy);

					
					
					break;
			}
            wo.createdTime = DateTime.Now;
            wo = MaximoServiceLibrary.AppContext.workOrderRepository.upsert(wo);
            MapVM.WorkOrderListVM.Update();
            var nwo =MapVM.WorkOrderListVM.WorkOrders.FirstOrDefault(_wo => _wo.Id == wo.Id);
            if(nwo == null)
            {
                MapVM.ShowWorkOrderDetail(wo);
            }
            else
            {
                MapVM.ShowWorkOrderDetail(nwo);
            }

            MapVM.WorkOrderListVM.Update();

        }

	}

	// Applicaton Commands
	class SettingsCommand : Command
	{
		public SettingsCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.ShowSettings();
		}

	}

	class LogoutCommand : Command
	{
		public LogoutCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.DoLogout((Map)parameter);
		}

	}

	// GPS Commands
	class KeepGPSCommand : Command
	{
		public KeepGPSCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override void Execute(object parameter)
		{
			MapVM.DoKeepGPS((Esri.ArcGISRuntime.UI.Controls.MapView)parameter);
		}

	}

	class ShowGPSInfoCommand : Command
	{
		public ShowGPSInfoCommand(MapVM mapVM) : base(mapVM)
		{

		}

		public override bool CanExecute(object parameter)
		{
			if (parameter == null) return false;
			return ((Esri.ArcGISRuntime.UI.Controls.MapView)parameter).LocationDisplay.IsEnabled;
		}

		public override void Execute(object parameter)
		{
			MapVM.DoShowGPSInfo((Esri.ArcGISRuntime.UI.Controls.MapView)parameter);
		}

	}

	class PanToGPSCommand : Command
	{
		public PanToGPSCommand(MapVM mapVM) : base(mapVM)
		{

		}



		public override bool CanExecute(object parameter)
		{
			if (parameter == null) return false;
			return ((Esri.ArcGISRuntime.UI.Controls.MapView)parameter).LocationDisplay.IsEnabled;
		}

		public override void Execute(object parameter)
		{
			MapVM.DoPanToGPS((Esri.ArcGISRuntime.UI.Controls.MapView)parameter);
		}

	}
}
