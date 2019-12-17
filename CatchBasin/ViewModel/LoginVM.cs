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
			
			UserName = "EDELIOGLU";
			Password = "E2019atlas";
		}


        public void DoLogin(Window window)
        {
          
            try
            {
                if (MaximoServiceLibrary.AppContext.synchronizationService.login(UserName, Password))
                {


                    Console.WriteLine("test");
					((App)Application.Current).AppType = ApplicationType;
                    if (MaximoServiceLibrary.AppContext.inventoryRepository.findAll().Count() == 0)
                    {
                        MaximoServiceLibrary.AppContext.synchronizationService.synchronizeHelperFromMaximoToLocalDb();
                    }

                    var interval = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["SyncIntervalTime"]);
                    MaximoServiceLibrary.AppContext.synchronizationService.startSyncronizationTimer(interval);
					
					new Map().Show();
                    window.Close();
                }
                else
                {
                    MessageBox.Show($"Something is wrong!\n", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception e)
            {

            }
            
        }
    }
}
