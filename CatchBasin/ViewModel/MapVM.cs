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
            if(status == "SYNC_FINISHED")
            {
                WorkOrderListVM.Update();
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

        public MapView MapView { get; set; }


        public async void MapTappedForSelectAsset(object sender, GeoViewInputEventArgs e)
        {
            GroupLayer layer = (GroupLayer)GetAssetGroupLayer();


            IdentifyLayerResult identifyResults = await MapView.IdentifyLayerAsync(layer, e.Position, 30, false);

            var filteredresults = identifyResults.SublayerResults.Where(result => result.LayerContent.Name == "Catch Basin - Cleaned by DC Water" || result.LayerContent.Name == "Catch Basin - Cleaned by Others" || result.LayerContent.Name == "Catch Basin - Proposed");

            foreach (var result in filteredresults)
            {
                if (result.GeoElements.Count > 0)
                {
                    MapView.GeoViewTapped -= MapTappedForSelectAsset;
                    var element = result.GeoElements.First();
                    QueryParameters queryParameters = new QueryParameters();
                    queryParameters.WhereClause = $"ASSETTAG='{element.Attributes["ASSETTAG"]}'";
                   
                    var queryLayer = ((FeatureLayer)layer.Layers.FirstOrDefault(sublayer => sublayer.Name == result.LayerContent.Name));
                    if(queryLayer!= null)
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
            var layer = GetAssetGroupLayer();
            FeatureLayer featurelayer = (FeatureLayer)layer.Layers.FirstOrDefault(__layer => __layer.Name == "Catch Basin - Cleaned by DC Water");
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
        }
        public async void MapTappedForCreateAsset(object sender, GeoViewInputEventArgs e)
        {
            var user = MaximoServiceLibrary.AppContext.synchronizationService.mxuser;
            // 
            MapView.GeoViewTapped -= MapTappedForCreateAsset;
            var tag = $"N{user.userPreferences.selectedPersonGroup}{DateTime.Now.ToString("MMddyyhhmmss")}";
            var layer = GetAssetGroupLayer();
            FeatureLayer featurelayer = (FeatureLayer)layer.Layers.FirstOrDefault(__layer => __layer.Name == "Catch Basin - Cleaned by DC Water");
            if (featurelayer != null)
            {
                var feature = featurelayer.FeatureTable.CreateFeature();
                feature.Attributes["ASSETTAG"] = tag;
                feature.Attributes["SUBTYPE"] = 0;
                feature.Attributes["TOPMATRL"] = "C";
                feature.Attributes["TOPTHICK"] = 4;
                feature.Attributes["LOCATIONDETAIL"] = "";
                feature.Attributes["OWNER"] = "WASA";
                feature.Attributes["CLNRESP"] = "DC WASA";
                feature.Attributes["ISWQI"] = "N";
                feature.Attributes["INMS4"] = "N";
                feature.Attributes["ISCORNRCB"] = "N";
                feature.Attributes["BIOFLTR"] = "N";
                feature.Attributes["HASSUMP"] = "Y";
                feature.Attributes["HASWATERSEAL"] = "N";


                feature.Geometry = (MapPoint)GeometryEngine.NormalizeCentralMeridian(e.Location);
                await featurelayer.FeatureTable.AddFeatureAsync(feature);
                feature.Refresh();
                featurelayer.SelectFeature(feature);
                WorkOrderDetailVM.SetAsset(feature);
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
                    queryParameters.WhereClause = $"wonum='{wo.wonum}'";
                    FeatureQueryResult features = await layer.FeatureTable.QueryFeaturesAsync(queryParameters);
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
                    queryParameters.WhereClause = $"wonum='{wo.wonum}'";
                    FeatureQueryResult features = await layer.FeatureTable.QueryFeaturesAsync(queryParameters);
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
                    queryParameters.WhereClause = $"wonum='{wo.wonum}'";
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

            layer?.ClearSelection();


            var assetLayer = GetAssetGroupLayer();
            ((FeatureLayer)assetLayer?.Layers?.FirstOrDefault())?.ClearSelection();
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


        public ZoomToFullExtentCommand ZoomToFullExtentCommand { get; set; }
        public void DoZoomToFullExtent(MapView mapView)
        {
            Envelope initialLocation = new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985));
            mapView.SetViewpointGeometryAsync(initialLocation);
        }


        public SyncCommand SyncCommand { get; set; }
        public void MakeSync()
        {
            MaximoServiceLibrary.AppContext.synchronizationService.triggerSynchronization();
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
            }catch(Exception e)
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
        private async void InitializeMap()
        {


           

            Envelope envelope = new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985));
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            List<LayerDescription> layerDescriptions = new List<LayerDescription>();
            layerDescriptions.Add(new LayerDescription("CNL/NoIDs", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBCNLNOIDS/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBCNLNOIDS.geodatabase", new string[] { "" }, new string[] { "Newly Discovered/CNL" }));

            if (((App)Application.Current).AppType == "PM")
            {
                layerDescriptions.Add(new LayerDescription("Open Workorders", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBWorkorders/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBWorkorders.geodatabase", new string[] { "" }, new string[] { "Catch Basin Workorder" }));

            }
            else
            {
                layerDescriptions.Add(new LayerDescription("Open Workorders", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBInsp/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBInsp.geodatabase", new string[] { "" }, new string[] { "" }));

            }


            layerDescriptions.Add(new LayerDescription("Assets", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBAssetNeedsJetVac/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBAssetNeedsJetVac.geodatabase", new string[] { "" }, new string[] { "Catch Basin - Cleaned by DC Water - Needs Jet Vac" }));
            layerDescriptions.Add(new LayerDescription("Assets", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBAssetWaterQuality/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBAssetWaterQuality.geodatabase", new string[] { "" }, new string[] { "Catch Basin - Cleaned by DC Water - Water Quality" }));
            layerDescriptions.Add(new LayerDescription("Assets", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBAssetHeavilyTravelled/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBAssetHeavilyTravelled.geodatabase", new string[] { "" }, new string[] { "Catch Basin - Cleaned by DC Water - Heavily Travelled" }));
            layerDescriptions.Add(new LayerDescription("Assets", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBAssetProposed/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBAssetProposed.geodatabase", new string[] { "" }, new string[] { "Catch Basin - Proposed" }));
            layerDescriptions.Add(new LayerDescription("Assets", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBAssetCleanedByOthers/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBAssetCleanedByOthers.geodatabase", new string[] { "" }, new string[] { "Catch Basin - Cleaned by Others" }));

            // todo:  set SyncDirection.Bidirectional
            layerDescriptions.Add(new LayerDescription("Assets", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBAssetCleanedByDCW/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBAssetCleanedByDCW.geodatabase", new string[] { "" }, new string[] { "Catch Basin - Cleaned by DC Water" }));


            layerDescriptions.Add(new LayerDescription("Sewer Network", "https://azw-pgis02.dcwasa.com:6443/arcgis/rest/services/Mobile/CBSewer/FeatureServer", SyncDirection.Download, "C:\\CatchBasin\\CBSewer.geodatabase", new string[] { "", "" }, new string[] { "Sewer Manhole", "Sewer Gravity Main" }));

            layerDescriptions.Reverse();

            foreach (LayerDescription layerDescription in layerDescriptions)
            {
                Geodatabase localGdb = null;
                try
                {
                    localGdb = await Geodatabase.OpenAsync(layerDescription.geodatabaseFilePath);

                }
                catch (Exception e)
                {
                    
                }

                if (localGdb == null)
                {
                    await GISLayerToOffline(layerDescription.url, layerDescription.layername, layerDescription.displayExpressions, layerDescription.sublayerNames, envelope, layerDescription.geodatabaseFilePath);
                }
                else
                {
                    GroupLayer layer = AddLocalDataToMap(localGdb, layerDescription.layername, layerDescription.sublayerNames);
                    SyncronizeEditsAsync(layerDescription.url, layerDescription.geodatabaseFilePath, layerDescription.syncDirection, layerDescription.layername, layerDescription.sublayerNames, layer);

                }
            }

        }

        public void updateDefinitionQuery()
        {
            FeatureLayer layer = GetWorkorderLayer();
            if (layer != null)
            {
                layer.DefinitionExpression = $"PERSONGROUP = '{MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences.selectedPersonGroup}' OR PERSONGROUP = 'CB00'";

            }

        }

        public async Task GISLayerToOffline(string url, string layername, string[] expression, string[] sublayers, Envelope envelope, string path)
        {

            GISSyncStatus = $"Download First GIS Data Started : {layername}";
            Uri featureServiceUri = new Uri(url);
            GeodatabaseSyncTask gdbSyncTask = await GeodatabaseSyncTask.CreateAsync(featureServiceUri);

            GenerateGeodatabaseParameters generateGdbParams = await gdbSyncTask.CreateDefaultGenerateGeodatabaseParametersAsync(envelope);
            //generateGdbParams.SyncModel = SyncModel.Geodatabase;
            //generateGdbParams.ReturnAttachments = false;
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

                    return;
                }


                if (generateGdbJob.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Succeeded)
                {
                    GISSyncStatus = $"Download Complete : {layername}";
                    Geodatabase localGdb = await generateGdbJob.GetResultAsync();
                    AddLocalDataToMap(localGdb, layername, sublayers);
                }
                else if (generateGdbJob.Status == Esri.ArcGISRuntime.Tasks.JobStatus.Failed)
                {
                    GISSyncStatus = $"Unable to create local geodatabase.";


                }
                else
                {
                    GISSyncStatus = $"Download continue : {layername} {generateGdbJob.Messages.Count}";


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

            if (layername == "Open Workorders")
            {
                updateDefinitionQuery();
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

            // create a sync task with the URL of the feature service to sync
            var syncTask = await GeodatabaseSyncTask.CreateAsync(new Uri(serviceUrl));

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

                }
            };

            // await the completion of the job
            var result = await job.GetResultAsync();
        }

        public FeatureLayer GetWorkorderLayer()
        {
            try
            {
                var layers = Map.OperationalLayers.Where(layer => layer.Name == "Open Workorders").ToList();
                if (layers.Count > 0)
                {
                    return (FeatureLayer)((GroupLayer)layers[0]).Layers.First();
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public GroupLayer GetAssetGroupLayer()
        {
            try
            {
                var layers = Map.OperationalLayers.Where(layer => layer.Name == "Assets").ToList();
                if (layers.Count > 0)
                {
                    return ((GroupLayer)layers[0]);
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
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
