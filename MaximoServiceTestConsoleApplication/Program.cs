using System;
using System.Collections.Generic;
using System.Threading;
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
			LegacyAppTest.doTest();
			
			//NewAppTest.doTest();
		}
	}

}