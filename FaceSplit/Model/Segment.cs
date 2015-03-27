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
            this.segmentTime = segmentTime;
            this.bestSegmentTime = bestSegmentTime;
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
    }
}
