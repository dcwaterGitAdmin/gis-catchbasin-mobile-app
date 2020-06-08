
using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Portal;
using Esri.ArcGISRuntime.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CatchBasin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

       
        public string AppType = null;


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            try
            {
                // Getting collection of process  
                Process currentProcess = Process.GetCurrentProcess();

                // Check with other process already running   
                foreach (var p in Process.GetProcesses())
                {

                    if (p.Id != currentProcess.Id) // Check running process   
                    {
                        if (p.ProcessName.Equals(currentProcess.ProcessName) == true)
                        {
                            MessageBox.Show("Application instance is already running!");
                            
                            Shutdown();
                        }
                    }
                }
            }
            catch { }
        }


        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

            MaximoServiceLibrary.AppContext.maximoService.BASE_HOST = System.Configuration.ConfigurationManager.AppSettings["MaximoBaseUrl"];
            MaximoServiceLibrary.AppContext.Log.Info($"BASE_HOST : { MaximoServiceLibrary.AppContext.maximoService.BASE_HOST}");
            try
            {
                // Challenge the user for portal credentials (OAuth credential request for arcgis.com)


                try
                {
                    //LicenseInfo.FromJson("{\"licenseString\":\"plv1qGVKC+Nq1nPxZhTCMc+I/bhdFqNX7Wkfszv6sjTcoiftoW0c8p0q/6JZ\"}");
                    var licenseKey = System.Configuration.ConfigurationManager.AppSettings["runtimeLicenseKey"];
                    ArcGISRuntimeEnvironment.SetLicense(licenseKey);

                }
                catch(Exception e2)
                {
                    MaximoServiceLibrary.AppContext.Log.Error(e2.ToString());
                }



                ArcGISRuntimeEnvironment.Initialize();


            }
			catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ArcGIS Runtime initialization failed.",MessageBoxButton.OK);
                MaximoServiceLibrary.AppContext.Log.Error(ex.ToString());
                // Exit application
                this.Shutdown();
            }


            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            // Handler for exceptions in threads behind forms.
            System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;
        }

        private void GlobalThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = e.Exception;
            MaximoServiceLibrary.AppContext.Log.Error(ex.Message + "\n" + ex.StackTrace);
        }

        private void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = (Exception)e.ExceptionObject;
            MaximoServiceLibrary.AppContext.Log.Error(ex.Message + "\n" + ex.StackTrace);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
           
        }
    }
}
