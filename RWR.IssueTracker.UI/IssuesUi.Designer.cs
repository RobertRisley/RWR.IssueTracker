namespace RWR.IssueTracker.UI
{
    partial class Issues
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Issues));
			this.dtpAssignedDate = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.cboAssignedToName = new System.Windows.Forms.ComboBox();
			this._bsIssue = new System.Windows.Forms.BindingSource(this.components);
			this.label9 = new System.Windows.Forms.Label();
			this.txtSubmittedBy = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cboPrioritySequence = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cboPriority = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtShortDescription = new System.Windows.Forms.TextBox();
			this.dtpSubmitDt = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.txtComponent = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTaskId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.rtbLongDescription = new System.Windows.Forms.RichTextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.pnlEdit = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.FormSettings)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._bsIssue)).BeginInit();
			this.pnlEdit.SuspendLayout();
			this.SuspendLayout();
			// 
			// Grid
			// 
			this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Grid.Size = new System.Drawing.Size(1016, 366);
			// 
			// dtpAssignedDate
			// 
			this.dtpAssignedDate.Enabled = false;
			this.dtpAssignedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpAssignedDate.Location = new System.Drawing.Point(753, 68);
			this.dtpAssignedDate.Name = "dtpAssignedDate";
			this.dtpAssignedDate.Size = new System.Drawing.Size(88, 20);
			this.dtpAssignedDate.TabIndex = 33;
			this.dtpAssignedDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpAssignedDate_Validating);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Location = new System.Drawing.Point(847, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(23, 13);
			this.label10.TabIndex = 41;
			this.label10.Text = "To:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboAssignedToName
			// 
			this.cboAssignedToName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "AssignedToName", true));
			this.cboAssignedToName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAssignedToName.FormattingEnabled = true;
			this.cboAssignedToName.Items.AddRange(new object[] {
            "Ai Duong",
            "Angela Chow",
            "Anurag bhargava",
            "Loay Alnaji",
            "Pawan Dubey",
            "Robert Risley",
            "Sami Saman",
            "Samip Bararia",
            "Thomas Margraff",
            "Tracy Fletcher",
            "Veronica Meitllis"});
			this.cboAssignedToName.Location = new System.Drawing.Point(870, 69);
			this.cboAssignedToName.MaxDropDownItems = 12;
			this.cboAssignedToName.Name = "cboAssignedToName";
			this.cboAssignedToName.Size = new System.Drawing.Size(127, 21);
			this.cboAssignedToName.TabIndex = 34;
			// 
			// _bsIssue
			// 
			this._bsIssue.DataMember = "Issues";
			this._bsIssue.DataSource = typeof(RWR.IssueTracker.DSBO.IssuesCD);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Location = new System.Drawing.Point(699, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 13);
			this.label9.TabIndex = 40;
			this.label9.Text = "Assigned:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSubmittedBy
			// 
			this.txtSubmittedBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "SubmittedBy", true));
			this.txtSubmittedBy.Location = new System.Drawing.Point(870, 5);
			this.txtSubmittedBy.Name = "txtSubmittedBy";
			this.txtSubmittedBy.Size = new System.Drawing.Size(127, 20);
			this.txtSubmittedBy.TabIndex = 28;
			this.txtSubmittedBy.Validating += new System.ComponentModel.CancelEventHandler(this.txtSubmittedBy_Validating);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Location = new System.Drawing.Point(847, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(22, 13);
			this.label8.TabIndex = 39;
			this.label8.Text = "By:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboPrioritySequence
			// 
			this.cboPrioritySequence.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "PrioritySequence", true));
			this.cboPrioritySequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPrioritySequence.FormattingEnabled = true;
			this.cboPrioritySequence.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.cboPrioritySequence.Location = new System.Drawing.Point(217, 69);
			this.cboPrioritySequence.MaxDropDownItems = 11;
			this.cboPrioritySequence.Name = "cboPrioritySequence";
			this.cboPrioritySequence.Size = new System.Drawing.Size(55, 21);
			this.cboPrioritySequence.TabIndex = 32;
			this.cboPrioritySequence.Validating += new System.ComponentModel.CancelEventHandler(this.cboPrioritySequence_Validating);
			this.cboPrioritySequence.Validated += new System.EventHandler(this.cboPrioritySequence_Validated);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(188, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(29, 13);
			this.label7.TabIndex = 38;
			this.label7.Text = "Seq:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboPriority
			// 
			this.cboPriority.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "Priority", true));
			this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPriority.FormattingEnabled = true;
			this.cboPriority.Location = new System.Drawing.Point(55, 69);
			this.cboPriority.MaxDropDownItems = 5;
			this.cboPriority.Name = "cboPriority";
			this.cboPriority.Size = new System.Drawing.Size(122, 21);
			this.cboPriority.TabIndex = 25;
			this.cboPriority.Validating += new System.ComponentModel.CancelEventHandler(this.cboPriority_Validating);
			this.cboPriority.Validated += new System.EventHandler(this.cboPriority_Validated);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(10, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(41, 13);
			this.label6.TabIndex = 37;
			this.label6.Text = "Priority:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point(22, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 36;
			this.label5.Text = "Text:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(24, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 35;
			this.label4.Text = "Title:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtShortDescription
			// 
			this.txtShortDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "ShortDescription", true));
			this.txtShortDescription.Location = new System.Drawing.Point(55, 37);
			this.txtShortDescription.Name = "txtShortDescription";
			this.txtShortDescription.Size = new System.Drawing.Size(942, 20);
			this.txtShortDescription.TabIndex = 29;
			this.txtShortDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtShortDescription_Validating);
			// 
			// dtpSubmitDt
			// 
			this.dtpSubmitDt.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "SubmitDt", true));
			this.dtpSubmitDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpSubmitDt.Location = new System.Drawing.Point(753, 4);
			this.dtpSubmitDt.Name = "dtpSubmitDt";
			this.dtpSubmitDt.Size = new System.Drawing.Size(88, 20);
			this.dtpSubmitDt.TabIndex = 26;
			this.dtpSubmitDt.Validating += new System.ComponentModel.CancelEventHandler(this.dtpSubmitDt_Validating);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(694, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 31;
			this.label3.Text = "Submitted:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtComponent
			// 
			this.txtComponent.BackColor = System.Drawing.Color.White;
			this.txtComponent.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "Component", true));
			this.txtComponent.Location = new System.Drawing.Point(217, 5);
			this.txtComponent.Name = "txtComponent";
			this.txtComponent.Size = new System.Drawing.Size(402, 20);
			this.txtComponent.TabIndex = 24;
			this.txtComponent.Validating += new System.ComponentModel.CancelEventHandler(this.txtComponent_Validating);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(153, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 30;
			this.label2.Text = "Component:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTaskId
			// 
			this.txtTaskId.BackColor = System.Drawing.Color.White;
			this.txtTaskId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "TaskId", true));
			this.txtTaskId.Location = new System.Drawing.Point(55, 5);
			this.txtTaskId.Name = "txtTaskId";
			this.txtTaskId.ReadOnly = true;
			this.txtTaskId.Size = new System.Drawing.Size(51, 20);
			this.txtTaskId.TabIndex = 23;
			this.txtTaskId.TabStop = false;
			this.txtTaskId.Text = "8888888";
			this.txtTaskId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(10, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 27;
			this.label1.Text = "Issue#:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(792, 296);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 23);
			this.btnSave.TabIndex = 43;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Visible = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// rtbLongDescription
			// 
			this.rtbLongDescription.AcceptsTab = true;
			this.rtbLongDescription.AutoWordSelection = true;
			this.rtbLongDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._bsIssue, "LongDescription", true));
			this.rtbLongDescription.EnableAutoDragDrop = true;
			this.rtbLongDescription.Location = new System.Drawing.Point(55, 104);
			this.rtbLongDescription.Name = "rtbLongDescription";
			this.rtbLongDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.rtbLongDescription.Size = new System.Drawing.Size(942, 186);
			this.rtbLongDescription.TabIndex = 42;
			this.rtbLongDescription.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(898, 296);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 23);
			this.btnCancel.TabIndex = 44;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnNew
			// 
			this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNew.Location = new System.Drawing.Point(897, 296);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(100, 23);
			this.btnNew.TabIndex = 45;
			this.btnNew.Text = "New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// pnlEdit
			// 
			this.pnlEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlEdit.Controls.Add(this.btnSave);
			this.pnlEdit.Controls.Add(this.btnNew);
			this.pnlEdit.Controls.Add(this.btnCancel);
			this.pnlEdit.Controls.Add(this.rtbLongDescription);
			this.pnlEdit.Controls.Add(this.txtTaskId);
			this.pnlEdit.Controls.Add(this.cboPrioritySequence);
			this.pnlEdit.Controls.Add(this.label1);
			this.pnlEdit.Controls.Add(this.label7);
			this.pnlEdit.Controls.Add(this.label3);
			this.pnlEdit.Controls.Add(this.cboAssignedToName);
			this.pnlEdit.Controls.Add(this.dtpSubmitDt);
			this.pnlEdit.Controls.Add(this.dtpAssignedDate);
			this.pnlEdit.Controls.Add(this.label2);
			this.pnlEdit.Controls.Add(this.cboPriority);
			this.pnlEdit.Controls.Add(this.txtComponent);
			this.pnlEdit.Controls.Add(this.label10);
			this.pnlEdit.Controls.Add(this.txtShortDescription);
			this.pnlEdit.Controls.Add(this.label6);
			this.pnlEdit.Controls.Add(this.label4);
			this.pnlEdit.Controls.Add(this.label9);
			this.pnlEdit.Controls.Add(this.label5);
			this.pnlEdit.Controls.Add(this.txtSubmittedBy);
			this.pnlEdit.Controls.Add(this.label8);
			this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlEdit.Location = new System.Drawing.Point(0, 366);
			this.pnlEdit.Name = "pnlEdit";
			this.pnlEdit.Size = new System.Drawing.Size(1016, 327);
			this.pnlEdit.TabIndex = 46;
			// 
			// Issues
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 715);
			this.Controls.Add(this.pnlEdit);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Issues";
			this.Text = "Issues";
			this.Load += new System.EventHandler(this.Form_Load);
			this.Controls.SetChildIndex(this.pnlEdit, 0);
			this.Controls.SetChildIndex(this.Grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.FormSettings)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._bsIssue)).EndInit();
			this.pnlEdit.ResumeLayout(false);
			this.pnlEdit.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.DateTimePicker dtpAssignedDate;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cboAssignedToName;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSubmittedBy;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cboPrioritySequence;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cboPriority;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtShortDescription;
		private System.Windows.Forms.DateTimePicker dtpSubmitDt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtComponent;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTaskId;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.RichTextBox rtbLongDescription;
		private System.Windows.Forms.BindingSource _bsIssue;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Panel pnlEdit;




	}
}

