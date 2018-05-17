using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Get FormSettings Request
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "GetFormSettingsRQ")]
	public partial class GetFormSettingsRequest : BaseRequest
	{
		/// <summary>
		/// The FormSettings UserName.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public string UserName;

		/// <summary>
		/// The FormSettings FormName.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public string FormName;
	}
}
