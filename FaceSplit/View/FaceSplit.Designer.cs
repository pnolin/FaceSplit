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
            this.ticksTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMnuPrincipal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditRun = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuExit});
            this.contextMnuPrincipal.Name = "contextMnuPrincipal";
            this.contextMnuPrincipal.Size = new System.Drawing.Size(154, 48);
            // 
            // mnuEditRun
            // 
            this.mnuEditRun.Name = "mnuEditRun";
            this.mnuEditRun.Size = new System.Drawing.Size(153, 22);
            this.mnuEditRun.Text = "New / Edit Run";
            this.mnuEditRun.Click += new System.EventHandler(this.mnuEditRun_Click);
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
            this.KeyPreview = true;
            this.Name = "FaceSplit";
            this.Text = "Form1";
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
    }
}

