using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Get UserSettings Request
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "GetUserSettingsRQ")]
	public partial class GetUserSettingsRequest : BaseRequest
	{
		/// <summary>
		/// The UserSettings UserName.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public string UserName;
	}
}
