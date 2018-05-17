using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Update GridFilters Request
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "UpdateGridFiltersRQ")]
	public partial class UpdateGridFiltersRequest : BaseRequest
	{
		/// <summary>
		/// The GridFilters Client DataSet.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public RWR.Windows.Components.DSBO.GridFiltersCD GridFiltersCD;
	}
}
