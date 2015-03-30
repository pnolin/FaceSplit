using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceSplit.Model
{
    public class Segment
    {
        private String segmentName;
        private double segmentTime;
        private double backupSegmentTime;
        private double bestSegmentTime;
        private double backupBestSegmentTime;
        private double splitTime;
        private double backupSplitTime;

        public Segment(String name, double splitTime, double segmentTime, double bestSegmentTime)
        {
            this.segmentName = name;
            this.splitTime = splitTime;
            this.backupSplitTime = splitTime;
            this.segmentTime = segmentTime;
            this.backupSegmentTime = segmentTime;
            this.bestSegmentTime = bestSegmentTime;
            this.backupBestSegmentTime = bestSegmentTime;
        }

        public String SegmentName
        {
            get { return this.segmentName; }
            set { this.segmentName = value; }
        }

        public double SplitTime
        {
            get { return this.splitTime; }
            set { this.splitTime = value; }
        }

        public double SegmentTime
        {
            get { return this.segmentTime; }
            set { this.segmentTime = value; }
        }

        public double BestSegmentTime
        {
            get { return this.bestSegmentTime; }
            set { this.bestSegmentTime = value; }
        }

        public void DoSplit(Double splitTime)
        {
            this.splitTime = splitTime;
        }

        /// <summary>
        /// If this segment has no split time, we can't calculate run delta, this is what we are looking at here.
        /// </summary>
        /// <returns></returns>
        public Boolean HasRunDelta()
        {
            return backupSplitTime != 0.0 && splitTime != 0.0;
        }

        /// <summary>
        /// Calculate the run delta from the segment.
        /// </summary>
        /// <returns></returns>
        public double CalculateRunDelta()
        {
            return this.splitTime - this.backupSplitTime;
        }

        public void SaveTimes()
        {
            this.backupSplitTime = this.splitTime;
        }

        public void ResetTimes()
        {
            this.splitTime = backupSplitTime;
        }

        public void Skip()
        {
            this.splitTime = 0.0;
        }

    }
}
