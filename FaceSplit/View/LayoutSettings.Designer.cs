namespace FaceSplit
{
    partial class LayoutSettings
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
            this.tabLayoutSettings = new System.Windows.Forms.TabControl();
            this.tabLayoutTimer = new System.Windows.Forms.TabPage();
            this.btnChooseTimerFont = new System.Windows.Forms.Button();
            this.lblTimerFontName = new System.Windows.Forms.Label();
            this.lblTimerFont = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gboTimerColors = new System.Windows.Forms.GroupBox();
            this.lblTimerNotRunningColor = new System.Windows.Forms.Label();
            this.btnTimerNotRunningColor = new System.Windows.Forms.Button();
            this.tabLayoutSettings.SuspendLayout();
            this.tabLayoutTimer.SuspendLayout();
            this.gboTimerColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLayoutSettings
            // 
            this.tabLayoutSettings.Controls.Add(this.tabLayoutTimer);
            this.tabLayoutSettings.Controls.Add(this.tabPage2);
            this.tabLayoutSettings.Location = new System.Drawing.Point(1, 1);
            this.tabLayoutSettings.Name = "tabLayoutSettings";
            this.tabLayoutSettings.SelectedIndex = 0;
            this.tabLayoutSettings.Size = new System.Drawing.Size(284, 261);
            this.tabLayoutSettings.TabIndex = 0;
            // 
            // tabLayoutTimer
            // 
            this.tabLayoutTimer.Controls.Add(this.gboTimerColors);
            this.tabLayoutTimer.Controls.Add(this.btnChooseTimerFont);
            this.tabLayoutTimer.Controls.Add(this.lblTimerFontName);
            this.tabLayoutTimer.Controls.Add(this.lblTimerFont);
            this.tabLayoutTimer.Location = new System.Drawing.Point(4, 22);
            this.tabLayoutTimer.Name = "tabLayoutTimer";
            this.tabLayoutTimer.Padding = new System.Windows.Forms.Padding(3);
            this.tabLayoutTimer.Size = new System.Drawing.Size(276, 235);
            this.tabLayoutTimer.TabIndex = 0;
            this.tabLayoutTimer.Text = "Timer";
            this.tabLayoutTimer.UseVisualStyleBackColor = true;
            // 
            // btnChooseTimerFont
            // 
            this.btnChooseTimerFont.Location = new System.Drawing.Point(143, 2);
            this.btnChooseTimerFont.Name = "btnChooseTimerFont";
            this.btnChooseTimerFont.Size = new System.Drawing.Size(75, 23);
            this.btnChooseTimerFont.TabIndex = 2;
            this.btnChooseTimerFont.Text = "Choose...";
            this.btnChooseTimerFont.UseVisualStyleBackColor = true;
            this.btnChooseTimerFont.Click += new System.EventHandler(this.btnChooseTimerFont_Click);
            // 
            // lblTimerFontName
            // 
            this.lblTimerFontName.AutoSize = true;
            this.lblTimerFontName.Location = new System.Drawing.Point(45, 7);
            this.lblTimerFontName.Name = "lblTimerFontName";
            this.lblTimerFontName.Size = new System.Drawing.Size(53, 13);
            this.lblTimerFontName.TabIndex = 1;
            this.lblTimerFontName.Text = "fontName";
            // 
            // lblTimerFont
            // 
            this.lblTimerFont.AutoSize = true;
            this.lblTimerFont.Location = new System.Drawing.Point(8, 7);
            this.lblTimerFont.Name = "lblTimerFont";
            this.lblTimerFont.Size = new System.Drawing.Size(31, 13);
            this.lblTimerFont.TabIndex = 0;
            this.lblTimerFont.Text = "Font:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(276, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gboTimerColors
            // 
            this.gboTimerColors.Controls.Add(this.btnTimerNotRunningColor);
            this.gboTimerColors.Controls.Add(this.lblTimerNotRunningColor);
            this.gboTimerColors.Location = new System.Drawing.Point(11, 31);
            this.gboTimerColors.Name = "gboTimerColors";
            this.gboTimerColors.Size = new System.Drawing.Size(200, 196);
            this.gboTimerColors.TabIndex = 3;
            this.gboTimerColors.TabStop = false;
            this.gboTimerColors.Text = "Colors";
            // 
            // lblTimerNotRunningColor
            // 
            this.lblTimerNotRunningColor.AutoSize = true;
            this.lblTimerNotRunningColor.Location = new System.Drawing.Point(7, 20);
            this.lblTimerNotRunningColor.Name = "lblTimerNotRunningColor";
            this.lblTimerNotRunningColor.Size = new System.Drawing.Size(65, 13);
            this.lblTimerNotRunningColor.TabIndex = 0;
            this.lblTimerNotRunningColor.Text = "Not running:";
            // 
            // btnTimerNotRunningColor
            // 
            this.btnTimerNotRunningColor.BackColor = System.Drawing.Color.White;
            this.btnTimerNotRunningColor.ForeColor = System.Drawing.Color.White;
            this.btnTimerNotRunningColor.Location = new System.Drawing.Point(78, 19);
            this.btnTimerNotRunningColor.Name = "btnTimerNotRunningColor";
            this.btnTimerNotRunningColor.Size = new System.Drawing.Size(20, 20);
            this.btnTimerNotRunningColor.TabIndex = 1;
            this.btnTimerNotRunningColor.UseVisualStyleBackColor = false;
            this.btnTimerNotRunningColor.Click += new System.EventHandler(this.btnTimerNotRunningColor_Click);
            // 
            // LayoutSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 262);
            this.Controls.Add(this.tabLayoutSettings);
            this.Name = "LayoutSettings";
            this.Text = "Layout Settings";
            this.tabLayoutSettings.ResumeLayout(false);
            this.tabLayoutTimer.ResumeLayout(false);
            this.tabLayoutTimer.PerformLayout();
            this.gboTimerColors.ResumeLayout(false);
            this.gboTimerColors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabLayoutSettings;
        private System.Windows.Forms.TabPage tabLayoutTimer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTimerFont;
        private System.Windows.Forms.Button btnChooseTimerFont;
        private System.Windows.Forms.Label lblTimerFontName;
        private System.Windows.Forms.GroupBox gboTimerColors;
        private System.Windows.Forms.Label lblTimerNotRunningColor;
        private System.Windows.Forms.Button btnTimerNotRunningColor;
    }
}