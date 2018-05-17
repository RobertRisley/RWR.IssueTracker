using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RWR.Common;

namespace RWR.IssueTracker.DSBO.Tests
{
	/// <summary>
	/// Summary description for TasksTDTests
	/// </summary>
	[TestClass]
	public class Test_TasksTD
	{
		public Test_TasksTD() { }

		private TestContext testContextInstance;
		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Initialize/cleanup
		// Use ClassInitialize to run code before running the first test in the class
		[ClassInitialize()]
		public static void ClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		[ClassCleanup()]
		public static void ClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		[TestInitialize()]
		public void TestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		[TestCleanup()]
		public void TestCleanup() { }
		#endregion

		protected static TasksTD.TasksDataTable _taskTable = new TasksTD.TasksDataTable();
		protected static TasksTD.TasksRow _taskRow;

		#region GetTask
		/// <remarks/>
		[TestMethod]
		public void GetTask()
		{
			try
			{
				_taskTable.Merge(TasksTD.GetTask(1), false);
				Assert.AreNotEqual(null, _taskTable);
				Assert.AreEqual(1, _taskTable.Rows.Count);
				_taskRow = (TasksTD.TasksRow)_taskTable.Rows[0];
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void GetTask_InvalidTaskId()
		{
			try
			{
				DataTable taskTable = TasksTD.GetTask(9999999);
				Assert.AreNotEqual(null, taskTable, "TaskDataTable is null.");
				Assert.AreEqual(0, taskTable.Rows.Count, "TaskDataTable does not contain 0 rows.");
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		#endregion

		#region IsExistingTask
		/// <remarks/>
		[TestMethod]
		public void IsExistingTask()
		{
			try
			{
				bool isExisting = TasksTD.IsExistingTask(1);
				Assert.AreNotEqual(null, isExisting);
				Assert.AreEqual(true, isExisting);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void IsExistingTask_InvalidTaskId()
		{
			try
			{
				bool isExisting = TasksTD.IsExistingTask(9999999);
				Assert.AreEqual(false, isExisting);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		#endregion

		#region UpdateTasks
		/// <remarks/>
		[TestMethod]
		public void UpdateTasks()
		{
			SqlTransaction transaction = null;
			try
			{
				if (_taskTable.Rows.Count == 0)
					GetTask();

				DateTime dueDate = DateUtils.SqlUtcNow;
				_taskRow.DueDt = dueDate;

				TasksTD tasksDataSet = new TasksTD();
				tasksDataSet.Merge(_taskTable);

				TasksTD.UpdateTasks(tasksDataSet, ref transaction);
				SqlUtils.CommitTransaction(transaction);

				GetTask();
				Assert.AreEqual(dueDate, _taskRow.DueDt);
			}
			catch (Exception ex)
			{
				SqlUtils.RollbackTransaction(transaction);
				Assert.Fail(ex.Message);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void UpdateTasks_NullDataSet()
		{
			SqlTransaction transaction = null;
			try
			{
				TasksTD.UpdateTasks(null, ref transaction);
				Assert.Fail("Update should have failed.");
			}
			catch (Exception ex)
			{
				Assert.AreEqual("The DataSet and/or DataTable is null or empty.", ex.Message);
			}
			finally
			{
				SqlUtils.RollbackTransaction(transaction);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void UpdateTasks_NullDataTable()
		{
			SqlTransaction transaction = null; 
			try
			{
				DataSet tasksDataSet = new DataSet();
				TasksTD.UpdateTasks(tasksDataSet, ref transaction);
				Assert.Fail("Update should have failed.");
			}
			catch (Exception ex)
			{
				Assert.AreEqual("The DataSet and/or DataTable is null or empty.", ex.Message);
			}
			finally
			{
				SqlUtils.RollbackTransaction(transaction);
			}
		}
		/// <remarks/>
		[TestMethod]
		public void UpdateTasks_EmptyDataTable()
		{
			SqlTransaction transaction = null;
			try
			{
				TasksTD tasksDataSet = new TasksTD();
				TasksTD.UpdateTasks(tasksDataSet, ref transaction);
				Assert.Fail("Update should have failed.");
			}
			catch (Exception ex)
			{
				Assert.AreEqual("The DataSet and/or DataTable is null or empty.", ex.Message);
			}
			finally
			{
				SqlUtils.RollbackTransaction(transaction);
			}
		}
		#endregion
	}
}
