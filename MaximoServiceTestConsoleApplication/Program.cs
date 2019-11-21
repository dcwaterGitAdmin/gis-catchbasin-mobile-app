using System;
using System.Collections.Generic;
using LocalDBLibrary;
using MaximoServiceLibrary;
using MaximoServiceLibrary.model;

namespace MaximoServiceTestConsoleApplication
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			MaximoService maximoService = new MaximoService();

			bool isLoggedIn = maximoService.login("erdem", "password");
			Console.WriteLine($"is user Logged in Maximo: {isLoggedIn}");

			maximoService.whoami();
			MaximoUser maximoUser = maximoService.mxuser;

			Console.WriteLine($"userid: {maximoUser.userName}");

			List<MaximoWorkOrder> workOrders = maximoService.getWorkOrders();
			Console.WriteLine(workOrders[0].wonum);

			DbConnection dbConnection = new DbConnection();
			

			MaximoWorkOrder wo = new MaximoWorkOrder();
			wo.wonum = "123123";
			wo.assetnum = "1111";
			//wo.locationdetails = "First AVE";
			
			/*
			MaximoAsset asset = new MaximoAsset();
			asset.assetnum = "234234";
			asset.assetid = 314;
			//wo.asset = asset;
			*/
			
			//WorkOrder.Insert(wo);

			WorkOrderRepository workOrderRepository = new WorkOrderRepository(dbConnection);
			workOrderRepository.removeCollection();
			
			workOrderRepository.upsert(wo.wonum, wo);
			
			Console.WriteLine(workOrderRepository.count());
			IEnumerable<MaximoWorkOrder> maximoWorkOrders = workOrderRepository.findAll();
			foreach (var maximoWorkOrder in maximoWorkOrders)
			{
				Console.WriteLine(maximoWorkOrder.wonum + " - " + maximoWorkOrder.assetnum);
			}

			//MaximoWorkOrder woQueried = workOrderRepository.findOne(wo.wonum);
			//Console.WriteLine(woQueried.wonum + " - " + woQueried.assetnum);

			/*
			MaximoWorkOrder wo2 = WorkOrder.FindByWoNum("123123");
			Console.WriteLine(wo2.locationdetails);
			
			MaximoWorkOrder wo3 = WorkOrder.FindByAssetAssetNum("234234");
			Console.WriteLine(wo3.asset.assetid);
			//list work orders
			*/
		}
	}

	public class WorkOrderRepository : DbReposistory<String, MaximoWorkOrder>
	{
		public WorkOrderRepository(DbConnection dbConnection) : base(dbConnection)
		{
		}

		public override string tableName()
		{
			return "workorders2";
		}
	}
}