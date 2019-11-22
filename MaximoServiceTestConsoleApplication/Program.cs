using System;
using System.Collections.Generic;
using LocalDBLibrary;
using MaximoServiceLibrary;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;

namespace MaximoServiceTestConsoleApplication
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			MaximoService maximoService = new MaximoService();
			DbConnection dbConnection = new DbConnection();

			
			bool isLoggedIn = maximoService.login("erdem", "password");
			Console.WriteLine($"is user Logged in Maximo: {isLoggedIn}");

			maximoService.whoami();
			MaximoUser maximoUser = maximoService.mxuser;

			Console.WriteLine($"userid: {maximoUser.userName}");

			SynchronizationService synchronizationService = new SynchronizationService(maximoService, dbConnection);
			
			//synchronizationService.synchronizeWorkOrderCompositeFromMaximoToLocalDb();

			Console.WriteLine("work order count : " + synchronizationService.workOrderRepository.count());
			Console.WriteLine("asset count : " + synchronizationService.assetRepository.count());

			//synchronizationService.synchronizeHelperFromMaximoToLocalDb();
			
			Console.WriteLine("domain count : " + synchronizationService.domainRepository.count());
			Console.WriteLine("attribute count : " + synchronizationService.attributeRepository.count());


<<<<<<< HEAD
			//foreach (var assetSpec in synchronizationService.assetRepository.findOne("442605").assetspec)
			//{
			//	var attribute = synchronizationService.attributeRepository.findOne(assetSpec.assetattrid);
			//	if (attribute == null) continue;
			//	Console.WriteLine("Attribute : " +attribute.description);
			//	if (attribute.domainid != null)
			//	{
			//		var domain = synchronizationService.domainRepository.findOne(attribute.domainid);
			//		Console.WriteLine("Domain  : " +domain.description);
			//	}
			//	else
			//	{
			//		Console.WriteLine("DataType  : " +attribute.datatype);
			//	}

			//}

			foreach (var domain in synchronizationService.domainRepository.findAll())
            {
                Console.WriteLine(domain.domaintype);
            }
            Console.ReadKey();
=======
			foreach (var assetSpec in synchronizationService.assetRepository.findOne("442605").assetspec)
			{
				var attribute = synchronizationService.attributeRepository.findOne(assetSpec.assetattrid);
				if (attribute == null) continue;
				Console.WriteLine("Attribute : " +attribute.description);
				if (attribute.domainid != null)
				{
					var domain = synchronizationService.domainRepository.findOne(attribute.domainid);
					Console.WriteLine("Domain  : " +domain.description);
				}
				else
				{
					Console.WriteLine("DataType  : " +attribute.datatype);
				}

			}

			MaximoWorkOrder woUpdated = synchronizationService.workOrderRepository.findOne("19-661918");
			Console.WriteLine($"wonum : {woUpdated.wonum}, edited: {woUpdated.editedFromApp}, actlabcost: {woUpdated.actlabcost}");
			
			woUpdated.actlabcost += 1;
			synchronizationService.workOrderRepository.update(woUpdated);

			// find again
			woUpdated = synchronizationService.workOrderRepository.findOne("19-661918");
			Console.WriteLine($"wonum : {woUpdated.wonum}, edited: {woUpdated.editedFromApp}, actlabcost: {woUpdated.actlabcost}");
			
			synchronizationService.synchronizeWorkOrderCompositeFromLocalDbToMaximo();

			
				

>>>>>>> 6c40b74af5bae52d58d5e6f4661a5160e88739cf

			/*
			List<MaximoWorkOrder> workOrders = maximoService.getWorkOrders();
			Console.WriteLine(workOrders[0].wonum);

			

			MaximoWorkOrder wo = new MaximoWorkOrder();
			wo.wonum = "123124";
			wo.assetnum = "1111";
			//wo.locationdetails = "First AVE";
*/

			/*
			MaximoAsset asset = new MaximoAsset();
			asset.assetnum = "234234";
			asset.assetid = 314;
			//wo.asset = asset;
			*/

			//WorkOrder.Insert(wo);

			/*
			WorkOrderRepository workOrderRepository = new WorkOrderRepository(dbConnection);
			//workOrderRepository.removeCollection();
			
			workOrderRepository.upsert(wo);
			
			Console.WriteLine(workOrderRepository.count());
			IEnumerable<MaximoWorkOrder> maximoWorkOrders = workOrderRepository.findAll();
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				Console.WriteLine(maximoWorkOrder.wonum + " - " + maximoWorkOrder.assetnum);
			}

			MaximoWorkOrder woQueried = workOrderRepository.findOne("123123");
			Console.WriteLine(woQueried.wonum + " - " + woQueried.assetnum);
			*/

			/*
			MaximoWorkOrder wo2 = WorkOrder.FindByWoNum("123123");
			Console.WriteLine(wo2.locationdetails);
			
			MaximoWorkOrder wo3 = WorkOrder.FindByAssetAssetNum("234234");
			Console.WriteLine(wo3.asset.assetid);
			//list work orders
			*/
		}
	}

}