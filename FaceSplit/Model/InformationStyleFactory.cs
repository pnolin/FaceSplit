using FaceSplit.Properties;

namespace FaceSplit.Model
{
    public class InformationStyleFactory
    {
        public static void SetInformationStyle(Information information)
        {
            if (information.InformationName == InformationName.TITLE)
            {
                information.BackgroundColor = SettingsLayout.Default.TitleBackgroundColor;
                information.PrimaryTextFont = SettingsLayout.Default.TitleFont;
                information.PrimaryTextColor = SettingsLayout.Default.TitleColor;
                information.SecondaryTextFont = SettingsLayout.Default.AttemptsFont;
                information.SecondaryTextColor = SettingsLayout.Default.AttemptsColor;
            }
            else if (information.InformationName == InformationName.GOAL)
            {
                information.BackgroundColor = SettingsLayout.Default.GoalBackgroundColor;
                information.PrimaryTextFont = SettingsLayout.Default.GoalFont;
                information.PrimaryTextColor = SettingsLayout.Default.GoalColor;
            }
            else if(information.InformationName == InformationName.PREVIOUS_SEGMENT)
            {
                information.BackgroundColor = SettingsLayout.Default.PreviousSegmentBackgroundColor;
                information.PrimaryTextFont = SettingsLayout.Default.PreviousSegmentTextFont;
                information.PrimaryTextColor = SettingsLayout.Default.PreviousSegmentTextColor;
                information.SecondaryTextFont = SettingsLayout.Default.PreviousSegmentDeltaFont;
                information.SecondaryTextColor = SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor;
            }
            else if (information.InformationName == InformationName.POSSIBLE_TIME_SAVE)
            {
                information.BackgroundColor = SettingsLayout.Default.PossibleTimeSaveBackgroundColor;
                information.PrimaryTextFont = SettingsLayout.Default.PossibleTimeSaveTextFont;
                information.PrimaryTextColor = SettingsLayout.Default.PossibleTimeSaveTextColor;
                information.SecondaryTextFont = SettingsLayout.Default.PossibleTimeSaveFont;
                information.SecondaryTextColor = SettingsLayout.Default.PossibleTimeSaveColor;
            }
            else if (information.InformationName == InformationName.PREDICTED_TIME)
            {
                information.BackgroundColor = SettingsLayout.Default.PredictedTimeBackgroundColor;
                information.PrimaryTextFont = SettingsLayout.Default.PredictedTimeTextFont;
                information.PrimaryTextColor = SettingsLayout.Default.PredictedTimeTextColor;
                information.SecondaryTextFont = SettingsLayout.Default.PredictedTimeFont;
                information.SecondaryTextColor = SettingsLayout.Default.PredictedTimeColor;
            }
            else if (information.InformationName == InformationName.SUM_OF_BEST)
            {
                information.BackgroundColor = SettingsLayout.Default.SumOfBestBackgroundColor;
                information.PrimaryTextFont = SettingsLayout.Default.SumOfBestTextFont;
                information.PrimaryTextColor = SettingsLayout.Default.SumOfBestTextColor;
                information.SecondaryTextFont = SettingsLayout.Default.SumOfBestFont;
                information.SecondaryTextColor = SettingsLayout.Default.SumOfBestColor;
            }
        }
    }
}
