using FaceSplit.Properties;
using FaceSplit.ViewModels;
using System.Drawing;
using System.Windows.Forms;

namespace FaceSplit.Drawables
{
    public class SegmentTimer
    {
        TextFormatFlags segmentPersonalBestFlags = TextFormatFlags.Left | TextFormatFlags.Bottom | TextFormatFlags.WordEllipsis;
        TextFormatFlags segmentBestTimeFlags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordEllipsis;

        public void Draw(Graphics graphics, ViewModels.SegmentTimer segmentTimer)
        {
            if(segmentTimer.State == SegmentTimerState.EMPTY)
            {
                DrawEmptySegmentTimer(graphics, segmentTimer);
            }
            else
            {
                DrawSegmentTimer(graphics, segmentTimer);
            }
        }

        private void DrawEmptySegmentTimer(Graphics graphics, ViewModels.SegmentTimer segmentTimer)
        {
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), segmentTimer.SegmentWatchRectangle);
        }

        private void DrawSegmentTimer(Graphics graphics, ViewModels.SegmentTimer segmentTimer)
        {
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), segmentTimer.SegmentWatchRectangle);
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), segmentTimer.SegmentPersonalBestRectangle);
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), segmentTimer.SegmentBestTimeRectangle);

            TextRenderer.DrawText(graphics, segmentTimer.SegmentPersonalBestString + FaceSplitUtils.TimeFormat(segmentTimer.SegmentPersonalBest), SettingsLayout.Default.SegmentTimerPBFont,
                segmentTimer.SegmentPersonalBestRectangle, SettingsLayout.Default.SegmentTimerPBColor, segmentPersonalBestFlags);
            TextRenderer.DrawText(graphics, segmentTimer.SegmentBestTimeString + FaceSplitUtils.TimeFormat(segmentTimer.SegmentBestTime), SettingsLayout.Default.SegmentTimerBestFont,
                segmentTimer.SegmentBestTimeRectangle, SettingsLayout.Default.SegmentTimerBestColor, segmentBestTimeFlags);
            TextRenderer.DrawText(graphics, FaceSplitUtils.TimeFormat(segmentTimer.SegmentTime), SettingsLayout.Default.SegmentTimerFont,
                segmentTimer.SegmentWatchRectangle, segmentTimer.TimerColor);
        }
    }
}
