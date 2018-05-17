using System.Net.Security;
using RWR.Common;
using RWR.FaultContracts;
using RWR.MessageContracts.Issues;
using WCF = System.ServiceModel;

namespace RWR.ServiceContracts.WCF
{
	/// <summary>
	/// Service Contract Class - IssuesContract
	/// </summary>
	[WCF::ServiceContract(Namespace = Constants.SERVER_URL, Name = "IssuesContract", SessionMode = WCF::SessionMode.Allowed, ProtectionLevel = ProtectionLevel.None)]
	public partial interface IIssuesContract
	{
		/// <summary>
		/// Get All Issues (where project = RWR)
		/// </summary>
		/// <param name="request">A GetIssuesRequest object.</param>
		/// <returns>A GetIssuesResponse object</returns>
		[WCF::FaultContract(typeof(UnspecifiedFault), Name = "UnspecifiedFault", Namespace = Constants.SERVER_URL)]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetIssues", ProtectionLevel = ProtectionLevel.None)]
		GetIssuesResponse GetIssues(GetIssuesRequest request);

		/// <summary>
		/// Update Issues.
		/// </summary>
		/// <param name="request">A UpdateIssuesRequest object.</param>
		/// <returns>A UpdateIssuesResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "UpdateIssues", ProtectionLevel = ProtectionLevel.None)]
		UpdateIssuesResponse UpdateIssues(UpdateIssuesRequest request);

		/// <summary>
		/// Get PriorityType Key/Value Pairesponse
		/// </summary>
		/// <returns>A DataSet object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetPriorityTypeCodes", ProtectionLevel = ProtectionLevel.None)]
		GetPriorityTypeCodesResponse GetPriorityTypeCodes(GetPriorityTypeCodesRequest request);

		/// <summary>
		/// Diagnostic Ping
		/// </summary>
		/// <returns>A string that contains the DNS host name of the local computer.</returns>
		[WCF::FaultContract(typeof(UnspecifiedFault), Name = "UnspecifiedFault", Namespace = Constants.SERVER_URL)]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "Ping", ProtectionLevel = ProtectionLevel.None)]
		string Ping();
	}
}
