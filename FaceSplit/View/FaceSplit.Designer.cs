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
            this.mnuSaveRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveRunAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadRun = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloseSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuSaveRun,
            this.mnuSaveRunAs,
            this.mnuLoadRun,
            this.mnuCloseSplit,
            this.mnuExit});
            this.contextMnuPrincipal.Name = "contextMnuPrincipal";
            this.contextMnuPrincipal.Size = new System.Drawing.Size(154, 136);
            // 
            // mnuEditRun
            // 
            this.mnuEditRun.Name = "mnuEditRun";
            this.mnuEditRun.Size = new System.Drawing.Size(153, 22);
            this.mnuEditRun.Text = "New / Edit Run";
            this.mnuEditRun.Click += new System.EventHandler(this.mnuEditRun_Click);
            // 
            // mnuSaveRun
            // 
            this.mnuSaveRun.Name = "mnuSaveRun";
            this.mnuSaveRun.Size = new System.Drawing.Size(153, 22);
            this.mnuSaveRun.Text = "Save run";
            this.mnuSaveRun.Click += new System.EventHandler(this.mnuSaveRun_Click);
            // 
            // mnuSaveRunAs
            // 
            this.mnuSaveRunAs.Name = "mnuSaveRunAs";
            this.mnuSaveRunAs.Size = new System.Drawing.Size(153, 22);
            this.mnuSaveRunAs.Text = "Save run as";
            this.mnuSaveRunAs.Click += new System.EventHandler(this.mnuSaveRunAs_Click);
            // 
            // mnuLoadRun
            // 
            this.mnuLoadRun.Name = "mnuLoadRun";
            this.mnuLoadRun.Size = new System.Drawing.Size(153, 22);
            this.mnuLoadRun.Text = "Load run";
            this.mnuLoadRun.Click += new System.EventHandler(this.mnuLoadRun_Click);
            // 
            // mnuCloseSplit
            // 
            this.mnuCloseSplit.Name = "mnuCloseSplit";
            this.mnuCloseSplit.Size = new System.Drawing.Size(153, 22);
            this.mnuCloseSplit.Text = "Close split";
            this.mnuCloseSplit.Click += new System.EventHandler(this.mnuCloseSplit_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(153, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
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
    }
}

