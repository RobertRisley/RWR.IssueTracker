namespace RWR.IssueTracker.DSBO
{
	/// <summary>
	/// The Cached Codes key/value pairs.
	/// </summary>
	public class CodesCache
	{
		private static readonly CodesCD _clientCodes = new CodesCD();

		/// <summary>
		/// The Priority Type Key/Value Pairs.
		/// </summary>
		public static CodesCD.PriorityTypesDataTable PriorityTypeCodes
		{
			get
			{
				if (_clientCodes.PriorityTypes.Rows.Count == 0)
					_clientCodes.ClientGetPriorityTypeCodes(false);

				return _clientCodes.PriorityTypes;
			}
		}
	}
}
