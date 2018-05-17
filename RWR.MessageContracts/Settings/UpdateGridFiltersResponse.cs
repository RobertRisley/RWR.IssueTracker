using System;
using System.Xml.Serialization;
using RWR.Common;

namespace RWR.MessageContracts
{
	/// <summary>
	/// Message Contract - Update GridFilters Response
	/// </summary>
	[Serializable]
	[XmlRoot(Namespace = Constants.SERVER_URL, IsNullable = false, ElementName = "UpdateGridFiltersRS")]
	public partial class UpdateGridFiltersResponse : BaseResponse
	{
		/// <summary>
		/// The GridFilters Client DataSet.
		/// </summary>
		[XmlElement(IsNullable = false)]
		public RWR.Windows.Components.DSBO.GridFiltersCD GridFiltersCD;
	}
}
