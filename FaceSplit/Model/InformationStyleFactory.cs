using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FaceSplit.Properties;

namespace FaceSplit.Model
{
    public class InformationStyleFactory
    {
        public static void SetInformationStyle(Information information)
        {
            if (information.InformationName == InformationName.TITLE)
            {
                information.BackgroundColor = Settings.Default.TitleBackgroundColor;
                information.PrimaryTextFont = Settings.Default.TitleFont;
                information.PrimaryTextColor = Settings.Default.TitleColor;
                information.SecondaryTextFont = Settings.Default.AttemptsFont;
                information.SecondaryTextColor = Settings.Default.AttemptsColor;
            }
            else if (information.InformationName == InformationName.GOAL)
            {
                information.BackgroundColor = Settings.Default.GoalBackgroundColor;
                information.PrimaryTextFont = Settings.Default.GoalFont;
                information.PrimaryTextColor = Settings.Default.GoalColor;
            }
            else if(information.InformationName == InformationName.PREVIOUS_SEGMENT)
            {
                information.BackgroundColor = Settings.Default.PreviousSegmentBackgroundColor;
                information.PrimaryTextFont = Settings.Default.PreviousSegmentTextFont;
                information.PrimaryTextColor = Settings.Default.PreviousSegmentTextColor;
                information.SecondaryTextFont = Settings.Default.PreviousSegmentDeltaFont;
                information.SecondaryTextColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor;
            }
            else if (information.InformationName == InformationName.POSSIBLE_TIME_SAVE)
            {
                information.BackgroundColor = Settings.Default.PossibleTimeSaveBackgroundColor;
                information.PrimaryTextFont = Settings.Default.PossibleTimeSaveTextFont;
                information.PrimaryTextColor = Settings.Default.PossibleTimeSaveTextColor;
                information.SecondaryTextFont = Settings.Default.PossibleTimeSaveFont;
                information.SecondaryTextColor = Settings.Default.PossibleTimeSaveColor;
            }
            else if (information.InformationName == InformationName.PREDICTED_TIME)
            {
                information.BackgroundColor = Settings.Default.PredictedTimeBackgroundColor;
                information.PrimaryTextFont = Settings.Default.PredictedTimeTextFont;
                information.PrimaryTextColor = Settings.Default.PredictedTimeTextColor;
                information.SecondaryTextFont = Settings.Default.PredictedTimeFont;
                information.SecondaryTextColor = Settings.Default.PredictedTimeColor;
            }
            else if (information.InformationName == InformationName.SUM_OF_BEST)
            {
                information.BackgroundColor = Settings.Default.SumOfBestBackgroundColor;
                information.PrimaryTextFont = Settings.Default.SumOfBestTextFont;
                information.PrimaryTextColor = Settings.Default.SumOfBestTextColor;
                information.SecondaryTextFont = Settings.Default.SumOfBestFont;
                information.SecondaryTextColor = Settings.Default.SumOfBestColor;
            }
        }
    }
}
