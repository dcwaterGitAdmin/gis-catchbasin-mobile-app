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

namespace CatchBasin.View
{
    /// <summary>
    /// Interaction logic for Identify.xaml
    /// </summary>
    public partial class Identify : Window
    {
        public Identify()
        {
            InitializeComponent();
            Closing += Identify_Closing;
        }

        private void Identify_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((ViewModel.IdentifyVM)this.DataContext).Close();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ((ViewModel.IdentifyVM)this.DataContext).setSelectedItem(this.treeview.SelectedItem);
        }
    }
}
