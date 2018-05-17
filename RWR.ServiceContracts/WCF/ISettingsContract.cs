using System.Net.Security;
using RWR.Common;
using RWR.MessageContracts;
using WCF = System.ServiceModel;

namespace RWR.ServiceContracts.WCF
{
	/// <summary>
	/// Service Contract Class - SettingsContract
	/// </summary>
	[WCF::ServiceContract(Namespace = Constants.SERVER_URL, Name = "SettingsContract", SessionMode = WCF::SessionMode.Allowed, ProtectionLevel = ProtectionLevel.None)]
	public partial interface ISettingsContract
	{
		/// <summary>
		/// Get UserSettings by UserName
		/// </summary>
		/// <param name="request">A GetUserSettingsRequest object.</param>
		/// <returns>A GetUserSettingsResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetUserSettings", ProtectionLevel = ProtectionLevel.None)]
		GetUserSettingsResponse GetUserSettings(GetUserSettingsRequest request);

		/// <summary>
		/// Update UserSettings by UserName and GridName
		/// </summary>
		/// <param name="request">A UpdateUserSettingsRequest object.</param>
		/// <returns>A UpdateUserSettingsResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "UpdateUserSettings", ProtectionLevel = ProtectionLevel.None)]
		UpdateUserSettingsResponse UpdateUserSettings(UpdateUserSettingsRequest request);

		/// <summary>
		/// Get FormSettings by UserName and FormName
		/// </summary>
		/// <param name="request">A GetFormSettingsRequest object.</param>
		/// <returns>A GetFormSettingsResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetFormSettings", ProtectionLevel = ProtectionLevel.None)]
		GetFormSettingsResponse GetFormSettings(GetFormSettingsRequest request);

		/// <summary>
		/// Update FormSettings by UserName and FormName
		/// </summary>
		/// <param name="request">A UpdateFormSettingsRequest object.</param>
		/// <returns>A UpdateFormSettingsResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "UpdateFormSettings", ProtectionLevel = ProtectionLevel.None)]
		UpdateFormSettingsResponse UpdateFormSettings(UpdateFormSettingsRequest request);

		/// <summary>
		/// Get GridSettings by UserName and GridName
		/// </summary>
		/// <param name="request">A GetGridSettingsRequest object.</param>
		/// <returns>A GetGridSettingsResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetGridSettings", ProtectionLevel = ProtectionLevel.None)]
		GetGridSettingsResponse GetGridSettings(GetGridSettingsRequest request);

		/// <summary>
		/// Update GridSettings
		/// </summary>
		/// <param name="request">A UpdateGridSettingsRequest object.</param>
		/// <returns>A UpdateGridSettingsResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "UpdateGridSettings", ProtectionLevel = ProtectionLevel.None)]
		UpdateGridSettingsResponse UpdateGridSettings(UpdateGridSettingsRequest request);

		/// <summary>
		/// Replace GridSettings
		/// </summary>
		/// <param name="request">A ReplaceGridSettingsRequest object.</param>
		/// <returns>A ReplaceGridSettingsResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "ReplaceGridSettings", ProtectionLevel = ProtectionLevel.None)]
		ReplaceGridSettingsResponse ReplaceGridSettings(ReplaceGridSettingsRequest request);

		/// <summary>
		/// Get GridFilters by UserName and GridName
		/// </summary>
		/// <param name="request">A GetGridFiltersRequest object.</param>
		/// <returns>A GetGridFiltersResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "GetGridFilters", ProtectionLevel = ProtectionLevel.None)]
		GetGridFiltersResponse GetGridFilters(GetGridFiltersRequest request);

		/// <summary>
		/// Update GridFilters by UserName and GridName
		/// </summary>
		/// <param name="request">A UpdateGridFiltersRequest object.</param>
		/// <returns>A UpdateGridFiltersResponse object</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "UpdateGridFilters", ProtectionLevel = ProtectionLevel.None)]
		UpdateGridFiltersResponse UpdateGridFilters(UpdateGridFiltersRequest request);

		/// <summary>
		/// Diagnostic Ping
		/// </summary>
		/// <returns>A string that contains the DNS host name of the local computer.</returns>
		//[WCF::FaultContract(typeof(RWR.FaultContracts.PartNotFoundFault))]
		[WCF::OperationContract(IsTerminating = false, IsInitiating = true, IsOneWay = false, AsyncPattern = false, Action = "Ping", ProtectionLevel = ProtectionLevel.None)]
		string Ping();
	}
}
