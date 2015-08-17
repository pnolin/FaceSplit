﻿using System;
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
        }
    }
}