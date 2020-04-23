using CatchBasin.ViewModel;
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

namespace CatchBasin.View.UserControl
{
    /// <summary>
    /// Interaction logic for WorkOrderList.xaml
    /// </summary>
    public partial class WorkOrderList : System.Windows.Controls.UserControl
    {
        public WorkOrderList()
        {
           InitializeComponent();
           
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ((WorkOrderListVM)this.DataContext).PropertyChanged += WorkOrderList_PropertyChanged;
            ((WorkOrderListVM)this.DataContext).listView = listView;
        }

        private void WorkOrderList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if (e.PropertyName == "SelectedIndex")
            //{


            //    if (((WorkOrderListVM)this.DataContext).SelectedIndex > -1)
            //    {
            //        var wo = ((WorkOrderListVM)this.DataContext).WorkOrders[((WorkOrderListVM)this.DataContext).SelectedIndex];
            //        listView.SelectedItem = wo;
            //    }
            //}
        }

        private void ListView_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listView.ScrollIntoView(listView.SelectedItem);
           
        }
    }
}
