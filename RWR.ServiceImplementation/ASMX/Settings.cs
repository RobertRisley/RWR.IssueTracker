using RWR.Common;
using RWR.MessageContracts;
using RWR.Windows.Components.DSBO;
using ASMX = System.Web.Services;

namespace RWR.ServiceImplementation.ASMX
{
	/// <summary>
	/// Service Class - Settings
	/// </summary>
	[ASMX::WebService( Name = "SettingsServiceASMX", Namespace = Constants.SERVER_URL, Description = "Manages the RWR.Windows.Components Settings Data")]
	[ASMX::WebServiceBinding( Name = "SettingsServiceASMX", ConformsTo = ASMX::WsiProfiles.BasicProfile1_1, EmitConformanceClaims = true)]
	[System.Web.Script.Services.ScriptService] // Allows this Web Service to be called from script, using ASP.NET AJAX
	public partial class SettingsServiceASMX : System.Web.Services.WebService, RWR.ServiceContracts.ASMX.ISettingsContract
	{
		/// <summary>
		/// Get UserSettings by UserName
		/// </summary>
		/// <param name="request">The GetUserSettingsRequest object.</param>
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
		/// <param name="request">The UpdateUserSettingsRequest object.</param>
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
		/// <param name="request">The GetFormSettingsRequest object.</param>
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
		/// <param name="request">The UpdateFormSettingsRequest object.</param>
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
		/// <param name="request">The GetGridSettingsRequest object.</param>
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
		/// <param name="request">The UpdateGridSettingsRequest object.</param>
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
		/// <param name="request">The ReplaceGridSettingsRequest object.</param>
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
		/// <param name="request">The GetGridFiltersRequest object.</param>
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
		/// <param name="request">The UpdateGridFiltersRequest object.</param>
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