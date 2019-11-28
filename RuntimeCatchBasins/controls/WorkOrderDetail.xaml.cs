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
    public partial class WorkOrderDetail : System.Windows.Controls.UserControl
    {
        public WorkOrderDetail()
        {
            InitializeComponent();
        }


        public void update(MaximoWorkOrder wo)
        {if (wo != null)
            {
                if (wo.asset != null)
                {
                    Visibility = Visibility.Visible;
                    panel.Children.Clear();
                    foreach (var assetSpec in wo.asset.assetspecList)
                    {

                        panel.Children.Add(new DetailRow(assetSpec));
                    }

                }
                else
                {
                    Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                Visibility = Visibility.Collapsed;
            }
           
          
        }


        public void generateScreen( List<MaximoAssetSpec>  assetSpecs)
        {

            
        }
    }
}
