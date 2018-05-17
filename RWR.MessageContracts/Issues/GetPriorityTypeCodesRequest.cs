using System;
using RWR.Common;
using ASMX = System.Xml.Serialization;

namespace RWR.MessageContracts.Issues
{
	/// <summary>
	/// Message Contract - Get PriorityTypeCodes Request
	/// </summary>
	[Serializable]
	[ASMX::XmlRoot(ElementName = "GetPriorityTypeCodesRQ", Namespace = Constants.SERVER_URL, IsNullable = false)]
	public partial class GetPriorityTypeCodesRequest : BaseRequest
	{
	}
}
