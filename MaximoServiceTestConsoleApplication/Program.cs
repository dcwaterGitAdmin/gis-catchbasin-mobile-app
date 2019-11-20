using System;
using LocalDBLibrary;
using MaximoServiceLibrary;
using MaximoServiceLibrary.model;

namespace MaximoServiceTestConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
//            MaximoService maximoService = new MaximoService();
//
//            bool isLoggedIn = maximoService.login("erdem", "password");
//            Console.WriteLine($"is user Logged in Maximo: {isLoggedIn}");
//            
//            maximoService.whoami();
//            MaximoUser maximoUser = maximoService.mxuser;
//            
//            Console.WriteLine($"userid: {maximoUser.userName}");
//          
            
            MaximoWorkOrder wo = new MaximoWorkOrder();
            wo.wonum = "123123";
            wo.locationdetails = "First AVE";
            MaximoAsset asset = new MaximoAsset();
            asset.assetnum = "234234";
            asset.assetid = 3.14;
            wo.asset = asset;
            WorkOrder.Insert(wo);

            MaximoWorkOrder wo2 = WorkOrder.FindByWoNum("123123");
            Console.WriteLine(wo2.locationdetails);
            
            MaximoWorkOrder wo3 = WorkOrder.FindByAssetAssetNum("234234");
            Console.WriteLine(wo3.asset.assetid);
            //list work orders
            
        }
    }
}



