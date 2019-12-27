using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LocalDBLibrary;
using LocalDBLibrary.model;
using MaximoServiceLibrary;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;
using AppContext = MaximoServiceLibrary.AppContext;

namespace MaximoServiceTestConsoleApplication
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Task task = new Task(() =>
			{
				Console.WriteLine($" async rnning in thread: {Thread.CurrentThread.ManagedThreadId}");
			});
			task.Start();
			
			Console.WriteLine($" sync rnning in thread: {Thread.CurrentThread.ManagedThreadId}");

			
			IEnumerable<MaximoWorkOrder> maximoWorkOrdersFromDb = AppContext.workOrderRepository.findAll();

			Console.WriteLine($"fetched : {maximoWorkOrdersFromDb.ToList().Count} workorders from db");


			MaximoService maximoService = AppContext.maximoService;
			bool loginResponse = AppContext.maximoService.login("erdem", "password");
			Console.WriteLine($"authenticated : {loginResponse}");

			MaximoUser maximoUser = maximoService.whoami();
			MaximoPersonGroup maximoPersonGroup = maximoService.getPersonGroup(maximoUser.personId);

			List<MaximoWorkOrder> maximoWorkOrders = AppContext.maximoService.getWorkOrders(maximoPersonGroup.persongroup);
			Console.WriteLine($"fetched : {maximoWorkOrders.Count} workorders from Maximo");

			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				MaximoAsset maximoAsset = maximoService.getAssetByAssetnum(maximoWorkOrder.assetnum);
				maximoWorkOrder.asset = maximoAsset;

				List<MaximoDocLinks> workOrderDocLists = maximoService.getWorkOrderDocLinks(maximoWorkOrder);
				maximoWorkOrder.doclink = workOrderDocLists;
				Console.WriteLine($"fetched {workOrderDocLists.Count} doclinks");
			}

		}
	}

}