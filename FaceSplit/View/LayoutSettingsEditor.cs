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
            this.lblPossibleTimeSaveFontName.Text = Settings.Default.PossibleTimeSaveFont.FontFamily.Name;
            this.pnlPossibleTimeSaveColor.BackColor = Settings.Default.PossibleTimeSaveColor;

            this.pnlPredictedTimeBackgroundColor.BackColor = Settings.Default.PredictedTimeBackgroundColor;
            this.lblPredictedTimeTextFontName.Text = Settings.Default.PredictedTimeTextFont.FontFamily.Name;
            this.pnlPredictedTimeTextColor.BackColor = Settings.Default.PredictedTimeTextColor;
            this.lblPredictedTimeFontName.Text = Settings.Default.PredictedTimeFont.FontFamily.Name;
            this.pnlPredictedTimeColor.BackColor = Settings.Default.PredictedTimeColor;

            this.pnlSumOfBestBackgroundColor.BackColor = Settings.Default.SumOfBestBackgroundColor;
            this.lblSumOfBestTextFontName.Text = Settings.Default.SumOfBestTextFont.FontFamily.Name;
            this.pnlSumOfBestTextColor.BackColor = Settings.Default.SumOfBestTextColor;
            this.lblSumOfBestFontName.Text = Settings.Default.SumOfBestFont.FontFamily.Name;
            this.pnlSumOfBestColor.BackColor = Settings.Default.SumOfBestColor;

            this.pnlSegmentTimerBackgroundColor.BackColor = Settings.Default.SegmentTimerBackgroundColor;
            this.lblSegmentTimerPBFontName.Text = Settings.Default.SegmentTimerPBFont.FontFamily.Name;
            this.pnlSegmentTimerPBColor.BackColor = Settings.Default.SegmentTimerPBColor;
            this.lblSegmentTimerBestFontName.Text = Settings.Default.SegmentTimerBestFont.FontFamily.Name;
            this.pnlSegmentTimerBestColor.BackColor = Settings.Default.SegmentTimerBestColor;
            this.lblSegmentTimerFontName.Text = Settings.Default.SegmentTimerFont.FontFamily.Name;
            this.pnlSegmentTimerRunningColor.BackColor = Settings.Default.SegmentTimerRunningColor;
            this.pnlSegmentTimerLosingTimeColor.BackColor = Settings.Default.SegmentTimerLosingTimeColor;
            this.pnlSegmentTimerPausedColor.BackColor = Settings.Default.SegmentTimerPausedColor;
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
            colorDialog.Color = Settings.Default.TimerBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerBackgroundColor = colorDialog.Color;
                this.pnlTimerBackgroundColor.BackColor = Settings.Default.TimerBackgroundColor;
            }
        }

        private void pnlTimerNotRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerNotRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerNotRunningColor = colorDialog.Color;
                this.pnlTimerNotRunningColor.BackColor = Settings.Default.TimerNotRunningColor;
            }
        }

        private void pnlTimerRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerRunningColor = colorDialog.Color;
                this.pnlTimerRunningColor.BackColor = Settings.Default.TimerRunningColor;
            }
        }

        private void pnlTimerBehindColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerBehindColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerBehindColor = colorDialog.Color;
                this.pnlTimerBehindColor.BackColor = Settings.Default.TimerBehindColor;
            }
        }

        private void pnlTimerPausedColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerPausedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerPausedColor = colorDialog.Color;
                this.pnlTimerPausedColor.BackColor = Settings.Default.TimerPausedColor;
            }
        }

        private void pnlSplitsBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitsBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitsBackgroundColor = colorDialog.Color;
                this.pnlSplitsBackgroundColor.BackColor = Settings.Default.SplitsBackgroundColor;
            }
        }

        private void pnlCurrentSegmentColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.CurrentSegmentColor;
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
            colorDialog.Color = Settings.Default.SplitTimesColor;
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
            colorDialog.Color = Settings.Default.SplitNamesColor;
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
            colorDialog.Color = Settings.Default.SplitDeltasAheadSavingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasAheadSavingColor = colorDialog.Color;
                this.pnlSplitDeltaAheadSavingColor.BackColor = Settings.Default.SplitDeltasAheadSavingColor;
            }
        }

        private void pnlSplitDeltaAheadLosingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasAheadLosingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasAheadLosingColor = colorDialog.Color;
                this.pnlSplitDeltaAheadLosingColor.BackColor = Settings.Default.SplitDeltasAheadLosingColor;
            }
        }

        private void pnlSplitDeltaBehindSavingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasBehindSavingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBehindSavingColor = colorDialog.Color;
                this.pnlSplitDeltaBehindSavingColor.BackColor = Settings.Default.SplitDeltasBehindSavingColor;
            }
        }

        private void pnlSplitDeltaBehindLosingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasBehindLosingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBehindLosingColor = colorDialog.Color;
                this.pnlSplitDeltaBehindLosingColor.BackColor = Settings.Default.SplitDeltasBehindLosingColor;
            }
        }

        private void pnlSplitDeltaBestSegmentColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasBestSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBestSegmentColor = colorDialog.Color;
                this.pnlSplitDeltaBestSegmentColor.BackColor = Settings.Default.SplitDeltasBestSegmentColor;
            }
        }

        private void pnlTitleBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TitleBackgroundColor;
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
            colorDialog.Color = Settings.Default.TitleColor;
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
            colorDialog.Color = Settings.Default.AttemptsColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.AttemptsColor = colorDialog.Color;
                this.pnlAttemptsColor.BackColor = Settings.Default.AttemptsColor;
            }
        }

        private void pnlGoalBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.GoalBackgroundColor;
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
            colorDialog.Color = Settings.Default.GoalColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.GoalColor = colorDialog.Color;
                this.pnlGoalColor.BackColor = Settings.Default.GoalColor;
            }
        }

        private void pnlPreviousSegmentBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentBackgroundColor;
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
            colorDialog.Color = Settings.Default.PreviousSegmentTextColor;
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
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaSavedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaSavedColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaSavedColor.BackColor = Settings.Default.PreviousSegmentDeltaSavedColor;
            }
        }

        private void pnlPreviousSegmentDeltaLosingTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaLostColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaLostColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaLostColor.BackColor = Settings.Default.PreviousSegmentDeltaLostColor;
            }
        }

        private void pnlPreviousSegmentDeltaBestSegmentColors_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaBestSegmentColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaBestSegmentColor.BackColor = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
            }
        }

        private void pnlPreviousSegmentDeltaNoDeltaColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaNoDeltaColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaNoDeltaColor = colorDialog.Color;
                this.pnlPreviousSegmentDeltaNoDeltaColor.BackColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor;
            }
        }

        private void pnlPossibleTimeSaveBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PossibleTimeSaveBackgroundColor;
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
            colorDialog.Color = Settings.Default.PossibleTimeSaveTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveTextColor = colorDialog.Color;
                this.pnlPossibleTimeSaveTextColor.BackColor = Settings.Default.PossibleTimeSaveTextColor;
            }
        }

        private void btnChoosePossibleTimeSaveFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PossibleTimeSaveFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveFont = fontDialog.Font;
                this.lblPossibleTimeSaveFontName.Text = Settings.Default.PossibleTimeSaveFont.FontFamily.Name;
            }
        }

        private void pnlPossibleTimeSaveColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PossibleTimeSaveColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveColor = colorDialog.Color;
                this.pnlPossibleTimeSaveColor.BackColor = Settings.Default.PossibleTimeSaveColor;
            }
        }

        private void pnlPredictedTimeBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PossibleTimeSaveColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeBackgroundColor = colorDialog.Color;
                this.pnlPredictedTimeBackgroundColor.BackColor = Settings.Default.PredictedTimeBackgroundColor;
            }
        }

        private void btnChoosePredictedTimeTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PredictedTimeTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeTextFont = fontDialog.Font;
                this.lblPredictedTimeTextFontName.Text = Settings.Default.PredictedTimeTextFont.FontFamily.Name;
            }
        }

        private void pnlPredictedTimeTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PredictedTimeTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeTextColor = colorDialog.Color;
                this.pnlPredictedTimeTextColor.BackColor = Settings.Default.PredictedTimeTextColor;
            }
        }

        private void btnChoosePredictedTimeFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PredictedTimeFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeFont = fontDialog.Font;
                this.lblPredictedTimeFontName.Text = Settings.Default.PredictedTimeFont.FontFamily.Name;
            }
        }

        private void pnlPredictedTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PredictedTimeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeColor = colorDialog.Color;
                this.pnlPredictedTimeColor.BackColor = Settings.Default.PredictedTimeColor;
            }
        }

        private void pnlSumOfBestBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SumOfBestBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestBackgroundColor = colorDialog.Color;
                this.pnlSumOfBestBackgroundColor.BackColor = Settings.Default.SumOfBestBackgroundColor;
            }
        }

        private void btnChooseSumOfBestTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SumOfBestTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestTextFont = fontDialog.Font;
                this.lblSumOfBestTextFontName.Text = Settings.Default.SumOfBestTextFont.FontFamily.Name;
            }
        }

        private void pnlSumOfBestTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SumOfBestTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestTextColor = colorDialog.Color;
                this.pnlSumOfBestTextColor.BackColor = Settings.Default.SumOfBestTextColor;
            }
        }

        private void btnChooseSumOfBestFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SumOfBestFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestFont = fontDialog.Font;
                this.lblSumOfBestFontName.Text = Settings.Default.SumOfBestFont.FontFamily.Name;
            }
        }

        private void pnlSumOfBestColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SumOfBestColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestColor = colorDialog.Color;
                this.pnlSumOfBestColor.BackColor = Settings.Default.SumOfBestColor;
            }
        }

        private void pnlSegmentTimerBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerBackgroundColor = colorDialog.Color;
                this.pnlSegmentTimerBackgroundColor.BackColor = Settings.Default.SegmentTimerBackgroundColor;
            }
        }

        private void btnChooseSegmentTimerPBFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SegmentTimerPBFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerPBFont = fontDialog.Font;
                this.lblSegmentTimerPBFontName.Text = Settings.Default.SegmentTimerPBFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerPBColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerPBColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerPBColor = colorDialog.Color;
                this.pnlSegmentTimerPBColor.BackColor = Settings.Default.SegmentTimerPBColor;
            }
        }

        private void btnChooseSegmentTimerBestFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SegmentTimerBestFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerBestFont = fontDialog.Font;
                this.lblSegmentTimerBestFontName.Text = Settings.Default.SegmentTimerBestFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerBestColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerBestColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerBestColor = colorDialog.Color;
                this.pnlSegmentTimerBestColor.BackColor = Settings.Default.SegmentTimerBestColor;
            }
        }

        private void btnChooseSegmentTimerFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SegmentTimerFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerFont = fontDialog.Font;
                this.lblSegmentTimerFontName.Text = Settings.Default.SegmentTimerFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerRunningColor = colorDialog.Color;
                this.pnlSegmentTimerRunningColor.BackColor = Settings.Default.SegmentTimerRunningColor;
            }
        }

        private void pnlSegmentTimerLosingTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerLosingTimeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerLosingTimeColor = colorDialog.Color;
                this.pnlSegmentTimerLosingTimeColor.BackColor = Settings.Default.SegmentTimerLosingTimeColor;
            }
        }

        private void pnlSegmentTimerPausedColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerPausedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerPausedColor = colorDialog.Color;
                this.pnlSegmentTimerPausedColor.BackColor = Settings.Default.SegmentTimerPausedColor;
            }
        }
    }
}
