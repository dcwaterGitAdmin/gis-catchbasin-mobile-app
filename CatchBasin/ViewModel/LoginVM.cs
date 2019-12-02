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

        public MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;

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


        public LoginVM()
        {
            LoginCommand = new LoginCommand(this);
			MaximoServiceLibraryBeanConfiguration = ((App)Application.Current).MaximoServiceLibraryBeanConfiguration;
			UserName = "EDELIOGLU";
			Password = "E2019atlas";
		}


        public void DoLogin(Window window)
        {
            //new Map().Show();
            //window.Close();
            //return;

           
            try
            {
                if (MaximoServiceLibraryBeanConfiguration.maximoService.login(UserName, Password))
                {
					 //MaximoServiceLibraryBeanConfiguration.synchronizationService.synchronizeHelperFromMaximoToLocalDb();
					// MaximoServiceLibraryBeanConfiguration.synchronizationService.synchronizeWorkOrderCompositeFromMaximoToLocalDb();
					MaximoServiceLibraryBeanConfiguration.synchronizationService.startSyncronizationTimer();
					
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
