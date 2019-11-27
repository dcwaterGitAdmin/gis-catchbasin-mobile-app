using MaximoServiceLibrary;
using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Ribbon;

namespace CatchBasin.ViewModel
{
    class WorkOrderListVM : BaseVM
    {


        private List<MaximoWorkOrder> workOrders;

        public List<MaximoWorkOrder> WorkOrders
        {
            get { return workOrders; }
            set { workOrders = value; OnPropertyChanged("WorkOrders"); }
        }

        private int selectedIndex=-1;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; OnPropertyChanged("SelectedIndex"); }
        }

        private MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;

        private MapVM mapVM;

        public MapVM MapVM
        {
            get { return mapVM; }
            set { mapVM = value; }
        }

        public WorkOrderListVM(MapVM mapVM )
        {
            MapVM = mapVM;
            MaximoServiceLibraryBeanConfiguration = new MaximoServiceLibraryBeanConfiguration();
            WorkOrders = MaximoServiceLibraryBeanConfiguration.workOrderRepository.findAll().ToList();
            //List<MaximoWorkOrder> list = new List<MaximoWorkOrder>();
            //var wo = new MaximoWorkOrder();
            //wo.description = "Test";
            //wo.worktype = "PM";
            //wo.wonum = "test";
            //list.Add(wo);
            // wo = new MaximoWorkOrder();
            //wo.worktype = "CM";
            //list.Add(wo);
            // wo = new MaximoWorkOrder();
            //wo.worktype = "EMERG";
            //list.Add(wo);
            // wo = new MaximoWorkOrder();
            //wo.worktype = "INV";
            //list.Add(wo);

            //WorkOrders = list;
            PropertyChanged += SelectedIndexChanged;
        }

        public void SelectedIndexChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedIndex")
            {
                var wo = WorkOrders[this.SelectedIndex];
                createWorkOrderList(wo);
                showWorkOrder(wo);
            }
        }

        public void createWorkOrderList(MaximoWorkOrder wo)
        { 
            List<string> list = new List<string>();
            list.Add("emre");
            list.Add("atlas");
            MapVM.generateCreateWorkOrderList(list);
        }

        public void showWorkOrder(MaximoWorkOrder wo)
        {
            MapVM.ShowWorkOrderDetail(wo);
           // MapVM.ShowAssetDetail(wo);
        }
    }
}
