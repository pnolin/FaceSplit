using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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
        private Boolean wasSkipped;
        private Boolean previousWasSkipped;
        private Color runDeltaColor;

        public Segment(String name, double splitTime, double segmentTime, double bestSegmentTime)
        {
            this.segmentName = name;
            this.splitTime = splitTime;
            this.backupSplitTime = splitTime;
            this.segmentTime = segmentTime;
            this.backupSegmentTime = segmentTime;
            this.bestSegmentTime = bestSegmentTime;
            this.backupBestSegmentTime = bestSegmentTime;
            this.wasSkipped = false;
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

        public Double BackupSplitTime
        {
            get { return this.backupSplitTime; }
        }

        public Double BackupSegmentTime
        {
            get { return this.backupSegmentTime; }
        }

        public double BackupBestSegmentTime
        {
            get { return this.backupBestSegmentTime; }
        }

        public Boolean WasSkipped
        {
            get { return this.wasSkipped; }
        }

        public Boolean PreviousWasSkipped
        {
            get { return this.previousWasSkipped; }
            set { this.previousWasSkipped = value; }
        }

        public Color RunDeltaColor
        {
            get { return this.runDeltaColor; }
            set { this.runDeltaColor = value; }
        }

        public void DoSplit(Double splitTime, Double segmentTime)
        {
            this.splitTime = splitTime;
            this.segmentTime = segmentTime;
            this.wasSkipped = false;
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
        /// If this is a new run or if the segment was skip in PB we don't have a delta.
        /// </summary>
        /// <returns></returns>
        public Boolean HasSegmentDelta()
        {
            return backupSegmentTime != 0.0 && segmentTime != 0.0 && !this.wasSkipped && !this.previousWasSkipped;
        }

        public Boolean HasLiveSegmentDelta(double timeElapsed)
        {
            return !this.previousWasSkipped && timeElapsed >= backupBestSegmentTime && this.backupSegmentTime != 0.0 && this.bestSegmentTime != 0.0;
        }

        public Boolean HasPossibleTimeSave()
        {
            return this.BackupSegmentTime != 0.0 && this.BackupBestSegmentTime != 0.0;
        }

        public double CalculateLiveSegmentDelta(double timeElapsed)
        {
            return timeElapsed - backupSegmentTime;
        }

        /// <summary>
        /// Calculate the run delta from the segment.
        /// </summary>
        /// <returns></returns>
        public double CalculateRunDelta()
        {
            return this.splitTime - this.backupSplitTime;
        }

        public double CalculateSegmentDelta()
        {
            return this.segmentTime - this.backupSegmentTime;
        }

        public Boolean IsBestSegment()
        {
            Boolean bestSegment = ((this.segmentTime < this.backupBestSegmentTime || backupBestSegmentTime == 0.0) && !this.wasSkipped);
            if (bestSegment)
            {
                this.bestSegmentTime = this.segmentTime;
            }
            return bestSegment;
        }

        public void SaveTimes(Boolean saveOnlyBest)
        {
            if (!saveOnlyBest)
            {
                if (!this.wasSkipped && !this.previousWasSkipped)
                {
                    this.backupSegmentTime = this.segmentTime;
                }
                else
                {
                    this.backupSegmentTime = 0.0;
                }          
            this.backupSplitTime = this.splitTime;
            }
            this.backupBestSegmentTime = this.bestSegmentTime;
        }

        public void ResetTimes(Boolean resetBest)
        {
            this.splitTime = backupSplitTime;
            this.segmentTime = backupSegmentTime;
            if (resetBest)
            {
                this.bestSegmentTime = backupBestSegmentTime;
            }
            this.wasSkipped = false;
        }

        public void Skip(double segmentTime)
        {
            this.wasSkipped = true;
            this.splitTime = 0.0;
            this.segmentTime = segmentTime;
        }

    }
}
