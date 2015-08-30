using System;
using System.Windows.Forms;
using FaceSplit.Properties;

namespace FaceSplit
{
    public partial class LayoutSettingsEditor : Form
    {
        private FontDialog fontDialog;
        private ColorDialog colorDialog;

        public LayoutSettingsEditor()
        {
            InitializeComponent();
            fontDialog = new FontDialog();
            colorDialog = new ColorDialog();
            lblTimerFontName.Text = SettingsLayout.Default.TimerFont.FontFamily.Name;
            pnlTimerBackgroundColor.BackColor = SettingsLayout.Default.TimerBackgroundColor;
            pnlTimerNotRunningColor.BackColor = SettingsLayout.Default.TimerNotRunningColor;
            pnlTimerRunningColor.BackColor = SettingsLayout.Default.TimerRunningColor;
            pnlTimerBehindColor.BackColor = SettingsLayout.Default.TimerBehindColor;
            pnlTimerPausedColor.BackColor = SettingsLayout.Default.TimerPausedColor;

            pnlSplitsBackgroundColor.BackColor = SettingsLayout.Default.SplitsBackgroundColor;
            pnlCurrentSegmentColor.BackColor = SettingsLayout.Default.CurrentSegmentColor;
            lblSplitTimesFontName.Text = SettingsLayout.Default.SplitTimesFont.FontFamily.Name;
            pnlSplitTimesColor.BackColor = SettingsLayout.Default.SplitTimesColor;
            lblSplitNamesFontName.Text = SettingsLayout.Default.SplitNamesFont.FontFamily.Name;
            pnlSplitNameColor.BackColor = SettingsLayout.Default.SplitNamesColor;

            lblSplitDeltasFontName.Text = SettingsLayout.Default.SplitDeltasFont.FontFamily.Name;
            pnlSplitDeltaAheadSavingColor.BackColor = SettingsLayout.Default.SplitDeltasAheadSavingColor;
            pnlSplitDeltaAheadLosingColor.BackColor = SettingsLayout.Default.SplitDeltasAheadLosingColor;
            pnlSplitDeltaBehindSavingColor.BackColor = SettingsLayout.Default.SplitDeltasBehindSavingColor;
            pnlSplitDeltaBehindLosingColor.BackColor = SettingsLayout.Default.SplitDeltasBehindLosingColor;
            pnlSplitDeltaBestSegmentColor.BackColor = SettingsLayout.Default.SplitDeltasBestSegmentColor;

            pnlTitleBackgroundColor.BackColor = SettingsLayout.Default.TitleBackgroundColor;
            lblTitleFontName.Text = SettingsLayout.Default.TitleFont.FontFamily.Name;
            pnlTitleColor.BackColor = SettingsLayout.Default.TitleColor;

            lblAttemptsFontName.Text = SettingsLayout.Default.AttemptsFont.FontFamily.Name;
            pnlAttemptsColor.BackColor = SettingsLayout.Default.AttemptsColor;

            pnlGoalBackgroundColor.BackColor = SettingsLayout.Default.GoalBackgroundColor;
            lblGoalFontName.Text = SettingsLayout.Default.GoalFont.FontFamily.Name;
            pnlGoalColor.BackColor = SettingsLayout.Default.GoalColor;

            pnlPreviousSegmentBackgroundColor.BackColor = SettingsLayout.Default.PreviousSegmentBackgroundColor;
            lblPreviousSegmentTextFontName.Text = SettingsLayout.Default.PreviousSegmentTextFont.FontFamily.Name;
            pnlPreviousSegmentTextColor.BackColor = SettingsLayout.Default.PreviousSegmentTextColor;

            lblPreviousSegmentDeltaFontName.Text = SettingsLayout.Default.PreviousSegmentDeltaFont.FontFamily.Name;
            pnlPreviousSegmentDeltaSavedColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaSavedColor;
            pnlPreviousSegmentDeltaLostColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaLostColor;
            pnlPreviousSegmentDeltaBestSegmentColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaBestSegmentColor;
            pnlPreviousSegmentDeltaNoDeltaColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor;

            pnlPossibleTimeSaveBackgroundColor.BackColor = SettingsLayout.Default.PossibleTimeSaveBackgroundColor;
            lblPossibleTimeSaveTextFontName.Text = SettingsLayout.Default.PossibleTimeSaveTextFont.FontFamily.Name;
            pnlPossibleTimeSaveTextColor.BackColor = SettingsLayout.Default.PossibleTimeSaveTextColor;
            lblPossibleTimeSaveFontName.Text = SettingsLayout.Default.PossibleTimeSaveFont.FontFamily.Name;
            pnlPossibleTimeSaveColor.BackColor = SettingsLayout.Default.PossibleTimeSaveColor;

            pnlPredictedTimeBackgroundColor.BackColor = SettingsLayout.Default.PredictedTimeBackgroundColor;
            lblPredictedTimeTextFontName.Text = SettingsLayout.Default.PredictedTimeTextFont.FontFamily.Name;
            pnlPredictedTimeTextColor.BackColor = SettingsLayout.Default.PredictedTimeTextColor;
            lblPredictedTimeFontName.Text = SettingsLayout.Default.PredictedTimeFont.FontFamily.Name;
            pnlPredictedTimeColor.BackColor = SettingsLayout.Default.PredictedTimeColor;

            pnlSumOfBestBackgroundColor.BackColor = SettingsLayout.Default.SumOfBestBackgroundColor;
            lblSumOfBestTextFontName.Text = SettingsLayout.Default.SumOfBestTextFont.FontFamily.Name;
            pnlSumOfBestTextColor.BackColor = SettingsLayout.Default.SumOfBestTextColor;
            lblSumOfBestFontName.Text = SettingsLayout.Default.SumOfBestFont.FontFamily.Name;
            pnlSumOfBestColor.BackColor = SettingsLayout.Default.SumOfBestColor;

            pnlSegmentTimerBackgroundColor.BackColor = SettingsLayout.Default.SegmentTimerBackgroundColor;
            lblSegmentTimerPBFontName.Text = SettingsLayout.Default.SegmentTimerPBFont.FontFamily.Name;
            pnlSegmentTimerPBColor.BackColor = SettingsLayout.Default.SegmentTimerPBColor;
            lblSegmentTimerBestFontName.Text = SettingsLayout.Default.SegmentTimerBestFont.FontFamily.Name;
            pnlSegmentTimerBestColor.BackColor = SettingsLayout.Default.SegmentTimerBestColor;
            lblSegmentTimerFontName.Text = SettingsLayout.Default.SegmentTimerFont.FontFamily.Name;
            pnlSegmentTimerRunningColor.BackColor = SettingsLayout.Default.SegmentTimerRunningColor;
            pnlSegmentTimerLosingTimeColor.BackColor = SettingsLayout.Default.SegmentTimerLosingTimeColor;
            pnlSegmentTimerPausedColor.BackColor = SettingsLayout.Default.SegmentTimerPausedColor;
        }

        private void btnChooseTimerFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.TimerFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TimerFont = fontDialog.Font;
                lblTimerFontName.Text = SettingsLayout.Default.TimerFont.FontFamily.Name;
            }
        }

        private void pnlTimerBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.TimerBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TimerBackgroundColor = colorDialog.Color;
                pnlTimerBackgroundColor.BackColor = SettingsLayout.Default.TimerBackgroundColor;
            }
        }

        private void pnlTimerNotRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.TimerNotRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TimerNotRunningColor = colorDialog.Color;
                pnlTimerNotRunningColor.BackColor = SettingsLayout.Default.TimerNotRunningColor;
            }
        }

        private void pnlTimerRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.TimerRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TimerRunningColor = colorDialog.Color;
                pnlTimerRunningColor.BackColor = SettingsLayout.Default.TimerRunningColor;
            }
        }

        private void pnlTimerBehindColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.TimerBehindColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TimerBehindColor = colorDialog.Color;
                pnlTimerBehindColor.BackColor = SettingsLayout.Default.TimerBehindColor;
            }
        }

        private void pnlTimerPausedColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.TimerPausedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TimerPausedColor = colorDialog.Color;
                pnlTimerPausedColor.BackColor = SettingsLayout.Default.TimerPausedColor;
            }
        }

        private void pnlSplitsBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitsBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitsBackgroundColor = colorDialog.Color;
                pnlSplitsBackgroundColor.BackColor = SettingsLayout.Default.SplitsBackgroundColor;
            }
        }

        private void pnlCurrentSegmentColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.CurrentSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.CurrentSegmentColor = colorDialog.Color;
                pnlCurrentSegmentColor.BackColor = SettingsLayout.Default.CurrentSegmentColor;
            }
        }

        private void btnChooseSplitTimesFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SplitTimesFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitTimesFont = fontDialog.Font;
                lblSplitTimesFontName.Text = SettingsLayout.Default.SplitTimesFont.FontFamily.Name;
            }
        }

        private void pnlSplitTimesColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitTimesColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitTimesColor = colorDialog.Color;
                pnlSplitTimesColor.BackColor = SettingsLayout.Default.SplitTimesColor;
            }
        }

        private void btnChooseSplitNamesFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SplitNamesFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitNamesFont = fontDialog.Font;
                lblSplitNamesFontName.Text = SettingsLayout.Default.SplitNamesFont.FontFamily.Name;
            }
        }

        private void pnlSplitNameColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitNamesColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitNamesColor = colorDialog.Color;
                pnlSplitNameColor.BackColor = SettingsLayout.Default.SplitNamesColor;
            }
        }

        private void btnChooseSplitDeltasFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SplitDeltasFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitDeltasFont = fontDialog.Font;
                lblSplitDeltasFontName.Text = SettingsLayout.Default.SplitDeltasFont.FontFamily.Name;
            }
        }

        private void pnlSplitDeltaAheadSavingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitDeltasAheadSavingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitDeltasAheadSavingColor = colorDialog.Color;
                pnlSplitDeltaAheadSavingColor.BackColor = SettingsLayout.Default.SplitDeltasAheadSavingColor;
            }
        }

        private void pnlSplitDeltaAheadLosingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitDeltasAheadLosingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitDeltasAheadLosingColor = colorDialog.Color;
                pnlSplitDeltaAheadLosingColor.BackColor = SettingsLayout.Default.SplitDeltasAheadLosingColor;
            }
        }

        private void pnlSplitDeltaBehindSavingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitDeltasBehindSavingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitDeltasBehindSavingColor = colorDialog.Color;
                pnlSplitDeltaBehindSavingColor.BackColor = SettingsLayout.Default.SplitDeltasBehindSavingColor;
            }
        }

        private void pnlSplitDeltaBehindLosingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitDeltasBehindLosingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitDeltasBehindLosingColor = colorDialog.Color;
                pnlSplitDeltaBehindLosingColor.BackColor = SettingsLayout.Default.SplitDeltasBehindLosingColor;
            }
        }

        private void pnlSplitDeltaBestSegmentColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SplitDeltasBestSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SplitDeltasBestSegmentColor = colorDialog.Color;
                pnlSplitDeltaBestSegmentColor.BackColor = SettingsLayout.Default.SplitDeltasBestSegmentColor;
            }
        }

        private void pnlTitleBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.TitleBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TitleBackgroundColor = colorDialog.Color;
                pnlTitleBackgroundColor.BackColor = SettingsLayout.Default.TitleBackgroundColor;
            }
        }

        private void btnChooseTitleFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.TitleFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TitleFont = fontDialog.Font;
                lblTitleFontName.Text = SettingsLayout.Default.TitleFont.FontFamily.Name;
            }
        }

        private void pnlTitleColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.TitleColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.TitleColor = colorDialog.Color;
                pnlTitleColor.BackColor = SettingsLayout.Default.TitleColor;
            }
        }

        private void btnChooseAttemptsFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.AttemptsFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.AttemptsFont = fontDialog.Font;
                lblAttemptsFontName.Text = SettingsLayout.Default.AttemptsFont.FontFamily.Name;
            }
        }

        private void pnlAttemptsColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.AttemptsColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.AttemptsColor = colorDialog.Color;
                pnlAttemptsColor.BackColor = SettingsLayout.Default.AttemptsColor;
            }
        }

        private void pnlGoalBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.GoalBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.GoalBackgroundColor = colorDialog.Color;
                pnlGoalBackgroundColor.BackColor = SettingsLayout.Default.GoalBackgroundColor;
            }
        }

        private void btnChooseGoalFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.GoalFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.GoalFont = fontDialog.Font;
                lblGoalFontName.Text = SettingsLayout.Default.GoalFont.FontFamily.Name;
            }
        }

        private void pnlGoalColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.GoalColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.GoalColor = colorDialog.Color;
                pnlGoalColor.BackColor = SettingsLayout.Default.GoalColor;
            }
        }

        private void pnlPreviousSegmentBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PreviousSegmentBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentBackgroundColor = colorDialog.Color;
                pnlPreviousSegmentBackgroundColor.BackColor = SettingsLayout.Default.PreviousSegmentBackgroundColor;
            }
        }

        private void btnChoosePreviousSegmentTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.PreviousSegmentTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentTextFont = fontDialog.Font;
                lblPreviousSegmentTextFontName.Text = SettingsLayout.Default.PreviousSegmentTextFont.FontFamily.Name;
            }
        }

        private void pnlPreviousSegmentTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PreviousSegmentTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentTextColor = colorDialog.Color;
                pnlPreviousSegmentTextColor.BackColor = SettingsLayout.Default.PreviousSegmentTextColor;
            }
        }

        private void btnChoosePreviousSegmentDeltaFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.PreviousSegmentDeltaFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentDeltaFont = fontDialog.Font;
                lblPreviousSegmentDeltaFontName.Text = SettingsLayout.Default.PreviousSegmentDeltaFont.FontFamily.Name;
            }
        }

        private void pnlPreviousSegmentDeltaSavedTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PreviousSegmentDeltaSavedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentDeltaSavedColor = colorDialog.Color;
                pnlPreviousSegmentDeltaSavedColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaSavedColor;
            }
        }

        private void pnlPreviousSegmentDeltaLosingTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PreviousSegmentDeltaLostColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentDeltaLostColor = colorDialog.Color;
                pnlPreviousSegmentDeltaLostColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaLostColor;
            }
        }

        private void pnlPreviousSegmentDeltaBestSegmentColors_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PreviousSegmentDeltaBestSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentDeltaBestSegmentColor = colorDialog.Color;
                pnlPreviousSegmentDeltaBestSegmentColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaBestSegmentColor;
            }
        }

        private void pnlPreviousSegmentDeltaNoDeltaColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor = colorDialog.Color;
                pnlPreviousSegmentDeltaNoDeltaColor.BackColor = SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor;
            }
        }

        private void pnlPossibleTimeSaveBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PossibleTimeSaveBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PossibleTimeSaveBackgroundColor = colorDialog.Color;
                pnlPossibleTimeSaveBackgroundColor.BackColor = SettingsLayout.Default.PossibleTimeSaveBackgroundColor;
            }
        }

        private void btnChoosePossibleTimeSaveTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.PossibleTimeSaveTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PossibleTimeSaveTextFont = fontDialog.Font;
                lblPossibleTimeSaveTextFontName.Text = SettingsLayout.Default.PossibleTimeSaveTextFont.FontFamily.Name;
            }
        }

        private void pnlPossibleTimeSaveTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PossibleTimeSaveTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PossibleTimeSaveTextColor = colorDialog.Color;
                pnlPossibleTimeSaveTextColor.BackColor = SettingsLayout.Default.PossibleTimeSaveTextColor;
            }
        }

        private void btnChoosePossibleTimeSaveFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.PossibleTimeSaveFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PossibleTimeSaveFont = fontDialog.Font;
                lblPossibleTimeSaveFontName.Text = SettingsLayout.Default.PossibleTimeSaveFont.FontFamily.Name;
            }
        }

        private void pnlPossibleTimeSaveColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PossibleTimeSaveColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PossibleTimeSaveColor = colorDialog.Color;
                pnlPossibleTimeSaveColor.BackColor = SettingsLayout.Default.PossibleTimeSaveColor;
            }
        }

        private void pnlPredictedTimeBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PossibleTimeSaveColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PredictedTimeBackgroundColor = colorDialog.Color;
                pnlPredictedTimeBackgroundColor.BackColor = SettingsLayout.Default.PredictedTimeBackgroundColor;
            }
        }

        private void btnChoosePredictedTimeTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.PredictedTimeTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PredictedTimeTextFont = fontDialog.Font;
                lblPredictedTimeTextFontName.Text = SettingsLayout.Default.PredictedTimeTextFont.FontFamily.Name;
            }
        }

        private void pnlPredictedTimeTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PredictedTimeTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PredictedTimeTextColor = colorDialog.Color;
                pnlPredictedTimeTextColor.BackColor = SettingsLayout.Default.PredictedTimeTextColor;
            }
        }

        private void btnChoosePredictedTimeFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.PredictedTimeFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PredictedTimeFont = fontDialog.Font;
                lblPredictedTimeFontName.Text = SettingsLayout.Default.PredictedTimeFont.FontFamily.Name;
            }
        }

        private void pnlPredictedTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.PredictedTimeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.PredictedTimeColor = colorDialog.Color;
                pnlPredictedTimeColor.BackColor = SettingsLayout.Default.PredictedTimeColor;
            }
        }

        private void pnlSumOfBestBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SumOfBestBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SumOfBestBackgroundColor = colorDialog.Color;
                pnlSumOfBestBackgroundColor.BackColor = SettingsLayout.Default.SumOfBestBackgroundColor;
            }
        }

        private void btnChooseSumOfBestTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SumOfBestTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SumOfBestTextFont = fontDialog.Font;
                lblSumOfBestTextFontName.Text = SettingsLayout.Default.SumOfBestTextFont.FontFamily.Name;
            }
        }

        private void pnlSumOfBestTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SumOfBestTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SumOfBestTextColor = colorDialog.Color;
                pnlSumOfBestTextColor.BackColor = SettingsLayout.Default.SumOfBestTextColor;
            }
        }

        private void btnChooseSumOfBestFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SumOfBestFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SumOfBestFont = fontDialog.Font;
                lblSumOfBestFontName.Text = SettingsLayout.Default.SumOfBestFont.FontFamily.Name;
            }
        }

        private void pnlSumOfBestColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SumOfBestColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SumOfBestColor = colorDialog.Color;
                pnlSumOfBestColor.BackColor = SettingsLayout.Default.SumOfBestColor;
            }
        }

        private void pnlSegmentTimerBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SegmentTimerBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerBackgroundColor = colorDialog.Color;
                pnlSegmentTimerBackgroundColor.BackColor = SettingsLayout.Default.SegmentTimerBackgroundColor;
            }
        }

        private void btnChooseSegmentTimerPBFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SegmentTimerPBFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerPBFont = fontDialog.Font;
                lblSegmentTimerPBFontName.Text = SettingsLayout.Default.SegmentTimerPBFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerPBColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SegmentTimerPBColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerPBColor = colorDialog.Color;
                pnlSegmentTimerPBColor.BackColor = SettingsLayout.Default.SegmentTimerPBColor;
            }
        }

        private void btnChooseSegmentTimerBestFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SegmentTimerBestFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerBestFont = fontDialog.Font;
                lblSegmentTimerBestFontName.Text = SettingsLayout.Default.SegmentTimerBestFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerBestColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SegmentTimerBestColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerBestColor = colorDialog.Color;
                pnlSegmentTimerBestColor.BackColor = SettingsLayout.Default.SegmentTimerBestColor;
            }
        }

        private void btnChooseSegmentTimerFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = SettingsLayout.Default.SegmentTimerFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerFont = fontDialog.Font;
                lblSegmentTimerFontName.Text = SettingsLayout.Default.SegmentTimerFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SegmentTimerRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerRunningColor = colorDialog.Color;
                pnlSegmentTimerRunningColor.BackColor = SettingsLayout.Default.SegmentTimerRunningColor;
            }
        }

        private void pnlSegmentTimerLosingTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SegmentTimerLosingTimeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerLosingTimeColor = colorDialog.Color;
                pnlSegmentTimerLosingTimeColor.BackColor = SettingsLayout.Default.SegmentTimerLosingTimeColor;
            }
        }

        private void pnlSegmentTimerPausedColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = SettingsLayout.Default.SegmentTimerPausedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.SegmentTimerPausedColor = colorDialog.Color;
                pnlSegmentTimerPausedColor.BackColor = SettingsLayout.Default.SegmentTimerPausedColor;
            }
        }
    }
}
