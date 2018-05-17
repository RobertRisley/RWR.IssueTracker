using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Get GridFilters Request
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "GetGridFiltersRQ")]
	public partial class GetGridFiltersRequest : BaseRequest
	{
		/// <summary>
		/// The GridFilters UserName.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public string UserName;

		/// <summary>
		/// The GridFilters GridName.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public string GridName;
	}
}
