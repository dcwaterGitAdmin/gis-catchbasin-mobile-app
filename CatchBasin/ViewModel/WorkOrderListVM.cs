using MaximoServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchBasin.ViewModel
{
    class WorkOrderListVM : BaseVM
    {
        private List<MaximoServiceLibrary.model.MaximoWorkOrder> workOrders;

        public List<MaximoServiceLibrary.model.MaximoWorkOrder> WorkOrders
        {
            get { return workOrders; }
            set { workOrders = value; }
        }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }

        private MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;

        public WorkOrderListVM()
        {
            MaximoServiceLibraryBeanConfiguration = new MaximoServiceLibraryBeanConfiguration();
            WorkOrders = MaximoServiceLibraryBeanConfiguration.workOrderRepository.findAll().ToList();
        }


    }
}
