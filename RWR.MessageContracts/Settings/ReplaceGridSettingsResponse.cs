using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Replace GridSettings Response
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "ReplaceGridSettingsRS")]
	public partial class ReplaceGridSettingsResponse : BaseResponse
	{
		/// <summary>
		/// The Replace GridSettings successfully boolean.
		/// </summary>
		[XmlElement]
		public bool ReplaceSuccessful;
	}
}
