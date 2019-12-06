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

	enum LocalWorkOrderType
	{
		TRUCKDUMPING,
		NEWLYDISCOVERED,
		EXISTING,
		NOTININVENTORY,
		INSPECTNEWLYDISCOVERED
	}


}
