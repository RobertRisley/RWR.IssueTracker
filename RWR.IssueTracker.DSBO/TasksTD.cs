using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using RWR.Common;
using TasksTableAdapter = RWR.IssueTracker.DSBO.TasksTDTableAdapters.TasksTableAdapter;

namespace RWR.IssueTracker.DSBO
{
	/// <summary>
	/// The Tasks Table DataSet BusinessObject.
	/// </summary>
	partial class TasksTD
	{
		/// <summary>
		/// Get all Tasks
		/// </summary>
		/// <returns>A TasksTD</returns>
		public static DataSet GetTasks()
		{
			TasksTD td = new TasksTD();
			TasksTableAdapter ta = new TasksTableAdapter();
			ta.Fill(td.Tasks);
			ta.Dispose();
			return td;
		}

		/// <summary>
		/// Get Task row by TaskId
		/// </summary>
		/// <returns>A TasksDataTable with one row if TaskId exists</returns>
		public static DataTable GetTask(int taskId)
		{
			if (taskId == 0)
				throw new Exception("The TaskId is zero.");

			TasksTableAdapter ta = new TasksTableAdapter();
			TasksDataTable tt = ta.GetDataByTaskId(taskId);
			ta.Dispose();
			return tt;
		}

		/// <summary>
		/// Returns true or false if a Tasks exists
		/// </summary>
		/// <param name="taskId">The TaskId to check existance</param>
		/// <returns>true if Tasks exists, false if not</returns>
		public static bool IsExistingTask(int taskId)
		{
			if (taskId == 0)
				throw new Exception("The TaskId cannot be zero.");

			TasksTableAdapter ta = new TasksTableAdapter();
			bool isExistingTask = (ta.IsExistingTask(taskId) == 1 ? true : false);
			ta.Dispose();
			return isExistingTask;
		}

		/// <summary>
		/// Service callable code to Delete/Insert/Update Tasks
		/// </summary>
		/// <returns>A TasksTD. If ALL updated OK contains updated data, if not contains the RowErrors</returns>
		public static DataSet UpdateTasks(DataSet tasksDataSet, ref SqlTransaction transaction)
		{
			if (tasksDataSet == null || tasksDataSet.Tables["Tasks"] == null || tasksDataSet.Tables["Tasks"].Rows.Count == 0)
				throw new Exception("The DataSet and/or DataTable is null or empty.");

			TasksDataTable dtTasks = new TasksDataTable();
			dtTasks.BeginLoadData();
			dtTasks.Merge(tasksDataSet.Tables["Tasks"], false, MissingSchemaAction.Error);

			TasksTableAdapter taTasks = new TasksTableAdapter();
			TableAdapterUtils.UseTransaction(taTasks, ref transaction);

			#region do deletes
			foreach (TasksRow deletedRow in dtTasks.Select("", "", DataViewRowState.Deleted))
			{
				// get the primary key value(s) from the Original version (for child deletes)
				int taskId = (int)deletedRow["TaskId", DataRowVersion.Original];

				// do child deletes (if any exist)
				//TasksChildrenDataSet.UpdateTasksChildren

				// delete the row
				taTasks.Delete(taskId);
			}
			#endregion

			#region do inserts
			foreach (TasksRow insertedRow in dtTasks.Select("", "", DataViewRowState.Added))
			{
				//insertedRow["SubmitDt"] = DBNull.Value;  // for testing SetDefaultValues
				insertedRow.SetDefaultValues();

				if (insertedRow.IsValidRow())
					taTasks.Update(insertedRow);
				else
					throw new Exception("A row to be inserted contains invalid data. Entire transaction cancelled.");
			}
			#endregion

			#region do updates
			foreach (TasksRow modifiedRow in dtTasks.Select("", "", DataViewRowState.ModifiedCurrent))
			{
				// get the primary key value(s) from the Original version
				int taskId = (int)modifiedRow["TaskId", DataRowVersion.Original];

				// do not allow key changes
				int taskIdCurr = (int)modifiedRow["TaskId", DataRowVersion.Current];
				if (taskId != taskIdCurr)
					throw new Exception("Change of primary key(s) is not permitted. Entire transaction cancelled.");

				if (modifiedRow.IsValidRow())
					taTasks.Update(modifiedRow);
				else
					throw new Exception("A row to be modified contains invalid data. Entire transaction cancelled.");
			}
			#endregion

			dtTasks.AcceptChanges();
			tasksDataSet.Tables["Tasks"].Merge(dtTasks, false, MissingSchemaAction.Ignore);

			return tasksDataSet;
		}


		/// <summary>
		/// <para>Validate all of the column values in a DataRow.</para>
		/// <para>The RowError text is set and HasErrors property is true if exists RowError text.</para>
		/// </summary>
		/// <param name="row">the DataRow to be validated</param>
		/// <param name="cols">the DataColumnCollection to iterate through</param>
		public static void CheckTableRow(DataRow row, DataColumnCollection cols)
		{
			try
			{
				foreach (DataColumn col in cols)
					switch (col.ColumnName)
					{ // TODO: code case for each column to be validated
						case "PrioritySequence": row.RowError += CheckPrioritySequence(row[col].ToString()); break;
					}
			}
			catch
			{
				row.RowError = "OOPS! ERROR checking DataRow!";
			}
		}

		/// <summary>
		/// Validity-check the PrioritySequence value.
		/// </summary>
		/// <param name="value"></param>
		/// <returns>Error Text.</returns>
		public static string CheckPrioritySequence(string value)
		{

			string errorText = string.Empty;

			int seq;
			if (int.TryParse(value, out seq) == false)
				errorText = "     SubPriority must be a number";
			else if (seq < 0 || seq > 25)
				errorText = "     SubPriority must be between 0 and 25";

			return errorText;
		}

		/// <summary>
		/// Call this from the DataGridView.CellValidating event
		/// </summary>
		/// <param name="sender">The sender object (DataGridView) from CellValidatingEvent</param>
		/// <param name="e">The e DataGridViewCellValidatingEventArgs from CellValidatingEvent</param>
		public static void CheckGridColumn(object sender, DataGridViewCellValidatingEventArgs e)
		{

			DataGridView grid = (DataGridView)sender;

			//grid.CurrentCell.ErrorText = "";
			try
			{

				switch (grid.Columns[e.ColumnIndex].Name)
				{
					case "PrioritySequence":
						grid.Rows[e.RowIndex].ErrorText = CheckPrioritySequence(e.FormattedValue as String);
						break;
				}

				if (grid.Rows[e.RowIndex].ErrorText != string.Empty)
					e.Cancel = true;
			}
			catch
			{
				grid.CurrentCell.ErrorText = "OOPS! ERROR!";
				e.Cancel = true;
			}
		}


		/// <summary>
		/// A Tasks row.
		/// </summary>
		public partial class TasksRow
		{
			/// <summary>
			/// Set value for columns == DBNull to their DefaultValue  (if DefaultValue specified in XSD)
			/// </summary>
			public void SetDefaultValues()
			{
				DataRowUtils.SetDefaultValues(this, Table.Columns);
			}

			/// <summary>
			/// Validates the current TasksRow
			/// </summary>
			/// <returns>The row is valid</returns>
			public bool IsValidRow()
			{
				CheckTableRow(this, Table.Columns);
				return !HasErrors;
			}
		}

		#region Authorization Rules

		/// <summary>
		/// 
		/// </summary>
		public void AddAuthorizationRules()
		{
			//AuthorizationRules.AllowWrite(
			//  "Name", "ProjectManager");
			//AuthorizationRules.AllowWrite(
			//  "Started", "ProjectManager");
			//AuthorizationRules.AllowWrite(
			//  "Ended", "ProjectManager");
			//AuthorizationRules.AllowWrite(
			//  "Description", "ProjectManager");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool CanAddObject()
		{
			return true;
			//return Csla.ApplicationContext.User.IsInRole(
			//  "ProjectManager");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool CanGetObject()
		{
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool CanDeleteObject()
		{
			return true;
			//bool result = false;
			//if (Csla.ApplicationContext.User.IsInRole(
			//  "ProjectManager"))
			//    result = true;
			//if (Csla.ApplicationContext.User.IsInRole(
			//  "Administrator"))
			//    result = true;
			//return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static bool CanEditObject()
		{
			return true;
			//return Csla.ApplicationContext.User.IsInRole("ProjectManager");
		}

		#endregion
	}
}
