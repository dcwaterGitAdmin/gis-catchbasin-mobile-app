using System;
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
            
            //list work orders
            
        }
    }
}