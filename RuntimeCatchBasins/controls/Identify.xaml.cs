using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI.Controls;

namespace RuntimeCatchBasins.controls
{
    /// <summary>
    /// Interaction logic for Identify.xaml
    /// </summary>
    public partial class Identify : UserControl
    {


    
        Map map;
        Dictionary<string, Layer> hash = new Dictionary<string, Layer>();
        Dictionary<string, GeoElement> geohash = new Dictionary<string, GeoElement>();
        public static readonly DependencyProperty mapViewProperty = DependencyProperty.Register(nameof(MapView), typeof(MapView),typeof(Identify), new PropertyMetadata(null, OnMapViewPropertyChanged));

        public MapView MapView
        {
            get { return (MapView)GetValue(mapViewProperty); }
            set { SetValue(mapViewProperty, value); }
        }

        private static void OnMapViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var identify = (Identify)d;

            ComboBoxItem item = new ComboBoxItem();
            item.Content = "< All Layer >";
            item.Uid = "all";
            identify.layerList.Items.Add(item);
            identify.layerList.SelectedItem = item;

            identify.MapView = (MapView)e.NewValue;
            identify.map = identify.MapView.Map;

            foreach (ArcGISMapImageLayer layer in identify.map.OperationalLayers.ToArray())
            {
                string layerName = layer.Name;
                foreach (ArcGISSublayer sublayer in layer.Sublayers.ToArray())
                {
                    identify.addSublayer(layer, sublayer, identify.hash);
                }
            }
        }

        public Identify()
        {
            InitializeComponent();

            
            

            IsVisibleChanged += visibleChangedEvent;
        }

    


        // protected  override void onLoad(EventArgs e)
        //{
        
        //}


        private void addSublayer(Layer layer, ArcGISSublayer sublayer, Dictionary<string, Layer> hash)
        {
            if (sublayer.Sublayers.Count > 0)
            {
                foreach (ArcGISSublayer _sublayer in sublayer.Sublayers.ToArray())
                {
                    addSublayer(layer, _sublayer, hash);
                }
            }
            else
            {
                string sublayerName = sublayer.Name;
                ComboBoxItem item = new ComboBoxItem();
                item.Content = sublayer.Name;
                item.Uid = layer.Name + "_" + sublayerName;
                hash.Add(item.Uid, layer);
                layerList.Items.Add(item);
            }
        }


        private async void GeoViewTapped(object sender, GeoViewInputEventArgs e)
        {
            resultList.Items.Clear();

            geohash.Clear();
            if ((layerList.SelectedItem as ComboBoxItem).Uid == "all")
            {
                IReadOnlyList<IdentifyLayerResult> results = await MapView.IdentifyLayersAsync(e.Position, 15, false);
                resultList.Items.Clear();

                foreach (IdentifyLayerResult result in results.ToArray())
                {
                    TreeViewItem treeViewItem = new TreeViewItem();
                    treeViewItem.Focusable = false;

                    treeViewItem.Header = result.LayerContent.Name;
                    resultList.Items.Add(treeViewItem);

                    addTreeView(treeViewItem, result);
                }
            }
            else
            {

                Layer layer = hash[(layerList.SelectedItem as ComboBoxItem).Uid];
                IdentifyLayerResult result = await MapView.IdentifyLayerAsync(layer, e.Position, 15, false);
                resultList.Items.Clear();
                TreeViewItem treeViewItem = new TreeViewItem();
                treeViewItem.Focusable = false;

                treeViewItem.Header = result.LayerContent.Name;
                resultList.Items.Add(treeViewItem);

                addTreeView(treeViewItem, result);




            }


        }



        private void addTreeView(TreeViewItem treeViewItem, IReadOnlyList<IdentifyLayerResult> results)
        {
            foreach (IdentifyLayerResult result in results.ToArray())
            {
                addTreeView(treeViewItem, result);
            }

        }

        private void addTreeView(TreeViewItem treeViewItem, IdentifyLayerResult result)
        {

            if (result.SublayerResults.Count > 0)
            {
                addTreeView(treeViewItem, result.SublayerResults);
            }
            else
            {
                foreach (GeoElement geoelement in result.GeoElements)
                {
                    TreeViewItem subTreeViewItem = new TreeViewItem();
                    subTreeViewItem.Uid = RandomString(16);
                    subTreeViewItem.Header = geoelement.Attributes["OBJECTID"];


                    geohash.Add(subTreeViewItem.Uid, geoelement);
                    treeViewItem.Items.Add(subTreeViewItem);

                }

            }



        }


        private Random random = new Random();
        public string RandomString(int length)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void ResultList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (resultList.SelectedItem != null)
            {
                GeoElement geoElement = geohash[(resultList.SelectedItem as TreeViewItem).Uid];
                foreach (string key in geoElement.Attributes.Keys.ToArray())
                {
                    dataGrid.Items.Add(new IdentifyDataGridRow() { Field = key, Value = geoElement.Attributes[key] });



                }
            }


        }
    

    void visibleChangedEvent(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (MapView == null) return;
            switch (Visibility)
            {
                case System.Windows.Visibility.Visible:
                    MapView.GeoViewTapped += GeoViewTapped;
                    break;
                    case System.Windows.Visibility.Hidden:
                    MapView.GeoViewTapped -= GeoViewTapped;
                    break;
                    case System.Windows.Visibility.Collapsed:
                default:
                    MapView.GeoViewTapped += GeoViewTapped;
                    break;
                    
            }
        }

        private void CloseLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}


public class IdentifyDataGridRow
{
    public string Field { get; set; }
    public object Value { get; set; }

}
