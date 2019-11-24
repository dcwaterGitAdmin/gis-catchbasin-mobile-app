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
			MaximoServiceLibraryBeanConfiguration maximoServiceLibraryBeanConfiguration = new MaximoServiceLibraryBeanConfiguration();
			
			MaximoService maximoService = maximoServiceLibraryBeanConfiguration.maximoService;
			DbConnection dbConnection = maximoServiceLibraryBeanConfiguration.dbConnection;

			
			bool isLoggedIn = maximoService.login("erdem", "password");
			Console.WriteLine($"is user Logged in Maximo: {isLoggedIn}");

			maximoService.whoami();
			MaximoUser maximoUser = maximoService.mxuser;

			Console.WriteLine($"userid: {maximoUser.userName}");

			SynchronizationService synchronizationService = maximoServiceLibraryBeanConfiguration.synchronizationService;
			
			//synchronizationService.synchronizeWorkOrderCompositeFromMaximoToLocalDb();

			Console.WriteLine("work order count : " + maximoServiceLibraryBeanConfiguration.workOrderRepository.count());
			Console.WriteLine("asset count : " + maximoServiceLibraryBeanConfiguration.assetRepository.count());

			//synchronizationService.synchronizeHelperFromMaximoToLocalDb();
			
			Console.WriteLine("domain count : " + maximoServiceLibraryBeanConfiguration.domainRepository.count());
			Console.WriteLine("attribute count : " + maximoServiceLibraryBeanConfiguration.attributeRepository.count());
			
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

//			foreach (var domain in synchronizationService.domainRepository.findAll())
//            {
//                Console.WriteLine(domain.domaintype);
//            }
//            Console.ReadKey();
//
//			foreach (var assetSpec in synchronizationService.assetRepository.findOne("442605").assetspec)
//			{
//				var attribute = synchronizationService.attributeRepository.findOne(assetSpec.assetattrid);
//				if (attribute == null) continue;
//				Console.WriteLine("Attribute : " +attribute.description);
//				if (attribute.domainid != null)
//				{
//					var domain = synchronizationService.domainRepository.findOne(attribute.domainid);
//					Console.WriteLine("Domain  : " +domain.description);
//				}
//				else
//				{
//					Console.WriteLine("DataType  : " +attribute.datatype);
//				}
//
//			}

			MaximoWorkOrder woUpdated = maximoServiceLibraryBeanConfiguration.workOrderRepository.findOne("19-661918");
			Console.WriteLine($"wonum : {woUpdated.wonum}, edited: {woUpdated.editedFromApp}, actlabcost: {woUpdated.actlabcost}");
			
			woUpdated.actlabcost += 1;
			maximoServiceLibraryBeanConfiguration.workOrderRepository.update(woUpdated);

			// find again
			woUpdated = maximoServiceLibraryBeanConfiguration.workOrderRepository.findOne("19-661918");
			Console.WriteLine($"wonum : {woUpdated.wonum}, edited: {woUpdated.editedFromApp}, actlabcost: {woUpdated.actlabcost}");
			
			synchronizationService.synchronizeWorkOrderCompositeFromLocalDbToMaximo();

			

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