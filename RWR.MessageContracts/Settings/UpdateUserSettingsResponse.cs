using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Update UserSettings Response
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "UpdateUserSettingsRS")]
	public partial class UpdateUserSettingsResponse : BaseResponse
	{
		/// <summary>
		/// The UserSettings Client DataSet.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public RWR.Windows.Components.DSBO.UserSettingsCD UserSettingsCD;
	}
}
