using System;
using RWR.Common;
using ASMX = System.Xml.Serialization;

namespace RWR.MessageContracts.Issues
{
	/// <summary>
	/// Message Contract - Get Issues Response
	/// </summary>
	[Serializable]
	[ASMX::XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "GetIssuesRS")]
	public partial class GetIssuesResponse : BaseResponse
	{
		/// <summary>
		/// The Issues Client DataSet.
		/// </summary>
		[ASMX::XmlElement(IsNullable = false)]
		public RWR.IssueTracker.DSBO.IssuesCD IssuesCD;
	}
}
