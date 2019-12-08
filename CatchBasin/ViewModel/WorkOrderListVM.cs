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

		private Command.StartStopTimerCommand startStopTimerCommand;

		public Command.StartStopTimerCommand StartStopTimerCommand
		{
			get { return startStopTimerCommand; }
			set { startStopTimerCommand = value; OnPropertyChanged("StartStopTimerCommand"); }
		}

		private List<OrderDomain> orderList;

		public List<OrderDomain> OrderList
		{
			get { return orderList; }
			set
			{
				orderList = value;
				OnPropertyChanged("OrderList");
			}
		}

		private OrderType order;

		public OrderType Order
		{
			get { return order; }
			set
			{
				order = value;
				OnPropertyChanged("Order");
			}
		}

		private List<FilterDomain> filterList;

		public List<FilterDomain> FilterList
		{
			get { return filterList; }
			set
			{
				filterList = value;
				OnPropertyChanged("FilterList");
			}
		}

		private FilterType filter;

		public FilterType Filter
		{
			get { return filter; }
			set
			{
				filter = value;
				OnPropertyChanged("Filter");
			}
		}

		private MapVM mapVM;

        public MapVM MapVM
        {
            get { return mapVM; }
            set { mapVM = value; }
        }


		private MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;
		public WorkOrderListVM(MapVM mapVM )
        {
            MapVM = mapVM;
			MaximoServiceLibraryBeanConfiguration = ((App)Application.Current).MaximoServiceLibraryBeanConfiguration;
			StartStopTimerCommand = new Command.StartStopTimerCommand(this);

			FilterList = new List<FilterDomain>();
			FilterList.Add(new FilterDomain("Work Assigned to My Crew", FilterType.ALLDISPTCHD));
			FilterList.Add(new FilterDomain("Non Dispatched", FilterType.NODISPTCHD));
			if (((App) Application.Current).AppType == "PM")
			{
				
				FilterList.Add(new FilterDomain("PM Work", FilterType.PMDISPTCHD));
				FilterList.Add(new FilterDomain("Emergency Work", FilterType.EMERGDISPTCHD));
				FilterList.Add(new FilterDomain("Non PM Work", FilterType.NOPMDISPTCHD));
			}
			
			OrderList = new List<OrderDomain>();
			OrderList.Add(new OrderDomain("Scheduled Start",OrderType.SCHEDSTART));
			OrderList.Add(new OrderDomain("Status",OrderType.STATUS));
			OrderList.Add(new OrderDomain("Work Type",OrderType.WORKTYPE));
			Order = OrderType.SCHEDSTART;
			Filter = FilterType.ALLDISPTCHD;
			
			
			Update();
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
               
            }else if (e.PropertyName == "Filter" || e.PropertyName == "Order")
            {
	            Update();
            }
        }

        public void showWorkOrder(MaximoWorkOrder wo)
        {
			Update();
			MapVM.ShowWorkOrderDetail(wo);
			
		}

		public void Update()
		{
			IEnumerable<MaximoWorkOrder> wos;
			if (Filter == FilterType.NODISPTCHD)
			{
				wos = MaximoServiceLibraryBeanConfiguration.workOrderRepository.findNot("status", "DISPTCHD");
			}
			else
			{
				wos = MaximoServiceLibraryBeanConfiguration.workOrderRepository.Find("status", "DISPTCHD");
			}
			


			if (((App)Application.Current).AppType == "PM")
			{
				wos = wos.Where(wo => wo.worktype == "EMERG" || wo.worktype == "INV" || wo.worktype == "PM" || wo.worktype == "CM");
				var t = wos.ToList();
				var mxuser = MaximoServiceLibraryBeanConfiguration.userRepository.findOneIgnoreCase(MaximoServiceLibraryBeanConfiguration
					.maximoService.mxuser.userName);
				wos = wos.Where(wo => wo.persongroup == (mxuser.userPreferences.selectedPersonGroup ?? mxuser.personGroupList?[0].persongroup) || wo.persongroup == "CB00");

				switch (Filter)
				{
					case FilterType.PMDISPTCHD:
						wos = wos.Where(wo => wo.worktype == "PM");
						break;
					case FilterType.NOPMDISPTCHD:
						wos = wos.Where(wo => wo.worktype == "EMERG" || wo.worktype == "INV");
						break;
					case FilterType.EMERGDISPTCHD:
						wos = wos.Where(wo => wo.worktype == "EMERG");
						break;
				}
			
			}
			else
			{
				 wos = wos.Where(wo => wo.worktype == "INSP");

			}

			switch (Order)
			{
				case OrderType.SCHEDSTART:
					wos = wos.OrderBy(wo => wo.schedstart);
					break;
				case OrderType.STATUS:
					wos = wos.OrderBy(wo => wo.status);
					break;
				case OrderType.WORKTYPE:
					wos = wos.OrderBy(wo => wo.worktype);
					break;
			}

			WorkOrders = wos.ToList();
		}
    }
}
