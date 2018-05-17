using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Replace GridSettings Request
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "ReplaceGridSettingsRQ")]
	public partial class ReplaceGridSettingsRequest : BaseRequest
	{
		/// <summary>
		/// The GridSettings Client DataSet.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public RWR.Windows.Components.DSBO.GridSettingsCD GridSettingsCD;
	}
}
