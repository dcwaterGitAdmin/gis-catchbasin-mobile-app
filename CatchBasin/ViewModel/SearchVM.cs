using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CatchBasin.ViewModel
{
    class SearchVM : BaseVM
    {
        private string geocodeText;

        public string GeoCodeText
        {
            get { return geocodeText; }
            set { geocodeText = value; OnPropertyChanged("GeoCodeText"); }
        }

        private List<Layer> layers = new List<Layer>();

        public List<Layer> Layers
        {
            get { return layers; }
            set { layers = value; OnPropertyChanged("Layers"); }
        }


        private Layer selectedLayer;

        public Layer SelectedLayer
        {
            get { return selectedLayer; }
            set
            {
                selectedLayer = value; OnPropertyChanged("SelectedLayer");
                ReCreateFields();
            }
        }

        internal void Close()
        {
            MapVM.SearchIsVisible = false;
        }

        private Field selectedField;

        public Field SelectedField
        {
            get { return selectedField; }
            set
            {
                selectedField = value; OnPropertyChanged("SelectedField");

            }
        }

        internal async void Geocode()
        {
            if(StreetLayer != null && StreetLayer is FeatureLayer)
            {

          
            Helper.AddressParser addressParser = new Helper.AddressParser(GeoCodeText);



            GeoCodeActionVisibility = false;
            QueryParameters query = new QueryParameters();

            query.WhereClause = $"REGISTEREDNAME like '%{addressParser.getStreetName()}%' and ((FROMLEFTTHEORETICRANGE <= {addressParser.getStreetNumber()}  and TOLEFTTHEORETICRANGE >=  {addressParser.getStreetNumber()} ) or (FROMRIGHTTHEORETICRANGE <= {addressParser.getStreetNumber()}  and TORIGHTTHEORETICRANGE >=  {addressParser.getStreetNumber()} ) )";

           var features = await StreetLayer.FeatureTable.QueryFeaturesAsync(query);
            var _dataTable = new DataTable();



            foreach (var field in StreetLayer.FeatureTable.Fields)
            {

                _dataTable.Columns.Add(new DataColumn(field.Name));

            }


            foreach (var feature in features)
            {
                GeoCodeActionVisibility = true;
                var row = _dataTable.NewRow();
                foreach (var attribute in feature.Attributes)
                {
                    row[attribute.Key] = attribute.Value;
                }
                _dataTable.Rows.Add(row);
            }
            GeoCodeDataTable = _dataTable;


            }
        }

        internal async void GeoCodeFlash()
        {
            if(StreetLayer != null && StreetLayer is FeatureLayer)
            {
                var featurelayer = StreetLayer;
                var objectid = SelectedRow["OBJECTID"].ToString();
                QueryParameters query = new QueryParameters();
                query.WhereClause = "OBJECTID = " + objectid;
                featurelayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);

                await Task.Delay(1 * 1000);

                featurelayer.ClearSelection();
            }
            
        }

        internal async void GeoCodeZoomTo()
        {
            if (StreetLayer != null && StreetLayer is FeatureLayer)
            {
                var featurelayer = StreetLayer;
                var objectid = SelectedRow["OBJECTID"].ToString();
                QueryParameters query = new QueryParameters();
                query.WhereClause = "OBJECTID = " + objectid;
                var features = await featurelayer.FeatureTable.QueryFeaturesAsync(query);

                MapVM.MapView?.SetViewpointGeometryAsync(features.First()?.Geometry, 2);
            }
        }

        private void ReCreateFields()
        {
            if (SelectedLayer != null)
            {
                if (SelectedLayer is FeatureLayer)
                {
                    Fields = ((FeatureLayer)SelectedLayer).FeatureTable.Fields.ToList();
                }
            }
        }

        internal async void Flash()
        {
            try
            {

                var featurelayer = ((FeatureLayer)SelectedLayer);
                var objectid = SelectedRow["OBJECTID"].ToString();
                QueryParameters query = new QueryParameters();
                query.WhereClause = "OBJECTID = " + objectid;
                featurelayer.SelectFeaturesAsync(query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);

                await Task.Delay(1 * 1000);

                featurelayer.ClearSelection();


            }
            catch (Exception e)
            {

            }
        }

        internal async void ZoomToStreet()
        {
            if (StreetLayer != null && StreetLayer is FeatureLayer)
            {
                if(Type == "INTERSECTS")
                {
                    QueryParameters _query = new QueryParameters();
                    _query.WhereClause = $"REGISTEREDNAME = '{SelectedPrimaryStreet.name}' and STREETTYPE = '{SelectedPrimaryStreet.type}' and QUADRANT = '{SelectedPrimaryStreet.quad}'";

                    var prifeatures = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);

                    _query.WhereClause = $"REGISTEREDNAME = '{SelectedIntersectingStreet.name}' and STREETTYPE = '{SelectedIntersectingStreet.type}' and QUADRANT = '{SelectedIntersectingStreet.quad}'";
                    var intfeatures = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);

                    var showfeatures = new List<Feature>();
                    foreach (var prifeature in prifeatures)
                    {
                        foreach (var intfeature in intfeatures)
                        {
                           if(GeometryEngine.Touches(prifeature.Geometry, intfeature.Geometry))
                            {
                                showfeatures.Add(prifeature);
                                showfeatures.Add(intfeature);
                            }
                           
                        }
                    }
                    var strings = showfeatures.Select(feature => $"OBJECTID = {feature.Attributes["OBJECTID"]?.ToString()}");


                    _query.WhereClause = String.Join(" or ", strings.ToArray());

                    var features = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);
                    if(features.Count() > 0)
                    {

                        try
                        {
                            var newGeometry = GeometryEngine.Union(features.Select(ft => ft.Geometry));

                            MapVM.MapView?.SetViewpointGeometryAsync(newGeometry, 2);
                        }catch(Exception e)
                        {
                            MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    
                    }
                }
                else
                {
                    QueryParameters _query = new QueryParameters();
                    _query.WhereClause = $"REGISTEREDNAME = '{SelectedPrimaryStreet.name}' and STREETTYPE = '{SelectedPrimaryStreet.type}' and QUADRANT = '{SelectedPrimaryStreet.quad}'";
                    _query.WhereClause = _query.WhereClause + $" and  FROMLEFTTHEORETICRANGE = '{SelectedRange.leftLower}' and TOLEFTTHEORETICRANGE = '{SelectedRange.leftUpper}' and FROMRIGHTTHEORETICRANGE = '{SelectedRange.rightLower}' and TORIGHTTHEORETICRANGE = '{SelectedRange.rightUpper}'";
                    var features = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);
                    if (features.Count() > 0)
                    {
                        try
                        {
                            var newGeometry = GeometryEngine.Union(features.Select(ft => ft.Geometry));

                            MapVM.MapView?.SetViewpointGeometryAsync(newGeometry, 2);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                       
                    }
                    

                }

            }
        }

        private DataTable dataTable;

        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; OnPropertyChanged("DataTable"); }
        }


        private DataTable geoCodeDataTable;

        public DataTable GeoCodeDataTable
        {
            get { return geoCodeDataTable; }
            set { geoCodeDataTable = value; OnPropertyChanged("GeoCodeDataTable"); }
        }

        internal async void FlashStreet()
        {
            if (StreetLayer != null && StreetLayer is FeatureLayer)
            {
                if (Type == "INTERSECTS")
                {
                    QueryParameters _query = new QueryParameters();
                    _query.WhereClause = $"REGISTEREDNAME = '{SelectedPrimaryStreet.name}' and STREETTYPE = '{SelectedPrimaryStreet.type}' and QUADRANT = '{SelectedPrimaryStreet.quad}'";

                    var prifeatures = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);

                    _query.WhereClause = $"REGISTEREDNAME = '{SelectedIntersectingStreet.name}' and STREETTYPE = '{SelectedIntersectingStreet.type}' and QUADRANT = '{SelectedIntersectingStreet.quad}'";
                    var intfeatures = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);

                    var showfeatures = new List<Feature>();
                    foreach (var prifeature in prifeatures)
                    {
                        foreach (var intfeature in intfeatures)
                        {
                            if (GeometryEngine.Touches(prifeature.Geometry, intfeature.Geometry))
                            {
                                showfeatures.Add(prifeature);
                                showfeatures.Add(intfeature);
                            }

                        }
                    }
                    var strings = showfeatures.Select(feature => $"OBJECTID = {feature.Attributes["OBJECTID"]?.ToString()}");


                    _query.WhereClause = String.Join(" or ", strings.ToArray());

                    StreetLayer.SelectFeaturesAsync(_query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);

                    await Task.Delay(1 * 1000);

                    StreetLayer.ClearSelection();

                }
                else
                {
                    QueryParameters _query = new QueryParameters();
                    _query.WhereClause = $"REGISTEREDNAME = '{SelectedPrimaryStreet.name}' and STREETTYPE = '{SelectedPrimaryStreet.type}' and QUADRANT = '{SelectedPrimaryStreet.quad}'";
                    _query.WhereClause = _query.WhereClause + $" and  FROMLEFTTHEORETICRANGE = '{SelectedRange.leftLower}' and TOLEFTTHEORETICRANGE = '{SelectedRange.leftUpper}' and FROMRIGHTTHEORETICRANGE = '{SelectedRange.rightLower}' and TORIGHTTHEORETICRANGE = '{SelectedRange.rightUpper}'";
                    StreetLayer.SelectFeaturesAsync(_query, Esri.ArcGISRuntime.Mapping.SelectionMode.New);

                    await Task.Delay(1 * 1000);

                    StreetLayer.ClearSelection();

                }

            }
        }

        internal async void SearchInLayer()
        {
            ActionVisibility = false;
            QueryParameters query = new QueryParameters();
            if (FindSimilar)
            {
                query.WhereClause = SelectedField.Name + " like '%" + SearchValue + "%'";
            }
            else
            {
                query.WhereClause = SelectedField.Name + " = '" + SearchValue + "'";
            }

            var features = await ((FeatureLayer)selectedLayer).FeatureTable.QueryFeaturesAsync(query);
            var _dataTable = new DataTable();



            foreach (var field in ((FeatureLayer)SelectedLayer).FeatureTable.Fields)
            {

                _dataTable.Columns.Add(new DataColumn(field.Name));

            }


            foreach (var feature in features)
            {
                ActionVisibility = true;
                var row = _dataTable.NewRow();
                foreach (var attribute in feature.Attributes)
                {
                    row[attribute.Key] = attribute.Value;
                }
                _dataTable.Rows.Add(row);
            }
            DataTable = _dataTable;
        }



        internal async void ZoomTo()
        {
            try
            {


                var featurelayer = ((FeatureLayer)SelectedLayer);
                var objectid = SelectedRow["OBJECTID"].ToString();
                QueryParameters query = new QueryParameters();
                query.WhereClause = "OBJECTID = " + objectid;
                var features = await featurelayer.FeatureTable.QueryFeaturesAsync(query);

                MapVM.MapView?.SetViewpointGeometryAsync(features.First()?.Geometry, 2);
            }
            catch (Exception e)
            {

            }

        }

        private DataRowView selectedRow;

        public DataRowView SelectedRow
        {
            get { return selectedRow; }
            set
            {
                selectedRow = value; OnPropertyChanged("SelectedRow");

            }
        }


        private List<Field> fields;

        public List<Field> Fields
        {
            get { return fields; }
            set { fields = value; OnPropertyChanged("Fields"); }
        }
        private string searchValue;

        public string SearchValue
        {
            get { return searchValue; }
            set { searchValue = value; OnPropertyChanged("SearchValue"); }
        }

        private bool findSimilar;

        public bool FindSimilar
        {
            get { return findSimilar; }
            set { findSimilar = value; OnPropertyChanged("FindSimilar"); }
        }




        private List<StreetData> primaryStreetList;

        public List<StreetData> PrimaryStreetList
        {
            get { return primaryStreetList; }
            set { primaryStreetList = value; OnPropertyChanged("PrimaryStreetList"); }
        }

        private StreetData selectedPrimaryStreet;

        public StreetData SelectedPrimaryStreet
        {
            get { return selectedPrimaryStreet; }
            set { selectedPrimaryStreet = value; OnPropertyChanged("SelectedPrimaryStreet");
                FillOtherStreetData();
            }
        }

        private string type= "INTERSECTS";

        public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged("Type"); }
        }
       

        public async void FillOtherStreetData()
        {
            if (StreetLayer != null && StreetLayer is FeatureLayer)
            {
                
                try
                {
                    QueryParameters _query = new QueryParameters();
                    _query.WhereClause = $"REGISTEREDNAME = '{SelectedPrimaryStreet.name}' and STREETTYPE = '{SelectedPrimaryStreet.type}' and QUADRANT = '{SelectedPrimaryStreet.quad}'";

                    var features = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);

                    var ranges = features.Select(feature => new RangeData(feature.Attributes["FROMLEFTTHEORETICRANGE"]?.ToString(), feature.Attributes["TOLEFTTHEORETICRANGE"]?.ToString(), feature.Attributes["FROMRIGHTTHEORETICRANGE"]?.ToString(), feature.Attributes["TORIGHTTHEORETICRANGE"]?.ToString())).GroupBy(s => new { s.leftLower, s.leftUpper, s.rightLower, s.rightUpper }).Select(g => g.First());

                    RangeList = ranges.OrderBy(s => Int32.Parse(s.leftLower)).ToList();


                    var newGeometry = GeometryEngine.Union(features.Select(ft => ft.Geometry));

                    _query.WhereClause = "REGISTEREDNAME is not null and REGISTEREDNAME <> '" + SelectedPrimaryStreet.name + "'";
                    _query.Geometry = newGeometry;
                    _query.SpatialRelationship = SpatialRelationship.Intersects;

                    var intersectsFeatures = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);

                    var streets = intersectsFeatures.Select(feature => new StreetData(feature.Attributes["REGISTEREDNAME"]?.ToString(), feature.Attributes["STREETTYPE"]?.ToString(), feature.Attributes["QUADRANT"]?.ToString())).GroupBy(s => new { s.name, s.type, s.quad }).Select(g => g.First());

                    IntersectingStreetList = streets.OrderBy(s => s.name).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private List<StreetData> intersectingStreetList;

        public List<StreetData> IntersectingStreetList
        {
            get { return intersectingStreetList; }
            set { intersectingStreetList = value; OnPropertyChanged("IntersectingStreetList"); }
        }

        private StreetData selectedIntersectingStreet;

        public StreetData SelectedIntersectingStreet
        {
            get { return selectedIntersectingStreet; }
            set { selectedIntersectingStreet = value; }
        }


        private List<RangeData> rangeList;

        public List<RangeData> RangeList
        {
            get { return rangeList; }
            set { rangeList = value; OnPropertyChanged("RangeList"); }
        }
        private RangeData selectedRange;

        public RangeData SelectedRange
        {
            get { return selectedRange; }
            set { selectedRange = value; }
        }


        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        private Commands.GeoCodeCommand geoCodeCommand;

        public Commands.GeoCodeCommand GeoCodeCommand
        {
            get { return geoCodeCommand; }
            set
            {
                geoCodeCommand = value;
                OnPropertyChanged("GeoCodeCommand");
            }
        }

        private Commands.SearchFlashCommand searchFlashCommand;

        public Commands.SearchFlashCommand SearchFlashCommand
        {
            get { return searchFlashCommand; }
            set
            {
                searchFlashCommand = value;
                OnPropertyChanged("SearchFlashCommand");
            }
        }

        private Commands.GeoCodeFlashCommand geoCodeFlashCommand;

        public Commands.GeoCodeFlashCommand GeoCodeFlashCommand
        {
            get { return geoCodeFlashCommand; }
            set
            {
                geoCodeFlashCommand = value;
                OnPropertyChanged("GeoCodeFlashCommand");
            }
        }


        private Commands.SearchZoomToCommand searchZoomToCommand;

        public Commands.SearchZoomToCommand SearchZoomToCommand
        {
            get { return searchZoomToCommand; }
            set
            {
                searchZoomToCommand = value;
                OnPropertyChanged("SearchZoomToCommand");
            }
        }


        private Commands.GeoCodeZoomToCommand geoCodeZoomToCommand;

        public Commands.GeoCodeZoomToCommand GeoCodeZoomToCommand
        {
            get { return geoCodeZoomToCommand; }
            set
            {
                geoCodeZoomToCommand = value;
                OnPropertyChanged("GeoCodeZoomToCommand");
            }
        }

        private Commands.SearchInLayerCommand searchInLayerCommand;

        public Commands.SearchInLayerCommand SearchInLayerCommand
        {
            get { return searchInLayerCommand; }
            set
            {
                searchInLayerCommand = value;
                OnPropertyChanged("SearchInLayerCommand");
            }
        }



        private Commands.ZoomToStreetCoomand zoomToStreetCoomand;

        public Commands.ZoomToStreetCoomand ZoomToStreetCoomand
        {
            get { return zoomToStreetCoomand; }
            set
            {
                zoomToStreetCoomand = value;
                OnPropertyChanged("ZoomToStreetCoomand");
            }
        }

        private Commands.FlashStreetCoomand flashStreetCoomand;

        public Commands.FlashStreetCoomand FlashStreetCoomand
        {
            get { return flashStreetCoomand; }
            set
            {
                flashStreetCoomand = value;
                OnPropertyChanged("FlashStreetCoomand");
            }
        }

        private Commands.ReLoadStreetCoomand reLoadStreetCoomand;

        public Commands.ReLoadStreetCoomand ReLoadStreetCoomand
        {
            get { return reLoadStreetCoomand; }
            set
            {
                reLoadStreetCoomand = value;
                OnPropertyChanged("ReLoadStreetCoomand");
            }
        }

        private bool actionVisibility = false;

        public bool ActionVisibility
        {
            get { return actionVisibility; }
            set
            {
                actionVisibility = value;
                OnPropertyChanged("ActionVisibility");
            }
        }

        private bool geoCodeActionVisibility = false;

        public bool GeoCodeActionVisibility
        {
            get { return geoCodeActionVisibility; }
            set
            {
                geoCodeActionVisibility = value;
                OnPropertyChanged("GeoCodeActionVisibility");
            }
        }

        public async void FillStreetData()
        {
            if (StreetLayer != null && StreetLayer is FeatureLayer)
            {
                QueryParameters _query = new QueryParameters();
                _query.WhereClause = "REGISTEREDNAME is not null";
             
                var features = await StreetLayer.FeatureTable.QueryFeaturesAsync(_query);

               
                var streets = features.Select(feature => new StreetData(feature.Attributes["REGISTEREDNAME"]?.ToString(), feature.Attributes["STREETTYPE"]?.ToString(), feature.Attributes["QUADRANT"]?.ToString())).GroupBy(s=>new { s.name,s.type, s.quad}).Select(g=>g.First());

                PrimaryStreetList = streets.OrderBy(s => s.name).ToList();
            }
        }

        public FeatureLayer StreetLayer;
        public MapVM MapVM;

        public SearchVM(MapVM mapVM)
        {
            MapVM = mapVM;

            GeoCodeCommand = new Commands.GeoCodeCommand(this);
            SearchInLayerCommand = new Commands.SearchInLayerCommand(this);
            SearchFlashCommand = new Commands.SearchFlashCommand(this);
            SearchZoomToCommand = new Commands.SearchZoomToCommand(this);
            GeoCodeFlashCommand = new Commands.GeoCodeFlashCommand(this);
            GeoCodeZoomToCommand = new Commands.GeoCodeZoomToCommand(this);
            ZoomToStreetCoomand = new Commands.ZoomToStreetCoomand(this);
            FlashStreetCoomand = new Commands.FlashStreetCoomand(this);
            ReLoadStreetCoomand = new Commands.ReLoadStreetCoomand(this);
           

            var baseMap = MapVM.Map.OperationalLayers.FirstOrDefault(layer => layer.Name == "BaseMap");
            if (baseMap != null && baseMap is GroupLayer)
            {
                var streetGroupLayer = ((GroupLayer)baseMap).Layers.FirstOrDefault(_layer => _layer.Name == "Street Names");
                if (streetGroupLayer != null && streetGroupLayer is GroupLayer)
                {
                    StreetLayer = (FeatureLayer)((GroupLayer)streetGroupLayer).Layers.FirstOrDefault(__layer => __layer.Name == "Street Name");
                }

            }
            FillStreetData();




            foreach (var item in MapVM.Map.OperationalLayers)
            {
                if (item is FeatureLayer)
                {
                    Layers.Add(item);
                }

                if (item is GroupLayer)
                {

                    foreach (var subitem in ((GroupLayer)item).Layers)
                    {
                        if (subitem is FeatureLayer)
                        {
                            Layers.Add(subitem);
                        }
                    }
                }
            }


        }


    }

    class StreetData
    {
        public StreetData(string _name, string _type, string _quad)
        {
            name = _name;
            type = _type;
            quad = _quad;
        }
        public string name { get; set; }
        public string type { get; set; }
        public string quad { get; set; }

        public override string ToString()
        {
            return name + " | " + type + " | " + quad;
        }


    }

    class RangeData
    {
        public RangeData(string _leftLower, string _leftUpper, string _rightLower, string _rightUpper)
        {
            leftLower = _leftLower;
            leftUpper = _leftUpper;
            rightLower = _rightLower;
            rightUpper = _rightUpper;
        }

        public string leftLower { get; set; }
        public string leftUpper { get; set; }
        public string rightLower { get; set; }
        public string rightUpper { get; set; }

        public override string ToString()
        {
            return "Ranges : " +leftLower + " - "  + leftUpper + " and " + rightLower + " - "+ rightUpper;
        }
    }

}
