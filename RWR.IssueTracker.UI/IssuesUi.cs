using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using RWR.Common;
using RWR.IssueTracker.DSBO;
using RWR.Windows.Components;
using RWR.Windows.Components.DSBO;

namespace RWR.IssueTracker.UI
{
	/// <summary>
	/// Edit the IssueTracker "RWR" Issues (Tasks)
	/// </summary>
    public partial class Issues : BaseFormBaseGrid
	{
		#region Private Members

		private readonly IssuesCD _issuesCD = new IssuesCD();
		private readonly IssuesCD.IssuesDataTable _oneIssueDataTable = new IssuesCD.IssuesDataTable();
		private Form_GetDataCompletedCallBack _form_GetDataCompletedCallBack;
		private Form_UpdateCompletedCallBack _form_UpdateCompletedCallBack;

		#endregion

		/// <summary>
		/// Edit the IssueTracker "RWR" Issues (Tasks).
		/// </summary>
		public Issues()
        {
            InitializeComponent();
		}

		private void Form_Load(object sender, EventArgs e)
		{
			// TODO manually code this

			// set Grid Banner properties - Visible,Text
			Grid.BannerName = "Issues List";
			Grid.Banner.Visible = true;
			Grid.SetBannerText();

			// get lookup tables if needed
			cboPriority.DataSource = CodesCache.PriorityTypeCodes;
			cboPriority.DisplayMember = "ShortDescription";
			cboPriority.ValueMember = "PriorityTypeCd";

			Form_EventHandlers_Set(); // i.e., GetDataCompleted
			Form_RetrieveData(); // only RetrieveData after Form_EventHandlers_Set has run

			Grid_ToolStrip_Customize();
		}

		private void Form_EventHandlers_Set()
		{
			// if the user clicks Retrieve Data button on BaseGrid
			Grid.RetrieveData += Form_RetrieveData;
			Grid.FilterApply += Form_FilterSetStatusMessage;

			_issuesCD.ClientGetIssuesCompleted += Form_GetDataCompleted;
			_issuesCD.ClientUpdateIssuesCompleted += Async_UpdateCompleted;

			_form_GetDataCompletedCallBack = Form_GetDataCompleted;
			_form_UpdateCompletedCallBack = Async_UpdateCompleted;

			// TODO add custom FORM event handlers
		}
		private void Form_RetrieveData()
		{
			StatusMessage.Text = "Retrieving Data...";
			Grid.DisableRetrieveDataButton();

			DataSource_EventHandlers_Remove();

			//_issuesCD.UseWcfService = true;
			//_issuesCD.UseAsmxService= false;
			//_issuesCD.UseClientServer = false;

			//synch USE FOR DEBUGGING
			bool success = _issuesCD.ClientGetIssues(false);
			Form_GetDataCompleted(this, new EventArgs());

			//async USE FOR PRODUCTION
			//_issuesCD.ClientGetIssues(true);
		}
		private void Form_GetDataCompleted(object sender, EventArgs e)
		{
			try
			{
				// IMPORTANT! regarding WCF async calls.
				//		This control's System.Windows.Forms.Control.Handle was created on
				//		a different thread than the WCF calling thread (Cross-thread).
				//		If so, you must make calls to the control through an invoke method.
				if (InvokeRequired)
				{
					Invoke(_form_GetDataCompletedCallBack, new object[] { sender, e });
					return;
				}
				else
				{
					_issuesCD.ClientSetCaptions();

					Grid.GetDataCompleted(_issuesCD.Issues);  // populate the Grid DataSource

					Grid.GridName = "Issues"; // set the GridName for GridSettings retrieval
					if (FormatGrid)
					{
						Grid.FormSettings_Set(FormSettings);
						Grid.GridSettings_Apply();
					}

					Grid_GridSettings_Customize();
					Grid_EventHandlers_Add();  // i.e., CellValidating, CellEndEdit
					DataSource_EventHandlers_Add();  // i.e., TableNewRow, RowChanged, RowDeleted
					Form_FilterSetStatusMessage();

					Grid.EnableRetrieveDataButton();
				}
			}
			catch (Exception ex)
			{
				StatusMessage.Text = String.Format("ERROR Retrieving Data...{0}", ex.Message); 
			}
		}
		private delegate void Form_GetDataCompletedCallBack(object sender, EventArgs e);

		private void Form_FilterSetStatusMessage()
		{
			StatusMessage.Text = ((DataTable)Grid.BindingSource.DataSource).Rows.Count + " row(s) retrieved. " + Grid.DataGridView.Rows.Count + " row(s) displayed.";
		}

		private void Grid_ToolStrip_Customize()
		{
			// disable the ToolStrip here if it's not needed
			//_grid._tsMain.Visible = false;

			ToolStripButton _btnTest = new ToolStripButton();
			// to add an Image first add the .bmp,.jpg... to the Resources folder, then
			// go to Properties folder, double-click Resources.resx,
			// Add Resource-Add Existing File... then select the Resources folder image
			_btnTest.Image = global::RWR.IssueTracker.UI.Properties.Resources.install;
			_btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
			_btnTest.Name = "_btnTest";
			_btnTest.AutoSize = true;
			_btnTest.Text = "Button Test";
			_btnTest.ToolTipText = "Testing of Adding a Button from the Form";
			Grid.TopToolStrip.Items.Add(_btnTest);
			_btnTest.Click += _btnTest_Click;
		}
		private void Grid_GridSettings_Customize()
		{
			// set all columns to ReadOnly
			foreach (DataGridViewColumn col in Grid.DataGridView.Columns)
				col.ReadOnly = true;

			// set specific columns editable
			Grid.DataGridView.Columns["PrioritySequence"].ReadOnly = false;

			// override specific columns default formatting
			Grid.DataGridView.Columns["PrioritySequence"].DefaultCellStyle.Format = "0";
			Grid.DataGridView.Columns["PrioritySequence"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			Grid.DataGridView.Columns["TaskId"].DefaultCellStyle.Format = "0";
		}
		private void Grid_EventHandlers_Add()
		{
			Grid.GridDoubleClick += Grid_DoubleClick;
			Grid.DataGridView.CellValidating += Grid_CellValidating;
			Grid.DataGridView.CellEndEdit += Grid_CellEndEdit;

			// TODO add custom GRID event handlers
		}
		//private void Grid_EventHandlers_Remove()
		//{
		//    try { Grid.GridDoubleClick -= Grid_DoubleClick; } catch { }
		//    try { Grid.DataGridView.CellValidating -= Grid_CellValidating; } catch { }
		//    try { Grid.DataGridView.CellEndEdit -= Grid_CellEndEdit; } catch { }

		//    // TODO add custom GRID event handlers
		//}
		private void Grid_DoubleClick(object sender, GridDoubleClickEventArgs e)
		{
			_oneIssueDataTable.Clear();
			IssuesCD.IssuesRow dr = _oneIssueDataTable.NewIssuesRow();
			dr.ItemArray = e.Row.ItemArray;
			_oneIssueDataTable.Rows.Add(dr);
			_bsIssue.DataSource = _oneIssueDataTable;
			_oneIssueDataTable.AcceptChanges();

			btnSave.Visible = true;
			btnCancel.Visible = true;
			btnNew.Visible = false;
		}
		private static void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			//RWR.Business.IssuesDC.CheckGridColumn(sender, e);
		}
		private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			// Clear the row error in case the user presses ESC.   
			Grid.DataGridView.Rows[e.RowIndex].ErrorText = string.Empty;
			Grid.DataGridView.CurrentCell.ErrorText = string.Empty;
		}

		//void _dgvGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		//{
		//}
		private static void _btnTest_Click(object sender, EventArgs e)
		{
			UserSettingsCD _userSettings = new UserSettingsCD();
			_userSettings.ClientGetUserSettings(SystemInformation.UserName, false);

			UserSettingsUi ui = new UserSettingsUi(_userSettings);
			ui.ShowDialog();
		}

		private void DataSource_EventHandlers_Add()
		{
			DataTable dataSource = (DataTable)Grid.BindingSource.DataSource;
			dataSource.TableNewRow += DataSource_TableNewRow;
			dataSource.RowChanged += DataSource_RowUpdated;
			dataSource.RowDeleted += DataSource_RowUpdated;

			// TODO add custom DATASOURCE event handlers
		}
		private void DataSource_EventHandlers_Remove()
		{
			if (Grid.BindingSource.DataSource.ToString() == "Issues")
			{
				DataTable dataSource = (DataTable) Grid.BindingSource.DataSource;
				dataSource.TableNewRow -= DataSource_TableNewRow;
				dataSource.RowChanged -= DataSource_RowUpdated;
				dataSource.RowDeleted -= DataSource_RowUpdated;
			}

			// TODO add custom GRID event handlers
		}

		private void DataSource_TableNewRow(object sender, DataTableNewRowEventArgs e)
		{
			DataRowChangeEventArgs ea = new DataRowChangeEventArgs(e.Row, DataRowAction.Add);
			DataSource_RowUpdated(sender, ea);
		}
		private void DataSource_RowUpdated(object sender, DataRowChangeEventArgs e)
		{
			// TODO manually code this
			StatusMessage.Text = "Async Update Started";

			// put the e.Row into a DataSet for transport/update
			IssuesCD ds = new IssuesCD();
			ds.Issues.ImportRow(e.Row);

			//synch USE FOR DEBUGGING
			//ds.ClientUpdateIssues();
			//_issuesCD.ClientUpdateIssues(ds);

			//async USE FOR PRODUCTION
			ds.ClientUpdateIssuesCompleted += Async_UpdateCompleted;
			ds.ClientUpdateIssues(true);
			//_issuesCD.ClientUpdateIssuesAsync(ds);
		}

		private void Async_UpdateCompleted(object sender, AsyncCompletedEventArgs e)
		{
			// IMPORTANT! regarding WCF async calls.
			//		This control's System.Windows.Forms.Control.Handle was created on
			//		a different thread than the WCF calling thread (Cross-thread).
			//		If so, you must make calls to the control through an invoke method.
			if (InvokeRequired)
			{
				Invoke(_form_UpdateCompletedCallBack, new object[] { sender, e });
				return;
			}
			else
			{
				if (e.Error != null)
					StatusMessage.Text = e.Error.Message;
			}
		}
		private delegate void Form_UpdateCompletedCallBack(object sender, AsyncCompletedEventArgs e);

		private void btnSave_Click(object sender, EventArgs e)
		{
			IssuesCD.IssuesRow issuesRow = (IssuesCD.IssuesRow) _oneIssueDataTable.Rows[0];
			if (issuesRow.IsValidRow())
			{
				object[] keys = new object[] { _oneIssueDataTable.Rows[0]["TaskId"].ToString() };

				DataTable gridDataSource = Grid.BindingSource.DataSource as DataTable;
				if (gridDataSource != null)
				{
					DataRow gridRow = gridDataSource.Rows.Find(keys);
					if (gridRow != null)
					{
						gridRow.ItemArray = _oneIssueDataTable.Rows[0].ItemArray; // will fire RowUpdated event
					}
					else
					{
						gridDataSource.Rows.Add(_oneIssueDataTable.Rows[0].ItemArray);
						//gridRow.ItemArray = _oneIssueDataTable.Rows[0].ItemArray;
						//gridDataSource.Rows.Add(gridRow); // will fire TableNewRow event
					}
				}

				_oneIssueDataTable.Clear();
				btnSave.Visible = false;
				btnCancel.Visible = false;
				btnNew.Visible = true;
			}
			else
			{
				StatusMessage.Text = issuesRow.RowError;
			}
		}

		#region _Validating and _Validated event handlers

		private void txtComponent_Validating(object sender, CancelEventArgs e)
		{
			//e.Cancel = false;
		}

		private void dtpSubmitDt_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
		}

		private void txtSubmittedBy_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
		}

		private void txtShortDescription_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
		}

		private void cboPriority_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
		}

		private void cboPriority_Validated(object sender, EventArgs e)
		{
			if (_oneIssueDataTable.Rows.Count > 0)
			{
				switch (cboPriority.Text)
				{
					case "0-URGENT":
						((IssuesCD.IssuesRow)_oneIssueDataTable.Rows[0]).PriorityTypeCd = 4;
						break;
					case "1-HIGH":
						((IssuesCD.IssuesRow)_oneIssueDataTable.Rows[0]).PriorityTypeCd = 3;
						break;
					case "2-MED":
						((IssuesCD.IssuesRow)_oneIssueDataTable.Rows[0]).PriorityTypeCd = 2;
						break;
					case "3-LOW":
						((IssuesCD.IssuesRow)_oneIssueDataTable.Rows[0]).PriorityTypeCd = 1;
						break;
					default:
						break;
				}
			}
		}

		private void cboPrioritySequence_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
		}

		private void cboPrioritySequence_Validated(object sender, EventArgs e)
		{
			if (_oneIssueDataTable.Rows.Count > 0)
			{
				int ps ;
				int.TryParse(cboPrioritySequence.Text, out ps);
				((IssuesCD.IssuesRow)_oneIssueDataTable.Rows[0]).PrioritySequence = ps;
			}
		}

		private void dtpAssignedDate_Validating(object sender, CancelEventArgs e)
		{
			e.Cancel = false;
		}

		//private void cboAssignedToName_Validating(object sender, CancelEventArgs e)
		//{
		//    e.Cancel = false;
		//}

		//private void rtbLongDescription_Validating(object sender, CancelEventArgs e)
		//{
		//    e.Cancel = false;
		//}
		#endregion

		private void btnCancel_Click(object sender, EventArgs e)
		{
			_oneIssueDataTable.Clear();
			btnSave.Visible = false;
			btnCancel.Visible = false;
			btnNew.Visible = true;
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			_oneIssueDataTable.Clear();
			IssuesCD.IssuesRow dr = _oneIssueDataTable.NewIssuesRow();
			_oneIssueDataTable.Rows.Add(dr);
			_bsIssue.DataSource = _oneIssueDataTable;

			btnSave.Visible = true;
			btnCancel.Visible = true;
			btnNew.Visible = false;
		}

	}
}