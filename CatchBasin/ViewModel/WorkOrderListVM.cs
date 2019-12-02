using CatchBasin.ViewModel.Helper;
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
      
            PropertyChanged += SelectedIndexChanged;
        }

	
	

		public void SelectedIndexChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SelectedIndex")
            {
				if (this.SelectedIndex > -1)
				{
					var wo = WorkOrders[this.SelectedIndex];
					showWorkOrder(wo);
				}
               
            }
        }

        public void showWorkOrder(MaximoWorkOrder wo)
        {
			WorkOrders = MaximoServiceLibraryBeanConfiguration.workOrderRepository.findAll().ToList();
			MapVM.ShowWorkOrderDetail(wo);
			
		}

		public void Update()
		{
			WorkOrders = MaximoServiceLibraryBeanConfiguration.workOrderRepository.findAll().ToList();
		}
    }
}
