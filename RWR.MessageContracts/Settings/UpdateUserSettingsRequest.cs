using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Update UserSettings Request
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "UpdateUserSettingsRQ")]
	public partial class UpdateUserSettingsRequest : BaseRequest
	{
		/// <summary>
		/// The UserSettings Client DataSet.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public RWR.Windows.Components.DSBO.UserSettingsCD UserSettingsCD;
	}
}
