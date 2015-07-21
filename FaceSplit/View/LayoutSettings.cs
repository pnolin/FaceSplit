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
            this.pnlTimerBackgroundColor.BackColor = Settings.Default.TimerBackgroundColor;
            this.pnlTimerNotRunningColor.BackColor = Settings.Default.TimerNotRunningColor;
            this.pnlTimerRunningColor.BackColor = Settings.Default.TimerRunningColor;
        }

        private void btnChooseTimerFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerFont = fontDialog.Font;
                this.lblTimerFontName.Text = Settings.Default.TimerFont.FontFamily.Name;
            }
        }

        private void pnlTimerBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerBackgroundColor = colorDialog.Color;
                this.pnlTimerBackgroundColor.BackColor = Settings.Default.TimerBackgroundColor;
            }
        }

        private void pnlTimerNotRunningColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerNotRunningColor = colorDialog.Color;
                this.pnlTimerNotRunningColor.BackColor = Settings.Default.TimerNotRunningColor;
            }
        }

        private void pnlTimerRunningColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerRunningColor = colorDialog.Color;
                this.pnlTimerRunningColor.BackColor = Settings.Default.TimerRunningColor;
            }
        }


    }
}
