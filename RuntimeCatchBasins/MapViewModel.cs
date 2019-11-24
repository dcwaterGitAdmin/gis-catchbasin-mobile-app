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
using Esri.ArcGISRuntime.Tasks.Offline;
using Esri.ArcGISRuntime.Portal;

namespace RuntimeCatchBasins
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        private string arcgisBaseUrl = "https://geo.dcwater.com/arcgis/rest/services";
        private string cnlNoIDsLayerUrl = "/Mobile/CBCNLNOIDS/MapServer";
        private string openWorkOrderLayerUrl = "/Mobile/CBWorkorders/MapServer";
        private string assetsLayerUrl = "/Mobile/CBAssets/MapServer";
        private string sewerNetworkLayerUrl = "/Mobile/CBSewerContext/MapServer";
        private string baseMapLayerUrl = "/Mobile/CBBase/MapServer";
       

        public MapViewModel()
        {
            string[] layersUrl = { cnlNoIDsLayerUrl, openWorkOrderLayerUrl, assetsLayerUrl, sewerNetworkLayerUrl };
            foreach (string layerUrl in layersUrl)
            {
                Uri layerUri = new Uri(arcgisBaseUrl + layerUrl);
                ArcGISMapImageLayer layer = new ArcGISMapImageLayer(layerUri);
                _map.OperationalLayers.Add(layer);

            }

            Uri baseLayerUri = new Uri(arcgisBaseUrl + baseMapLayerUrl);
            ArcGISMapImageLayer baselayer = new ArcGISMapImageLayer(baseLayerUri);
           // _map.OperationalLayers.Add();

            Basemap basemapLayer = new Basemap(baselayer);
            _map.Basemap = basemapLayer;

          //  init();


          

        }


        public async void init()

        {

            try
            {
                MobileMapPackage offlineMapPackage = await MobileMapPackage.OpenAsync("C:/TEMPCD");



                // Get the map from the package and set it to the MapView
                var map = offlineMapPackage.Maps.First();
                Map = map;

            }
            catch (Exception e)
            {
                ArcGISPortal portal = await ArcGISPortal.CreateAsync();

                // Get a web map item using its ID.
                PortalItem webmapItem = await PortalItem.CreateAsync(portal, "a72f2553da664a41b5f00583f7780206");

                // Create a map from the web map item.
                _map = new Map(webmapItem);
                Map = _map;
                // Create an OfflineMapTask from the map ...
                OfflineMapTask takeMapOfflineTask = await OfflineMapTask.CreateAsync(_map);
                // ... or a web map portal item.



                // Create the default parameters for the task, pass in the area of interest.
                GenerateOfflineMapParameters parameters = await takeMapOfflineTask.CreateDefaultGenerateOfflineMapParametersAsync(new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985)));

                // Create the job with the parameters and output location.
                var _generateOfflineMapJob = takeMapOfflineTask.GenerateOfflineMap(parameters, "C:/TEMPCD");

                // Handle the progress changed event for the job.
                // _generateOfflineMapJob.ProgressChanged += OfflineMapJob_ProgressChanged;

                // Await the job to generate geodatabases, export tile packages, and create the mobile map package.
                GenerateOfflineMapResult results = await _generateOfflineMapJob.GetResultAsync();

                Map = results.OfflineMap;
            }


          

        }


        private Map _map = new Map(Basemap.CreateStreets());



        /// <summary>
        /// Gets or sets the map
        /// </summary>
        public Map Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Raises the <see cref="MapViewModel.PropertyChanged" /> event
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChangedHandler = PropertyChanged;
            if (propertyChangedHandler != null)
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void infoToolActivate()
        {

        }
    }
}
