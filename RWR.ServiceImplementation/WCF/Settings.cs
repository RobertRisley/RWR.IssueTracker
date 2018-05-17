using System;
using System.Data;
using System.Text;
using RWR.Common;
using RWR.Windows.Components.DSBO;
using RWR.MessageContracts;
using WCF = System.ServiceModel;

namespace RWR.ServiceImplementation.WCF
{
	/// <summary>
	/// Service Class - Settings
	/// </summary>
	[WCF::ServiceBehavior( Name = "SettingsServiceWCF", Namespace = Constants.SERVER_URL,
		InstanceContextMode = WCF::InstanceContextMode.PerSession,
		ConcurrencyMode = WCF::ConcurrencyMode.Single )]
	public partial class SettingsServiceWCF : RWR.ServiceContracts.WCF.ISettingsContract
	{
		/// <summary>
		/// Get UserSettings by UserName
		/// </summary>
		/// <param name="request">A GetUserSettingsRequest object.</param>
		/// <returns>A GetUserSettingsResponse object</returns>
		public GetUserSettingsResponse GetUserSettings(GetUserSettingsRequest request)
		{
			GetUserSettingsResponse response = new GetUserSettingsResponse();
			response.UserSettingsCD = UserSettingsCD.GetUserSettings(request.UserName);

			return response;
		}

		/// <summary>
		/// Update UserSettings by UserName
		/// </summary>
		/// <param name="request">A UpdateUserSettingsRequest object.</param>
		/// <returns>A UpdateUserSettingsResponse object</returns>
		public UpdateUserSettingsResponse UpdateUserSettings(UpdateUserSettingsRequest request)
		{
			UpdateUserSettingsResponse response = new UpdateUserSettingsResponse();
			response.UserSettingsCD = UserSettingsCD.UpdateUserSettings(request.UserSettingsCD);

			return response;
		}

		/// <summary>
		/// Get FormSettings by UserName and FormName
		/// </summary>
		/// <param name="request">A GetFormSettingsRequest object.</param>
		/// <returns>A GetFormSettingsResponse object</returns>
		public GetFormSettingsResponse GetFormSettings(GetFormSettingsRequest request)
		{
			GetFormSettingsResponse response = new GetFormSettingsResponse();
			response.FormSettingsCD = FormSettingsCD.GetFormSettings(request.UserName, request.FormName);

			return response;
		}

		/// <summary>
		/// Update FormSettings by UserName and FormName
		/// </summary>
		/// <param name="request">A UpdateFormSettingsRequest object.</param>
		/// <returns>A UpdateFormSettingsResponse object</returns>
		public UpdateFormSettingsResponse UpdateFormSettings(UpdateFormSettingsRequest request)
		{
			UpdateFormSettingsResponse response = new UpdateFormSettingsResponse();
			response.FormSettingsCD = FormSettingsCD.UpdateFormSettings(request.FormSettingsCD);

			return response;
		}

		/// <summary>
		/// Get GridSettings by UserName and GridName
		/// </summary>
		/// <param name="request">A GetGridSettingsRequest object.</param>
		/// <returns>A GetGridSettingsResponse object</returns>
		public GetGridSettingsResponse GetGridSettings(GetGridSettingsRequest request)
		{
			GetGridSettingsResponse response = new GetGridSettingsResponse();
			response.GridSettingsCD = GridSettingsCD.GetGridSettings(request.UserName, request.GridName);

			return response;
		}

		/// <summary>
		/// Update GridSettings
		/// </summary>
		/// <param name="request">A UpdateGridSettingsRequest object.</param>
		/// <returns>A UpdateGridSettingsResponse object</returns>
		public UpdateGridSettingsResponse UpdateGridSettings(UpdateGridSettingsRequest request)
		{
			UpdateGridSettingsResponse response = new UpdateGridSettingsResponse();
			response.GridSettingsCD = GridSettingsCD.UpdateGridSettings(request.GridSettingsCD);

			return response;
		}

		/// <summary>
		/// Replace GridSettings
		/// </summary>
		/// <param name="request">A ReplaceGridSettingsRequest object.</param>
		/// <returns>A ReplaceGridSettingsResponse object</returns>
		public ReplaceGridSettingsResponse ReplaceGridSettings(ReplaceGridSettingsRequest request)
		{
			ReplaceGridSettingsResponse response = new ReplaceGridSettingsResponse();
			response.ReplaceSuccessful = GridSettingsCD.ReplaceGridSettings(request.GridSettingsCD);

			return response;
		}

		/// <summary>
		/// Get GridFilters by UserName and GridName
		/// </summary>
		/// <param name="request">A GetGridFiltersRequest object.</param>
		/// <returns>A GetGridFiltersResponse object</returns>
		public GetGridFiltersResponse GetGridFilters(GetGridFiltersRequest request)
		{
			GetGridFiltersResponse response = new GetGridFiltersResponse();
			response.GridFiltersCD = GridFiltersCD.GetGridFilters(request.UserName, request.GridName);

			return response;
		}

		/// <summary>
		/// Update GridFilters by UserName and GridName
		/// </summary>
		/// <param name="request">A UpdateGridFiltersRequest object.</param>
		/// <returns>A UpdateGridFiltersResponse object</returns>
		public UpdateGridFiltersResponse UpdateGridFilters(UpdateGridFiltersRequest request)
		{
			UpdateGridFiltersResponse response = new UpdateGridFiltersResponse();
			response.GridFiltersCD = GridFiltersCD.UpdateGridFilters(request.GridFiltersCD);

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