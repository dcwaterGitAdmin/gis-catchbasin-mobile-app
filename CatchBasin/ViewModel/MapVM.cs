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
using Esri.ArcGISRuntime.Portal;

namespace CatchBasin.ViewModel
{

	class MapVM : BaseVM
	{

		private string syncStatus;

		public string SyncStatus
		{
			get { return syncStatus; }
			set { syncStatus = value; OnPropertyChanged("SyncStatus"); }
		}

		private string gisSyncStatus;

		public string GISSyncStatus
		{
			get { return gisSyncStatus; }
			set { gisSyncStatus = value; OnPropertyChanged("GISSyncStatus"); }
		}


		public void synchronizationStatus(string status, string substatus)
		{
			if (status == "SYNC_FINISHED")
			{
				//try { 
				WorkOrderListVM.Update();
				//}catch(Exception e)
				//{

				//}
			}
			else if (status == "SYNC_CONFLICT")
			{
				MessageBox.Show(substatus, status, MessageBoxButton.OK, MessageBoxImage.Warning);
			}
			SyncStatus = $"{substatus}";
		}

		private bool isOffline;

		public bool IsOffline
		{
			get { return isOffline; }
			set { isOffline = value; MaximoServiceLibrary.AppContext.synchronizationService.isOffline = isOffline; OnPropertyChanged("IsOffline"); }
		}


		private string userInfo;

		public string UserInfo
		{
			get { return userInfo; }
			set { userInfo = value; OnPropertyChanged("UserInfo"); }
		}

		private bool pmItemIsVisible;

		public bool PMItemIsVisible
		{
			get { return pmItemIsVisible; }
			set { pmItemIsVisible = value; OnPropertyChanged("PMItemIsVisible"); }
		}

		private bool inspItemIsVisible;

		public bool INSPItemIsVisible
		{
			get { return inspItemIsVisible; }
			set { inspItemIsVisible = value; OnPropertyChanged("INSPItemIsVisible"); }
		}

		private string title;

		public string Title
		{
			get { return title; }
			set { title = value; }
		}


		public void UpdateUserInfo()
		{
			if (((App)Application.Current).AppType == "PM")
			{
				UserInfo = $"CREW :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.selectedPersonGroup} \n" +
					$"LEADMAN :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting?.leadMan} \n" +
				$"SECOND :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting?.secondMan} \n" +
				$"DRIVER :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting?.driverMan} \n" +
				$"VEHICLE :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting?.vehiclenum} \n";

			}
			else
			{
				UserInfo = $"CREW :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.selectedPersonGroup} \n" +
					$"LEADMAN :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting?.leadMan} \n" +
				$"DRIVER :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting?.driverMan} \n" +
				$"VEHICLE :{MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting?.vehiclenum} \n";

			}
		}
		private MapView _mapView;
		public MapView MapView
		{
			get { return _mapView; }
			set
			{
				_mapView = value;
				_mapView.GeoViewTapped += WorkorderClicked;
			}
		}

		private async void WorkorderClicked(object sender, GeoViewInputEventArgs e)
		{
			var featureLayer = GetWorkorderLayer();
			if (featureLayer != null)
			{
				IdentifyLayerResult identify = await MapView.IdentifyLayerAsync(featureLayer, e.Position, 15, false);
				if (identify.GeoElements.Count > 0)
				{
					try
					{
						var wonum = identify.GeoElements.First().Attributes["WONUM"].ToString();
						if (!string.IsNullOrEmpty(wonum))
						{
							var wo = WorkOrderListVM.WorkOrders.FirstOrDefault(w => w.wonum == wonum);
							if (wo != null)
							{
								var index = WorkOrderListVM.WorkOrders.IndexOf(wo);
								if (index > -1)
								{
									WorkOrderListVM.SelectedIndex = index;
								}
							}
						}
					}
					catch (Exception ex)
					{
						MaximoServiceLibrary.AppContext.Log.Warn(e.ToString());
					}
				}
			}

		}

		public async void MapTappedForSelectAsset(object sender, GeoViewInputEventArgs e)
		{
			GroupLayer layer = (GroupLayer)GetAssetGroupLayer();


			IdentifyLayerResult identifyResults = await MapView.IdentifyLayerAsync(layer, e.Position, 30, false);

			var filteredresults = identifyResults.SublayerResults.Where(result => result.LayerContent.Name == "Catch Basin - Cleaned by DC Water" || result.LayerContent.Name == "Catch Basin - Cleaned by Others" || result.LayerContent.Name == "Catch Basin - Proposed");

			foreach (var result in filteredresults)
			{
				if (result.GeoElements.Count > 0)
				{
					WorkOrderDetailVM.SelectAssetOnMapIsActive = false;
					MapView.GeoViewTapped -= MapTappedForSelectAsset;
					var element = result.GeoElements.First();
					QueryParameters queryParameters = new QueryParameters();
					queryParameters.WhereClause = $"ASSETTAG='{element.Attributes["ASSETTAG"]}'";

					var queryLayer = ((FeatureLayer)layer.Layers.FirstOrDefault(sublayer => sublayer.Name == result.LayerContent.Name));
					if (queryLayer != null)
					{

						queryLayer.SelectFeaturesAsync(queryParameters, SelectionMode.New);

					}
					WorkOrderDetailVM.SetAsset(element);
					break;
				}
			}


		}

		public async void deleteAssetFromMap(string assettag)
		{

			FeatureLayer featurelayer = this.assetLayer;
			if (featurelayer != null)
			{
				QueryParameters queryParameters = new QueryParameters();
				queryParameters.WhereClause = $"ASSETTAG='{assettag}'";
				FeatureQueryResult features = await featurelayer.FeatureTable.QueryFeaturesAsync(queryParameters);
				if (features.Count() > 0)
				{
					featurelayer.FeatureTable.DeleteFeatureAsync(features.First());
				}

			}
			else
			{

				deleteAssetFromMap(assettag);
			}
		}
		public async void MapTappedForCreateAsset(MapPoint clickPoint = null)
		{

			WorkOrderDetailVM.CreateAssetOnMapIsActive = true;
			if (clickPoint == null)
			{
				if (MapView.SketchEditor.IsEnabled)
				{
					MapView.SketchEditor.Stop();
				}


				clickPoint = await MapView.SketchEditor.StartAsync(Esri.ArcGISRuntime.UI.SketchCreationMode.Point, false) as MapPoint;




			}
			if (clickPoint == null)
			{
				WorkOrderDetailVM.CreateAssetOnMapIsActive = false;
				return;
			}
			var user = MaximoServiceLibrary.AppContext.synchronizationService.mxuser;
			// 

			var tag = $"N{user.userPreferences.selectedPersonGroup}{DateTime.Now.ToString("MMddyyhhmmss")}";

			FeatureLayer featurelayer = this.assetLayer;
			if (featurelayer != null)
			{
				var feature = featurelayer.FeatureTable.CreateFeature();
				feature.SetAttributeValue("ASSETTAG", tag);
				feature.SetAttributeValue("SUBTYPE", 0);
				feature.SetAttributeValue("TOPMATRL", "C");
				feature.SetAttributeValue("TOPTHICK", 4);
				feature.SetAttributeValue("LOCATIONDETAIL", "");
				feature.SetAttributeValue("OWNER", "WASA");
				feature.SetAttributeValue("CLNRESP", "DC WASA");
				feature.SetAttributeValue("ISWQI", "N");
				feature.SetAttributeValue("INMS4", "N");
				feature.SetAttributeValue("ISCORNRCB", "N");
				feature.SetAttributeValue("BIOFLTR", "N");
				feature.SetAttributeValue("HASSUMP", "Y");
				feature.SetAttributeValue("HASWATERSEAL", "N");
				feature.SetAttributeValue("CHANGEBY", user.userName);
				// feature.SetAttributeValue("LIFECYCLESTATS", "Active");
				//feature.SetAttributeValue("CLNRESP","DC WASA");




				feature.Geometry = clickPoint;
				await featurelayer.FeatureTable.AddFeatureAsync(feature);

				feature.Refresh();
				featurelayer.SelectFeature(feature);
				WorkOrderDetailVM.SetAsset(feature);
				WorkOrderDetailVM.CreateAssetOnMapIsActive = false;
			}
			else
			{
				MapTappedForCreateAsset(clickPoint);
			}
		}

		public MapVM()
		{
			if (((App)Application.Current).AppType == null)
			{
				new Exception("Application Type Is Not Valid!");
			}
			else if (((App)Application.Current).AppType == "PM")
			{
				PMItemIsVisible = true;
				INSPItemIsVisible = false;
				Title = "Catch Basin Cleaning";
			}
			else
			{
				PMItemIsVisible = false;
				INSPItemIsVisible = true;
				Title = "Catch Basin Inspection";
			}
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
			ZoomInCommand = new ZoomInCommand(this);
			ZoomOutCommand = new ZoomOutCommand(this);
			ZoomWithDrawCommand = new ZoomWithDrawCommand(this);

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

			MaximoServiceLibrary.AppContext.synchronizationService.synchronizationDelegate += synchronizationStatus;
			MaximoServiceLibrary.AppContext.synchronizationService.assetGisSynchronizationDelegateHandler += syncAsset;

			setBaseMap();
			UpdateUserInfo();




		}



		private Esri.ArcGISRuntime.Mapping.Map _map;

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

			ZoomToWoAsync(wo);
			FlashAsync(wo);
			WorkOrderDetailVM.Update(wo);
			WorkOrderDetailIsVisible = true;
		}

		public async void ZoomToWoAsync(MaximoWorkOrder wo)
		{
			try
			{
				var layer = GetWorkorderLayer();
				if (layer != null)
				{
					QueryParameters queryParameters = new QueryParameters();
					if (wo.syncronizationStatus == LocalDBLibrary.model.SyncronizationStatus.CREATED)
					{
						queryParameters.WhereClause = $"WORKORDERID='{wo.Id}'";
					}
					else
					{
						queryParameters.WhereClause = $"wonum='{wo.wonum}'";

					}

					FeatureQueryResult features = await this.woFeatureTable.QueryFeaturesAsync(queryParameters);
					MapPoint f = (MapPoint)features.First()?.Geometry;
					MapView?.SetViewpointCenterAsync(f, 500);
				}





			}
			catch (Exception e)
			{
				try
				{
					if (wo.asset != null && !String.IsNullOrEmpty(wo.asset.assettag))
					{
						var layer = GetAssetGroupLayer();
						if (layer != null)
						{
							QueryParameters queryParameters = new QueryParameters();
							queryParameters.WhereClause = $"ASSETTAG='{wo.asset.assettag}'";
							FeatureQueryResult features = await ((FeatureLayer)layer.Layers.FirstOrDefault())?.FeatureTable.QueryFeaturesAsync(queryParameters);
							MapPoint f = (MapPoint)features.First()?.Geometry;
							MapView?.SetViewpointCenterAsync(f, 500);


							features = await this.assetLayer.FeatureTable.QueryFeaturesAsync(queryParameters);
							f = (MapPoint)features.First()?.Geometry;
							MapView?.SetViewpointCenterAsync(f, 500);
						}
					}
				}
				catch (Exception e2)
				{

				}


			}
		}

		public async void PanToWoAsync(MaximoWorkOrder wo)
		{
			try
			{
				var layer = GetWorkorderLayer();
				if (layer != null)
				{
					QueryParameters queryParameters = new QueryParameters();
					if (wo.syncronizationStatus == LocalDBLibrary.model.SyncronizationStatus.CREATED)
					{
						queryParameters.WhereClause = $"WORKORDERID='{wo.Id}'";
					}
					else
					{
						queryParameters.WhereClause = $"wonum='{wo.wonum}'";

					}
					FeatureQueryResult features = await this.woFeatureTable.QueryFeaturesAsync(queryParameters);
					MapPoint f = (MapPoint)features.First()?.Geometry;
					MapView?.SetViewpointCenterAsync(f);

				}





			}
			catch (Exception e)
			{

			}
		}


		public async void FlashAsync(MaximoWorkOrder wo)
		{
			try
			{
				var layer = GetWorkorderLayer();
				if (layer != null)
				{
					QueryParameters queryParameters = new QueryParameters();
					if (wo.syncronizationStatus == LocalDBLibrary.model.SyncronizationStatus.CREATED)
					{
						queryParameters.WhereClause = $"WORKORDERID='{wo.Id}'";
					}
					else
					{
						queryParameters.WhereClause = $"wonum='{wo.wonum}'";

					}
					await layer.SelectFeaturesAsync(queryParameters, SelectionMode.New);

				}
				if (wo.asset != null && !String.IsNullOrEmpty(wo.asset.assettag))
				{
					var assetLayer = GetAssetGroupLayer();
					if (assetLayer != null)
					{
						QueryParameters queryParameters = new QueryParameters();
						queryParameters.WhereClause = $"ASSETTAG='{wo.asset.assettag}'";
						((FeatureLayer)assetLayer.Layers.FirstOrDefault())?.SelectFeaturesAsync(queryParameters, SelectionMode.New);

						this.assetLayer.SelectFeaturesAsync(queryParameters, SelectionMode.New);

					}
				}
			}
			catch (Exception e)
			{

			}
		}


		public void HideWorkOrderDetail()
		{
			var layer = GetWorkorderLayer();

			//layer.


			var assetLayer = GetAssetGroupLayer();
			((FeatureLayer)assetLayer?.Layers?.FirstOrDefault())?.ClearSelection();
			WorkOrderDetailIsVisible = false;
			this.assetLayer.ClearSelection();
			this.woLayer.ClearSelection();

			//WorkOrderListVM.SelectedIndex = -1;
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

		public void ShowAssetDetail(MaximoWorkOrder wo)
		{

			AssetDetailVM.Update(wo);
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
			set { identifyIsVisible = value; OnPropertyChanged("IdentifyIsVisible"); }
		}
		public IdentifyCommand IdentifyCommand { get; set; }
		public void ShowIdentify()
		{
			if (!IdentifyIsVisible)
			{
				IdentifyIsVisible = true;
				Identify identify = new Identify();
				identify.DataContext = new IdentifyVM(this);
				identify.Topmost = true;

				identify.Show();
			}

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
			if (!SearchIsVisible)
			{
				SearchIsVisible = true;
				Search Search = new Search();
				Search.DataContext = new SearchVM(this);
				Search.Topmost = true;


				Search.Show();
			}
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
		public async void OpenSketch(MapView mapView)
		{

			string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
			string sketchFileName = "sketch_" + timeStamp + ".png";
			//todo : to app.config
			sketchFileName = Path.Combine(@"C:\CatchBasin", sketchFileName);

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
			catch (Exception e)
			{
				MessageBox.Show($"Something is wrong!\n{e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}

		}


		public ZoomInCommand ZoomInCommand { get; set; }
		public ZoomOutCommand ZoomOutCommand { get; set; }
		public ZoomWithDrawCommand ZoomWithDrawCommand { get; set; }

		private bool zoomWithDrawIsActive;

		public bool ZoomWithDrawIsActive
		{
			get { return zoomWithDrawIsActive; }
			set { zoomWithDrawIsActive = value; OnPropertyChanged("ZoomWithDrawIsActive"); }
		}


		public ZoomToFullExtentCommand ZoomToFullExtentCommand { get; set; }
		public void DoZoomToFullExtent(MapView mapView)
		{
			Envelope initialLocation = new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985));
			mapView.SetViewpointGeometryAsync(initialLocation);
		}


		public SyncCommand SyncCommand { get; set; }
		public async void MakeSync()
		{
			MaximoServiceLibrary.AppContext.synchronizationService.triggerSynchronization();
			if (((App)Application.Current).AppType == "PM")
			{

				await syncWorkorders();
			}
			else
			{

				await syncINSP();
			}
			await postAssets();
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
			try
			{
				Settings Settings = new Settings();
				Settings.DataContext = new SettingsVM(this);
				Settings.ShowInTaskbar = false;
				//Settings.Owner = ((App)Application.Current).MainWindow;
				Settings.ShowDialog();
			}
			catch (Exception e)
			{
				MaximoServiceLibrary.AppContext.Log.Warn(e.ToString());
			}

		}

		public LogoutCommand LogoutCommand { get; set; }
		public void DoLogout(Map map)
		{
			MaximoServiceLibrary.AppContext.synchronizationService.stopSyncronizationTimer();

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
			if (!mapView.LocationDisplay.IsEnabled)
			{
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
			if (e != null && e.Position != null)
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

		public async void setBaseMap()
		{
			MobileMapPackage mobileMapPackage;

			// Check whether the mobile map package supports direct read.
			bool isDirectReadSupported = await MobileMapPackage.IsDirectReadSupportedAsync("C:\\CatchBasin\\Layers.mmpk");
			if (isDirectReadSupported)
			{
				// If it does, create the mobile map package directly from the .mmpk file.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\Layers.mmpk");
				var map = mobileMapPackage.Maps.First();
				Map = map;
				InitializeMap();
			}
			else
			{
				// Otherwise, unpack the mobile map package file into a directory.
				await MobileMapPackage.UnpackAsync("C:\\CatchBasin\\Layers.mmpk", "C:\\CatchBasin\\Layers");

				// Create the mobile map package from the unpack directory.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\Layers");
				var map = mobileMapPackage.Maps.First();
				Map = map;
				InitializeMap();
			}


		}


		public async Task AddSewerPackage()
		{
			MobileMapPackage mobileMapPackage;

			// Check whether the mobile map package supports direct read.
			bool isDirectReadSupported = await MobileMapPackage.IsDirectReadSupportedAsync("C:\\CatchBasin\\SEWER.mmpk");
			if (isDirectReadSupported)
			{
				// If it does, create the mobile map package directly from the .mmpk file.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\SEWER.mmpk");
				var _map = mobileMapPackage.Maps.First();
				var layers = _map.OperationalLayers.ToList();
				_map.OperationalLayers.Clear();
				foreach (var item in layers)
				{
					if (item is GroupLayer)
					{
						var grouplayer = ((GroupLayer)item);
						var _layers = grouplayer.Layers.Reverse().ToList();
						grouplayer.Layers.Clear();
						foreach (var _item in _layers)
						{
							grouplayer.Layers.Add(_item);

						}
						//grouplayer.Layers = (LayerCollection)
						Map.OperationalLayers.Add(grouplayer);
					}

				}


			}
			else
			{
				// Otherwise, unpack the mobile map package file into a directory.
				await MobileMapPackage.UnpackAsync("C:\\CatchBasin\\SEWER.mmpk", "C:\\CatchBasin\\SEWER");

				// Create the mobile map package from the unpack directory.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\SEWER");
				var _map = mobileMapPackage.Maps.First();
				var layers = _map.OperationalLayers.ToList();
				_map.OperationalLayers.Clear();
				foreach (var item in layers)
				{
					Map.OperationalLayers.Add(item);
				}

			}
		}

		public async Task AddCNLPackage()
		{
			MobileMapPackage mobileMapPackage;

			// Check whether the mobile map package supports direct read.
			bool isDirectReadSupported = await MobileMapPackage.IsDirectReadSupportedAsync("C:\\CatchBasin\\CNL.mmpk");
			if (isDirectReadSupported)
			{
				// If it does, create the mobile map package directly from the .mmpk file.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\CNL.mmpk");
				var _map = mobileMapPackage.Maps.First();
				var layers = _map.OperationalLayers.ToList();
				_map.OperationalLayers.Clear();
				foreach (var item in layers)
				{
					Map.OperationalLayers.Add(item);
				}

			}
			else
			{
				// Otherwise, unpack the mobile map package file into a directory.
				await MobileMapPackage.UnpackAsync("C:\\CatchBasin\\CNL.mmpk", "C:\\CatchBasin\\CNL");

				// Create the mobile map package from the unpack directory.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\CNL");
				var _map = mobileMapPackage.Maps.First();
				var layers = _map.OperationalLayers.ToList();
				_map.OperationalLayers.Clear();
				foreach (var item in layers)
				{
					Map.OperationalLayers.Add(item);
				}

			}
		}

		public GroupLayer AssetsLayer { get; set; }

		public async Task AddAsssetsPackage()
		{
			MobileMapPackage mobileMapPackage;

			// Check whether the mobile map package supports direct read.
			bool isDirectReadSupported = await MobileMapPackage.IsDirectReadSupportedAsync("C:\\CatchBasin\\Assets.mmpk");
			if (isDirectReadSupported)
			{
				// If it does, create the mobile map package directly from the .mmpk file.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\Assets.mmpk");
				var _map = mobileMapPackage.Maps.First();
				var layers = _map.OperationalLayers.ToList();
				_map.OperationalLayers.Clear();
				foreach (var item in layers)
				{
					if (item is GroupLayer)
					{
						var grouplayer = ((GroupLayer)item);
						this.AssetsLayer = grouplayer;
						var _layers = grouplayer.Layers.Reverse().ToList();
						grouplayer.Layers.Clear();
						foreach (var _item in _layers)
						{
							grouplayer.Layers.Add(_item);

						}
						//grouplayer.Layers = (LayerCollection)
						Map.OperationalLayers.Add(grouplayer);
					}
				}

			}
			else
			{
				// Otherwise, unpack the mobile map package file into a directory.
				await MobileMapPackage.UnpackAsync("C:\\CatchBasin\\Assets.mmpk", "C:\\CatchBasin\\Assets");

				// Create the mobile map package from the unpack directory.
				mobileMapPackage = await MobileMapPackage.OpenAsync("C:\\CatchBasin\\Assets");
				var _map = mobileMapPackage.Maps.First();
				var layers = _map.OperationalLayers.ToList();
				_map.OperationalLayers.Clear();
				foreach (var item in layers)
				{
					Map.OperationalLayers.Add(item);
				}

			}
		}


		public async Task AddWorkorderPackage()
		{

			Geodatabase mobileGeodatabase = await Geodatabase.OpenAsync("C:\\CatchBasin\\Workorder.geodatabase");

			this.woFeatureTable = mobileGeodatabase.GeodatabaseFeatureTable("WORKORDERPT");

			await this.woFeatureTable.LoadAsync();
			this.woLayer = new FeatureLayer(this.woFeatureTable);
			this.woLayer.Name = "Open Workorders";

			Map.OperationalLayers.Add(this.woLayer);


		}

		public async Task AddINSPPackage()
		{

			Geodatabase mobileGeodatabase = await Geodatabase.OpenAsync("C:\\CatchBasin\\CBInsp.geodatabase");

			this.woFeatureTable = mobileGeodatabase.GeodatabaseFeatureTable("WORKORDERPT");

			await this.woFeatureTable.LoadAsync();
			this.woLayer = new FeatureLayer(this.woFeatureTable);
			this.woLayer.Name = "Open Workorders";

			Map.OperationalLayers.Add(this.woLayer);


		}


		public async Task AddEditAssetPackage()
		{

			Geodatabase mobileGeodatabase = await Geodatabase.OpenAsync("C:\\CatchBasin\\Asset.geodatabase");



			this.assetFeatureTable = mobileGeodatabase.GeodatabaseFeatureTable("sCatchBasinPt");

			await this.assetFeatureTable.LoadAsync();
			this.assetLayer = new FeatureLayer(this.assetFeatureTable);
			this.assetLayer.Name = "Created Asset";

			Map.OperationalLayers.Add(this.assetLayer);


		}

		public FeatureTable woFeatureTable { get; set; }

		public FeatureLayer woLayer { get; set; }

		public FeatureTable assetFeatureTable { get; set; }

		public FeatureLayer assetLayer { get; set; }

		private async void InitializeMap(bool sync = false)
		{
			await AddSewerPackage();
			await AddAsssetsPackage();
			await AddEditAssetPackage();
			if (((App)Application.Current).AppType == "PM")
			{
				await AddWorkorderPackage();
				await CheckTime();
				await syncWorkorders();
			}
			else
			{
				await AddINSPPackage();
				await CheckTime();
				await syncINSP();
			}

			await AddCNLPackage();

		}


		public async Task syncWorkorders()
		{



			try
			{
				GISSyncStatus = $"Started Work Order Layer Sync! ";

				var arcgisBaseUrl = System.Configuration.ConfigurationManager.AppSettings["ArcGISServerUrl"];


				var _featureTable = new ServiceFeatureTable(new Uri($"{arcgisBaseUrl}/CBWorkorders/FeatureServer/0"));

				var _featureLayer = new FeatureLayer(_featureTable);
				var dquery = $"SCHEDSTART < CURRENT_TIMESTAMP  AND (PERSONGROUP = '{MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences.selectedPersonGroup}' OR PERSONGROUP = 'CB00')";
				//dquery = $"(PERSONGROUP = '{MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences.selectedPersonGroup}' OR PERSONGROUP = 'CB00')";

				QueryParameters queryParams = new QueryParameters();


				queryParams.WhereClause = dquery;
				GISSyncStatus = $"Create Parameters! ";


				FeatureQueryResult queryResult = await _featureTable.QueryFeaturesAsync(queryParams);
				List<Feature> features = queryResult.ToList();


				GISSyncStatus = $"Downloaded Data! ";
				var featureTable = this.woFeatureTable;

				queryParams.WhereClause = "WONUM <> '-' and STATUS = 'DISPTCHD'";
				FeatureQueryResult _queryResult = await featureTable.QueryFeaturesAsync(queryParams);
				List<Feature> _features = _queryResult.ToList();
				featureTable.DeleteFeaturesAsync(_features);
				GISSyncStatus = $"Deleted Old Data! ";

				queryParams.WhereClause = "STATUS <> 'DISPTCHD'";
				FeatureQueryResult _queryResult_d = await featureTable.QueryFeaturesAsync(queryParams);
				List<Feature> _features__d = _queryResult_d.ToList();

				GISSyncStatus = $"Start Add Data! ";
				foreach (var item in features)
				{
					var feature = featureTable.CreateFeature();
					foreach (var att in item.Attributes)
					{
						if (att.Key != "OBJECTID" && att.Key != "GLOBALID")
						{
							feature.Attributes[att.Key] = att.Value;
						}
					}
					feature.Geometry = item.Geometry;
					if (_features__d.FindIndex(f => f.Attributes["WONUM"].ToString() == item.Attributes["WONUM"].ToString()) < 0)
					{
						await featureTable.AddFeatureAsync(feature);
						feature.Refresh();
					}
					else
					{

					}


				}

				GISSyncStatus = $"Finished Work Order Sync! ";
			}
			catch (Exception e)
			{
				GISSyncStatus = $"No Internet Connection! ";

			}



		}

		public async Task syncINSP()
		{

			try
			{
				GISSyncStatus = $"Started Work Order Layer Sync! ";

				var arcgisBaseUrl = System.Configuration.ConfigurationManager.AppSettings["ArcGISServerUrl"];


				var _featureTable = new ServiceFeatureTable(new Uri($"{arcgisBaseUrl}/CBInsp/FeatureServer/0"));

				var _featureLayer = new FeatureLayer(_featureTable);
				var dquery = $"SCHEDSTART < CURRENT_TIMESTAMP   AND  STATUS = 'DISPTCHD'  and (PERSONGROUP = '{MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences.selectedPersonGroup}' OR PERSONGROUP = 'CB00')";

				QueryParameters queryParams = new QueryParameters();


				queryParams.WhereClause = dquery;
				GISSyncStatus = $"Create Parameters! ";


				FeatureQueryResult queryResult = await _featureTable.QueryFeaturesAsync(queryParams);
				List<Feature> features = queryResult.ToList();


				GISSyncStatus = $"Downloaded Data! ";
				var featureTable = this.woFeatureTable;

				queryParams.WhereClause = "WONUM <> '-' and STATUS = 'DISPTCHD'";
				FeatureQueryResult _queryResult = await featureTable.QueryFeaturesAsync(queryParams);
				List<Feature> _features = _queryResult.ToList();
				featureTable.DeleteFeaturesAsync(_features);
				GISSyncStatus = $"Deleted Old Data! ";

				queryParams.WhereClause = "STATUS <> 'DISPTCHD'";
				FeatureQueryResult _queryResult_d = await featureTable.QueryFeaturesAsync(queryParams);
				List<Feature> _features__d = _queryResult_d.ToList();

				GISSyncStatus = $"Start Add Data! ";
				foreach (var item in features)
				{
					var feature = featureTable.CreateFeature();
					foreach (var att in item.Attributes)
					{
						if (att.Key != "OBJECTID" && att.Key != "GLOBALID")
						{
							feature.Attributes[att.Key] = att.Value;
						}
					}
					feature.Geometry = item.Geometry;
					if (_features__d.FindIndex(f => f.Attributes["WONUM"].ToString() == item.Attributes["WONUM"].ToString()) < 0)
					{
						await featureTable.AddFeatureAsync(feature);
						feature.Refresh();
					}
					else
					{

					}


				}

				GISSyncStatus = $"Finished Work Order Sync! ";
			}
			catch (Exception e)
			{
				GISSyncStatus = $"No Internet Connection! ";

			}


		}

		private async void syncAsset(string assettag, string assetnum)
		{
			if (String.IsNullOrEmpty(assetnum))
			{
				return;
			}
			if (assettag.First() != 'N')
			{
				return;
			}
			GISSyncStatus = "CatchBasin (GIS) with tag (" + assettag + ")  is syncing";
			try
			{
				var arcgisBaseUrl = System.Configuration.ConfigurationManager.AppSettings["ArcGISServerUrl"];


				var _featureTable = new ServiceFeatureTable(new Uri($"{arcgisBaseUrl}/CBAssetCleanedByDCW/FeatureServer/0"));
				await _featureTable.LoadAsync();
				var _featureLayer = new FeatureLayer(_featureTable);

				QueryParameters queryParams = new QueryParameters();


				queryParams.WhereClause = $"ASSETTAG = '{assettag}'";
				var result = await this.assetLayer.FeatureTable.QueryFeaturesAsync(queryParams);
				var features = result.ToList();
				var feature = features.FirstOrDefault();
				if (feature != null)
				{
					feature.SetAttributeValue("MXASSETNUM", assetnum);
					await this.assetLayer.FeatureTable.UpdateFeatureAsync(feature);


					var newFeature = _featureTable.CreateFeature();
					newFeature.Geometry = feature.Geometry;

					newFeature.SetAttributeValue("ASSETTAG", feature.Attributes["ASSETTAG"]);
					newFeature.SetAttributeValue("SUBTYPE", feature.Attributes["SUBTYPE"]);
					newFeature.SetAttributeValue("TOPMATRL", feature.Attributes["TOPMATRL"]);
					newFeature.SetAttributeValue("TOPTHICK", feature.Attributes["TOPTHICK"]);
					newFeature.SetAttributeValue("GRATETY", feature.Attributes["GRATETY"]);
					newFeature.SetAttributeValue("NUMCHAMB", feature.Attributes["NUMCHAMB"]);
					newFeature.SetAttributeValue("NUMTHROAT", feature.Attributes["NUMTHROAT"]);
					newFeature.SetAttributeValue("LOCATIONDETAIL", feature.Attributes["LOCATIONDETAIL"]);
					newFeature.SetAttributeValue("OWNER", feature.Attributes["OWNER"]);
					newFeature.SetAttributeValue("CLNRESP", feature.Attributes["CLNRESP"]);
					newFeature.SetAttributeValue("ISWQI", feature.Attributes["ISWQI"]);
					newFeature.SetAttributeValue("INMS4", feature.Attributes["INMS4"]);
					newFeature.SetAttributeValue("ISCORNRCB", feature.Attributes["ISCORNRCB"]);
					newFeature.SetAttributeValue("BIOFLTR", feature.Attributes["BIOFLTR"]);
					newFeature.SetAttributeValue("FLORESTY", feature.Attributes["FLORESTY"]);
					newFeature.SetAttributeValue("HASSUMP", feature.Attributes["HASSUMP"]);
					newFeature.SetAttributeValue("HASWATERSEAL", feature.Attributes["HASWATERSEAL"]);
					newFeature.SetAttributeValue("CHANGEBY", feature.Attributes["CHANGEBY"]);
					newFeature.SetAttributeValue("MXASSETNUM", feature.Attributes["MXASSETNUM"]);

					await _featureTable.AddFeatureAsync(newFeature);

					var editResults = await _featureTable.ApplyEditsAsync();
					var editResult = editResults.FirstOrDefault();
					if (editResult != null)
					{
						if (editResult.ObjectId > 0)
						{
							feature.Attributes["DISPLAYID"] = "SYNCED";
							await this.assetLayer.FeatureTable.UpdateFeatureAsync(feature);
                            GISSyncStatus = "CatchBasin (GIS) with tag (" + assettag + ")  is synced";
                        }
						else
						{
							GISSyncStatus = "CatchBasin (GIS) with tag (" + assettag + ")  is failed";
						}
					}
					else
					{
						GISSyncStatus = "CatchBasin (GIS) with tag (" + assettag + ")  is failed";
					}

				}
				else
				{
					GISSyncStatus = "CatchBasin (GIS) with tag (" + assettag + ")  is failed";
				}

			}
			catch (Exception e)
			{
				GISSyncStatus = "CatchBasin (GIS) with tag (" + assettag + ")  is failed";

			}
		}

		public async Task postAssets()
		{
			try
			{
				QueryParameters queryParams = new QueryParameters();


				queryParams.WhereClause = "DISPLAYID is null";
				var result = await this.assetLayer.FeatureTable.QueryFeaturesAsync(queryParams);
				var features = result.ToList();

				foreach (var item in features)
				{
					syncAsset(item.GetAttributeValue("ASSETTAG").ToString(), item.GetAttributeValue("MXASSETNUM").ToString());
				}
			}
			catch (Exception e)
			{
				//GISSyncStatus = $"No Internet Connection! ";
			}

		}

		public async Task GISLayerToOffline(string url, string layername, string[] expression, string[] sublayers, Envelope envelope, string path)
		{

			GISSyncStatus = $"Download First GIS Data Started : {layername}";
			Uri featureServiceUri = new Uri(url);

			var cred = await Esri.ArcGISRuntime.Security.AuthenticationManager.Current.GenerateCredentialAsync(featureServiceUri, "catchbasin", "DcnJLkq5xb5aCsd");

			GeodatabaseSyncTask gdbSyncTask = await GeodatabaseSyncTask.CreateAsync(featureServiceUri, cred);

			GenerateGeodatabaseParameters generateGdbParams = await gdbSyncTask.CreateDefaultGenerateGeodatabaseParametersAsync(envelope);
			generateGdbParams.OutSpatialReference = new SpatialReference(26985);
			//generateGdbParams.SyncModel = SyncModel.None;



			generateGdbParams.LayerOptions.Clear();
			for (int i = 0; i < expression.Count(); i++)
			{
				generateGdbParams.LayerOptions.Add(new GenerateLayerOption(i, expression[i]));
			}


			GenerateGeodatabaseJob generateGdbJob = gdbSyncTask.GenerateGeodatabase(generateGdbParams, path);




			generateGdbJob.JobChanged += async (sender, args) =>
			{

				if (generateGdbJob.Error != null)
				{
					GISSyncStatus = $"Error creating geodatabase:  : {generateGdbJob.Error.Message}";
					MaximoServiceLibrary.AppContext.Log.Warn(GISSyncStatus);
					return;
				}


				if (generateGdbJob.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Succeeded)
				{
					GISSyncStatus = $"Download Complete : {layername}";
					MaximoServiceLibrary.AppContext.Log.Warn(GISSyncStatus + $" {layername}");
					Geodatabase localGdb = await generateGdbJob.GetResultAsync();
					try
					{
						AddLocalDataToMap(localGdb, layername, sublayers);
					}
					catch (Exception ee)
					{
						MaximoServiceLibrary.AppContext.Log.Error(ee.ToString());
					}

				}
				else if (generateGdbJob.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Failed)
				{
					GISSyncStatus = $"Unable to create local geodatabase. {layername}";
					MaximoServiceLibrary.AppContext.Log.Warn(generateGdbJob.Messages.LastOrDefault()?.ToString());
					try
					{
						await GISLayerToOffline(url, layername, expression, sublayers, envelope, path);
					}
					catch (Exception e)
					{

					}

				}
				else
				{
					GISSyncStatus = $"Download continue : {layername} {generateGdbJob.Messages.Count}";
					MaximoServiceLibrary.AppContext.Log.Warn(GISSyncStatus);

				}
			};

			generateGdbJob.Start();
		}

		private GroupLayer AddLocalDataToMap(Geodatabase localGdb, string layername, string[] sublayers, GroupLayer layer = null)
		{
			GroupLayer groupLayer;
			GroupLayer findedLayer = (GroupLayer)Map.OperationalLayers.FirstOrDefault(_layer => _layer.Name == layername);
			if (layer != null)
			{
				groupLayer = layer;

			}
			else if (findedLayer != null)
			{
				groupLayer = findedLayer;
			}
			else
			{
				groupLayer = new GroupLayer();
				groupLayer.Name = layername;
			}


			for (int i = 0; i < localGdb.GeodatabaseFeatureTables.Count; i++)
			{
				FeatureTable ft = localGdb.GeodatabaseFeatureTables[i];


				FeatureLayer featureLayer = new FeatureLayer(ft);
				featureLayer.Name = sublayers[i];

				var _layer = groupLayer.Layers.FirstOrDefault(__layer => __layer.Name == sublayers[i]);
				if (_layer != null)
				{
					var ind = groupLayer.Layers.IndexOf(_layer);
					groupLayer.Layers[ind] = featureLayer;
				}
				else
				{
					groupLayer.Layers.Add(featureLayer);
				}


			}


			if (Map.OperationalLayers.IndexOf(groupLayer) < 0)
			{
				Map.OperationalLayers.Add(groupLayer);
			}
			else
			{

			}


			return groupLayer;
		}

		public async Task SyncronizeEditsAsync(string serviceUrl, string geodatabasePath, SyncDirection syncDirection, string layername, string[] sublayers, GroupLayer layer)
		{
			// create sync parameters
			var taskParameters = new SyncGeodatabaseParameters()
			{
				RollbackOnFailure = true,
				GeodatabaseSyncDirection = syncDirection
			};
			var cred = await Esri.ArcGISRuntime.Security.AuthenticationManager.Current.GenerateCredentialAsync(new Uri(serviceUrl), "catchbasin", "DcnJLkq5xb5aCsd");

			// create a sync task with the URL of the feature service to sync
			var syncTask = await GeodatabaseSyncTask.CreateAsync(new Uri(serviceUrl), cred);

			// open the local geodatabase
			var gdb = await Esri.ArcGISRuntime.Data.Geodatabase.OpenAsync(geodatabasePath);

			// create a synchronize geodatabase job, pass in the parameters and the geodatabase
			SyncGeodatabaseJob job = syncTask.SyncGeodatabase(taskParameters, gdb);

			// handle the JobChanged event for the job
			job.JobChanged += async (s, e) =>
			{
				// report changes in the job status
				if (job.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Succeeded)
				{
					// report success ...
					MaximoServiceLibrary.AppContext.Log.Warn("Synchronization is complete!");
					GISSyncStatus = $"Synchronization is complete! {layername}";

					try
					{
						Geodatabase localGdb = await Geodatabase.OpenAsync(geodatabasePath);

						AddLocalDataToMap(localGdb, layername, sublayers, layer);
					}
					catch (Exception _e)
					{
						MaximoServiceLibrary.AppContext.Log.Error(_e);
					}

				}
				else if (job.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Failed)
				{
					// report failure ...
					MaximoServiceLibrary.AppContext.Log.Warn(job.Error.Message);
					GISSyncStatus = $"Error: {job.Error.Message}";
				}
				else
				{
					GISSyncStatus = $"Sync in progress ... {layername}";
					MaximoServiceLibrary.AppContext.Log.Warn(GISSyncStatus);
				}
			};

			// await the completion of the job
			var result = await job.GetResultAsync();
		}

		public FeatureLayer GetWorkorderLayer()
		{

			return this.woLayer;
			//try
			//{
			//    var layers = Map.OperationalLayers.Where(layer => layer.Name == "Open Workorders").ToList();
			//    if (layers.Count > 0)
			//    {
			//        return (FeatureLayer)((GroupLayer)layers[0]).Layers.First();
			//    }
			//    return null;
			//}
			//catch (Exception e)
			//{
			//    return null;
			//}
		}

		public async Task CheckTime()
		{
			string path = "C:\\CatchBasin\\time.txt";

			var lastWriteTime = System.IO.File.GetLastWriteTime(path);
			var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
			if ((date - lastWriteTime).TotalDays > 1)
			{
				await DailyTask();
				using (StreamWriter sw = File.CreateText(path))
				{
					sw.WriteLine(DateTime.Now.ToString());
				}
			}

		}

		public async Task DailyTask()
		{
			QueryParameters queryParams = new QueryParameters();


			queryParams.WhereClause = "DISPLAYID = 'SYNCED'";
			var result = await this.assetLayer.FeatureTable.QueryFeaturesAsync(queryParams);
			var features = result.ToList();
			this.assetLayer.FeatureTable.DeleteFeaturesAsync(features);

			queryParams.WhereClause = "1=1";
			result = await this.woLayer.FeatureTable.QueryFeaturesAsync(queryParams);
			features = result.ToList();
			this.woLayer.FeatureTable.DeleteFeaturesAsync(features);

		}

		public GroupLayer GetAssetGroupLayer()
		{
			return this.AssetsLayer;

		}
	}


	public class Features
	{
		public Features(List<Feature> _features)
		{
			this.features = _features;
		}

		public List<Feature> features { get; set; }
		public int _id { get; set; }
	}
	class LayerDescription
	{
		public LayerDescription(string _layername, string _url, SyncDirection _syncDirection, string _geodatabaseFilePath, string[] _displayExpressions, string[] _sublayerNames)
		{
			url = _url;
			layername = _layername;
			syncDirection = _syncDirection;
			geodatabaseFilePath = _geodatabaseFilePath;
			displayExpressions = _displayExpressions;
			sublayerNames = _sublayerNames;

		}

		public string url { get; set; }
		public string geodatabaseFilePath { get; set; }
		public string[] displayExpressions { get; set; }
		public string[] sublayerNames { get; set; }
		public string layername { get; set; }
		public SyncDirection syncDirection { get; set; }
	}
}
