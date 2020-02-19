using CatchBasin.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaximoServiceLibrary;
using System.Windows;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using log4net;
using System.Net;

namespace CatchBasin.ViewModel
{
    class LoginVM : BaseVM
    {

        public LoginCommand LoginCommand { get; set; }


        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private string applicationType = "PM";

        public string ApplicationType
        {
            get { return applicationType; }
            set { applicationType = value; OnPropertyChanged("ApplicationType"); }
        }


        

        public LoginVM()
        {
            LoginCommand = new LoginCommand(this);
            UserName = "edelioglu";
                Password = "CatchBasin98!";

        }

        public void DownloadBaseMap()
        {
            try
            {
                const string Path = "C:\\CatchBasin\\Layers.mmpk";
                var lastWriteTime = System.IO.File.GetLastWriteTime(Path);
                if ((DateTime.Now - lastWriteTime).TotalDays > 0)
                {
                    
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(new Uri("https://geo.dcwater.com/MobileAppBaseMap/Layers.mmpk"), Path);


                    }
                }
            }
            catch (Exception e)
            {
                DownloadBaseMap();
            }
        }

        public void DownloadCNL(int count=1)
        {
            try
            {
                const string Path = "C:\\CatchBasin\\CNL.mmpk";
                var lastWriteTime = System.IO.File.GetLastWriteTime(Path);

                var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                if ((date - lastWriteTime).TotalDays > 1)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(new Uri("https://geo.dcwater.com/MobileAppBaseMap/CNL.mmpk"), Path);


                    }
                }
            }
            catch (Exception e)
            {
                DownloadCNL();
            }
        }

        public void DownloadSewer()
        {
            try
            {
                const string Path = "C:\\CatchBasin\\SEWER.mmpk";
                var lastWriteTime = System.IO.File.GetLastWriteTime(Path);
                var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                if ((date - lastWriteTime).TotalDays > 7)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(new Uri("https://geo.dcwater.com/MobileAppBaseMap/SEWER.mmpk"), Path);


                    }
                }
            }
            catch (Exception e)
            {
                DownloadSewer();
            }
        }

        public void DownloadAssets()
        {
            try
            {
                const string Path = "C:\\CatchBasin\\Assets.mmpk";
                var lastWriteTime = System.IO.File.GetLastWriteTime(Path);
                var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                if ((date - lastWriteTime).TotalDays > 1)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(new Uri("https://geo.dcwater.com/MobileAppBaseMap/Assets.mmpk"), Path);


                    }
                }
            }
            catch (Exception e)
            {
                DownloadAssets();
            }
        }


        public void DoLogin(Window window)
        {
           
            try
            {

                string loginStatus = MaximoServiceLibrary.AppContext.synchronizationService.login(UserName, Password);
                if (loginStatus == "success")
                {

                   
                    DownloadBaseMap();
                    DownloadCNL();
                    DownloadAssets();
                    DownloadSewer();
                 

                    ((App)Application.Current).AppType = ApplicationType;
                    if (MaximoServiceLibrary.AppContext.inventoryRepository.findAll().Count() == 0)
                    {
                        MaximoServiceLibrary.AppContext.synchronizationService.synchronizeHelperFromMaximoToLocalDb();
                    }
                   
                    new Map().Show();

                    var interval = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["SyncIntervalTime"]);
                    MaximoServiceLibrary.AppContext.synchronizationService.startSyncronizationTimer(interval);


                    window.Close();
                }
                else
                {
                    MessageBox.Show($"Something is wrong!\n{loginStatus}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception e)
            {
                MaximoServiceLibrary.AppContext.Log.Error(e);
                MessageBox.Show($"Something is wrong!\n{e}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
