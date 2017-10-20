using FaceSplit.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FaceSplit.Drawables 
{
    public class Timer
    {
        private TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

        Rectangle watchRectangle;
        Color watchColor;
        private TimeSpan time;

        public Timer()
        {
            watchRectangle = new Rectangle(
                DrawingConstants.ZERO,
                DrawingConstants.ZERO,
                DrawingConstants.DEFAULT_WIDTH,
                DrawingConstants.DEFAULT_HEIGHT);
            watchColor = Color.Wheat;
        }

        public void Update(TimeSpan time)
        {
            this.time = time;
        }

        public void Draw(Graphics graphics)
        {
            string timeString = time.ToString("hh\\:mm\\:ss\\.ff");
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.TimerBackgroundColor), watchRectangle);
            TextRenderer.DrawText(graphics, timeString, SettingsLayout.Default.TimerFont, watchRectangle, watchColor, flags);
        }
    }
}
