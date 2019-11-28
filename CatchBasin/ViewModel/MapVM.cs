using CatchBasin.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using System.Windows;
using CatchBasin.View;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Ribbon;
using MaximoServiceLibrary.model;

namespace CatchBasin.ViewModel
{

    class MapVM : BaseVM
    {

        

        public MapVM()
        {
            WorkOrderListVM = new WorkOrderListVM(this);
            WorkOrderDetailVM = new WorkOrderDetailVM(this);
            AssetDetailVM = new AssetDetailVM(this);
            IdentifyCommand = new IdentifyCommand(this);

            MeasureIsVisible = false;
            MeasureCommand = new MeasureCommand(this);
            SearchIsVisible = false;
            SearchCommand = new SearchCommand(this);
            TOCIsVisible = false;
            TOCCommand = new TOCCommand(this);
            SketchCommand = new SketchCommand(this);
            ZoomToFullExtentCommand = new ZoomToFullExtentCommand(this);
            SyncCommand = new SyncCommand(this);
            WorkOrdersIsVisible = false;
            WorkOrdersCommand = new WorkOrdersCommand(this);
            CreateWorkOrderCommand = new CreateWorkOrderCommand(this);
            SettingsCommand = new SettingsCommand(this);
            LogoutCommand = new LogoutCommand(this);
            KeepGPSCommand = new KeepGPSCommand(this);
            GPSLocationIsVisible = false;
            ShowGPSInfoCommand = new ShowGPSInfoCommand(this);
            PanToGPSCommand = new PanToGPSCommand(this);
          
        }

        private Esri.ArcGISRuntime.Mapping.Map _map = new Esri.ArcGISRuntime.Mapping.Map(Basemap.CreateStreets());

        public Esri.ArcGISRuntime.Mapping.Map Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        private WorkOrderListVM workOrderListVM;

        public WorkOrderListVM WorkOrderListVM
        {
            get { return workOrderListVM; }
            set { workOrderListVM = value; OnPropertyChanged("WorkOrderListVM"); }
        }

        private WorkOrderDetailVM workOrderDetailVM;

        public WorkOrderDetailVM WorkOrderDetailVM
        {
            get { return workOrderDetailVM; }
            set { workOrderDetailVM = value; OnPropertyChanged("WorkOrderDetailVM"); }
        }
        private bool workOrderDetailIsVisible;

        public bool WorkOrderDetailIsVisible
        {
            get { return workOrderDetailIsVisible; }
            set { workOrderDetailIsVisible = value; OnPropertyChanged("WorkOrderDetailIsVisible"); }
        }


        public void ShowWorkOrderDetail(MaximoWorkOrder wo)
        {
            WorkOrderDetailIsVisible = true;
            WorkOrderDetailVM.Update(wo);
        }

        public void HideWorkOrderDetail()
        {
            WorkOrderDetailIsVisible = false;
            WorkOrderDetailVM.Clear();
        }


        private AssetDetailVM assetDetailVM;

        public AssetDetailVM AssetDetailVM
        {
            get { return assetDetailVM; }
            set { assetDetailVM = value; OnPropertyChanged("AssetDetailVM"); }
        }

        private bool assetDetailIsVisible;

        public bool AssetDetailIsVisible
        {
            get { return assetDetailIsVisible; }
            set { assetDetailIsVisible = value; OnPropertyChanged("AssetDetailIsVisible"); }
        }

        public void ShowAssetDetail(MaximoWorkOrder wo)
        {
            AssetDetailIsVisible = true;
            if(wo != null && wo.asset != null)
            {
                AssetDetailVM.Update(wo.asset);
            }
            
        }

        public void HideAssetDetail()
        {
            AssetDetailIsVisible = false;
            AssetDetailVM.Clear();
        }


        private List<RibbonButton> createWorkOrderList;

        public List<RibbonButton> CreateWorkOrderList
        {
            get { return createWorkOrderList; }
            set { createWorkOrderList = value; OnPropertyChanged("CreateWorkOrderList"); }
        }

        public void generateCreateWorkOrderList(List<string> list)
        {
            List<RibbonButton> menuList = new List<RibbonButton>();
            foreach (string item in list)
            {
                RibbonButton ribbonMenuButton = new RibbonButton();
                ribbonMenuButton.Label = item;
                ribbonMenuButton.Command = CreateWorkOrderCommand;
                menuList.Add(ribbonMenuButton);
            }
            CreateWorkOrderList = menuList;
        }


        private bool identifyIsVisible;
        public bool IdentifyIsVisible
        {
            get { return identifyIsVisible; }
            set { identifyIsVisible = value; }
        }
        public IdentifyCommand IdentifyCommand { get; set; }
        public void ShowIdentify()
        {
            IdentifyIsVisible = !IdentifyIsVisible;
        }

        private bool measureIsVisible;
        public bool MeasureIsVisible
        {
            get { return measureIsVisible; }
            set { measureIsVisible = value; OnPropertyChanged("MeasureIsVisible"); }
        }
        public MeasureCommand MeasureCommand { get; set; }
        public void ShowMeasure()
        {
            MeasureIsVisible = !MeasureIsVisible;
        }

        private bool searchIsVisible;
        public bool SearchIsVisible
        {
            get { return searchIsVisible; }
            set { searchIsVisible = value; OnPropertyChanged("SearchIsVisible"); }
        }
        public SearchCommand SearchCommand { get; set; }
        public void ShowSearch()
        {
            SearchIsVisible = !SearchIsVisible;
        }

        private bool tocIsVisible;
        public bool TOCIsVisible
        {
            get { return tocIsVisible; }
            set { tocIsVisible = value; OnPropertyChanged("TOCIsVisible"); }
        }
        public TOCCommand TOCCommand { get; set; }
        public void ShowTOC()
        {
            TOCIsVisible = !TOCIsVisible;
        }


        public SketchCommand SketchCommand { get; set; }
        public async void  OpenSketch(MapView mapView)
        {

            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string sketchFileName = "sketch_" + timeStamp + ".png";
            //todo : to app.config
            sketchFileName = Path.Combine(@"C:\TEMP", sketchFileName);

            Viewpoint viewpoint = mapView.GetCurrentViewpoint(ViewpointType.BoundingGeometry);
            RuntimeImage runtimeImage = await mapView.ExportImageAsync();
            ImageSource image = await runtimeImage.ToImageSourceAsync();

            using (var fileStream = new FileStream(sketchFileName, FileMode.Create))
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(fileStream);
            }
            //todo : to app.config
            var path = @"C:\Program Files (x86)\GeoWorxSketch\GeoWorxSketch.exe";

            Envelope extent = (viewpoint.TargetGeometry as Envelope).Extent;
            try
            {
                System.Diagnostics.Process.Start(path, $"{sketchFileName} {extent.XMin} {extent.YMin} {extent.XMax} {extent.YMax} true");

            }
            catch(Exception e)
            {
                MessageBox.Show($"Something is wrong!\n{e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }


        public ZoomToFullExtentCommand ZoomToFullExtentCommand { get; set; }
        public void DoZoomToFullExtent(MapView mapView)
        {
            Envelope initialLocation = new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985));
            mapView.SetViewpointGeometryAsync(initialLocation);
        }


        public SyncCommand SyncCommand { get; set; }
        public void MakeSync()
        {

        }

        private bool workOrdersIsVisible;

        public bool WorkOrdersIsVisible
        {
            get { return workOrdersIsVisible; }
            set { workOrdersIsVisible = value; OnPropertyChanged("WorkOrdersIsVisible"); }
        }

        public WorkOrdersCommand WorkOrdersCommand { get; set; }
        public void ShowWorkOrders()
        {
            WorkOrdersIsVisible = !WorkOrdersIsVisible;
        }


        public CreateWorkOrderCommand CreateWorkOrderCommand { get; set; }
        public void ShowCreateWorkOrder()
        {

        }

        public SettingsCommand SettingsCommand { get; set; }
        public void ShowSettings()
        {

        }

        public LogoutCommand LogoutCommand { get; set; }
        public void DoLogout(Map map)
        {
            new Login().Show();
            map.Close();
        }

        private bool hasGPSLocationInMap;

        public bool HasGPSLocationInMap
        {
            get { return hasGPSLocationInMap; }
            set { hasGPSLocationInMap = value; OnPropertyChanged("HasGPSLocationInMap"); }
        }


        public KeepGPSCommand KeepGPSCommand { get; set; }
        public void DoKeepGPS(MapView mapView)
        {
            mapView.LocationDisplay.IsEnabled = mapView.LocationDisplay.IsEnabled ? false : true;
            HasGPSLocationInMap = mapView.LocationDisplay.IsEnabled;
            if (!mapView.LocationDisplay.IsEnabled) {
                mapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Off;
                GPSLocationIsVisible = false;
                mapView.LocationDisplay.LocationChanged -= LocationChanged;
                GPSLocation = "";
            }
        }

        private string gpsLocation;

        public string GPSLocation
        {
            get { return gpsLocation; }
            set { gpsLocation = value; OnPropertyChanged("GPSLocation"); }
        }


        private bool gpsLocationIsVisible;

        public bool GPSLocationIsVisible
        {
            get { return gpsLocationIsVisible; }
            set { gpsLocationIsVisible = value; OnPropertyChanged("GPSLocationIsVisible"); }
        }

        public ShowGPSInfoCommand ShowGPSInfoCommand { get; set; }
        public void DoShowGPSInfo(MapView mapView)
        {
            GPSLocationIsVisible = !GPSLocationIsVisible;
            if (GPSLocationIsVisible)
            {
                mapView.LocationDisplay.LocationChanged += LocationChanged;
                LocationChanged(null, mapView.LocationDisplay.Location);
            }
            else
            {
                mapView.LocationDisplay.LocationChanged -= LocationChanged;
                GPSLocation = "";
            }

            
        }

        private void LocationChanged(object sender, Location e)
        {
            if(e != null && e.Position != null)
            {
                GPSLocation = $"GPS x: {e.Position.X} y: {e.Position.Y}";
            }
            else
            {
                GPSLocation = $"GPS Location Not Found";
            }
            
        }

        private bool autoPanModeIsOn;

        public bool AutoPanModeIsOn
        {
            get { return autoPanModeIsOn; }
            set { autoPanModeIsOn = value; OnPropertyChanged("AutoPanModeIsOn"); }
        }

        public PanToGPSCommand PanToGPSCommand { get; set; }
        public void DoPanToGPS(MapView mapView)
        {
            mapView.LocationDisplay.AutoPanMode = mapView.LocationDisplay.AutoPanMode == LocationDisplayAutoPanMode.Off ? LocationDisplayAutoPanMode.Recenter : LocationDisplayAutoPanMode.Off;
            AutoPanModeIsOn = mapView.LocationDisplay.AutoPanMode == LocationDisplayAutoPanMode.Recenter;
            mapView.LocationDisplay.AutoPanModeChanged += AutoPanModeChange;
        }

        public void AutoPanModeChange(object sender, LocationDisplayAutoPanMode locationDisplayAutoPanMode)
        {
            AutoPanModeIsOn = locationDisplayAutoPanMode == LocationDisplayAutoPanMode.Recenter;
        }


    }
}
