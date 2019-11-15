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
            //_map.OperationalLayers.Add();

            Basemap basemapLayer = new Basemap(baselayer);
            _map.Basemap = basemapLayer;




          

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
