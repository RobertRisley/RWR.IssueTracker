using System.EnterpriseServices;
using RWR.Common;
using RWR.MessageContracts.Issues;
using ASMX = System.Web.Services;

namespace RWR.ServiceContracts.ASMX
{
	/// <summary>
	/// Service Contract Class - IssuesContract
	/// </summary>
	// IMPORTANT: The Namespace parameter of the System.Web.Services.WebService attribute 
	// cannot be used to control the XML Namespace of Web Service interfaces.
	// The attribute must be applied to a class which implements the service contract interface.
	[ASMX::WebService(Name = "IssuesContract")]
	[ASMX::WebServiceBinding(ConformsTo = ASMX::WsiProfiles.BasicProfile1_1, EmitConformanceClaims = true, Name = "IssuesContract")]
	public partial interface IIssuesContract
	{
		/// <summary>
		/// Get All Issues (where project = RWR)
		/// </summary>
		/// <param name="request">A GetIssuesRequest object.</param>
		/// <returns>A GetIssuesResponse object</returns>
		[ASMX::WebMethod(Description = "Get Issues", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/GetIssues", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		GetIssuesResponse GetIssues(GetIssuesRequest request);

		/// <summary>
		/// Update Issues.
		/// </summary>
		/// <param name="request">A UpdateIssuesRequest object.</param>
		/// <returns>A UpdateIssuesResponse object</returns>
		[ASMX::WebMethod(Description = "Update Issues", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/UpdateIssues", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		UpdateIssuesResponse UpdateIssues(UpdateIssuesRequest request);

		/// <summary>
		/// Get PriorityType Key/Value Pairesponse
		/// </summary>
		/// <returns>A DataSet object</returns>
		[ASMX::WebMethod(Description = "Get Priority Type Codes", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/GetPriorityTypeCodes", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		GetPriorityTypeCodesResponse GetPriorityTypeCodes(GetPriorityTypeCodesRequest request);

		/// <summary>
		/// Diagnostic Ping
		/// </summary>
		/// <returns>A string that contains the DNS host name of the local computer.</returns>
		[ASMX::WebMethod(Description = "Ping", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/Ping", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		string Ping();
	}
}
