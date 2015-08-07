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
            this.pnlTimerBehindColor.BackColor = Settings.Default.TimerBehindColor;
            this.pnlTimerPausedColor.BackColor = Settings.Default.TimerPausedColor;

            this.pnlSplitsBackgroundColor.BackColor = Settings.Default.SplitsBackgroundColor;
            this.pnlCurrentSegmentColor.BackColor = Settings.Default.CurrentSegmentColor;
            this.lblSplitTimesFontName.Text = Settings.Default.SplitTimesFont.FontFamily.Name;
            this.pnlSplitTimesColor.BackColor = Settings.Default.SplitTimesColor;
            this.lblSplitNamesFontName.Text = Settings.Default.SplitNamesFont.FontFamily.Name;
            this.pnlSplitNameColor.BackColor = Settings.Default.SplitNamesColor;

            this.lblSplitDeltasFontName.Text = Settings.Default.SplitDeltasFont.FontFamily.Name;
            this.pnlSplitDeltaAheadSavingColor.BackColor = Settings.Default.SplitDeltasAheadSavingColor;
            this.pnlSplitDeltaAheadLosingColor.BackColor = Settings.Default.SplitDeltasAheadLosingColor;
            this.pnlSplitDeltaBehindSavingColor.BackColor = Settings.Default.SplitDeltasBehindSavingColor;
            this.pnlSplitDeltaBehindLosingColor.BackColor = Settings.Default.SplitDeltasBehindLosingColor;
            this.pnlSplitDeltaBestSegmentColor.BackColor = Settings.Default.SplitDeltasBestSegmentColor;

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

        private void pnlTimerBehindColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerBehindColor = colorDialog.Color;
                this.pnlTimerBehindColor.BackColor = Settings.Default.TimerBehindColor;
            }
        }

        private void pnlTimerPausedColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerPausedColor = colorDialog.Color;
                this.pnlTimerPausedColor.BackColor = Settings.Default.TimerPausedColor;
            }
        }

        private void pnlSplitsBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitsBackgroundColor = colorDialog.Color;
                this.pnlSplitsBackgroundColor.BackColor = Settings.Default.SplitsBackgroundColor;
            }
        }

        private void pnlCurrentSegmentColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.CurrentSegmentColor = colorDialog.Color;
                this.pnlCurrentSegmentColor.BackColor = Settings.Default.CurrentSegmentColor;
            }
        }

        private void btnChooseSplitTimesFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitTimesFont = fontDialog.Font;
                this.lblSplitTimesFontName.Text = Settings.Default.SplitTimesFont.FontFamily.Name;
            }
        }

        private void pnlSplitTimesColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitTimesColor = colorDialog.Color;
                this.pnlSplitTimesColor.BackColor = Settings.Default.SplitTimesColor;
            }
        }

        private void btnChooseSplitNamesFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitNamesFont = fontDialog.Font;
                this.lblSplitNamesFontName.Text = Settings.Default.SplitNamesFont.FontFamily.Name;
            }
        }

        private void pnlSplitNameColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitNamesColor = colorDialog.Color;
                this.pnlSplitNameColor.BackColor = Settings.Default.SplitNamesColor;
            }
        }

        private void btnChooseSplitDeltasFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasFont = fontDialog.Font;
                this.lblSplitDeltasFontName.Text = Settings.Default.SplitDeltasFont.FontFamily.Name;
            }
        }

        private void pnlSplitDeltaAheadSavingColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasAheadSavingColor = colorDialog.Color;
                this.pnlSplitDeltaAheadSavingColor.BackColor = Settings.Default.SplitDeltasAheadSavingColor;
            }
        }

        private void pnlSplitDeltaAheadLosingColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasAheadLosingColor = colorDialog.Color;
                this.pnlSplitDeltaAheadLosingColor.BackColor = Settings.Default.SplitDeltasAheadLosingColor;
            }
        }

        private void pnlSplitDeltaBehindSavingColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBehindSavingColor = colorDialog.Color;
                this.pnlSplitDeltaBehindSavingColor.BackColor = Settings.Default.SplitDeltasBehindSavingColor;
            }
        }

        private void pnlSplitDeltaBehindLosingColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBehindLosingColor = colorDialog.Color;
                this.pnlSplitDeltaBehindLosingColor.BackColor = Settings.Default.SplitDeltasBehindLosingColor;
            }
        }

        private void pnlSplitDeltaBestSegmentColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBestSegmentColor = colorDialog.Color;
                this.pnlSplitDeltaBestSegmentColor.BackColor = Settings.Default.SplitDeltasBestSegmentColor;
            }
        }
    }
}
