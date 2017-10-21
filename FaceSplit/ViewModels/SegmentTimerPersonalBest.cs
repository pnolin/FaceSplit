using System.Drawing;

namespace FaceSplit.ViewModels
{
    public class SegmentTimerPersonalBest
    {
        private const string TEXT = "PB: ";

        private Rectangle segmentTimerPersonalBestRectangle;
        private double segmentTimerPersonalBest;

        public Rectangle SegmentTimerPersonalBestRectangle
        {
            get { return segmentTimerPersonalBestRectangle; }
            set { segmentTimerPersonalBestRectangle = value; }
        }

        public string Text
        {
            get { return TEXT; }
        }

        public double PersonalBest
        {
            get { return segmentTimerPersonalBest; }
            set { segmentTimerPersonalBest = value; }
        }
    }
}
