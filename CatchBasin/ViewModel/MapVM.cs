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
using Esri.ArcGISRuntime.Tasks.Offline;
using System.Net;

namespace CatchBasin.ViewModel
{

    class MapVM : BaseVM
    {

		private string syncStatus;

		public string SyncStatus
		{
			get { return syncStatus; }
			set { syncStatus = value;OnPropertyChanged("SyncStatus"); }
		}


		public void synchronizationStatus(string status, string substatus) {
			SyncStatus = $"{status} | {substatus}";
		}

		private bool isOffline;

		public bool IsOffline
		{
			get { return isOffline; }
			set { isOffline = value; ((App)Application.Current).MaximoServiceLibraryBeanConfiguration.synchronizationService.isOffline = isOffline; OnPropertyChanged("IsOffline"); }
		}


		public MapVM()
        {
            WorkOrderListVM = new WorkOrderListVM(this);
            WorkOrderDetailVM = new WorkOrderDetailVM(this);
            AssetDetailVM = new AssetDetailVM(workOrderDetailVM);
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

            AssetDetailIsVisible = false;
            WorkOrderDetailIsVisible = false;

			((App)Application.Current).MaximoServiceLibraryBeanConfiguration.synchronizationService.synchronizationDelegate += synchronizationStatus;
			InitializeMap();
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
            if (AssetDetailIsVisible)
            {
                AssetDetailVM.Cancel();
            }
            if (WorkOrderDetailIsVisible)
            {
                WorkOrderDetailVM.Cancel();
            }
            WorkOrderDetailVM.Update(wo);
            WorkOrderDetailIsVisible = true;
        }

        public void HideWorkOrderDetail()
        {
            WorkOrderDetailIsVisible = false;
            WorkOrderDetailVM.Clear();
			WorkOrderListVM.Update();
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

        public void ShowAssetDetail(MaximoAsset asset)
        {
            
            AssetDetailVM.Update(asset);
            AssetDetailIsVisible = true;
        }

        public void HideAssetDetail()
        {
            AssetDetailIsVisible = false;
            AssetDetailVM.Clear();
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
			if (WorkOrdersIsVisible) { WorkOrderListVM.Update(); }
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




		// Map
		private async void InitializeMap()
		{
			Envelope envelope = new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985));
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			

			try
			{
				
				Geodatabase localGdb = await Geodatabase.OpenAsync("C:\\TEMP\\CB.geodatabase");
				await SyncronizeEditsAsync("https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBSewer/FeatureServer", "C:\\TEMP\\CB.geodatabase", SyncDirection.Download);
			}
			catch(Exception e)
			{
				GISLayerToOffline("https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBSewer/FeatureServer", "", envelope, "C:\\TEMP\\DC.geodatabase");
			} 
			

	

			//
		}

		public async void GISLayerToOffline(string url, string expression, Envelope envelope, string path)
		{
			Uri featureServiceUri = new Uri(url);
			GeodatabaseSyncTask gdbSyncTask = await GeodatabaseSyncTask.CreateAsync(featureServiceUri);

			GenerateGeodatabaseParameters generateGdbParams = await gdbSyncTask.CreateDefaultGenerateGeodatabaseParametersAsync(envelope);

			GenerateGeodatabaseJob generateGdbJob = gdbSyncTask.GenerateGeodatabase(generateGdbParams, path);

			generateGdbJob.JobChanged += (sender, args) =>
			{
				
				if (generateGdbJob.Error != null)
				{
					Console.WriteLine("Error creating geodatabase: " + generateGdbJob.Error.Message);
					return;
				}

				
				if (generateGdbJob.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Succeeded)
				{
					
					AddLocalDataToMap(generateGdbJob);
				}
				else if (generateGdbJob.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Failed)
				{
					
					Console.WriteLine("Unable to create local geodatabase.");
				}
				else
				{
					
					//Console.WriteLine(generateGdbJob.Messages[generateGdbJob.Messages.Count - 1].Message);
				}
			};

			generateGdbJob.Start();
		}

		private async void AddLocalDataToMap(GenerateGeodatabaseJob geodatabaseJob)
		{
			Geodatabase localGdb = await geodatabaseJob.GetResultAsync();

		
			foreach (FeatureTable featureTable in localGdb.GeodatabaseFeatureTables)
			{
				FeatureLayer featureLayer = new FeatureLayer(featureTable);
				Map.OperationalLayers.Add(featureLayer);
			}
		}

		public async Task SyncronizeEditsAsync(string serviceUrl, string geodatabasePath , SyncDirection syncDirection)
		{
			// create sync parameters
			var taskParameters = new SyncGeodatabaseParameters()
			{
				RollbackOnFailure = true,
				GeodatabaseSyncDirection = syncDirection
			};

			// create a sync task with the URL of the feature service to sync
			var syncTask = await GeodatabaseSyncTask.CreateAsync(new Uri(serviceUrl));

			// open the local geodatabase
			var gdb = await Esri.ArcGISRuntime.Data.Geodatabase.OpenAsync(geodatabasePath);

			// create a synchronize geodatabase job, pass in the parameters and the geodatabase
			SyncGeodatabaseJob job = syncTask.SyncGeodatabase(taskParameters, gdb);

			// handle the JobChanged event for the job
			job.JobChanged += (s, e) =>
			{
				// report changes in the job status
				if (job.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Succeeded)
				{
					// report success ...
					Console.WriteLine(  "Synchronization is complete!");
				}
				else if (job.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Failed)
				{
					// report failure ...
					Console.WriteLine(  job.Error.Message);
				}
				else
				{
					Console.WriteLine( "Sync in progress ...");
				}
			};

			// await the completion of the job
			var result = await job.GetResultAsync();
		}
	}

	class LayerDescription
	{
		public LayerDescription(string _layername, string _url, string _geodatabaseFilePath, string[] _displayExpressions, string[] _sublayerNames)
		{
			url = _url;
			layername = _layername;
			geodatabaseFilePath = _geodatabaseFilePath;
			displayExpressions = _displayExpressions;
			sublayerNames = _sublayerNames;

		}

		public string url { get; set; }
		public string geodatabaseFilePath { get; set; }
		 public string[] displayExpressions { get; set; }
		public string[] sublayerNames { get; set; }
		public string layername { get; set; }
	}
}
