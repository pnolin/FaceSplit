using System;
using System.Drawing;
using FaceSplit.Properties;
using System.Xml.Serialization;

namespace FaceSplit.Model
{
    public class LayoutSettings
    {
        private string file;
        private FontConverter fontConverter;

        public string timerFont;
        public string timerNotRunningColor;
        public string timerBackgroundColor;
        public string timerRunningColor;
        public string timerBehindColor;
        public string timerPausedColor;
        public string splitsBackgroundColor;
        public string currentSegmentColor;
        public string splitTimesFont;
        public string splitTimesColor;
        public string splitNamesFont;
        public string splitNamesColor;
        public string splitDeltasFont;
        public string splitDeltasAheadSavingColor;
        public string splitDeltasAheadLosingColor;
        public string splitDeltasBehindSavingColor;
        public string splitDeltasBehindLosingColor;
        public string splitDeltasBestSegmentColor;
        public string titleBackgroundColor;
        public string titleFont;
        public string titleColor;
        public string attemptsFont;
        public string attemptsColor;
        public string goalBackgroundColor;
        public string goalColor;
        public string goalFont;
        public string previousSegmentBackgroundColor;
        public string previousSegmentTextColor;
        public string previousSegmentTextFont;
        public string previousSegmentDeltaSavedColor;
        public string previousSegmentDeltaLostColor;
        public string previousSegmentDeltaBestSegmentColor;
        public string previousSegmentDeltaFont;
        public string previousSegmentDeltaNoDeltaColor;
        public string possibleTimeSaveBackgroundColor;
        public string possibleTimeSaveTextColor;
        public string possibleTimeSaveTextFont;
        public string possibleTimeSaveColor;
        public string possibleTimeSaveFont;
        public string predictedTimeBackgroundColor;
        public string predictedTimeTextColor;
        public string predictedTimeTextFont;
        public string predictedTimeColor;
        public string predictedTimeFont;
        public string sumOfBestBackgroundColor;
        public string sumOfBestTextColor;
        public string sumOfBestTextFont;
        public string sumOfBestColor;
        public string sumOfBestFont;
        public string segmentTimerBackgroundColor;
        public string segmentTimerPBColor;
        public string segmentTimerPBFont;
        public string segmentTimerBestColor;
        public string segmentTimerBestFont;
        public string segmentTimerFont;
        public string segmentTimerNotRunningColor;
        public string segmentTimerRunningColor;
        public string segmentTimerLosingTimeColor;
        public string segmentTimerPausedColor;

        [XmlIgnore]
        public string File
        {
            get { return file; }
            set { file = value; }
        }

        public LayoutSettings()
        {
            fontConverter = new FontConverter();
        }

        public void SaveLayoutSettings()
        {
            timerFont = fontConverter.ConvertToString(SettingsLayout.Default.TimerFont);
            timerNotRunningColor = SettingsLayout.Default.TimerNotRunningColor.ToArgb().ToString();
            timerBackgroundColor = SettingsLayout.Default.TimerBackgroundColor.ToArgb().ToString();
            timerRunningColor = SettingsLayout.Default.TimerRunningColor.ToArgb().ToString();
            timerBehindColor = SettingsLayout.Default.TimerBehindColor.ToArgb().ToString();
            timerPausedColor = SettingsLayout.Default.TimerPausedColor.ToArgb().ToString();
            splitsBackgroundColor = SettingsLayout.Default.SplitsBackgroundColor.ToArgb().ToString();
            currentSegmentColor = SettingsLayout.Default.CurrentSegmentColor.ToArgb().ToString();
            splitTimesFont = fontConverter.ConvertToString(SettingsLayout.Default.SplitTimesFont);
            splitTimesColor = SettingsLayout.Default.SplitTimesColor.ToArgb().ToString();
            splitNamesFont = fontConverter.ConvertToString(SettingsLayout.Default.SplitNamesFont);
            splitNamesColor = SettingsLayout.Default.SplitNamesColor.ToArgb().ToString();
            splitDeltasFont = fontConverter.ConvertToString(SettingsLayout.Default.SplitDeltasFont);
            splitDeltasAheadSavingColor = SettingsLayout.Default.SplitDeltasAheadSavingColor.ToArgb().ToString();
            splitDeltasAheadLosingColor = SettingsLayout.Default.SplitDeltasAheadLosingColor.ToArgb().ToString();
            splitDeltasBehindSavingColor = SettingsLayout.Default.SplitDeltasBehindSavingColor.ToArgb().ToString();
            splitDeltasBehindLosingColor = SettingsLayout.Default.SplitDeltasBehindLosingColor.ToArgb().ToString();
            splitDeltasBestSegmentColor = SettingsLayout.Default.SplitDeltasBestSegmentColor.ToArgb().ToString();
            titleBackgroundColor = SettingsLayout.Default.TitleBackgroundColor.ToArgb().ToString();
            titleFont = fontConverter.ConvertToString(SettingsLayout.Default.TitleFont);
            titleColor = SettingsLayout.Default.TitleColor.ToArgb().ToString();
            attemptsFont = fontConverter.ConvertToString(SettingsLayout.Default.AttemptsFont);
            attemptsColor = SettingsLayout.Default.AttemptsColor.ToArgb().ToString();
            goalBackgroundColor = SettingsLayout.Default.GoalBackgroundColor.ToArgb().ToString();
            goalColor = SettingsLayout.Default.GoalColor.ToArgb().ToString();
            goalFont = fontConverter.ConvertToString(SettingsLayout.Default.GoalFont);
            previousSegmentBackgroundColor = SettingsLayout.Default.PreviousSegmentBackgroundColor.ToArgb().ToString();
            previousSegmentTextColor = SettingsLayout.Default.PreviousSegmentTextColor.ToArgb().ToString();
            previousSegmentTextFont = fontConverter.ConvertToString(SettingsLayout.Default.PreviousSegmentTextFont);
            previousSegmentDeltaSavedColor = SettingsLayout.Default.PreviousSegmentDeltaSavedColor.ToArgb().ToString();
            previousSegmentDeltaLostColor = SettingsLayout.Default.PreviousSegmentDeltaLostColor.ToArgb().ToString();
            previousSegmentDeltaBestSegmentColor = SettingsLayout.Default.PreviousSegmentDeltaBestSegmentColor.ToArgb().ToString();
            previousSegmentDeltaFont = fontConverter.ConvertToString(SettingsLayout.Default.PreviousSegmentDeltaFont);
            previousSegmentDeltaNoDeltaColor = SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor.ToArgb().ToString();
            possibleTimeSaveBackgroundColor = SettingsLayout.Default.PossibleTimeSaveBackgroundColor.ToArgb().ToString();
            possibleTimeSaveTextColor = SettingsLayout.Default.PossibleTimeSaveTextColor.ToArgb().ToString();
            possibleTimeSaveTextFont = fontConverter.ConvertToString(SettingsLayout.Default.PossibleTimeSaveTextFont);
            possibleTimeSaveColor = SettingsLayout.Default.PossibleTimeSaveColor.ToArgb().ToString();
            possibleTimeSaveFont = fontConverter.ConvertToString(SettingsLayout.Default.PossibleTimeSaveFont);
            predictedTimeBackgroundColor = SettingsLayout.Default.PredictedTimeBackgroundColor.ToArgb().ToString();
            predictedTimeTextColor = SettingsLayout.Default.PredictedTimeTextColor.ToArgb().ToString();
            predictedTimeTextFont = fontConverter.ConvertToString(SettingsLayout.Default.PredictedTimeTextFont);
            predictedTimeColor = SettingsLayout.Default.PredictedTimeColor.ToArgb().ToString();
            predictedTimeFont = fontConverter.ConvertToString(SettingsLayout.Default.PredictedTimeFont);
            sumOfBestBackgroundColor = SettingsLayout.Default.SumOfBestBackgroundColor.ToArgb().ToString();
            sumOfBestTextColor = SettingsLayout.Default.SumOfBestTextColor.ToArgb().ToString();
            sumOfBestTextFont = fontConverter.ConvertToString(SettingsLayout.Default.SumOfBestTextFont);
            sumOfBestColor = SettingsLayout.Default.SumOfBestColor.ToArgb().ToString();
            sumOfBestFont = fontConverter.ConvertToString(SettingsLayout.Default.SumOfBestFont);
            segmentTimerBackgroundColor = SettingsLayout.Default.SegmentTimerBackgroundColor.ToArgb().ToString();
            segmentTimerPBColor = SettingsLayout.Default.SegmentTimerPBColor.ToArgb().ToString();
            segmentTimerPBFont = fontConverter.ConvertToString(SettingsLayout.Default.SegmentTimerPBFont);
            segmentTimerBestColor = SettingsLayout.Default.SegmentTimerBestColor.ToArgb().ToString();
            segmentTimerBestFont = fontConverter.ConvertToString(SettingsLayout.Default.SegmentTimerBestFont);
            segmentTimerFont = fontConverter.ConvertToString(SettingsLayout.Default.SegmentTimerFont);
            segmentTimerNotRunningColor = SettingsLayout.Default.SegmentTimerNotRunningColor.ToArgb().ToString();
            segmentTimerRunningColor = SettingsLayout.Default.SegmentTimerRunningColor.ToArgb().ToString();
            segmentTimerLosingTimeColor = SettingsLayout.Default.SegmentTimerLosingTimeColor.ToArgb().ToString();
            segmentTimerPausedColor = SettingsLayout.Default.SegmentTimerPausedColor.ToArgb().ToString();
        }

        public void LoadLayoutSettings()
        {
            SettingsLayout.Default.TimerFont = fontConverter.ConvertFromString(timerFont) as Font;
            SettingsLayout.Default.TimerNotRunningColor = Color.FromArgb(int.Parse(timerNotRunningColor));
            SettingsLayout.Default.TimerBackgroundColor = Color.FromArgb(int.Parse(timerBackgroundColor));
            SettingsLayout.Default.TimerRunningColor = Color.FromArgb(int.Parse(timerRunningColor));
            SettingsLayout.Default.TimerBehindColor = Color.FromArgb(int.Parse(timerBehindColor));
            SettingsLayout.Default.TimerPausedColor = Color.FromArgb(int.Parse(timerPausedColor));
            SettingsLayout.Default.SplitsBackgroundColor = Color.FromArgb(int.Parse(splitsBackgroundColor));
            SettingsLayout.Default.CurrentSegmentColor = Color.FromArgb(int.Parse(currentSegmentColor));
            SettingsLayout.Default.SplitTimesFont = fontConverter.ConvertFromString(splitTimesFont) as Font;
            SettingsLayout.Default.SplitTimesColor = Color.FromArgb(int.Parse(splitTimesColor));
            SettingsLayout.Default.SplitNamesFont = fontConverter.ConvertFromString(splitNamesFont) as Font;
            SettingsLayout.Default.SplitNamesColor = Color.FromArgb(int.Parse(splitNamesColor));
            SettingsLayout.Default.SplitDeltasFont = fontConverter.ConvertFromString(splitDeltasFont) as Font;
            SettingsLayout.Default.SplitDeltasAheadSavingColor = Color.FromArgb(int.Parse(splitDeltasAheadSavingColor));
            SettingsLayout.Default.SplitDeltasAheadLosingColor = Color.FromArgb(int.Parse(splitDeltasAheadLosingColor));
            SettingsLayout.Default.SplitDeltasBehindSavingColor = Color.FromArgb(int.Parse(splitDeltasBehindSavingColor));
            SettingsLayout.Default.SplitDeltasBehindLosingColor = Color.FromArgb(int.Parse(splitDeltasBehindLosingColor));
            SettingsLayout.Default.SplitDeltasBestSegmentColor = Color.FromArgb(int.Parse(splitDeltasBestSegmentColor));
            SettingsLayout.Default.TitleBackgroundColor = Color.FromArgb(int.Parse(titleBackgroundColor));
            SettingsLayout.Default.TitleFont = fontConverter.ConvertFromString(titleFont) as Font;
            SettingsLayout.Default.TitleColor = Color.FromArgb(int.Parse(titleColor));
            SettingsLayout.Default.AttemptsFont = fontConverter.ConvertFromString(attemptsFont) as Font;
            SettingsLayout.Default.AttemptsColor = Color.FromArgb(int.Parse(attemptsColor));
            SettingsLayout.Default.GoalBackgroundColor = Color.FromArgb(int.Parse(goalBackgroundColor));
            SettingsLayout.Default.GoalColor = Color.FromArgb(int.Parse(goalColor));
            SettingsLayout.Default.GoalFont = fontConverter.ConvertFromString(goalFont) as Font;
            SettingsLayout.Default.PreviousSegmentBackgroundColor = Color.FromArgb(int.Parse(previousSegmentBackgroundColor));
            SettingsLayout.Default.PreviousSegmentTextColor = Color.FromArgb(int.Parse(previousSegmentTextColor));
            SettingsLayout.Default.PreviousSegmentTextFont = fontConverter.ConvertFromString(previousSegmentTextFont) as Font;
            SettingsLayout.Default.PreviousSegmentDeltaSavedColor = Color.FromArgb(int.Parse(previousSegmentDeltaSavedColor));
            SettingsLayout.Default.PreviousSegmentDeltaLostColor = Color.FromArgb(int.Parse(previousSegmentDeltaLostColor));
            SettingsLayout.Default.PreviousSegmentDeltaBestSegmentColor = Color.FromArgb(int.Parse(previousSegmentDeltaBestSegmentColor));
            SettingsLayout.Default.PreviousSegmentDeltaFont = fontConverter.ConvertFromString(previousSegmentDeltaFont) as Font;
            SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor = Color.FromArgb(int.Parse(previousSegmentDeltaNoDeltaColor));
            SettingsLayout.Default.PossibleTimeSaveBackgroundColor = Color.FromArgb(int.Parse(possibleTimeSaveBackgroundColor));
            SettingsLayout.Default.PossibleTimeSaveTextColor = Color.FromArgb(int.Parse(possibleTimeSaveTextColor));
            SettingsLayout.Default.PossibleTimeSaveTextFont = fontConverter.ConvertFromString(possibleTimeSaveTextFont) as Font;
            SettingsLayout.Default.PossibleTimeSaveColor = Color.FromArgb(int.Parse(possibleTimeSaveColor));
            SettingsLayout.Default.PossibleTimeSaveFont = fontConverter.ConvertFromString(possibleTimeSaveFont) as Font;
            SettingsLayout.Default.PredictedTimeBackgroundColor = Color.FromArgb(int.Parse(predictedTimeBackgroundColor));
            SettingsLayout.Default.PredictedTimeTextColor = Color.FromArgb(int.Parse(predictedTimeTextColor));
            SettingsLayout.Default.PredictedTimeTextFont = fontConverter.ConvertFromString(predictedTimeTextFont) as Font;
            SettingsLayout.Default.PredictedTimeColor = Color.FromArgb(int.Parse(predictedTimeColor));
            SettingsLayout.Default.PredictedTimeFont = fontConverter.ConvertFromString(predictedTimeFont) as Font;
            SettingsLayout.Default.SumOfBestBackgroundColor = Color.FromArgb(int.Parse(sumOfBestBackgroundColor));
            SettingsLayout.Default.SumOfBestTextColor = Color.FromArgb(int.Parse(sumOfBestTextColor));
            SettingsLayout.Default.SumOfBestTextFont = fontConverter.ConvertFromString(sumOfBestTextFont) as Font;
            SettingsLayout.Default.SumOfBestColor = Color.FromArgb(int.Parse(sumOfBestColor));
            SettingsLayout.Default.SumOfBestFont = fontConverter.ConvertFromString(sumOfBestFont) as Font;
            SettingsLayout.Default.SegmentTimerBackgroundColor = Color.FromArgb(int.Parse(segmentTimerBackgroundColor));
            SettingsLayout.Default.SegmentTimerPBColor = Color.FromArgb(int.Parse(segmentTimerPBColor));
            SettingsLayout.Default.SegmentTimerPBFont = fontConverter.ConvertFromString(segmentTimerPBFont) as Font;
            SettingsLayout.Default.SegmentTimerBestColor = Color.FromArgb(int.Parse(segmentTimerBestColor));
            SettingsLayout.Default.SegmentTimerBestFont = fontConverter.ConvertFromString(segmentTimerBestFont) as Font;
            SettingsLayout.Default.SegmentTimerFont = fontConverter.ConvertFromString(segmentTimerFont) as Font;
            SettingsLayout.Default.SegmentTimerNotRunningColor = Color.FromArgb(int.Parse(segmentTimerNotRunningColor));
            SettingsLayout.Default.SegmentTimerRunningColor = Color.FromArgb(int.Parse(segmentTimerRunningColor));
            SettingsLayout.Default.SegmentTimerLosingTimeColor = Color.FromArgb(int.Parse(segmentTimerLosingTimeColor));
            SettingsLayout.Default.SegmentTimerPausedColor = Color.FromArgb(int.Parse(segmentTimerPausedColor));
        }

    }
}
