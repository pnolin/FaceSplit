namespace FaceSplit
{
    partial class RunEditor
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunEditor));
            this.lblRunTitle = new System.Windows.Forms.Label();
            this.txtRunTitle = new System.Windows.Forms.TextBox();
            this.txtRunGoal = new System.Windows.Forms.TextBox();
            this.lblRunGoal = new System.Windows.Forms.Label();
            this.txtAttemptsCount = new System.Windows.Forms.TextBox();
            this.lblAttemptsCount = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.contextMenuImport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuImportFromLivesplit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.segmentsGridView = new System.Windows.Forms.DataGridView();
            this.SegmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SplitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SegmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BestSegment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.segmentsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRunTitle
            // 
            this.lblRunTitle.AutoSize = true;
            this.lblRunTitle.Location = new System.Drawing.Point(13, 13);
            this.lblRunTitle.Name = "lblRunTitle";
            this.lblRunTitle.Size = new System.Drawing.Size(49, 13);
            this.lblRunTitle.TabIndex = 0;
            this.lblRunTitle.Text = "Run title:";
            // 
            // txtRunTitle
            // 
            this.txtRunTitle.Location = new System.Drawing.Point(16, 30);
            this.txtRunTitle.Name = "txtRunTitle";
            this.txtRunTitle.Size = new System.Drawing.Size(285, 20);
            this.txtRunTitle.TabIndex = 1;
            // 
            // txtRunGoal
            // 
            this.txtRunGoal.Location = new System.Drawing.Point(307, 30);
            this.txtRunGoal.Name = "txtRunGoal";
            this.txtRunGoal.Size = new System.Drawing.Size(123, 20);
            this.txtRunGoal.TabIndex = 2;
            // 
            // lblRunGoal
            // 
            this.lblRunGoal.AutoSize = true;
            this.lblRunGoal.Location = new System.Drawing.Point(304, 13);
            this.lblRunGoal.Name = "lblRunGoal";
            this.lblRunGoal.Size = new System.Drawing.Size(32, 13);
            this.lblRunGoal.TabIndex = 3;
            this.lblRunGoal.Text = "Goal:";
            // 
            // txtAttemptsCount
            // 
            this.txtAttemptsCount.Location = new System.Drawing.Point(369, 159);
            this.txtAttemptsCount.Name = "txtAttemptsCount";
            this.txtAttemptsCount.Size = new System.Drawing.Size(61, 20);
            this.txtAttemptsCount.TabIndex = 5;
            this.txtAttemptsCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAttemptsCount_KeyPress);
            // 
            // lblAttemptsCount
            // 
            this.lblAttemptsCount.AutoSize = true;
            this.lblAttemptsCount.Location = new System.Drawing.Point(312, 162);
            this.lblAttemptsCount.Name = "lblAttemptsCount";
            this.lblAttemptsCount.Size = new System.Drawing.Size(51, 13);
            this.lblAttemptsCount.TabIndex = 6;
            this.lblAttemptsCount.Text = "Attempts:";
            // 
            // btnImport
            // 
            this.btnImport.ContextMenuStrip = this.contextMenuImport;
            this.btnImport.Location = new System.Drawing.Point(174, 108);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 25);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "\"Import... ▼\"";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // contextMenuImport
            // 
            this.contextMenuImport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportFromLivesplit});
            this.contextMenuImport.Name = "contextMenuImport";
            this.contextMenuImport.Size = new System.Drawing.Size(187, 26);
            // 
            // mnuImportFromLivesplit
            // 
            this.mnuImportFromLivesplit.Name = "mnuImportFromLivesplit";
            this.mnuImportFromLivesplit.Size = new System.Drawing.Size(186, 22);
            this.mnuImportFromLivesplit.Text = "Import from LiveSplit";
            this.mnuImportFromLivesplit.Click += new System.EventHandler(this.mnuImportFromLivesplit_Click);
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(330, 108);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(100, 25);
            this.btnFill.TabIndex = 8;
            this.btnFill.Text = "Fill segments time";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(17, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(17, 108);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 25);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "Insert segment";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // segmentsGridView
            // 
            this.segmentsGridView.AllowUserToAddRows = false;
            this.segmentsGridView.AllowUserToDeleteRows = false;
            this.segmentsGridView.AllowUserToResizeColumns = false;
            this.segmentsGridView.AllowUserToResizeRows = false;
            this.segmentsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.segmentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.segmentsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SegmentName,
            this.SplitTime,
            this.SegmentTime,
            this.BestSegment});
            this.segmentsGridView.Location = new System.Drawing.Point(16, 56);
            this.segmentsGridView.Name = "segmentsGridView";
            this.segmentsGridView.RowHeadersVisible = false;
            this.segmentsGridView.RowTemplate.Height = 28;
            this.segmentsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.segmentsGridView.Size = new System.Drawing.Size(416, 21);
            this.segmentsGridView.TabIndex = 12;
            // 
            // SegmentName
            // 
            this.SegmentName.HeaderText = "Segment name";
            this.SegmentName.Name = "SegmentName";
            this.SegmentName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SegmentName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SegmentName.Width = 112;
            // 
            // SplitTime
            // 
            this.SplitTime.HeaderText = "Split time";
            this.SplitTime.Name = "SplitTime";
            this.SplitTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SplitTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SegmentTime
            // 
            this.SegmentTime.HeaderText = "Segment time";
            this.SegmentTime.Name = "SegmentTime";
            this.SegmentTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SegmentTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // BestSegment
            // 
            this.BestSegment.HeaderText = "Best segment";
            this.BestSegment.Name = "BestSegment";
            this.BestSegment.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BestSegment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // RunEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 193);
            this.Controls.Add(this.segmentsGridView);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblAttemptsCount);
            this.Controls.Add(this.txtAttemptsCount);
            this.Controls.Add(this.lblRunGoal);
            this.Controls.Add(this.txtRunGoal);
            this.Controls.Add(this.txtRunTitle);
            this.Controls.Add(this.lblRunTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RunEditor";
            this.Text = "RunEditor";
            this.contextMenuImport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.segmentsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRunTitle;
        private System.Windows.Forms.TextBox txtRunTitle;
        private System.Windows.Forms.TextBox txtRunGoal;
        private System.Windows.Forms.Label lblRunGoal;
        private System.Windows.Forms.TextBox txtAttemptsCount;
        private System.Windows.Forms.Label lblAttemptsCount;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ContextMenuStrip contextMenuImport;
        private System.Windows.Forms.ToolStripMenuItem mnuImportFromLivesplit;
        private System.Windows.Forms.DataGridView segmentsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SplitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegmentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BestSegment;

    }
}