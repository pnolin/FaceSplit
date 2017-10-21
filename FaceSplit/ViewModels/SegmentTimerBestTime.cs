using System.Drawing;

namespace FaceSplit.ViewModels
{
    public class SegmentTimerBestTime
    {
        private const string TEXT = "BEST: ";

        private Rectangle segmentTimerBestTimeRectangle;
        private double segmentTimerBestTime;

        public Rectangle SegmentTimerBestTimeRectangle
        {
            get { return segmentTimerBestTimeRectangle; }
            set { segmentTimerBestTimeRectangle = value; }
        }

        public string Text
        {
            get { return TEXT; }
        }

        public double BestTime
        {
            get { return segmentTimerBestTime; }
            set { segmentTimerBestTime = value; }
        }
    }
}
