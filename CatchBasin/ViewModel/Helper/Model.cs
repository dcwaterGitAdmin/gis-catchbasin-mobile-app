using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchBasin.ViewModel.Helper
{
	class StaticDomain
	{
		public StaticDomain(string _code, string _desc)
		{
			code = _code;
			description = _desc;
		}
		public string code { get; set; }
		public string description { get; set; }
	}


	class FilterDomain
	{
		public FilterDomain(string _label, FilterType _filterType)
		{
			FilterType = _filterType;
			Label = _label;
		}
		public FilterType FilterType { get; set; }
		public string Label { get; set; }
	}

	class OrderDomain
	
	{

		public OrderDomain(string _label, OrderType _orderType)
		{
			OrderType = _orderType;
			Label = _label;
		}
		public OrderType OrderType { get; set; }
		public string Label { get; set; }
	}

	enum FilterType{
		ALLDISPTCHD,
		PMDISPTCHD,
		EMERGDISPTCHD,
		NOPMDISPTCHD,
		NODISPTCHD

	}
	
	enum OrderType
	{
		SCHEDSTART,
		STATUS,
		WORKTYPE
	}

	enum LocalWorkOrderType
	{
		TRUCKDUMPING,
		NEWLYDISCOVERED,
		EXISTING,
		NOTININVENTORY,
		INSPECTNEWLYDISCOVERED
	}


}
