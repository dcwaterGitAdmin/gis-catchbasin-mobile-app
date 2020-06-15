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


        private string progressText;

        public string ProgressText
        {
            get { return progressText; }
            set { progressText = value; OnPropertyChanged("ProgressText"); }
        }


        private int progressBarValue;

        public int ProgressBarValue
        {
            get { return progressBarValue; }
            set { progressBarValue = value; OnPropertyChanged("ProgressBarValue"); }
        }

        private bool progressIsVisible = false;

        public bool ProgressIsVisible
        {
            get { return progressIsVisible; }
            set { progressIsVisible = value; OnPropertyChanged("ProgressIsVisible"); }
        }





        public LoginVM()
        {
            LoginCommand = new LoginCommand(this);
            //UserName = "edelioglu";
            //Password = "CatchBasin98!";

        }

        public void DownloadBaseMap()
        {
            


            //todo: add config file
            const string Path = "C:\\CatchBasin\\Layers.mmpk";
            var lastWriteTime = System.IO.File.GetLastWriteTime(Path);
            var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            //todo: add config file (30)
            if ((date - lastWriteTime).TotalDays > 30)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(BaseMapDownloadProgress);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(BaseMapDownloadComplete);

                        ProgressBarValue = 0;
                        // todo: add config file url
                        client.DownloadFileAsync(new Uri("https://geo.dcwater.com/MobileAppBaseMap/Layers.mmpk"), Path);
                        ProgressText = "Basemap Download Started";


                    }
                }
                catch (Exception e)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Basemap failed to download, try again?",
                   "Basemap", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        DownloadBaseMap();
                    }
                    else if (messageBoxResult == MessageBoxResult.No)
                    {
                        DownloadCNL();
                    }
                }
            }
            else
            {
                DownloadCNL();
            }

           
        }

        private void BaseMapDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            ProgressText = "Basemap Download Complete";
            DownloadCNL();

        }

        private void BaseMapDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressText = "Basemap Download In Progress";

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            ProgressBarValue = int.Parse(Math.Truncate(percentage).ToString());
        }

        public void DownloadCNL(int count=1)
        {
           
            //todo: add config file
            const string Path = "C:\\CatchBasin\\CNL.mmpk";
            var lastWriteTime = System.IO.File.GetLastWriteTime(Path);
            var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            //todo: add config file (1)
            if ((date - lastWriteTime).TotalDays > 1)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(CNLDownloadProgress);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(CNLDownloadComplete);

                        ProgressBarValue = 0;
                        // todo: add config file url
                        client.DownloadFileAsync(new Uri("https://geo.dcwater.com/MobileAppBaseMap/CNL.mmpk"), Path);
                        ProgressText = "CNL Layer Download Started";


                    }
                }
                catch (Exception e)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("CNL Layer failed to download, try again?",
                   "CNL", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        DownloadCNL();
                    }
                    else if (messageBoxResult == MessageBoxResult.No)
                    {
                        DownloadAssets();
                    }
                }
            }
            else
            {
                DownloadAssets();
            }

        }


        private void CNLDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            ProgressText = "CNL Layer Download Complete";
            DownloadAssets();

        }

        private void CNLDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressText = "CNL Layer Download In Progress";

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            ProgressBarValue = int.Parse(Math.Truncate(percentage).ToString());
        }


        public void DownloadSewer()
        {
         

            //todo: add config file
            const string Path = "C:\\CatchBasin\\SEWER.mmpk";
            var lastWriteTime = System.IO.File.GetLastWriteTime(Path);
            var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            //todo: add config file (7)
            if ((date - lastWriteTime).TotalDays > 7)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(SewerDownloadProgress);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(SewerDownloadComplete);

                        ProgressBarValue = 0;
                        // todo: add config file url
                        client.DownloadFileAsync(new Uri("https://geo.dcwater.com/MobileAppBaseMap/SEWER.mmpk"), Path);
                        ProgressText = "Sewer Layer Download Started";


                    }
                }
                catch (Exception e)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Sewer Layer failed to download, try again?",
                   "Sewer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        DownloadSewer();
                    }
                    else if (messageBoxResult == MessageBoxResult.No)
                    {
                        OpenApplication();
                    }
                }
            }
            else
            {
                OpenApplication();
            }

        }

        private void SewerDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            ProgressText = "Sewer Layer Download Complete";
            OpenApplication();

        }

        private void SewerDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressText = "Sewer Layer Download In Progress";

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            ProgressBarValue = int.Parse(Math.Truncate(percentage).ToString());
        }

        public void DownloadAssets()
        {
            

            //todo: add config file
            const string Path = "C:\\CatchBasin\\Assets.mmpk";
            var lastWriteTime = System.IO.File.GetLastWriteTime(Path);
            var date = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            //todo: add config file (1)
            if ((date - lastWriteTime).TotalDays > 1)
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(AssetDownloadProgress);
                        client.DownloadFileCompleted += new AsyncCompletedEventHandler(AssetDownloadComplete);

                        ProgressBarValue = 0;
                        // todo: add config file url
                        client.DownloadFileAsync(new Uri("https://geo.dcwater.com/MobileAppBaseMap/Assets.mmpk"), Path);
                        ProgressText = "Asset Layer Download Started";


                    }
                }
                catch (Exception e)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Asset Layer failed to download, try again?",
                   "Asset", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        DownloadAssets();
                    }
                    else if (messageBoxResult == MessageBoxResult.No)
                    {
                        DownloadSewer();
                    }
                }
            }
            else
            {
                DownloadSewer();
            }


        }


        private void AssetDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            ProgressText = "Asset Layer Download Complete";
            DownloadSewer();

        }

        private void AssetDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressText = "Asset Layer Download In Progress";

            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            ProgressBarValue = int.Parse(Math.Truncate(percentage).ToString());
        }

        public void OpenApplication()
        {
            new Map().Show();

            var interval = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["SyncIntervalTime"]);
            MaximoServiceLibrary.AppContext.synchronizationService.startSyncronizationTimer(interval);

            
            Window.Close();
        }
        public Window Window;
     
        public void DoLogin(Window window)
        {
            Window = window;
            if (ProgressIsVisible) { return; }
            try
            {

                string loginStatus = MaximoServiceLibrary.AppContext.synchronizationService.login(UserName, Password);
                if (loginStatus == "success")
                {

                    ProgressIsVisible = true;
                    





                    ((App)Application.Current).AppType = ApplicationType;
                    if (MaximoServiceLibrary.AppContext.inventoryRepository.findAll().Count() == 0)
                    {
                        MaximoServiceLibrary.AppContext.synchronizationService.synchronizeHelperFromMaximoToLocalDb();
                    }
                    DownloadBaseMap();

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
