using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaximoServiceLibrary.model;

namespace RuntimeCatchBasins.controls
{
    /// <summary>
    /// Interaction logic for WorkOrderDetail.xaml
    /// </summary>
    public partial class WorkOrderDetail : UserControl
    {
        public WorkOrderDetail()
        {
            InitializeComponent();
        }


        public void update(MaximoWorkOrder wo)
        {
            if (wo.asset != null)
            {
                Visibility = Visibility.Visible;
                generateScreen(wo.asset.assetspec);

            }
            else{
                Visibility = Visibility.Collapsed;
            }
          
        }


        public void generateScreen( List<MaximoAssetSpec>  assetSpecs)
        {
            
           
            foreach (var assetSpec in assetSpecs)
            {
                
            }
        }
    }
}
