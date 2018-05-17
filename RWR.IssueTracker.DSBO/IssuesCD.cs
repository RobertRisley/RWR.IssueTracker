using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using RWR.Common;
using ASMX = RWR.IssueTracker.DSBO.IssuesServiceASMX;
using IssuesTableAdapter = RWR.IssueTracker.DSBO.IssuesCDTableAdapters.IssuesTableAdapter;
using WCF = RWR.IssueTracker.DSBO.IssuesServiceWCF;

namespace RWR.IssueTracker.DSBO
{
	/// <summary>
	/// The Issues Client DataSet BusinessObject.
	/// </summary>
	partial class IssuesCD
	{
		#region Service Code

		/// <summary>
		/// Service callable code to get all RWR issues
		/// </summary>
		/// <returns>A IssuesCD object with a Issues DataTable</returns>
		public static IssuesCD GetIssues()
		{
			IssuesCD cd = new IssuesCD();
			IssuesTableAdapter ta = new IssuesTableAdapter();
			ta.Fill(cd.Issues);
			ta.Dispose();
			return cd;
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update Issues
		/// </summary>
		/// <param name="cd">A ClientDataSet of type IssuesCD</param>
		/// <returns>A IssuesCD ClientDataSet. If ALL OK contains updated data, if not contains the RowErrors</returns>
		public static IssuesCD UpdateIssues(IssuesCD cd)
		{
			if (cd == null || cd.Tables["Issues"] == null || cd.Tables["Issues"].Rows.Count == 0)
				throw new Exception("The DataSet and/or DataTable is null or empty.");

			TasksTD.TasksDataTable tt = new TasksTD.TasksDataTable();
			IssuesCD.IssuesDataTable ct = new IssuesCD.IssuesDataTable();

			foreach (IssuesRow modifiedRow in cd.Issues.Select("", "", DataViewRowState.ModifiedCurrent))
			{
				ct.Clear(); // clear for next row to import
				ct.ImportRow(modifiedRow); // import single row into Table for merge

				tt.Merge(TasksTD.GetTask(modifiedRow.TaskId)); // populate with all current columns
				tt.Merge(ct, false, MissingSchemaAction.Ignore); // overlay with updated columns
			}

			TasksTD td = new TasksTD();
			td.Tasks.BeginLoadData();
			td.Tasks.Merge(cd.Issues, false, MissingSchemaAction.Ignore);
			td.Tasks.Merge(tt, false, MissingSchemaAction.Ignore);

			SqlTransaction transaction = null;
			try
			{
				TasksTD.UpdateTasks(td, ref transaction);
				SqlUtils.CommitTransaction(transaction);

				if (transaction.Connection != null && transaction.Connection.State == ConnectionState.Open)
					transaction.Connection.Close();
				transaction.Dispose();
			}
			catch (Exception ex)
			{
				SqlUtils.RollbackTransaction(transaction);
				throw ex;
			}

			return cd;
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
		/// Client callable code to get Issues.
		/// </summary>
		/// <param name="async">Call asynchronously.</param>
		/// <returns>True if get is successful</returns>
		public bool ClientGetIssues(bool async)
		{
			if (UseWcfService)
			{
				try
				{
					WCF.IssuesContractClient svWCF = new WCF.IssuesContractClient();
					WCF.GetIssuesRequest rqWCF = new WCF.GetIssuesRequest();

					if (async)
					{
						string ping = svWCF.Ping();
						if (String.IsNullOrEmpty(ping))
							throw new Exception("WCF is offline.");

						svWCF.BeginGetIssues(rqWCF, wcf_ClientGetIssuesCompleted, svWCF);
						return true;
					}
					else
					{
						WCF.GetIssuesResponse rsWCF = svWCF.GetIssues(rqWCF);
						Merge(rsWCF.IssuesCD, false, MissingSchemaAction.Ignore);
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
					ASMX.GetIssuesRequest rqASMX = new ASMX.GetIssuesRequest();

					if (async)
					{
						svASMX.GetIssuesCompleted += asmx_ClientGetIssuesCompleted;
						svASMX.GetIssuesAsync(rqASMX);
						return true;
					}
					else
					{
						ASMX.GetIssuesResponse rsASMX = svASMX.GetIssues(rqASMX);
						Merge(rsASMX.IssuesCD, false, MissingSchemaAction.Ignore);
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
					Merge(GetIssues(), false, MissingSchemaAction.Ignore);
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
		public event EventHandler ClientGetIssuesCompleted;
		private void wcf_ClientGetIssuesCompleted(IAsyncResult ar)
		{
			WCF.GetIssuesResponse rsWCF = ((WCF.IssuesContractClient)ar.AsyncState).EndGetIssues(ar);
			Merge(rsWCF.IssuesCD, false, MissingSchemaAction.Ignore);
			PrepareDataAfterGet();
			ClientGetIssuesCompleted(this, new EventArgs());
		}
		private void asmx_ClientGetIssuesCompleted(object sender, ASMX.GetIssuesCompletedEventArgs e)
		{
			ASMX.GetIssuesResponse rsASMX = e.Result;
			Merge(rsASMX.IssuesCD, false, MissingSchemaAction.Ignore);
			PrepareDataAfterGet();
			ClientGetIssuesCompleted(this, new EventArgs());
		}

		/// <summary>
		/// Client callable code to Delete/Insert/Update Issues
		/// </summary>
		/// <returns>True if update is successful. If False, check for RowErrors.</returns>
		public bool ClientUpdateIssues(bool async)
		{
			PrepareDataBeforeUpdate();

			IssuesCD updatedIssues = new IssuesCD();
			updatedIssues.Merge(Tables["Issues"].Select("", "", DataViewRowState.Deleted), false, MissingSchemaAction.Ignore);
			updatedIssues.Merge(Tables["Issues"].Select("", "", DataViewRowState.Added), false, MissingSchemaAction.Ignore);
			updatedIssues.Merge(Tables["Issues"].Select("", "", DataViewRowState.ModifiedCurrent), false, MissingSchemaAction.Ignore);

			if (updatedIssues.Issues.Rows.Count > 0)
			{
				if (UseWcfService)
				{
					try
					{
						WCF.IssuesContractClient svWCF = new WCF.IssuesContractClient();
						WCF.UpdateIssuesRequest rqWCF = new WCF.UpdateIssuesRequest();
						rqWCF.IssuesCD = new IssuesServiceWCF.IssuesCD();
						rqWCF.IssuesCD.Merge(updatedIssues, false, MissingSchemaAction.Ignore);

						if (async)
						{
							string ping = svWCF.Ping();
							if (String.IsNullOrEmpty(ping))
								throw new Exception("WCF is offline.");
							svWCF.BeginUpdateIssues(rqWCF, wcf_ClientUpdateIssuesCompleted, svWCF);
							return true;
						}
						else
						{
							WCF.UpdateIssuesResponse rsWCF = svWCF.UpdateIssues(rqWCF);
							Merge(rsWCF.IssuesCD, false, MissingSchemaAction.Ignore);
							PrepareDataAfterUpdate();
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
						ASMX.UpdateIssuesRequest rqASMX = new ASMX.UpdateIssuesRequest();
						rqASMX.IssuesCD = new IssuesServiceASMX.IssuesCD();
						rqASMX.IssuesCD.Merge(updatedIssues, false, MissingSchemaAction.Ignore);

						if (async)
						{
							svASMX.UpdateIssuesCompleted += asmx_ClientUpdateIssuesCompleted;
							svASMX.UpdateIssuesAsync(rqASMX);
							return true;
						}
						else
						{
							ASMX.UpdateIssuesResponse rsASMX = svASMX.UpdateIssues(rqASMX);
							Merge(rsASMX.IssuesCD, false, MissingSchemaAction.Ignore);
							PrepareDataAfterUpdate();
							return true;
						}
					}
					catch { UseAsmxService = false; } // ignore if not responding
				}
				if (UseClientServer)
				{
					try
					{
						Merge(UpdateIssues(updatedIssues), false, MissingSchemaAction.Ignore);
						PrepareDataAfterUpdate();
						return true;
					}
					catch { UseClientServer = false; } // ignore if not responding
				}
			}

			return false;
		}
		/// <summary>
		/// Event fired when UpdateAsyncCompleted
		/// </summary>
		public event AsyncCompletedEventHandler ClientUpdateIssuesCompleted;
		private void wcf_ClientUpdateIssuesCompleted(IAsyncResult ar)
		{
			Exception ex = new Exception("Async update completed normally", null);

			try
			{
				WCF.UpdateIssuesResponse rs = ((WCF.IssuesContractClient) ar.AsyncState).EndUpdateIssues(ar);
			}
			catch (Exception x)
			{
				ex = new Exception(x.Message, x.InnerException);
			}

			PrepareDataAfterUpdate();
			ClientUpdateIssuesCompleted(this, new AsyncCompletedEventArgs(ex, false, null));
		}

		private void asmx_ClientUpdateIssuesCompleted(object sender, ASMX.UpdateIssuesCompletedEventArgs e)
		{
			Exception ex = new Exception("Async update completed normally", null);

			if (e.Cancelled || (e.Error != null && !String.IsNullOrEmpty(e.Error.Message)))
				ex = new Exception(e.Error.Message, null);
			else
			{
				try
				{
					ASMX.UpdateIssuesResponse rs = e.Result;
				}
				catch (Exception x)
				{
					ex = new Exception(x.Message, x.InnerException);
				}
			}

			PrepareDataAfterUpdate();
			ClientUpdateIssuesCompleted(this, new AsyncCompletedEventArgs(ex, e.Cancelled, null));
		}

		/// <summary>
		/// Prepare any Data after Get is completed.
		/// </summary>
		private static void PrepareDataAfterGet()
		{
		}

		/// <summary>
		/// Prepare any Data before Update is started.
		/// </summary>
		private static void PrepareDataBeforeUpdate()
		{
		}

		/// <summary>
		/// Prepare any Data after Update is completed.
		/// </summary>
		private static void PrepareDataAfterUpdate()
		{
		}

		/// <summary>
		/// Sets the Caption text for the DataColumnCollection in a DataTable
		/// </summary>
		public void ClientSetCaptions()
		{
			DataTableUtils.SetCaptions(Issues.Columns, new TasksTD.TasksDataTable().Columns);
		}

		#endregion

		/// <summary>
		/// A Issues row.
		/// </summary>
		public partial class IssuesRow
		{
			/// <summary>
			/// Set value for columns == DBNull to their DefaultValue  (if DefaultValue specified in XSD)
			/// </summary>
			public void SetDefaultValues()
			{
				DataRowUtils.SetDefaultValues(this, new TasksTD.TasksDataTable().Columns);
			}

			/// <summary>
			/// Validates the current IssuesRow.
			///   This Row only validates the columns it uses from each different TableRow
			/// </summary>
			/// <returns>The row is valid</returns>
			public bool IsValidRow()
			{
				try
				{
					RowError = String.Empty;
					RowError += TasksTD.CheckPrioritySequence(PrioritySequence.ToString());
				}
				catch (Exception ex)
				{
					RowError += ex.Message;
				}
				return !HasErrors;
			}
		}
	}
}
