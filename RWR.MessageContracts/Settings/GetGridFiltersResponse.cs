using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Get GridFilters Response
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "GetGridFiltersRS")]
	public partial class GetGridFiltersResponse : BaseResponse
	{
		/// <summary>
		/// The GridFilters Client DataSet.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public RWR.Windows.Components.DSBO.GridFiltersCD GridFiltersCD;
	}
}
