using System.Runtime.Remoting.Messaging;
using DCWaterMobile.LocalData;
using DCWaterMobile.MaximoService;
using DCWaterMobile.Utilities;

namespace MaximoServiceTestConsoleApplication
{
	public class LegacyAppTest
	{
		public static void doTest()
		{
			string userName = "erdem";
			string password = "password";
				
			MaximoService maximoService = new MaximoService();
			LocalDataService _localDataService = new LocalDataService(maximoService);
			
			var crewInfo = _localDataService.GetCrewInfo(userName, password);
			
			Log.Write(LogLevel.Info, "crewInfo : " + crewInfo.CREWID);
		}
	}
}