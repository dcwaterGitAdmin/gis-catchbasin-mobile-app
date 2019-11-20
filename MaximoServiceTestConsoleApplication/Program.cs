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
            MaximoService maximoService = new MaximoService();

            bool isLoggedIn = maximoService.login("erdem", "password");
            Console.WriteLine($"is user Logged in Maximo: {isLoggedIn}");
            
            maximoService.whoami();
            MaximoUser maximoUser = maximoService.mxuser;
            
            Console.WriteLine($"userid: {maximoUser.userName}");
          
            
            MaximoWorkOrder wo = new MaximoWorkOrder();
            wo.wonum = "123123";
            wo.locationdetails = "First AVE";

            WorkOrder.Insert(wo);

            MaximoWorkOrder wo2 = WorkOrder.FindByWoNum("123123");
            Console.WriteLine(wo2.locationdetails);
            //list work orders

        }
    }
}