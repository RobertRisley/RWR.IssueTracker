using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Update FormSettings Response
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "UpdateFormSettingsRS")]
	public partial class UpdateFormSettingsResponse : BaseResponse
	{
		/// <summary>
		/// The FormSettings Client DataSet.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public RWR.Windows.Components.DSBO.FormSettingsCD FormSettingsCD;
	}
}
