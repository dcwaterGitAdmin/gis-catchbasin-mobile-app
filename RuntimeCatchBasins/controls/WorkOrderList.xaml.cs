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

namespace RuntimeCatchBasins.controls
{
    /// <summary>
    /// Interaction logic for WorkOrderList.xaml
    /// </summary>
    public partial class WorkOrderList : UserControl
    {

       

        public WorkOrderList()
        {
            InitializeComponent();
            IsVisibleChanged += visibleChangedEvent;
          
        }



        void visibleChangedEvent(object sender, DependencyPropertyChangedEventArgs e)
        {
           
            switch (Visibility)
            {
                case System.Windows.Visibility.Visible:

                    listView.ItemsSource = MainWindow.synchronizationService.workOrderRepository.findAll();
                      
                    break;
                case System.Windows.Visibility.Hidden:
                  
                    break;
                case System.Windows.Visibility.Collapsed:
                default:
                  
                    break;

            }
        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //listView.SelectedItem
        }
    }
}
