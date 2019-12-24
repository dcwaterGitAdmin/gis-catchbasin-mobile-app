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


		private Command.FlashCommand flashCommand;

		public Command.FlashCommand FlashCommand
		{
			get { return flashCommand; }
			set { flashCommand = value; OnPropertyChanged("FlashCommand"); }
		}

		private Command.ZoomToCommand zoomToCommand;

		public Command.ZoomToCommand ZoomToCommand
		{
			get { return zoomToCommand; }
			set { zoomToCommand = value; OnPropertyChanged("ZoomToCommand"); }
		}

		private Command.PanToCommand panToCommand;

		public Command.PanToCommand PanToCommand
		{
			get { return panToCommand; }
			set { panToCommand = value; OnPropertyChanged("PanToCommand"); }
		}

        private Command.DeleteLocalWoCommand deleteLocalWoCommand;

        public Command.DeleteLocalWoCommand DeleteLocalWoCommand
        {
            get { return deleteLocalWoCommand; }
            set { deleteLocalWoCommand = value; OnPropertyChanged("DeleteLocalWoCommand"); }
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



		
		public WorkOrderListVM(MapVM mapVM )
        {
            MapVM = mapVM;
			StartStopTimerCommand = new Command.StartStopTimerCommand(this);
			ZoomToCommand = new Command.ZoomToCommand(MapVM);
			PanToCommand = new Command.PanToCommand(MapVM);
			FlashCommand = new Command.FlashCommand(MapVM);
            DeleteLocalWoCommand = new Command.DeleteLocalWoCommand(MapVM);
            FilterList = new List<FilterDomain>();
			FilterList.Add(new FilterDomain("Work Assigned to My Crew", FilterType.ALLDISPTCHD));
			FilterList.Add(new FilterDomain("Closed Workorder", FilterType.NODISPTCHD));
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
                    if (MapVM.WorkOrderDetailIsVisible)
                    {
                        if (!(wo?.Id == MapVM.WorkOrderDetailVM?.MaximoWorkOrder?.Id)) {
                            showWorkOrder(wo);
                        }
                    }
                    else
                    {
                        showWorkOrder(wo);
                    }
                   


                }
                else
                {
                    if (MapVM.WorkOrderDetailIsVisible)
                    {
                        var index = WorkOrders.Select(wo => wo.Id).ToList().IndexOf(MapVM.WorkOrderDetailVM.MaximoWorkOrder.Id);
                        if (index >= 0)
                        {
                            SelectedIndex = index;
                        }
                    }
                }
               
            }else if (e.PropertyName == "Filter" || e.PropertyName == "Order")
            {
	            Update();
            }
        }

        public void showWorkOrder(MaximoWorkOrder wo)
        {
			
			MapVM.ShowWorkOrderDetail(wo);
			
		}

		public void Update()
		{

			IEnumerable<MaximoWorkOrder> wos;

			wos = MaximoServiceLibrary.AppContext.workOrderRepository.findAll();

		
			if (((App)Application.Current).AppType == "PM")
			{

				wos = wos.Where(wo => wo.persongroup == MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences.selectedPersonGroup || wo.persongroup == "CB00");
				wos = wos.Where(wo => wo.worktype == "EMERG" || wo.worktype == "INV" || wo.worktype == "PM" || wo.worktype == "CM");

				switch (Filter)
				{
					case FilterType.PMDISPTCHD:
						wos = wos.Where(wo => wo.worktype == "PM" && wo.status == "DISPTCHD");
						break;
					case FilterType.NOPMDISPTCHD:
						wos = wos.Where(wo => (wo.worktype == "EMERG" || wo.worktype == "INV")  && wo.status == "DISPTCHD");
						break;
					case FilterType.EMERGDISPTCHD:
						wos = wos.Where(wo => wo.worktype == "EMERG" && wo.status == "DISPTCHD");
						break;
					case FilterType.NODISPTCHD:
						wos = wos.Where(wo =>  wo.status != "DISPTCHD");
						break;
					default:
						wos = wos.Where(wo => wo.status == "DISPTCHD");
						break;

				}
			
			}
			else
			{
				wos = wos.Where(wo => wo.persongroup == MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences.selectedPersonGroup || wo.persongroup == "CB00");
				wos = wos.Where(wo => wo.worktype == "INSP");

				switch (Filter)
				{
					case FilterType.NODISPTCHD:
						wos = wos.Where(wo => wo.status != "DISPTCHD");
						break;
				}
			}

			switch (Order)
			{
				case OrderType.SCHEDSTART:
					wos = wos.OrderBy(wo => getOrderValue(wo.worktype)).ThenBy(wo => wo.schedstart);
					break;
				case OrderType.STATUS:
					wos = wos.OrderBy(wo => wo.status);
					break;
				case OrderType.WORKTYPE:
					wos = wos.OrderBy(wo => getOrderValue(wo.worktype));
					break;
			}

          

            WorkOrders = wos.ToList();

            SelectedIndex = -1;
            if (MapVM.WorkOrderDetailIsVisible)
            {
                var index =WorkOrders.Select(wo=> wo.Id).ToList().IndexOf(MapVM.WorkOrderDetailVM.MaximoWorkOrder.Id);
                if (index >= 0)
                {
                  
                    SelectedIndex = index;
                    
                }
            }
		}

        public int getOrderValue(string worktype)
        {
            if(worktype == "CM")
            {
                return 3;
            } else if(worktype == "PM")
            {
                return 4;
            }
            else if (worktype == "INV")
            {
                return 2;
            }
            else if (worktype == "EMERG")
            {
                return 1;
            }
            else if (worktype == "INSP")
            {
                return 5;
            }
            else
            {
                return 6;
            }
        }
    }
}
