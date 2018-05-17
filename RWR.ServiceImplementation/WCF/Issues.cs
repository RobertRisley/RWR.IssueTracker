using System.Data;
using RWR.Common;
using RWR.FaultContracts;
using RWR.IssueTracker.DSBO;
using RWR.MessageContracts.Issues;
using WCF = System.ServiceModel;

namespace RWR.ServiceImplementation.WCF
{
	/// <summary>
	/// Service Class - Issues
	/// </summary>
	[WCF::ServiceBehavior( Name = "IssuesServiceWCF", Namespace = Constants.SERVER_URL,
		InstanceContextMode = WCF::InstanceContextMode.PerSession,
		ConcurrencyMode = WCF::ConcurrencyMode.Single )]
	public partial class IssuesServiceWCF : RWR.ServiceContracts.WCF.IIssuesContract
	{
		/// <summary>
		/// Get All Issues (where project = RWR)
		/// </summary>
		/// <param name="request">A GetIssuesRequest object.</param>
		/// <returns>A GetIssuesResponse object</returns>
		public GetIssuesResponse GetIssues(GetIssuesRequest request)
		{
			GetIssuesResponse response = new GetIssuesResponse();
			response.IssuesCD = IssuesCD.GetIssues();

			return response;
		}

		/// <summary>
		/// Update Issues.
		/// </summary>
		/// <param name="request">A UpdateIssuesRequest object.</param>
		/// <returns>A UpdateIssuesResponse object</returns>
		public UpdateIssuesResponse UpdateIssues(UpdateIssuesRequest request)
		{
			UpdateIssuesResponse response = new UpdateIssuesResponse();

			if (request.IssuesCD.Issues == null || request.IssuesCD.Issues.Rows.Count == 0)
			{
				response.IssuesCD = request.IssuesCD;
			}
			else
			{
				response.IssuesCD = IssuesCD.UpdateIssues(request.IssuesCD);
			}

			return response;
		}

		/// <summary>
		/// Get PriorityType Key/Value Pairesponse
		/// </summary>
		/// <returns>A DataSet object</returns>
		public GetPriorityTypeCodesResponse GetPriorityTypeCodes(GetPriorityTypeCodesRequest request)
		{
			GetPriorityTypeCodesResponse response = new GetPriorityTypeCodesResponse();
			response.CodesCD = CodesCD.GetPriorityTypeCodes();

			return response;
		}

		/// <summary>
		/// Diagnostic Ping
		/// </summary>
		/// <returns>A string that contains the DNS host name of the local computer.</returns>
		public string Ping()
		{
            //for some kind of test ??
			//UnspecifiedFault uf = new UnspecifiedFault();
			//throw new WCF::FaultException<UnspecifiedFault>(uf);
			return System.Net.Dns.GetHostName();
		}
	}
}