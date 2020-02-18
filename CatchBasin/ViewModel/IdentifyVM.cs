using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchBasin.ViewModel
{
    class IdentifyVM : BaseVM
    {

        public MapVM MapVM;
        private List<Layer> layerList = new List<Layer>();

        public List<Layer> LayerList
        {
            get { return layerList; }
            set { layerList = value; OnPropertyChanged("LayerList"); }
        }

        private Layer selectedLayer;

        public Layer SelectedLayer
        {
            get { return selectedLayer; }
            set { selectedLayer = value; OnPropertyChanged("SelectedLayer"); }
        }

        internal void Close()
        {
            MapVM.MapView.GeoViewTapped -= Identify;
            GraphicsOverlay.Graphics.Clear();
            FeatureAttributes = new List<FeatureAttribute>();
            IdentifyLayerResults.Clear();
            MapVM.IdentifyIsVisible = false;

        }

        private ObservableCollection<LayerResult> identifyLayerResults;

        public ObservableCollection<LayerResult> IdentifyLayerResults
        {
            get { return identifyLayerResults; }
            set { identifyLayerResults = value; OnPropertyChanged("IdentifyLayerResults"); }
        }


        private List<FeatureAttribute> featureAttributes;

        public List<FeatureAttribute> FeatureAttributes
        {
            get { return featureAttributes; }
            set { featureAttributes = value; OnPropertyChanged("FeatureAttributes"); }
        }


        private string selectedValuePath;

        public string SelectedValuePath
        {
            get { return selectedValuePath; }
            set { selectedValuePath = value; OnPropertyChanged("SelectedValuePath"); }
        }

        public GraphicsOverlay GraphicsOverlay;

        public IdentifyVM(MapVM mapVM)
        {
            MapVM = mapVM;

            var _fakeLayer = new FeatureLayer();
            _fakeLayer.Name = "<All>";
            LayerList.Add(_fakeLayer);
            SelectedLayer = _fakeLayer;

            GraphicsOverlay = new GraphicsOverlay();
            MapVM.MapView.GraphicsOverlays.Add(GraphicsOverlay);

            IdentifyLayerResults = new ObservableCollection<LayerResult>();
            IdentifyLayerResults.CollectionChanged += IdentifyLayerResults_CollectionChanged;

            foreach (var item in MapVM.Map.OperationalLayers)
            {
                if (item is FeatureLayer)
                {
                    LayerList.Add(item);
                }

                if (item is GroupLayer)
                {

                    foreach (var subitem in ((GroupLayer)item).Layers)
                    {
                        if (subitem is FeatureLayer)
                        {
                            LayerList.Add(subitem);
                        }
                    }
                }
            }

            MapVM.MapView.GeoViewTapped += Identify;


        }

        private void IdentifyLayerResults_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("IdentifyLayerResults");
        }

        private async void Identify(object sender, Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs e)
        {
            GraphicsOverlay.Graphics.Clear();
            FeatureAttributes = new List<FeatureAttribute>();
           if(SelectedLayer.Name == "<All>")
            {
                IdentifyLayerResults.Clear();
                var results = await MapVM.MapView.IdentifyLayersAsync(e.Position, 10, false);
                foreach (var result in results)
                {
                    if(result.LayerContent is FeatureLayer && LayerList.FirstOrDefault(layer => layer.Name == result.LayerContent.Name) != null)
                    {

                        IdentifyLayerResults.Add(GetLayerResult(result));
                    }

                    if (result.LayerContent is GroupLayer)
                    {
                        foreach (var subresult in result.SublayerResults)
                        {
                            if (subresult.LayerContent is FeatureLayer && LayerList.FirstOrDefault(layer => layer.Name == subresult.LayerContent.Name) != null)
                            {
                                IdentifyLayerResults.Add(GetLayerResult(subresult));
                            }

                        }

                       
                    }


                }
            }
            else
            {
                IdentifyLayerResults.Clear();
                var result = await MapVM.MapView.IdentifyLayerAsync(SelectedLayer,e.Position, 10, false);
                IdentifyLayerResults.Add(GetLayerResult(result));
               
            }
        }

        public void setSelectedItem(object selectedItem)
        {
            GraphicsOverlay.Graphics.Clear();
            FeatureAttributes = new List<FeatureAttribute>();
            if (selectedItem is FeatureResult)
            {

               
                
                List<FeatureAttribute> _featureAttributes = new List<FeatureAttribute>();
                var featureResult =((FeatureResult)selectedItem);
                var layer = LayerList.FirstOrDefault(_layer => _layer.Name == featureResult.layer.Name);
                foreach (var keyValue in featureResult.feature.Attributes)
                {
                    var name = keyValue.Key;
                    if(layer != null)
                    {
                        if(layer is FeatureLayer)
                        {
                            var field =((FeatureLayer)layer).FeatureTable.Fields.FirstOrDefault(_field => _field.Name == keyValue.Key);
                            if(field != null)
                            {
                                name = field.Alias;
                            }
                        }
                    }
                    _featureAttributes.Add(new FeatureAttribute(name, keyValue.Value?.ToString()));
                }

                var geometry = featureResult.feature.Geometry;
                Symbol symbol;
                if(geometry.GeometryType == GeometryType.Point || geometry.GeometryType == GeometryType.Multipoint) {
                    symbol = new SimpleMarkerSymbol();
                } else if(geometry.GeometryType == GeometryType.Polyline)
                {
                    symbol = new SimpleLineSymbol();
                }
                else
                {
                    symbol = new SimpleFillSymbol();
                }

                GraphicsOverlay.Graphics.Add(new Graphic(geometry, symbol));
                FeatureAttributes = _featureAttributes;
            }
        }

        public LayerResult GetLayerResult(IdentifyLayerResult result)
        {
            LayerResult layerResult = new LayerResult();
            layerResult.LayerName = result.LayerContent.Name;
            layerResult.features = new List<FeatureResult>();

            foreach (var geoElement in result.GeoElements)
            {
                FeatureResult featureResult = new FeatureResult();
                featureResult.feature = geoElement;
                featureResult.DisplayValue = geoElement.Attributes["OBJECTID"].ToString();
                featureResult.layer = result.LayerContent;
                layerResult.features.Add(featureResult);
            }
            return layerResult;
        }
    }


    class LayerResult
    {
     

        public string LayerName { get; set; }
        public List<FeatureResult> features { get; set; }
    }

    class FeatureResult
    {
        public string DisplayValue { get; set; }
        public GeoElement feature { get; set; }
        public ILayerContent layer { get; set; }
    }

    class FeatureAttribute
    {

        public FeatureAttribute(string name, string value)
        {
            FieldValue = value;
            FieldName = name;
        }
        public string FieldValue { get; set; }
        public string FieldName { get; set; }
    }
}
