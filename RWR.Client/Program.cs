using System;
using System.ServiceModel;
using RWR.Common;
using RWR.Client.IssuesServiceWCF;
using RWR.Client.SettingsServiceWCF;

namespace RWR.Client
{
	class Program
	{
		static void Main(string[] args)
		{

			HelloServiceClient p = new HelloServiceClient();
			Console.WriteLine("Hello World says: " + p.sayHi());

			IssuesContractClient wcfIssues = new IssuesContractClient();

			// verify running
			Console.WriteLine("This system name is " + wcfIssues.Ping() + ".");

			GetIssuesRequest rqGetIssues = new GetIssuesRequest();
			// Get Sync
			GetIssuesResponse rsGetIssues = wcfIssues.GetIssues(rqGetIssues);
			Console.WriteLine(rsGetIssues.IssuesCD.Issues.Rows.Count + " row(s) read from IssuesServiceWCF.");
			// Get Async
			IAsyncResult ar = wcfIssues.BeginGetIssues(rqGetIssues, wcf_ClientGetIssuesCompleted, wcfIssues);

			SettingsContractClient wcfSettings = new SettingsContractClient();

			// verify running
			Console.WriteLine("This system name is " + wcfSettings.Ping() + ".");

			GetUserSettingsRequest rqGetUserSettings = new GetUserSettingsRequest();
			rqGetUserSettings.UserName = "Robert";
			//// Get Sync
			GetUserSettingsResponse rsGetUserSettings = wcfSettings.GetUserSettings(rqGetUserSettings);
		}

		private static void wcf_ClientGetIssuesCompleted(IAsyncResult ar)
		{
			GetIssuesResponse rs = ((IssuesContractClient)ar.AsyncState).EndGetIssues(ar);

			object[] results = new object[1];
			results[0] = rs.IssuesCD;

			//this.ClientGetIssuesCompleted(this, new AsyncDataSetCompletedEventArgs(results, null, false, null));
		}

	}
}

