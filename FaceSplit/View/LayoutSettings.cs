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

            this.pnlTitleBackgroundColor.BackColor = Settings.Default.TitleBackgroundColor;
            this.lblTitleFontName.Text = Settings.Default.TitleFont.FontFamily.Name;
            this.pnlTitleColor.BackColor = Settings.Default.TitleColor;

            this.lblAttemptsFontName.Text = Settings.Default.AttemptsFont.FontFamily.Name;
            this.pnlAttemptsColor.BackColor = Settings.Default.AttemptsColor;

            this.pnlGoalBackgroundColor.BackColor = Settings.Default.GoalBackgroundColor;
            this.lblGoalFontName.Text = Settings.Default.GoalFont.FontFamily.Name;
            this.pnlGoalColor.BackColor = Settings.Default.GoalColor;

            this.pnlPreviousSegmentBackgroundColor.BackColor = Settings.Default.PreviousSegmentBackgroundColor;
            this.lblPreviousSegmentTextFontName.Text = Settings.Default.PreviousSegmentTextFont.FontFamily.Name;
            this.pnlPreviousSegmentTextColor.BackColor = Settings.Default.PreviousSegmentTextColor;

            this.lblPreviousSegmentDeltaFontName.Text = Settings.Default.PreviousSegmentDeltaFont.FontFamily.Name;
            this.pnlPreviousSegmentDeltaSavedColor.BackColor = Settings.Default.PreviousSegmentDeltaSavedColor;
            this.pnlPreviousSegmentDeltaLostColor.BackColor = Settings.Default.PreviousSegmentDeltaLostColor;
            this.pnlPreviousSegmentDeltaBestSegmentColor.BackColor = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
            this.pnlPreviousSegmentDeltaNoDeltaColor.BackColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor;

            this.pnlPossibleTimeSaveBackgroundColor.BackColor = Settings.Default.PossibleTimeSaveBackgroundColor;
            this.lblPossibleTimeSaveTextFontName.Text = Settings.Default.PossibleTimeSaveTextFont.FontFamily.Name;
            this.pnlPossibleTimeSaveTextColor.BackColor = Settings.Default.PossibleTimeSaveTextColor;
        }

        private void btnChooseTimerFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.TimerFont;
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
            fontDialog.Font = Settings.Default.SplitTimesFont;
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
            fontDialog.Font = Settings.Default.SplitNamesFont;
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
            fontDialog.Font = Settings.Default.SplitDeltasFont;
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

        private void pnlTitleBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TitleBackgroundColor = colorDialog.Color;
                this.pnlTitleBackgroundColor.BackColor = Settings.Default.TitleBackgroundColor;
            }
        }

        private void btnChooseTitleFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.TitleFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TitleFont = fontDialog.Font;
                this.lblTitleFontName.Text = Settings.Default.TitleFont.FontFamily.Name;
            }
        }

        private void pnlTitleColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TitleColor = colorDialog.Color;
                this.pnlTitleColor.BackColor = Settings.Default.TitleColor;
            }
        }

        private void btnChooseAttemptsFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.AttemptsFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.AttemptsFont = fontDialog.Font;
                this.lblAttemptsFontName.Text = Settings.Default.AttemptsFont.FontFamily.Name;
            }
        }

        private void pnlAttemptsColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.AttemptsColor = colorDialog.Color;
                this.pnlAttemptsColor.BackColor = Settings.Default.AttemptsColor;
            }
        }

        private void pnlGoalBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.GoalBackgroundColor = colorDialog.Color;
                this.pnlGoalBackgroundColor.BackColor = Settings.Default.GoalBackgroundColor;
            }
        }

        private void btnChooseGoalFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.GoalFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.GoalFont = fontDialog.Font;
                this.lblGoalFontName.Text = Settings.Default.GoalFont.FontFamily.Name;
            }
        }

        private void pnlGoalColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.GoalColor = colorDialog.Color;
                this.pnlGoalColor.BackColor = Settings.Default.GoalColor;
            }
        }

        private void pnlPreviousSegmentBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentBackgroundColor = colorDialog.Color;
                this.pnlPreviousSegmentBackgroundColor.BackColor = Settings.Default.PreviousSegmentBackgroundColor;
            }
        }

        private void btnChoosePreviousSegmentTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PreviousSegmentTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentTextFont = fontDialog.Font;
                this.lblPreviousSegmentTextFontName.Text = Settings.Default.PreviousSegmentTextFont.FontFamily.Name;
            }
        }

        private void pnlPreviousSegmentTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentTextColor = colorDialog.Color;
                this.pnlPreviousSegmentTextColor.BackColor = Settings.Default.PreviousSegmentTextColor;
            }
        }

        private void btnChoosePreviousSegmentDeltaFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PreviousSegmentDeltaFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaFont = fontDialog.Font;
                this.lblPreviousSegmentDeltaFontName.Text = Settings.Default.PreviousSegmentDeltaFont.FontFamily.Name;
            }
        }

        private void pnlPreviousSegmentDeltaSavedTimeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaSavedColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaSavedColor.BackColor = Settings.Default.PreviousSegmentDeltaSavedColor;
            }
        }

        private void pnlPreviousSegmentDeltaLosingTimeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaLostColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaLostColor.BackColor = Settings.Default.PreviousSegmentDeltaLostColor;
            }
        }

        private void pnlPreviousSegmentDeltaBestSegmentColors_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaBestSegmentColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaBestSegmentColor.BackColor = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
            }
        }

        private void pnlPreviousSegmentDeltaNoDeltaColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaNoDeltaColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaNoDeltaColor.BackColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor;
            }
        }

        private void pnlPossibleTimeSaveBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveBackgroundColor = colorDialog.Color;
                this.pnlPossibleTimeSaveBackgroundColor.BackColor = Settings.Default.PossibleTimeSaveBackgroundColor;
            }
        }

        private void btnChoosePossibleTimeSaveTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PossibleTimeSaveTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveTextFont = fontDialog.Font;
                this.lblPossibleTimeSaveTextFontName.Text = Settings.Default.PossibleTimeSaveTextFont.FontFamily.Name;
            }
        }

        private void pnlPossibleTimeSaveTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveTextColor = colorDialog.Color;
                this.pnlPossibleTimeSaveTextColor.BackColor = Settings.Default.PossibleTimeSaveTextColor;
            }
        }
    }
}
