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
using System.Windows.Shapes;

namespace RuntimeCatchBasins.windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private helpers.MaximoRestService maximoRestService;
        public Login(helpers.MaximoRestService _maximoRestService)
        {
            maximoRestService = _maximoRestService;
            InitializeComponent();
        }

        private  void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;
            var resilt = maximoRestService.login(username, password);

            if (resilt)
            {
                this.Close();
            }
           
        }
    }
}
