using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Tasks.Offline;
using Esri.ArcGISRuntime.Toolkit.UI.Controls;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
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
using MaximoServiceLibrary;
using LocalDBLibrary;
using MaximoServiceLibrary.model;

namespace RuntimeCatchBasins
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MaximoService maximoService = new MaximoService();
		public static DbConnection dbConnection = new DbConnection();

		public static SynchronizationService synchronizationService =
			new SynchronizationService(maximoService, dbConnection);

		public MainWindow()
		{
			InitializeComponent();

			maximoService.loginDelegate += changeStatusLabel;
			maximoService.loginDelegate += enableButton;
			maximoService.loginDelegate += startSync;
			woList.listView.SelectionChanged += workOrderSelectedChange;
		}

		private void toc_LayerContentContextMenuOpening(object sender, LayerContentContextMenuEventArgs args)
		{
			if (args.LayerContent is Layer layer)
			{
				if (layer.LoadStatus == LoadStatus.FailedToLoad)
				{
					var retry = new MenuItem() {Header = "Retry load"};
					retry.Click += (s, e) => layer.RetryLoadAsync();
					args.MenuItems.Add(retry);
					return;
				}

				if (layer.FullExtent != null)
				{
					var zoomTo = new MenuItem() {Header = "Zoom To"};
					zoomTo.Click += (s, e) => mapView.SetViewpointGeometryAsync(layer.FullExtent);
					args.MenuItems.Add(zoomTo);
				}
			}
		}


		public void workOrderSelectedChange(object sender, SelectionChangedEventArgs e)
		{
			woDetail.update((sender as ListView).SelectedItem as MaximoWorkOrder);
		}


		private void IdentifyButton_Click(object sender, RoutedEventArgs e)
		{
			if (identifyControl.Visibility == Visibility.Visible)
			{
				identifyControl.Visibility = Visibility.Collapsed;
			}
			else
			{
				identifyControl.Visibility = Visibility.Visible;
			}
		}

		private void TableOfContentButton_Click(object sender, RoutedEventArgs e)
		{
			if (toc.Visibility == Visibility.Visible)
			{
				toc.Visibility = Visibility.Collapsed;
			}
			else
			{
				toc.Visibility = Visibility.Visible;
			}
		}

		private void ZoomToFullExtentButton_Click(object sender, RoutedEventArgs e)
		{
			Envelope initialLocation = new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985));
			mapView.SetViewpointGeometryAsync(initialLocation);
		}

		private void MeasureButton_Click(object sender, RoutedEventArgs e)
		{
			if (measure.Visibility == Visibility.Visible)
			{
				measure.Visibility = Visibility.Collapsed;
			}
			else
			{
				measure.Visibility = Visibility.Visible;
			}
		}

		private void KeepGPSInViewButton_Click(object sender, RoutedEventArgs e)
		{
			mapView.LocationDisplay.IsEnabled = true;
			mapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Off;
		}

		private void ShowGPSInfoButton_Click(object sender, RoutedEventArgs e)
		{
			// todo
		}

		private void PanToGPSButton_Click(object sender, RoutedEventArgs e)
		{
			if (mapView.LocationDisplay.AutoPanMode != LocationDisplayAutoPanMode.Recenter)
			{
				mapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Recenter;
			}
			else
			{
				mapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Off;
			}
		}


		public async void generateOfflineMap()
		{
			OfflineMapTask task = await OfflineMapTask.CreateAsync(mapView.Map);
			Envelope initialLocation = new Envelope(375474, 120000, 422020, 152000, new SpatialReference(26985));
			GenerateOfflineMapParameters parameters =
				await task.CreateDefaultGenerateOfflineMapParametersAsync(initialLocation);


			GenerateOfflineMapJob generateMapJob = task.GenerateOfflineMap(parameters, "C:\\RuntimeArcgis");
			GenerateOfflineMapResult results = await generateMapJob.GetResultAsync();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			(new windows.Login(maximoService)).Show();
		}

		private void SyncButton_Click(object sender, RoutedEventArgs e)
		{
            statusLabel.Content = "Wait for Maximo Sync ";
            synchronizationService.synchronizeWorkOrderCompositeFromLocalDbToMaximo();
            MessageBox.Show("Maximo Sync Completed");
        }

		private void WorkOrderListButton_Click(object sender, RoutedEventArgs e)
		{
			if (woList.Visibility == Visibility.Visible)
			{
				woList.Visibility = Visibility.Collapsed;
			}
			else
			{
				woList.Visibility = Visibility.Visible;
			}
		}


		public void changeStatusLabel()
		{
			statusLabel.Content = maximoService.mxuser.displayName;
		}

		public void enableButton()
		{
			syncButton.IsEnabled = true;
			workOrderListButton.IsEnabled = true;
		}

		public  void startSync()
		{


            //if (synchronizationService.domainRepository.count() == 0)
            //{
            //	synchronizationService.synchronizeHelperFromMaximoToLocalDb();
            //}
           // statusLabel.Content = "Wait for Maximo Sync ";
          
            synchronizationService.synchronizeWorkOrderCompositeFromMaximoToLocalDb();
            //statusLabel.Content = "Maximo Sync Completed";
            MessageBox.Show("Maximo Sync Completed");
        }

		// Map initialization logic is contained in MapViewModel.cs
	}
}