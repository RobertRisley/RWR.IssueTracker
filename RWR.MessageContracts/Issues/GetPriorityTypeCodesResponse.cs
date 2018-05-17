using System;
using RWR.Common;
using ASMX = System.Xml.Serialization;

namespace RWR.MessageContracts.Issues
{
	/// <summary>
	/// Message Contract - Get PriorityTypeCodes Response
	/// </summary>
	[Serializable]
	[ASMX::XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "GetPriorityTypeCodesRS")]
	public partial class GetPriorityTypeCodesResponse : BaseResponse
	{
		/// <summary>
		/// The Codes Client DataSet.
		/// </summary>
		[ASMX::XmlElement(IsNullable = false)]
		public RWR.IssueTracker.DSBO.CodesCD CodesCD;
	}
}
