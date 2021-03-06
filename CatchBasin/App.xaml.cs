﻿using Esri.ArcGISRuntime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CatchBasin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

		public MaximoServiceLibrary.MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                // Deployed applications must be licensed at the Lite level or greater. 
                // See https://developers.arcgis.com/licensing for further details.

                // Initialize the ArcGIS Runtime before any components are created.
                ArcGISRuntimeEnvironment.Initialize();
				MaximoServiceLibraryBeanConfiguration = new MaximoServiceLibrary.MaximoServiceLibraryBeanConfiguration();
				//MaximoServiceLibraryBeanConfiguration.assetRepository.removeCollection();

				//MaximoServiceLibraryBeanConfiguration.workOrderRepository.removeCollection();

				//var mxuser = MaximoServiceLibraryBeanConfiguration.userRepository.findOneIgnoreCase("EDELIOGLU");
				//mxuser.userPreferences.lastSyncTime = DateTime.MinValue;
				//MaximoServiceLibraryBeanConfiguration.userRepository.upsert(mxuser);
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ArcGIS Runtime initialization failed.");

                // Exit application
                this.Shutdown();
            }
        }
    }
}
