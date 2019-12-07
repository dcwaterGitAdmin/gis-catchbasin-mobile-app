using System;
using System.Collections.Generic;
using System.Threading;
using LocalDBLibrary;
using MaximoServiceLibrary;
using MaximoServiceLibrary.model;
using MaximoServiceLibrary.repository;

namespace MaximoServiceTestConsoleApplication
{
	public class NewAppTest
	{
		public static void doTest(string[] args)
		{
			MaximoServiceLibraryBeanConfiguration maximoServiceLibraryBeanConfiguration = new MaximoServiceLibraryBeanConfiguration();
			var assets = maximoServiceLibraryBeanConfiguration.assetRepository.findAllToBeScynced();
			foreach (var asset in assets)
			{
				asset.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.SYNCED;
				maximoServiceLibraryBeanConfiguration.assetRepository.upsert(asset);
			}
			foreach (var wo in maximoServiceLibraryBeanConfiguration.workOrderRepository.findAllToBeScynced())
			{
				wo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.SYNCED;
				maximoServiceLibraryBeanConfiguration.workOrderRepository.upsert(wo);
			}


			return;

			
			MaximoService maximoService = maximoServiceLibraryBeanConfiguration.maximoService;
			DbConnection dbConnection = maximoServiceLibraryBeanConfiguration.dbConnection;
			UserRepository userRepository = maximoServiceLibraryBeanConfiguration.userRepository;
			
			//userRepository.removeCollection();

			
			bool isLoggedIn = maximoService.login("edelioglu", "password");
			MaximoUser maximoUser = userRepository.findOneIgnoreCase("EdelIOglu");
			Console.WriteLine($"found user from local DB: {maximoUser.userName}");
			
			Console.WriteLine($"is user Logged in Maximo: {isLoggedIn}");

			maximoUser = maximoService.mxuser;

			Console.WriteLine($"userid: {maximoUser.userName}");
			
			Console.WriteLine($"userid from db: {userRepository.findOne(maximoUser.userName).userName}");

			SynchronizationService synchronizationService = maximoServiceLibraryBeanConfiguration.synchronizationService;

			synchronizationService.startSyncronizationTimer();
			
			//if (maximoService.isOnline)
			//{
			//	synchronizationService.synchronizeWorkOrderCompositeFromMaximoToLocalDb();
			//}

			Console.WriteLine("work order count : " + maximoServiceLibraryBeanConfiguration.workOrderRepository.count());
			Console.WriteLine("asset count : " + maximoServiceLibraryBeanConfiguration.assetRepository.count());

			//synchronizationService.synchronizeHelperFromMaximoToLocalDb();
			
			Console.WriteLine("domain count : " + maximoServiceLibraryBeanConfiguration.domainRepository.count());
			Console.WriteLine("attribute count : " + maximoServiceLibraryBeanConfiguration.attributeRepository.count());

			MaximoWorkOrder woUpdated = maximoServiceLibraryBeanConfiguration.workOrderRepository.findOne("19-661918");
			Console.WriteLine($"wonum : {woUpdated.wonum}, syncStatus: {woUpdated.syncronizationStatus}, actlabcost: {woUpdated.actlabcost}");
			
			woUpdated.actlabcost += 1;
			//maximoServiceLibraryBeanConfiguration.workOrderRepository.update(woUpdated);

			// find again
			woUpdated = maximoServiceLibraryBeanConfiguration.workOrderRepository.findOne("19-661918");
			Console.WriteLine($"wonum : {woUpdated.wonum}, syncStatus: {woUpdated.syncronizationStatus}, actlabcost: {woUpdated.actlabcost}");
			
			//synchronizationService.synchronizeWorkOrderCompositeFromLocalDbToMaximo();

			
			Thread.Sleep(100000);
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