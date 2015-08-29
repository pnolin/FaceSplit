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
            lblTimerFontName.Text = Settings.Default.TimerFont.FontFamily.Name;
            pnlTimerBackgroundColor.BackColor = Settings.Default.TimerBackgroundColor;
            pnlTimerNotRunningColor.BackColor = Settings.Default.TimerNotRunningColor;
            pnlTimerRunningColor.BackColor = Settings.Default.TimerRunningColor;
            pnlTimerBehindColor.BackColor = Settings.Default.TimerBehindColor;
            pnlTimerPausedColor.BackColor = Settings.Default.TimerPausedColor;

            pnlSplitsBackgroundColor.BackColor = Settings.Default.SplitsBackgroundColor;
            pnlCurrentSegmentColor.BackColor = Settings.Default.CurrentSegmentColor;
            lblSplitTimesFontName.Text = Settings.Default.SplitTimesFont.FontFamily.Name;
            pnlSplitTimesColor.BackColor = Settings.Default.SplitTimesColor;
            lblSplitNamesFontName.Text = Settings.Default.SplitNamesFont.FontFamily.Name;
            pnlSplitNameColor.BackColor = Settings.Default.SplitNamesColor;

            lblSplitDeltasFontName.Text = Settings.Default.SplitDeltasFont.FontFamily.Name;
            pnlSplitDeltaAheadSavingColor.BackColor = Settings.Default.SplitDeltasAheadSavingColor;
            pnlSplitDeltaAheadLosingColor.BackColor = Settings.Default.SplitDeltasAheadLosingColor;
            pnlSplitDeltaBehindSavingColor.BackColor = Settings.Default.SplitDeltasBehindSavingColor;
            pnlSplitDeltaBehindLosingColor.BackColor = Settings.Default.SplitDeltasBehindLosingColor;
            pnlSplitDeltaBestSegmentColor.BackColor = Settings.Default.SplitDeltasBestSegmentColor;

            pnlTitleBackgroundColor.BackColor = Settings.Default.TitleBackgroundColor;
            lblTitleFontName.Text = Settings.Default.TitleFont.FontFamily.Name;
            pnlTitleColor.BackColor = Settings.Default.TitleColor;

            lblAttemptsFontName.Text = Settings.Default.AttemptsFont.FontFamily.Name;
            pnlAttemptsColor.BackColor = Settings.Default.AttemptsColor;

            pnlGoalBackgroundColor.BackColor = Settings.Default.GoalBackgroundColor;
            lblGoalFontName.Text = Settings.Default.GoalFont.FontFamily.Name;
            pnlGoalColor.BackColor = Settings.Default.GoalColor;

            pnlPreviousSegmentBackgroundColor.BackColor = Settings.Default.PreviousSegmentBackgroundColor;
            lblPreviousSegmentTextFontName.Text = Settings.Default.PreviousSegmentTextFont.FontFamily.Name;
            pnlPreviousSegmentTextColor.BackColor = Settings.Default.PreviousSegmentTextColor;

            lblPreviousSegmentDeltaFontName.Text = Settings.Default.PreviousSegmentDeltaFont.FontFamily.Name;
            pnlPreviousSegmentDeltaSavedColor.BackColor = Settings.Default.PreviousSegmentDeltaSavedColor;
            pnlPreviousSegmentDeltaLostColor.BackColor = Settings.Default.PreviousSegmentDeltaLostColor;
            pnlPreviousSegmentDeltaBestSegmentColor.BackColor = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
            pnlPreviousSegmentDeltaNoDeltaColor.BackColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor;

            pnlPossibleTimeSaveBackgroundColor.BackColor = Settings.Default.PossibleTimeSaveBackgroundColor;
            lblPossibleTimeSaveTextFontName.Text = Settings.Default.PossibleTimeSaveTextFont.FontFamily.Name;
            pnlPossibleTimeSaveTextColor.BackColor = Settings.Default.PossibleTimeSaveTextColor;
            lblPossibleTimeSaveFontName.Text = Settings.Default.PossibleTimeSaveFont.FontFamily.Name;
            pnlPossibleTimeSaveColor.BackColor = Settings.Default.PossibleTimeSaveColor;

            pnlPredictedTimeBackgroundColor.BackColor = Settings.Default.PredictedTimeBackgroundColor;
            lblPredictedTimeTextFontName.Text = Settings.Default.PredictedTimeTextFont.FontFamily.Name;
            pnlPredictedTimeTextColor.BackColor = Settings.Default.PredictedTimeTextColor;
            lblPredictedTimeFontName.Text = Settings.Default.PredictedTimeFont.FontFamily.Name;
            pnlPredictedTimeColor.BackColor = Settings.Default.PredictedTimeColor;

            pnlSumOfBestBackgroundColor.BackColor = Settings.Default.SumOfBestBackgroundColor;
            lblSumOfBestTextFontName.Text = Settings.Default.SumOfBestTextFont.FontFamily.Name;
            pnlSumOfBestTextColor.BackColor = Settings.Default.SumOfBestTextColor;
            lblSumOfBestFontName.Text = Settings.Default.SumOfBestFont.FontFamily.Name;
            pnlSumOfBestColor.BackColor = Settings.Default.SumOfBestColor;

            pnlSegmentTimerBackgroundColor.BackColor = Settings.Default.SegmentTimerBackgroundColor;
            lblSegmentTimerPBFontName.Text = Settings.Default.SegmentTimerPBFont.FontFamily.Name;
            pnlSegmentTimerPBColor.BackColor = Settings.Default.SegmentTimerPBColor;
            lblSegmentTimerBestFontName.Text = Settings.Default.SegmentTimerBestFont.FontFamily.Name;
            pnlSegmentTimerBestColor.BackColor = Settings.Default.SegmentTimerBestColor;
            lblSegmentTimerFontName.Text = Settings.Default.SegmentTimerFont.FontFamily.Name;
            pnlSegmentTimerRunningColor.BackColor = Settings.Default.SegmentTimerRunningColor;
            pnlSegmentTimerLosingTimeColor.BackColor = Settings.Default.SegmentTimerLosingTimeColor;
            pnlSegmentTimerPausedColor.BackColor = Settings.Default.SegmentTimerPausedColor;
        }

        private void btnChooseTimerFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.TimerFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerFont = fontDialog.Font;
                lblTimerFontName.Text = Settings.Default.TimerFont.FontFamily.Name;
            }
        }

        private void pnlTimerBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerBackgroundColor = colorDialog.Color;
                pnlTimerBackgroundColor.BackColor = Settings.Default.TimerBackgroundColor;
            }
        }

        private void pnlTimerNotRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerNotRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerNotRunningColor = colorDialog.Color;
                pnlTimerNotRunningColor.BackColor = Settings.Default.TimerNotRunningColor;
            }
        }

        private void pnlTimerRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerRunningColor = colorDialog.Color;
                pnlTimerRunningColor.BackColor = Settings.Default.TimerRunningColor;
            }
        }

        private void pnlTimerBehindColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerBehindColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerBehindColor = colorDialog.Color;
                pnlTimerBehindColor.BackColor = Settings.Default.TimerBehindColor;
            }
        }

        private void pnlTimerPausedColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TimerPausedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TimerPausedColor = colorDialog.Color;
                pnlTimerPausedColor.BackColor = Settings.Default.TimerPausedColor;
            }
        }

        private void pnlSplitsBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitsBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitsBackgroundColor = colorDialog.Color;
                pnlSplitsBackgroundColor.BackColor = Settings.Default.SplitsBackgroundColor;
            }
        }

        private void pnlCurrentSegmentColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.CurrentSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.CurrentSegmentColor = colorDialog.Color;
                pnlCurrentSegmentColor.BackColor = Settings.Default.CurrentSegmentColor;
            }
        }

        private void btnChooseSplitTimesFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SplitTimesFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitTimesFont = fontDialog.Font;
                lblSplitTimesFontName.Text = Settings.Default.SplitTimesFont.FontFamily.Name;
            }
        }

        private void pnlSplitTimesColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitTimesColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitTimesColor = colorDialog.Color;
                pnlSplitTimesColor.BackColor = Settings.Default.SplitTimesColor;
            }
        }

        private void btnChooseSplitNamesFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SplitNamesFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitNamesFont = fontDialog.Font;
                lblSplitNamesFontName.Text = Settings.Default.SplitNamesFont.FontFamily.Name;
            }
        }

        private void pnlSplitNameColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitNamesColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitNamesColor = colorDialog.Color;
                pnlSplitNameColor.BackColor = Settings.Default.SplitNamesColor;
            }
        }

        private void btnChooseSplitDeltasFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SplitDeltasFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasFont = fontDialog.Font;
                lblSplitDeltasFontName.Text = Settings.Default.SplitDeltasFont.FontFamily.Name;
            }
        }

        private void pnlSplitDeltaAheadSavingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasAheadSavingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasAheadSavingColor = colorDialog.Color;
                pnlSplitDeltaAheadSavingColor.BackColor = Settings.Default.SplitDeltasAheadSavingColor;
            }
        }

        private void pnlSplitDeltaAheadLosingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasAheadLosingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasAheadLosingColor = colorDialog.Color;
                pnlSplitDeltaAheadLosingColor.BackColor = Settings.Default.SplitDeltasAheadLosingColor;
            }
        }

        private void pnlSplitDeltaBehindSavingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasBehindSavingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBehindSavingColor = colorDialog.Color;
                pnlSplitDeltaBehindSavingColor.BackColor = Settings.Default.SplitDeltasBehindSavingColor;
            }
        }

        private void pnlSplitDeltaBehindLosingColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasBehindLosingColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBehindLosingColor = colorDialog.Color;
                pnlSplitDeltaBehindLosingColor.BackColor = Settings.Default.SplitDeltasBehindLosingColor;
            }
        }

        private void pnlSplitDeltaBestSegmentColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SplitDeltasBestSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SplitDeltasBestSegmentColor = colorDialog.Color;
                pnlSplitDeltaBestSegmentColor.BackColor = Settings.Default.SplitDeltasBestSegmentColor;
            }
        }

        private void pnlTitleBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TitleBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TitleBackgroundColor = colorDialog.Color;
                pnlTitleBackgroundColor.BackColor = Settings.Default.TitleBackgroundColor;
            }
        }

        private void btnChooseTitleFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.TitleFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TitleFont = fontDialog.Font;
                lblTitleFontName.Text = Settings.Default.TitleFont.FontFamily.Name;
            }
        }

        private void pnlTitleColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.TitleColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TitleColor = colorDialog.Color;
                pnlTitleColor.BackColor = Settings.Default.TitleColor;
            }
        }

        private void btnChooseAttemptsFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.AttemptsFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.AttemptsFont = fontDialog.Font;
                lblAttemptsFontName.Text = Settings.Default.AttemptsFont.FontFamily.Name;
            }
        }

        private void pnlAttemptsColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.AttemptsColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.AttemptsColor = colorDialog.Color;
                pnlAttemptsColor.BackColor = Settings.Default.AttemptsColor;
            }
        }

        private void pnlGoalBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.GoalBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.GoalBackgroundColor = colorDialog.Color;
                pnlGoalBackgroundColor.BackColor = Settings.Default.GoalBackgroundColor;
            }
        }

        private void btnChooseGoalFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.GoalFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.GoalFont = fontDialog.Font;
                lblGoalFontName.Text = Settings.Default.GoalFont.FontFamily.Name;
            }
        }

        private void pnlGoalColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.GoalColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.GoalColor = colorDialog.Color;
                pnlGoalColor.BackColor = Settings.Default.GoalColor;
            }
        }

        private void pnlPreviousSegmentBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentBackgroundColor = colorDialog.Color;
                pnlPreviousSegmentBackgroundColor.BackColor = Settings.Default.PreviousSegmentBackgroundColor;
            }
        }

        private void btnChoosePreviousSegmentTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PreviousSegmentTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentTextFont = fontDialog.Font;
                lblPreviousSegmentTextFontName.Text = Settings.Default.PreviousSegmentTextFont.FontFamily.Name;
            }
        }

        private void pnlPreviousSegmentTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentTextColor = colorDialog.Color;
                pnlPreviousSegmentTextColor.BackColor = Settings.Default.PreviousSegmentTextColor;
            }
        }

        private void btnChoosePreviousSegmentDeltaFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PreviousSegmentDeltaFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaFont = fontDialog.Font;
                lblPreviousSegmentDeltaFontName.Text = Settings.Default.PreviousSegmentDeltaFont.FontFamily.Name;
            }
        }

        private void pnlPreviousSegmentDeltaSavedTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaSavedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaSavedColor = colorDialog.Color;
                pnlPreviousSegmentDeltaSavedColor.BackColor = Settings.Default.PreviousSegmentDeltaSavedColor;
            }
        }

        private void pnlPreviousSegmentDeltaLosingTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaLostColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaLostColor = colorDialog.Color;
                pnlPreviousSegmentDeltaLostColor.BackColor = Settings.Default.PreviousSegmentDeltaLostColor;
            }
        }

        private void pnlPreviousSegmentDeltaBestSegmentColors_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaBestSegmentColor = colorDialog.Color;
                pnlPreviousSegmentDeltaBestSegmentColor.BackColor = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
            }
        }

        private void pnlPreviousSegmentDeltaNoDeltaColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PreviousSegmentDeltaNoDeltaColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PreviousSegmentDeltaNoDeltaColor = colorDialog.Color;
                pnlPreviousSegmentDeltaNoDeltaColor.BackColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor;
            }
        }

        private void pnlPossibleTimeSaveBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PossibleTimeSaveBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveBackgroundColor = colorDialog.Color;
                pnlPossibleTimeSaveBackgroundColor.BackColor = Settings.Default.PossibleTimeSaveBackgroundColor;
            }
        }

        private void btnChoosePossibleTimeSaveTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PossibleTimeSaveTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveTextFont = fontDialog.Font;
                lblPossibleTimeSaveTextFontName.Text = Settings.Default.PossibleTimeSaveTextFont.FontFamily.Name;
            }
        }

        private void pnlPossibleTimeSaveTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PossibleTimeSaveTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveTextColor = colorDialog.Color;
                pnlPossibleTimeSaveTextColor.BackColor = Settings.Default.PossibleTimeSaveTextColor;
            }
        }

        private void btnChoosePossibleTimeSaveFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PossibleTimeSaveFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveFont = fontDialog.Font;
                lblPossibleTimeSaveFontName.Text = Settings.Default.PossibleTimeSaveFont.FontFamily.Name;
            }
        }

        private void pnlPossibleTimeSaveColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PossibleTimeSaveColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PossibleTimeSaveColor = colorDialog.Color;
                pnlPossibleTimeSaveColor.BackColor = Settings.Default.PossibleTimeSaveColor;
            }
        }

        private void pnlPredictedTimeBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PossibleTimeSaveColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeBackgroundColor = colorDialog.Color;
                pnlPredictedTimeBackgroundColor.BackColor = Settings.Default.PredictedTimeBackgroundColor;
            }
        }

        private void btnChoosePredictedTimeTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PredictedTimeTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeTextFont = fontDialog.Font;
                lblPredictedTimeTextFontName.Text = Settings.Default.PredictedTimeTextFont.FontFamily.Name;
            }
        }

        private void pnlPredictedTimeTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PredictedTimeTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeTextColor = colorDialog.Color;
                pnlPredictedTimeTextColor.BackColor = Settings.Default.PredictedTimeTextColor;
            }
        }

        private void btnChoosePredictedTimeFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.PredictedTimeFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeFont = fontDialog.Font;
                lblPredictedTimeFontName.Text = Settings.Default.PredictedTimeFont.FontFamily.Name;
            }
        }

        private void pnlPredictedTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.PredictedTimeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.PredictedTimeColor = colorDialog.Color;
                pnlPredictedTimeColor.BackColor = Settings.Default.PredictedTimeColor;
            }
        }

        private void pnlSumOfBestBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SumOfBestBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestBackgroundColor = colorDialog.Color;
                pnlSumOfBestBackgroundColor.BackColor = Settings.Default.SumOfBestBackgroundColor;
            }
        }

        private void btnChooseSumOfBestTextFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SumOfBestTextFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestTextFont = fontDialog.Font;
                lblSumOfBestTextFontName.Text = Settings.Default.SumOfBestTextFont.FontFamily.Name;
            }
        }

        private void pnlSumOfBestTextColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SumOfBestTextColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestTextColor = colorDialog.Color;
                pnlSumOfBestTextColor.BackColor = Settings.Default.SumOfBestTextColor;
            }
        }

        private void btnChooseSumOfBestFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SumOfBestFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestFont = fontDialog.Font;
                lblSumOfBestFontName.Text = Settings.Default.SumOfBestFont.FontFamily.Name;
            }
        }

        private void pnlSumOfBestColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SumOfBestColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SumOfBestColor = colorDialog.Color;
                pnlSumOfBestColor.BackColor = Settings.Default.SumOfBestColor;
            }
        }

        private void pnlSegmentTimerBackgroundColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerBackgroundColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerBackgroundColor = colorDialog.Color;
                pnlSegmentTimerBackgroundColor.BackColor = Settings.Default.SegmentTimerBackgroundColor;
            }
        }

        private void btnChooseSegmentTimerPBFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SegmentTimerPBFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerPBFont = fontDialog.Font;
                lblSegmentTimerPBFontName.Text = Settings.Default.SegmentTimerPBFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerPBColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerPBColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerPBColor = colorDialog.Color;
                pnlSegmentTimerPBColor.BackColor = Settings.Default.SegmentTimerPBColor;
            }
        }

        private void btnChooseSegmentTimerBestFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SegmentTimerBestFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerBestFont = fontDialog.Font;
                lblSegmentTimerBestFontName.Text = Settings.Default.SegmentTimerBestFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerBestColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerBestColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerBestColor = colorDialog.Color;
                pnlSegmentTimerBestColor.BackColor = Settings.Default.SegmentTimerBestColor;
            }
        }

        private void btnChooseSegmentTimerFont_Click(object sender, EventArgs e)
        {
            fontDialog.Font = Settings.Default.SegmentTimerFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerFont = fontDialog.Font;
                lblSegmentTimerFontName.Text = Settings.Default.SegmentTimerFont.FontFamily.Name;
            }
        }

        private void pnlSegmentTimerRunningColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerRunningColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerRunningColor = colorDialog.Color;
                pnlSegmentTimerRunningColor.BackColor = Settings.Default.SegmentTimerRunningColor;
            }
        }

        private void pnlSegmentTimerLosingTimeColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerLosingTimeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerLosingTimeColor = colorDialog.Color;
                pnlSegmentTimerLosingTimeColor.BackColor = Settings.Default.SegmentTimerLosingTimeColor;
            }
        }

        private void pnlSegmentTimerPausedColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = Settings.Default.SegmentTimerPausedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.SegmentTimerPausedColor = colorDialog.Color;
                pnlSegmentTimerPausedColor.BackColor = Settings.Default.SegmentTimerPausedColor;
            }
        }
    }
}
