using System;
using System.Data;
using System.Transactions;
using ASMX = RWR.IssueTracker.DSBO.IssuesServiceASMX;
using WCF = RWR.IssueTracker.DSBO.IssuesServiceWCF;

namespace RWR.IssueTracker.DSBO
{
	/// <summary>
	/// The Codes Client DataSet BusinessObject.
	/// </summary>
	partial class CodesCD
	{
		#region Service Code

		/// <summary>
		/// Service callable code to get PriorityType Key/Value Pairs
		/// </summary>
		/// <returns>A DataSet of type CodesCD</returns>
		public static CodesCD GetPriorityTypeCodes()
		{
			using (new TransactionScope(TransactionScopeOption.Suppress))
			{
				CodesCD cd = new CodesCD();
				CodesCDTableAdapters.PriorityTypesTableAdapter ta = new CodesCDTableAdapters.PriorityTypesTableAdapter();
				ta.FillKeyValuePairs(cd.PriorityTypes);
				ta.Dispose();
				return cd;
			}
		}

		#endregion

		#region Client Code

		#region Try-to-Use Service Types
		/// <summary>
		/// Use Win Services.
		/// </summary>
		public bool UseWcfService = true;
		/// <summary>
		/// Use Web Services.
		/// </summary>
		public bool UseAsmxService = true;
		/// <summary>
		/// Use Client/Server (last resort).
		/// </summary>
		public bool UseClientServer = true;
		#endregion

		/// <summary>
		/// Client callable code to get PriorityTypeCodes.
		/// </summary>
		/// <param name="async">Call asynchronously.</param>
		/// <returns>True if get is successful</returns>
		public bool ClientGetPriorityTypeCodes(bool async)
		{
			if (UseWcfService)
			{
				try
				{
					WCF.IssuesContractClient svWCF = new WCF.IssuesContractClient();
					WCF.GetPriorityTypeCodesRequest rqWCF = new WCF.GetPriorityTypeCodesRequest();

					if (async)
					{
						svWCF.BeginGetPriorityTypeCodes(rqWCF, wcf_ClientGetPriorityTypeCodesCompleted, svWCF);
						return true;
					}
					else
					{
						WCF.GetPriorityTypeCodesResponse rsWCF = svWCF.GetPriorityTypeCodes(rqWCF);
						Merge(rsWCF.CodesCD, false, MissingSchemaAction.Ignore);
						PrepareDataAfterGet();
						return true;
					}
				}
				catch { UseWcfService = false; } // ignore if not responding
			}
			if (UseAsmxService)
			{
				try
				{
					ASMX.IssuesServiceASMX svASMX = new ASMX.IssuesServiceASMX();
					ASMX.GetPriorityTypeCodesRequest rqASMX = new ASMX.GetPriorityTypeCodesRequest();

					if (async)
					{
						svASMX.GetPriorityTypeCodesCompleted += asmx_ClientGetPriorityTypeCodesCompleted;
						svASMX.GetPriorityTypeCodesAsync(rqASMX);
						return true;
					}
					else
					{
						ASMX.GetPriorityTypeCodesResponse rsASMX = svASMX.GetPriorityTypeCodes(rqASMX);
						Merge(rsASMX.CodesCD, false, MissingSchemaAction.Ignore);
						PrepareDataAfterGet();
						return true;
					}
				}
				catch { UseAsmxService = false; } // ignore if not responding
			}
			if (UseClientServer)
			{
				try
				{
					Merge(GetPriorityTypeCodes(), false, MissingSchemaAction.Ignore);
					PrepareDataAfterGet();
					return true;
				}
				catch { UseClientServer = false; } // ignore if not responding
			}

			return false;
		}
		/// <summary>
		/// Event fired when GetAsyncCompleted
		/// </summary>
		public event EventHandler ClientGetPriorityTypeCodesCompleted;
		private void wcf_ClientGetPriorityTypeCodesCompleted(IAsyncResult ar)
		{
			WCF.GetPriorityTypeCodesResponse rsWCF = ((WCF.IssuesContractClient)ar.AsyncState).EndGetPriorityTypeCodes(ar);
			Merge(rsWCF.CodesCD.PriorityTypes, false, MissingSchemaAction.Ignore);
			PrepareDataAfterGet();
			ClientGetPriorityTypeCodesCompleted(this, new EventArgs());
		}
		private void asmx_ClientGetPriorityTypeCodesCompleted(object sender, ASMX.GetPriorityTypeCodesCompletedEventArgs e)
		{
			ASMX.GetPriorityTypeCodesResponse rsASMX = e.Result;
			Merge(rsASMX.CodesCD.PriorityTypes, false, MissingSchemaAction.Ignore);
			PrepareDataAfterGet();
			ClientGetPriorityTypeCodesCompleted(this, new EventArgs());
		}

		/// <summary>
		/// Prepare any Data after Get is completed.
		/// </summary>
		private static void PrepareDataAfterGet()
		{
		}
		#endregion
	}
}
