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

        public override void Execute(object parameter)
        {
            MapVM.ShowCreateWorkOrder();
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
            MapVM.DoLogout((Map) parameter);
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
