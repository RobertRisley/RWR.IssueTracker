using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Get GridSettings Request
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "GetGridSettingsRQ")]
	public partial class GetGridSettingsRequest : BaseRequest
	{
		/// <summary>
		/// The GridSettings UserName.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public string UserName;

		/// <summary>
		/// The GridSettings GridName.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public string GridName;
	}
}
