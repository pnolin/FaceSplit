using System;
using System.Drawing;

namespace FaceSplit.ViewModels
{
    public class Timer
    {
        private Drawables.Timer timer;
        private Rectangle watchRectangle;
        private Color timeColor;
        private TimeSpan time;

        public Timer()
        {
            timer = new Drawables.Timer();
        }

        public Rectangle WatchRectangle
        {
            get { return watchRectangle; }
            set { watchRectangle = value; }
        }

        public int Y
        {
            get { return watchRectangle.Y; }
            set { watchRectangle.Y = value; }
        }

        public int Height
        {
            get { return watchRectangle.Height; }
        }

        public Color TimeColor
        {
            get { return timeColor; }
            set { timeColor = value; }
        }

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        public void Update(TimeSpan time)
        {
            this.time = time;
        }

        public void Draw(Graphics graphics)
        {
            timer.Draw(graphics, this);
        }
    }
}
