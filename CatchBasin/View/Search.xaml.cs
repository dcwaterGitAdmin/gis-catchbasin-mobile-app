using CatchBasin.ViewModel;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CatchBasin.View
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
            Closing += Search_Closing;
        }

        private void Search_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((ViewModel.SearchVM)this.DataContext).Close();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
           

        }
    }
}
