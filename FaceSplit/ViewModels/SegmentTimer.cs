using System;
using System.Collections.Generic;
using System.Drawing;

namespace FaceSplit.ViewModels
{
    public class SegmentTimer
    {
        private Drawables.SegmentTimer segmentTimer;
        private SegmentTimerState state;
        private Rectangle segmentWatchRectangle;
        private SegmentTimerPersonalBest segmentPersonalBestRectangle;
        private SegmentTimerBestTime segmentBestTimeRectangle;
        private Color timerColor;
        private double segmentTime;

        public SegmentTimer()
        {
            segmentTimer = new Drawables.SegmentTimer();
            state = SegmentTimerState.EMPTY;
            segmentPersonalBestRectangle = new SegmentTimerPersonalBest();
            segmentBestTimeRectangle = new SegmentTimerBestTime();
        }

        public SegmentTimerState State
        {
            get { return state; }
            set { state = value; }
        }

        public Rectangle SegmentWatchRectangle
        {
            get { return segmentWatchRectangle; }
            set { segmentWatchRectangle = value; }
        }

        public int Y
        {
            get { return segmentWatchRectangle.Y; }
            set { segmentWatchRectangle.Y = value; }
        }

        public Rectangle SegmentPersonalBestRectangle
        {
            get { return segmentPersonalBestRectangle.SegmentTimerPersonalBestRectangle; }
            set { segmentPersonalBestRectangle.SegmentTimerPersonalBestRectangle = value; }
        }

        public Rectangle SegmentBestTimeRectangle
        {
            get { return segmentBestTimeRectangle.SegmentTimerBestTimeRectangle; }
            set { segmentBestTimeRectangle.SegmentTimerBestTimeRectangle = value; }
        }

        public string SegmentPersonalBestString
        {
            get { return segmentPersonalBestRectangle.Text; }
        }

        public string SegmentBestTimeString
        {
            get { return segmentBestTimeRectangle.Text; }
        }

        public double SegmentTime
        {
            get { return segmentTime; }
            set { segmentTime = value; }
        }

        public double SegmentPersonalBest
        {
            get { return segmentPersonalBestRectangle.PersonalBest; }
            set { segmentPersonalBestRectangle.PersonalBest = value; }
        }

        public double SegmentBestTime
        {
            get { return segmentBestTimeRectangle.BestTime; }
            set { segmentBestTimeRectangle.BestTime = value; }
        }

        public Color TimerColor
        {
            get { return timerColor; }
            set { timerColor = value; }
        }

        public void Draw(Graphics graphics)
        {
            segmentTimer.Draw(graphics, this);
        }
    }
}
