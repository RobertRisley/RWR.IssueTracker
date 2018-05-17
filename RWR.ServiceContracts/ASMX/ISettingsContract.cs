using System.EnterpriseServices;
using RWR.Common;
using RWR.MessageContracts;
using ASMX = System.Web.Services;

namespace RWR.ServiceContracts.ASMX
{
	/// <summary>
	/// Service Contract Class - SettingsContract
	/// </summary>
	// IMPORTANT: The Namespace parameter of the System.Web.Services.WebService attribute 
	// cannot be used to control the XML Namespace of Web Service interfaces.
	// The attribute must be applied to a class which implements the service contract interface.
	[ASMX::WebService(Name = "SettingsContract")]
	[ASMX::WebServiceBinding(ConformsTo = ASMX::WsiProfiles.BasicProfile1_1, EmitConformanceClaims = true, Name = "SettingsContract")]
	public partial interface ISettingsContract
	{
		/// <summary>
		/// Get UserSettings by UserName
		/// </summary>
		/// <param name="request">A GetUserSettingsRequest object.</param>
		/// <returns>A GetUserSettingsResponse object</returns>
		[ASMX::WebMethod(Description = "Get UserSettings", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/GetUserSettings", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		GetUserSettingsResponse GetUserSettings(GetUserSettingsRequest request);

		/// <summary>
		/// Update UserSettings
		/// </summary>
		/// <param name="request">The UpdateUserSettingsRequest object.</param>
		/// <returns>A UpdateUserSettingsResponse object</returns>
		[ASMX::WebMethod(Description = "Update UserSettings", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/UpdateUserSettings", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		UpdateUserSettingsResponse UpdateUserSettings(UpdateUserSettingsRequest request);

		/// <summary>
		/// Get FormSettings by UserName and FormName
		/// </summary>
		/// <param name="request">A GetFormSettingsRequest object.</param>
		/// <returns>A GetFormSettingsResponse object</returns>
		[ASMX::WebMethod(Description = "Get FormSettings", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/GetFormSettings", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		GetFormSettingsResponse GetFormSettings(GetFormSettingsRequest request);

		/// <summary>
		/// Update FormSettings
		/// </summary>
		/// <param name="request">The UpdateFormSettingsRequest object.</param>
		/// <returns>A UpdateFormSettingsResponse object</returns>
		[ASMX::WebMethod(Description = "Update FormSettings", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/UpdateFormSettings", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		UpdateFormSettingsResponse UpdateFormSettings(UpdateFormSettingsRequest request);

		/// <summary>
		/// Get GridSettings by UserName and GridName
		/// </summary>
		/// <param name="request">A GetGridSettingsRequest object.</param>
		/// <returns>A GetGridSettingsResponse object</returns>
		[ASMX::WebMethod(Description = "Get GridSettings", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/GetGridSettings", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		GetGridSettingsResponse GetGridSettings(GetGridSettingsRequest request);

		/// <summary>
		/// Update GridSettings
		/// </summary>
		/// <param name="request">The UpdateGridSettingsRequest object.</param>
		/// <returns>A UpdateGridSettingsResponse object</returns>
		[ASMX::WebMethod(Description = "Update GridSettings", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/UpdateGridSettings", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		UpdateGridSettingsResponse UpdateGridSettings(UpdateGridSettingsRequest request);

		/// <summary>
		/// Replace GridSettings
		/// </summary>
		/// <param name="request">The ReplaceGridSettingsRequest object.</param>
		/// <returns>A ReplaceGridSettingsResponse object</returns>
		[ASMX::WebMethod(Description = "Replace GridSettings", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/ReplaceGridSettings", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		ReplaceGridSettingsResponse ReplaceGridSettings(ReplaceGridSettingsRequest request);

		/// <summary>
		/// Get GridFilters by UserName and GridName
		/// </summary>
		/// <param name="request">A GetGridFiltersRequest object.</param>
		/// <returns>A GetGridFiltersResponse object</returns>
		[ASMX::WebMethod(Description = "Get GridFilters", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/GetGridFilters", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		GetGridFiltersResponse GetGridFilters(GetGridFiltersRequest request);

		/// <summary>
		/// Update GridFilters
		/// </summary>
		/// <param name="request">The UpdateGridFiltersRequest object.</param>
		/// <returns>A UpdateGridFiltersResponse object</returns>
		[ASMX::WebMethod(Description = "Update GridFilters", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/UpdateGridFilters", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		UpdateGridFiltersResponse UpdateGridFilters(UpdateGridFiltersRequest request);

		/// <summary>
		/// Diagnostic Ping
		/// </summary>
		/// <returns>A string that contains the DNS host name of the local computer.</returns>
		[ASMX::WebMethod(Description = "Ping", EnableSession = false, TransactionOption = TransactionOption.Disabled)]
		[ASMX::Protocols.SoapDocumentMethod(Action = Constants.SERVER_URL + "/Ping", ParameterStyle = ASMX::Protocols.SoapParameterStyle.Wrapped)]
		string Ping();
	}
}
