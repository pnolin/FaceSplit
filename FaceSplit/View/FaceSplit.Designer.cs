namespace FaceSplit
{
    partial class FaceSplit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceSplit));
            this.ticksTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMnuPrincipal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveRunAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveLayoutAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResetLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCloseSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // ticksTimer
            // 
            this.ticksTimer.Interval = 10;
            this.ticksTimer.Tick += new System.EventHandler(this.TimerTicks);
            // 
            // contextMnuPrincipal
            // 
            this.contextMnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditRun,
            this.toolStripMenuItem1,
            this.mnuSaveRun,
            this.mnuSaveRunAs,
            this.mnuLoadRun,
            this.toolStripMenuItem2,
            this.mnuEditLayout,
            this.mnuSaveLayout,
            this.mnuSaveLayoutAs,
            this.loadLayoutToolStripMenuItem,
            this.mnuResetLayout,
            this.toolStripMenuItem3,
            this.mnuCloseSplit,
            this.mnuExit});
            this.contextMnuPrincipal.Name = "contextMnuPrincipal";
            this.contextMnuPrincipal.Size = new System.Drawing.Size(153, 286);
            // 
            // mnuEditRun
            // 
            this.mnuEditRun.Name = "mnuEditRun";
            this.mnuEditRun.Size = new System.Drawing.Size(152, 22);
            this.mnuEditRun.Text = "New / Edit run";
            this.mnuEditRun.Click += new System.EventHandler(this.mnuEditRun_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuSaveRun
            // 
            this.mnuSaveRun.Name = "mnuSaveRun";
            this.mnuSaveRun.Size = new System.Drawing.Size(152, 22);
            this.mnuSaveRun.Text = "Save run";
            this.mnuSaveRun.Click += new System.EventHandler(this.mnuSaveRun_Click);
            // 
            // mnuSaveRunAs
            // 
            this.mnuSaveRunAs.Name = "mnuSaveRunAs";
            this.mnuSaveRunAs.Size = new System.Drawing.Size(152, 22);
            this.mnuSaveRunAs.Text = "Save run as";
            this.mnuSaveRunAs.Click += new System.EventHandler(this.mnuSaveRunAs_Click);
            // 
            // mnuLoadRun
            // 
            this.mnuLoadRun.Name = "mnuLoadRun";
            this.mnuLoadRun.Size = new System.Drawing.Size(152, 22);
            this.mnuLoadRun.Text = "Load run";
            this.mnuLoadRun.Click += new System.EventHandler(this.mnuLoadRun_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuEditLayout
            // 
            this.mnuEditLayout.Name = "mnuEditLayout";
            this.mnuEditLayout.Size = new System.Drawing.Size(152, 22);
            this.mnuEditLayout.Text = "Edit layout";
            this.mnuEditLayout.Click += new System.EventHandler(this.mnuEditLayout_Click);
            // 
            // mnuSaveLayout
            // 
            this.mnuSaveLayout.Name = "mnuSaveLayout";
            this.mnuSaveLayout.Size = new System.Drawing.Size(152, 22);
            this.mnuSaveLayout.Text = "Save layout";
            this.mnuSaveLayout.Click += new System.EventHandler(this.mnuSaveLayout_Click);
            // 
            // mnuSaveLayoutAs
            // 
            this.mnuSaveLayoutAs.Name = "mnuSaveLayoutAs";
            this.mnuSaveLayoutAs.Size = new System.Drawing.Size(152, 22);
            this.mnuSaveLayoutAs.Text = "Save layout as";
            this.mnuSaveLayoutAs.Click += new System.EventHandler(this.mnuSaveLayoutAs_Click);
            // 
            // mnuResetLayout
            // 
            this.mnuResetLayout.Name = "mnuResetLayout";
            this.mnuResetLayout.Size = new System.Drawing.Size(152, 22);
            this.mnuResetLayout.Text = "Reset layout";
            this.mnuResetLayout.Click += new System.EventHandler(this.mnuResetLayout_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuCloseSplit
            // 
            this.mnuCloseSplit.Name = "mnuCloseSplit";
            this.mnuCloseSplit.Size = new System.Drawing.Size(152, 22);
            this.mnuCloseSplit.Text = "Close split";
            this.mnuCloseSplit.Click += new System.EventHandler(this.mnuCloseSplit_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // loadLayoutToolStripMenuItem
            // 
            this.loadLayoutToolStripMenuItem.Name = "loadLayoutToolStripMenuItem";
            this.loadLayoutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadLayoutToolStripMenuItem.Text = "Load layout";
            this.loadLayoutToolStripMenuItem.Click += new System.EventHandler(this.loadLayoutToolStripMenuItem_Click);
            // 
            // FaceSplit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.ContextMenuStrip = this.contextMnuPrincipal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FaceSplit";
            this.Text = "FaceSplit";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FaceSplit_MouseDown);
            this.contextMnuPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ticksTimer;
        private System.Windows.Forms.ContextMenuStrip contextMnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuEditRun;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuCloseSplit;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveRun;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadRun;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveRunAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuEditLayout;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuResetLayout;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveLayout;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveLayoutAs;
        private System.Windows.Forms.ToolStripMenuItem loadLayoutToolStripMenuItem;
    }
}

