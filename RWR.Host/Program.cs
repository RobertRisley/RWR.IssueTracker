using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using RWR.ServiceContracts.WCF;
using RWR.ServiceImplementation.WCF;

namespace RWR.Host
{
	class Program
	{
		static void Main(string[] args)
        {
			Uri baseURI;

			baseURI = new Uri("http://localhost/hello");
			ServiceHost HService = new ServiceHost(typeof(HelloService), baseURI);
			HService.Open();
			Console.WriteLine("Hello Service...");

			baseURI = new Uri("http://localhost/SettingsService");
			ServiceHost SService = new ServiceHost(typeof(SettingsServiceWCF), baseURI);
			SService.Open();
			Console.WriteLine("Settings Service...");

			baseURI = new Uri("http://localhost/IssuesService");
			ServiceHost IService = new ServiceHost(typeof(IssuesServiceWCF), baseURI);
			IService.Open();
			Console.WriteLine("Issues Service...");


            Console.ReadKey();

			IService.Close();
			SService.Close();
            HService.Close();
        }
	}

	[ServiceContract]
	class HelloService
	{
		[OperationContract]
		string sayHi()
		{
			return ("Hello Alexandria!");
		}
	}
}

