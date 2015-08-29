using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FaceSplit.Properties;
using System.Xml.Serialization;

namespace FaceSplit.Model
{
    public class LayoutSettings
    {
        private String file;
        private FontConverter fontConverter;

        public String timerFont;
        public String timerNotRunningColor;
        public String timerBackgroundColor;
        public String timerRunningColor;
        public String timerBehindColor;
        public String timerPausedColor;
        public String splitsBackgroundColor;
        public String currentSegmentColor;
        public String splitTimesFont;
        public String splitTimesColor;
        public String splitNamesFont;
        public String splitNamesColor;
        public String splitDeltasFont;
        public String splitDeltasAheadSavingColor;
        public String splitDeltasAheadLosingColor;
        public String splitDeltasBehindSavingColor;
        public String splitDeltasBehindLosingColor;
        public String splitDeltasBestSegmentColor;
        public String titleBackgroundColor;
        public String titleFont;
        public String titleColor;
        public String attemptsFont;
        public String attemptsColor;
        public String goalBackgroundColor;
        public String goalColor;
        public String goalFont;
        public String previousSegmentBackgroundColor;
        public String previousSegmentTextColor;
        public String previousSegmentTextFont;
        public String previousSegmentDeltaSavedColor;
        public String previousSegmentDeltaLostColor;
        public String previousSegmentDeltaBestSegmentColor;
        public String previousSegmentDeltaFont;
        public String previousSegmentDeltaNoDeltaColor;
        public String possibleTimeSaveBackgroundColor;
        public String possibleTimeSaveTextColor;
        public String possibleTimeSaveTextFont;
        public String possibleTimeSaveColor;
        public String possibleTimeSaveFont;
        public String predictedTimeBackgroundColor;
        public String predictedTimeTextColor;
        public String predictedTimeTextFont;
        public String predictedTimeColor;
        public String predictedTimeFont;
        public String sumOfBestBackgroundColor;
        public String sumOfBestTextColor;
        public String sumOfBestTextFont;
        public String sumOfBestColor;
        public String sumOfBestFont;
        public String segmentTimerBackgroundColor;
        public String segmentTimerPBColor;
        public String segmentTimerPBFont;
        public String segmentTimerBestColor;
        public String segmentTimerBestFont;
        public String segmentTimerFont;
        public String segmentTimerNotRunningColor;
        public String segmentTimerRunningColor;
        public String segmentTimerLosingTimeColor;
        public String segmentTimerPausedColor;

        [XmlIgnore]
        public String File
        {
            get { return this.file; }
            set { this.file = value; }
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
            Settings.Default.TimerNotRunningColor = Color.FromArgb(Int32.Parse(timerNotRunningColor));
            Settings.Default.TimerBackgroundColor = Color.FromArgb(Int32.Parse(timerBackgroundColor));
            Settings.Default.TimerRunningColor = Color.FromArgb(Int32.Parse(timerRunningColor));
            Settings.Default.TimerBehindColor = Color.FromArgb(Int32.Parse(timerBehindColor));
            Settings.Default.TimerPausedColor = Color.FromArgb(Int32.Parse(timerPausedColor));
            Settings.Default.SplitsBackgroundColor = Color.FromArgb(Int32.Parse(splitsBackgroundColor));
            Settings.Default.CurrentSegmentColor = Color.FromArgb(Int32.Parse(currentSegmentColor));
            Settings.Default.SplitTimesFont = fontConverter.ConvertFromString(splitTimesFont) as Font;
            Settings.Default.SplitTimesColor = Color.FromArgb(Int32.Parse(splitTimesColor));
            Settings.Default.SplitNamesFont = fontConverter.ConvertFromString(splitNamesFont) as Font;
            Settings.Default.SplitNamesColor = Color.FromArgb(Int32.Parse(splitNamesColor));
            Settings.Default.SplitDeltasFont = fontConverter.ConvertFromString(splitDeltasFont) as Font;
            Settings.Default.SplitDeltasAheadSavingColor = Color.FromArgb(Int32.Parse(splitDeltasAheadSavingColor));
            Settings.Default.SplitDeltasAheadLosingColor = Color.FromArgb(Int32.Parse(splitDeltasAheadLosingColor));
            Settings.Default.SplitDeltasBehindSavingColor = Color.FromArgb(Int32.Parse(splitDeltasBehindSavingColor));
            Settings.Default.SplitDeltasBehindLosingColor = Color.FromArgb(Int32.Parse(splitDeltasBehindLosingColor));
            Settings.Default.SplitDeltasBestSegmentColor = Color.FromArgb(Int32.Parse(splitDeltasBestSegmentColor));
            Settings.Default.TitleBackgroundColor = Color.FromArgb(Int32.Parse(titleBackgroundColor));
            Settings.Default.TitleFont = fontConverter.ConvertFromString(titleFont) as Font;
            Settings.Default.TitleColor = Color.FromArgb(Int32.Parse(titleColor));
            Settings.Default.AttemptsFont = fontConverter.ConvertFromString(attemptsFont) as Font;
            Settings.Default.AttemptsColor = Color.FromArgb(Int32.Parse(attemptsColor));
            Settings.Default.GoalBackgroundColor = Color.FromArgb(Int32.Parse(goalBackgroundColor));
            Settings.Default.GoalColor = Color.FromArgb(Int32.Parse(goalColor));
            Settings.Default.GoalFont = fontConverter.ConvertFromString(goalFont) as Font;
            Settings.Default.PreviousSegmentBackgroundColor = Color.FromArgb(Int32.Parse(previousSegmentBackgroundColor));
            Settings.Default.PreviousSegmentTextColor = Color.FromArgb(Int32.Parse(previousSegmentTextColor));
            Settings.Default.PreviousSegmentTextFont = fontConverter.ConvertFromString(previousSegmentTextFont) as Font;
            Settings.Default.PreviousSegmentDeltaSavedColor = Color.FromArgb(Int32.Parse(previousSegmentDeltaSavedColor));
            Settings.Default.PreviousSegmentDeltaLostColor = Color.FromArgb(Int32.Parse(previousSegmentDeltaLostColor));
            Settings.Default.PreviousSegmentDeltaBestSegmentColor = Color.FromArgb(Int32.Parse(previousSegmentDeltaBestSegmentColor));
            Settings.Default.PreviousSegmentDeltaFont = fontConverter.ConvertFromString(previousSegmentDeltaFont) as Font;
            Settings.Default.PreviousSegmentDeltaNoDeltaColor = Color.FromArgb(Int32.Parse(previousSegmentDeltaNoDeltaColor));
            Settings.Default.PossibleTimeSaveBackgroundColor = Color.FromArgb(Int32.Parse(possibleTimeSaveBackgroundColor));
            Settings.Default.PossibleTimeSaveTextColor = Color.FromArgb(Int32.Parse(possibleTimeSaveTextColor));
            Settings.Default.PossibleTimeSaveTextFont = fontConverter.ConvertFromString(possibleTimeSaveTextFont) as Font;
            Settings.Default.PossibleTimeSaveColor = Color.FromArgb(Int32.Parse(possibleTimeSaveColor));
            Settings.Default.PossibleTimeSaveFont = fontConverter.ConvertFromString(possibleTimeSaveFont) as Font;
            Settings.Default.PredictedTimeBackgroundColor = Color.FromArgb(Int32.Parse(predictedTimeBackgroundColor));
            Settings.Default.PredictedTimeTextColor = Color.FromArgb(Int32.Parse(predictedTimeTextColor));
            Settings.Default.PredictedTimeTextFont = fontConverter.ConvertFromString(predictedTimeTextFont) as Font;
            Settings.Default.PredictedTimeColor = Color.FromArgb(Int32.Parse(predictedTimeColor));
            Settings.Default.PredictedTimeFont = fontConverter.ConvertFromString(predictedTimeFont) as Font;
            Settings.Default.SumOfBestBackgroundColor = Color.FromArgb(Int32.Parse(sumOfBestBackgroundColor));
            Settings.Default.SumOfBestTextColor = Color.FromArgb(Int32.Parse(sumOfBestTextColor));
            Settings.Default.SumOfBestTextFont = fontConverter.ConvertFromString(sumOfBestTextFont) as Font;
            Settings.Default.SumOfBestColor = Color.FromArgb(Int32.Parse(sumOfBestColor));
            Settings.Default.SumOfBestFont = fontConverter.ConvertFromString(sumOfBestFont) as Font;
            Settings.Default.SegmentTimerBackgroundColor = Color.FromArgb(Int32.Parse(segmentTimerBackgroundColor));
            Settings.Default.SegmentTimerPBColor = Color.FromArgb(Int32.Parse(segmentTimerPBColor));
            Settings.Default.SegmentTimerPBFont = fontConverter.ConvertFromString(segmentTimerPBFont) as Font;
            Settings.Default.SegmentTimerBestColor = Color.FromArgb(Int32.Parse(segmentTimerBestColor));
            Settings.Default.SegmentTimerBestFont = fontConverter.ConvertFromString(segmentTimerBestFont) as Font;
            Settings.Default.SegmentTimerFont = fontConverter.ConvertFromString(segmentTimerFont) as Font;
            Settings.Default.SegmentTimerNotRunningColor = Color.FromArgb(Int32.Parse(segmentTimerNotRunningColor));
            Settings.Default.SegmentTimerRunningColor = Color.FromArgb(Int32.Parse(segmentTimerRunningColor));
            Settings.Default.SegmentTimerLosingTimeColor = Color.FromArgb(Int32.Parse(segmentTimerLosingTimeColor));
            Settings.Default.SegmentTimerPausedColor = Color.FromArgb(Int32.Parse(segmentTimerPausedColor));
        }

    }
}
