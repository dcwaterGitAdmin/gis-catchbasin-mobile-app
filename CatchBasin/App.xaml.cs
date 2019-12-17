using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Portal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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

        FileStream ostrm;
        StreamWriter writer;
        public string AppType = null;
        TextWriter oldOut = Console.Out;
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                // Deployed applications must be licensed at the Lite level or greater. 
                // See https://developers.arcgis.com/licensing for further details.
                try
                {
                    // License the app using the license info
                    Esri.ArcGISRuntime.LicenseInfo.FromJson("{\"licenseString\":\"u2D6sG1SE+ty3nv5bhzKOdeQBsBlHqtf9XEnu0ADw0futTsDsH4xC71eM9VT\"}");
                }
                catch (Exception e2)
                {

                }

              

                try
                {
                    ostrm = new FileStream("./log.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new StreamWriter(ostrm);
                }
                catch (Exception fileStreamException)
                {
                    Console.WriteLine("Cannot open Redirect.txt for writing");
                    Console.WriteLine(fileStreamException.Message);
                    return;
                }
                if(writer != null)
                {
                    Console.SetOut(writer);
                }
                

                // Initialize the ArcGIS Runtime before any components are created.
                ArcGISRuntimeEnvironment.Initialize();

                //MaximoServiceLibrary.AppContext.assetRepository.removeCollection();

                //MaximoServiceLibrary.AppContext.workOrderRepository.removeCollection();

                //var mxuser = MaximoServiceLibrary.AppContext.userRepository.findOneIgnoreCase("EDELIOGLU");
                //mxuser.userPreferences.lastSyncTime = DateTime.MinValue;
                //MaximoServiceLibrary.AppContext.userRepository.upsert(mxuser);
            }
			catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ArcGIS Runtime initialization failed.",MessageBoxButton.OK);

                // Exit application
                this.Shutdown();
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Console.SetOut(oldOut);
            writer?.Close();
            ostrm?.Close();
        }
    }
}
