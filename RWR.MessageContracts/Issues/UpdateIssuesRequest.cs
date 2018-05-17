using System;
using RWR.Common;
using ASMX = System.Xml.Serialization;

namespace RWR.MessageContracts.Issues
{
	/// <summary>
	/// Message Contract - Update Issues Request
	/// </summary>
	[Serializable]
	[ASMX::XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "UpdateIssuesRQ")]
	public partial class UpdateIssuesRequest : BaseRequest
	{
		/// <summary>
		/// The Issues Client DataSet.
		/// </summary>
		[ASMX::XmlElement(IsNullable = false)]
		public RWR.IssueTracker.DSBO.IssuesCD IssuesCD;
	}
}
