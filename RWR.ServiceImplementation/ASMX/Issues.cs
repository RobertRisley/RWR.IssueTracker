using RWR.Common;
using RWR.IssueTracker.DSBO;
using RWR.MessageContracts.Issues;
using ASMX = System.Web.Services;

namespace RWR.ServiceImplementation.ASMX
{
	/// <summary>
	/// Service Class - Issues
	/// </summary>
	[ASMX::WebService( Name = "IssuesServiceASMX", Namespace = Constants.SERVER_URL, Description = "Manages the Issue Tracker Data")]
	[ASMX::WebServiceBinding( Name = "IssuesServiceASMX", ConformsTo = ASMX::WsiProfiles.BasicProfile1_1, EmitConformanceClaims = true)]
	[System.Web.Script.Services.ScriptService] // Allows this Web Service to be called from script, using ASP.NET AJAX
	public partial class IssuesServiceASMX : System.Web.Services.WebService, RWR.ServiceContracts.ASMX.IIssuesContract
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
			return System.Net.Dns.GetHostName();
		}
	}
}