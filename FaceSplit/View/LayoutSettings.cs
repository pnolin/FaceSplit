using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FaceSplit.Properties;

namespace FaceSplit
{
    public partial class LayoutSettings : Form
    {
        private FontDialog fontDialog;
        private ColorDialog colorDialog;

        public LayoutSettings()
        {
            InitializeComponent();
            this.fontDialog = new FontDialog();
            colorDialog = new ColorDialog();
            this.lblTimerFontName.Text = Settings.Default.TimerFont.FontFamily.Name;
            this.btnTimerNotRunningColor.BackColor = Settings.Default.TimerNotRunningColor;
        }

        private void btnChooseTimerFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerFont = fontDialog.Font;
                this.lblTimerFontName.Text = Settings.Default.TimerFont.FontFamily.Name;
            }
        }

        private void btnTimerNotRunningColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerNotRunningColor = colorDialog.Color;
                this.btnTimerNotRunningColor.BackColor = Settings.Default.TimerNotRunningColor;
            }
        }
    }
}
