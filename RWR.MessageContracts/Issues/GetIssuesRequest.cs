using System;
using RWR.Common;
using ASMX = System.Xml.Serialization;

namespace RWR.MessageContracts.Issues
{
	/// <summary>
	/// Message Contract - Get Issues Request
	/// </summary>
	[Serializable]
	[ASMX::XmlRoot(ElementName = "GetIssuesRQ", Namespace = Constants.SERVER_URL, IsNullable = false)]
	public partial class GetIssuesRequest : BaseRequest
	{
	}
}
