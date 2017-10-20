using FaceSplit.Properties;
using FaceSplit.ViewModels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FaceSplit.Drawables
{
    public class Timer
    {
        private TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

        public Timer() { }

        public void Draw(Graphics graphics, ViewModels.Timer timer)
        {
            string timeString = timer.Time.ToString("hh\\:mm\\:ss\\.ff");
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.TimerBackgroundColor), timer.WatchRectangle);
            TextRenderer.DrawText(graphics, timeString, SettingsLayout.Default.TimerFont, timer.WatchRectangle, timer.TimeColor, flags);
        }
    }
}
