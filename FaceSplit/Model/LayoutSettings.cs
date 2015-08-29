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
            timerFont = fontConverter.ConvertToString(Settings.Default.TimerFont);
            timerNotRunningColor = Settings.Default.TimerNotRunningColor.ToArgb().ToString();
            timerBackgroundColor = Settings.Default.TimerBackgroundColor.ToArgb().ToString();
            timerRunningColor = Settings.Default.TimerRunningColor.ToArgb().ToString();
            timerBehindColor = Settings.Default.TimerBehindColor.ToArgb().ToString();
            timerPausedColor = Settings.Default.TimerPausedColor.ToArgb().ToString();
            splitsBackgroundColor = Settings.Default.SplitsBackgroundColor.ToArgb().ToString();
            currentSegmentColor = Settings.Default.CurrentSegmentColor.ToArgb().ToString();
            splitTimesFont = fontConverter.ConvertToString(Settings.Default.SplitTimesFont);
            splitTimesColor = Settings.Default.SplitTimesColor.ToArgb().ToString();
            splitNamesFont = fontConverter.ConvertToString(Settings.Default.SplitNamesFont);
            splitNamesColor = Settings.Default.SplitNamesColor.ToArgb().ToString();
            splitDeltasFont = fontConverter.ConvertToString(Settings.Default.SplitDeltasFont);
            splitDeltasAheadSavingColor = Settings.Default.SplitDeltasAheadSavingColor.ToArgb().ToString();
            splitDeltasAheadLosingColor = Settings.Default.SplitDeltasAheadLosingColor.ToArgb().ToString();
            splitDeltasBehindSavingColor = Settings.Default.SplitDeltasBehindSavingColor.ToArgb().ToString();
            splitDeltasBehindLosingColor = Settings.Default.SplitDeltasBehindLosingColor.ToArgb().ToString();
            splitDeltasBestSegmentColor = Settings.Default.SplitDeltasBestSegmentColor.ToArgb().ToString();
            titleBackgroundColor = Settings.Default.TitleBackgroundColor.ToArgb().ToString();
            titleFont = fontConverter.ConvertToString(Settings.Default.TitleFont);
            titleColor = Settings.Default.TitleColor.ToArgb().ToString();
            attemptsFont = fontConverter.ConvertToString(Settings.Default.AttemptsFont);
            attemptsColor = Settings.Default.AttemptsColor.ToArgb().ToString();
            goalBackgroundColor = Settings.Default.GoalBackgroundColor.ToArgb().ToString();
            goalColor = Settings.Default.GoalColor.ToArgb().ToString();
            goalFont = fontConverter.ConvertToString(Settings.Default.GoalFont);
            previousSegmentBackgroundColor = Settings.Default.PreviousSegmentBackgroundColor.ToArgb().ToString();
            previousSegmentTextColor = Settings.Default.PreviousSegmentTextColor.ToArgb().ToString();
            previousSegmentTextFont = fontConverter.ConvertToString(Settings.Default.PreviousSegmentTextFont);
            previousSegmentDeltaSavedColor = Settings.Default.PreviousSegmentDeltaSavedColor.ToArgb().ToString();
            previousSegmentDeltaLostColor = Settings.Default.PreviousSegmentDeltaLostColor.ToArgb().ToString();
            previousSegmentDeltaBestSegmentColor = Settings.Default.PreviousSegmentDeltaBestSegmentColor.ToArgb().ToString();
            previousSegmentDeltaFont = fontConverter.ConvertToString(Settings.Default.PreviousSegmentDeltaFont);
            previousSegmentDeltaNoDeltaColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor.ToArgb().ToString();
            possibleTimeSaveBackgroundColor = Settings.Default.PossibleTimeSaveBackgroundColor.ToArgb().ToString();
            possibleTimeSaveTextColor = Settings.Default.PossibleTimeSaveTextColor.ToArgb().ToString();
            possibleTimeSaveTextFont = fontConverter.ConvertToString(Settings.Default.PossibleTimeSaveTextFont);
            possibleTimeSaveColor = Settings.Default.PossibleTimeSaveColor.ToArgb().ToString();
            possibleTimeSaveFont = fontConverter.ConvertToString(Settings.Default.PossibleTimeSaveFont);
            predictedTimeBackgroundColor = Settings.Default.PredictedTimeBackgroundColor.ToArgb().ToString();
            predictedTimeTextColor = Settings.Default.PredictedTimeTextColor.ToArgb().ToString();
            predictedTimeTextFont = fontConverter.ConvertToString(Settings.Default.PredictedTimeTextFont);
            predictedTimeColor = Settings.Default.PredictedTimeColor.ToArgb().ToString();
            predictedTimeFont = fontConverter.ConvertToString(Settings.Default.PredictedTimeFont);
            sumOfBestBackgroundColor = Settings.Default.SumOfBestBackgroundColor.ToArgb().ToString();
            sumOfBestTextColor = Settings.Default.SumOfBestTextColor.ToArgb().ToString();
            sumOfBestTextFont = fontConverter.ConvertToString(Settings.Default.SumOfBestTextFont);
            sumOfBestColor = Settings.Default.SumOfBestColor.ToArgb().ToString();
            sumOfBestFont = fontConverter.ConvertToString(Settings.Default.SumOfBestFont);
            segmentTimerBackgroundColor = Settings.Default.SegmentTimerBackgroundColor.ToArgb().ToString();
            segmentTimerPBColor = Settings.Default.SegmentTimerPBColor.ToArgb().ToString();
            segmentTimerPBFont = fontConverter.ConvertToString(Settings.Default.SegmentTimerPBFont);
            segmentTimerBestColor = Settings.Default.SegmentTimerBestColor.ToArgb().ToString();
            segmentTimerBestFont = fontConverter.ConvertToString(Settings.Default.SegmentTimerBestFont);
            segmentTimerFont = fontConverter.ConvertToString(Settings.Default.SegmentTimerFont);
            segmentTimerNotRunningColor = Settings.Default.SegmentTimerNotRunningColor.ToArgb().ToString();
            segmentTimerRunningColor = Settings.Default.SegmentTimerRunningColor.ToArgb().ToString();
            segmentTimerLosingTimeColor = Settings.Default.SegmentTimerLosingTimeColor.ToArgb().ToString();
            segmentTimerPausedColor = Settings.Default.SegmentTimerPausedColor.ToArgb().ToString();
        }

        public void LoadLayoutSettings()
        {
            Settings.Default.TimerFont = fontConverter.ConvertFromString(timerFont) as Font;
            Settings.Default.TimerNotRunningColor = Color.FromArgb(int.Parse(timerNotRunningColor));
            Settings.Default.TimerBackgroundColor = Color.FromArgb(int.Parse(timerBackgroundColor));
            Settings.Default.TimerRunningColor = Color.FromArgb(int.Parse(timerRunningColor));
            Settings.Default.TimerBehindColor = Color.FromArgb(int.Parse(timerBehindColor));
            Settings.Default.TimerPausedColor = Color.FromArgb(int.Parse(timerPausedColor));
            Settings.Default.SplitsBackgroundColor = Color.FromArgb(int.Parse(splitsBackgroundColor));
            Settings.Default.CurrentSegmentColor = Color.FromArgb(int.Parse(currentSegmentColor));
            Settings.Default.SplitTimesFont = fontConverter.ConvertFromString(splitTimesFont) as Font;
            Settings.Default.SplitTimesColor = Color.FromArgb(int.Parse(splitTimesColor));
            Settings.Default.SplitNamesFont = fontConverter.ConvertFromString(splitNamesFont) as Font;
            Settings.Default.SplitNamesColor = Color.FromArgb(int.Parse(splitNamesColor));
            Settings.Default.SplitDeltasFont = fontConverter.ConvertFromString(splitDeltasFont) as Font;
            Settings.Default.SplitDeltasAheadSavingColor = Color.FromArgb(int.Parse(splitDeltasAheadSavingColor));
            Settings.Default.SplitDeltasAheadLosingColor = Color.FromArgb(int.Parse(splitDeltasAheadLosingColor));
            Settings.Default.SplitDeltasBehindSavingColor = Color.FromArgb(int.Parse(splitDeltasBehindSavingColor));
            Settings.Default.SplitDeltasBehindLosingColor = Color.FromArgb(int.Parse(splitDeltasBehindLosingColor));
            Settings.Default.SplitDeltasBestSegmentColor = Color.FromArgb(int.Parse(splitDeltasBestSegmentColor));
            Settings.Default.TitleBackgroundColor = Color.FromArgb(int.Parse(titleBackgroundColor));
            Settings.Default.TitleFont = fontConverter.ConvertFromString(titleFont) as Font;
            Settings.Default.TitleColor = Color.FromArgb(int.Parse(titleColor));
            Settings.Default.AttemptsFont = fontConverter.ConvertFromString(attemptsFont) as Font;
            Settings.Default.AttemptsColor = Color.FromArgb(int.Parse(attemptsColor));
            Settings.Default.GoalBackgroundColor = Color.FromArgb(int.Parse(goalBackgroundColor));
            Settings.Default.GoalColor = Color.FromArgb(int.Parse(goalColor));
            Settings.Default.GoalFont = fontConverter.ConvertFromString(goalFont) as Font;
            Settings.Default.PreviousSegmentBackgroundColor = Color.FromArgb(int.Parse(previousSegmentBackgroundColor));
            Settings.Default.PreviousSegmentTextColor = Color.FromArgb(int.Parse(previousSegmentTextColor));
            Settings.Default.PreviousSegmentTextFont = fontConverter.ConvertFromString(previousSegmentTextFont) as Font;
            Settings.Default.PreviousSegmentDeltaSavedColor = Color.FromArgb(int.Parse(previousSegmentDeltaSavedColor));
            Settings.Default.PreviousSegmentDeltaLostColor = Color.FromArgb(int.Parse(previousSegmentDeltaLostColor));
            Settings.Default.PreviousSegmentDeltaBestSegmentColor = Color.FromArgb(int.Parse(previousSegmentDeltaBestSegmentColor));
            Settings.Default.PreviousSegmentDeltaFont = fontConverter.ConvertFromString(previousSegmentDeltaFont) as Font;
            Settings.Default.PreviousSegmentDeltaNoDeltaColor = Color.FromArgb(int.Parse(previousSegmentDeltaNoDeltaColor));
            Settings.Default.PossibleTimeSaveBackgroundColor = Color.FromArgb(int.Parse(possibleTimeSaveBackgroundColor));
            Settings.Default.PossibleTimeSaveTextColor = Color.FromArgb(int.Parse(possibleTimeSaveTextColor));
            Settings.Default.PossibleTimeSaveTextFont = fontConverter.ConvertFromString(possibleTimeSaveTextFont) as Font;
            Settings.Default.PossibleTimeSaveColor = Color.FromArgb(int.Parse(possibleTimeSaveColor));
            Settings.Default.PossibleTimeSaveFont = fontConverter.ConvertFromString(possibleTimeSaveFont) as Font;
            Settings.Default.PredictedTimeBackgroundColor = Color.FromArgb(int.Parse(predictedTimeBackgroundColor));
            Settings.Default.PredictedTimeTextColor = Color.FromArgb(int.Parse(predictedTimeTextColor));
            Settings.Default.PredictedTimeTextFont = fontConverter.ConvertFromString(predictedTimeTextFont) as Font;
            Settings.Default.PredictedTimeColor = Color.FromArgb(int.Parse(predictedTimeColor));
            Settings.Default.PredictedTimeFont = fontConverter.ConvertFromString(predictedTimeFont) as Font;
            Settings.Default.SumOfBestBackgroundColor = Color.FromArgb(int.Parse(sumOfBestBackgroundColor));
            Settings.Default.SumOfBestTextColor = Color.FromArgb(int.Parse(sumOfBestTextColor));
            Settings.Default.SumOfBestTextFont = fontConverter.ConvertFromString(sumOfBestTextFont) as Font;
            Settings.Default.SumOfBestColor = Color.FromArgb(int.Parse(sumOfBestColor));
            Settings.Default.SumOfBestFont = fontConverter.ConvertFromString(sumOfBestFont) as Font;
            Settings.Default.SegmentTimerBackgroundColor = Color.FromArgb(int.Parse(segmentTimerBackgroundColor));
            Settings.Default.SegmentTimerPBColor = Color.FromArgb(int.Parse(segmentTimerPBColor));
            Settings.Default.SegmentTimerPBFont = fontConverter.ConvertFromString(segmentTimerPBFont) as Font;
            Settings.Default.SegmentTimerBestColor = Color.FromArgb(int.Parse(segmentTimerBestColor));
            Settings.Default.SegmentTimerBestFont = fontConverter.ConvertFromString(segmentTimerBestFont) as Font;
            Settings.Default.SegmentTimerFont = fontConverter.ConvertFromString(segmentTimerFont) as Font;
            Settings.Default.SegmentTimerNotRunningColor = Color.FromArgb(int.Parse(segmentTimerNotRunningColor));
            Settings.Default.SegmentTimerRunningColor = Color.FromArgb(int.Parse(segmentTimerRunningColor));
            Settings.Default.SegmentTimerLosingTimeColor = Color.FromArgb(int.Parse(segmentTimerLosingTimeColor));
            Settings.Default.SegmentTimerPausedColor = Color.FromArgb(int.Parse(segmentTimerPausedColor));
        }

    }
}
