using System;
using System.Drawing;
using FaceSplit.Properties;

namespace FaceSplit.Model
{
    public class Segment
    {
        private string segmentName;
        private double segmentTime;
        private double backupSegmentTime;
        private double bestSegmentTime;
        private double backupBestSegmentTime;
        private double splitTime;
        private double backupSplitTime;
        private bool wasSkipped;
        private bool previousWasSkipped;
        private Color runDeltaColor;
        private BitmapFile icon;

        public Segment(string name, double splitTime, double segmentTime, double bestSegmentTime, BitmapFile icon)
        {
            segmentName = name;
            this.splitTime = splitTime;
            backupSplitTime = splitTime;
            this.segmentTime = segmentTime;
            backupSegmentTime = segmentTime;
            this.bestSegmentTime = bestSegmentTime;
            backupBestSegmentTime = bestSegmentTime;
            this.icon = icon;
            wasSkipped = false;
        }

        public string SegmentName
        {
            get { return segmentName; }
            set { segmentName = value; }
        }

        public double SplitTime
        {
            get { return splitTime; }
            set { splitTime = value; }
        }

        public double SegmentTime
        {
            get { return segmentTime; }
            set { segmentTime = value; }
        }

        public double BestSegmentTime
        {
            get { return bestSegmentTime; }
            set { bestSegmentTime = value; }
        }

        public Bitmap Icon
        {
            get { return icon.Icon; }
        }

        public String IconPath
        {
            get { return icon.IconPath; }
        }

        public double BackupSplitTime
        {
            get { return backupSplitTime; }
        }

        public double BackupSegmentTime
        {
            get { return backupSegmentTime; }
        }

        public double BackupBestSegmentTime
        {
            get { return backupBestSegmentTime; }
        }

        public bool WasSkipped
        {
            get { return wasSkipped; }
        }

        public bool PreviousWasSkipped
        {
            get { return previousWasSkipped; }
            set { previousWasSkipped = value; }
        }

        public Color RunDeltaColor
        {
            get { return runDeltaColor; }
            set { runDeltaColor = value; }
        }

        public void DoSplit(double splitTime, double segmentTime)
        {
            this.splitTime = splitTime;
            this.segmentTime = segmentTime;
            wasSkipped = false;
        }

        /// <summary>
        /// If this segment has no split time, we can't calculate run delta, this is what we are looking at here.
        /// </summary>
        /// <returns></returns>
        public bool HasRunDelta()
        {
            return backupSplitTime != 0.0 && splitTime != 0.0;
        }

        /// <summary>
        /// If this is a new run or if the segment was skip in PB we don't have a delta.
        /// </summary>
        /// <returns></returns>
        public bool HasSegmentDelta()
        {
            return backupSegmentTime != 0.0 && segmentTime != 0.0 && !wasSkipped && !previousWasSkipped;
        }

        public bool HasLiveSegmentDelta(double timeElapsed)
        {
            return !previousWasSkipped && timeElapsed >= backupBestSegmentTime && backupSegmentTime != 0.0 && bestSegmentTime != 0.0;
        }

        public bool HasPossibleTimeSave()
        {
            return BackupSegmentTime != 0.0 && BackupBestSegmentTime != 0.0;
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
            return splitTime - backupSplitTime;
        }

        public double CalculateSegmentDelta()
        {
            return segmentTime - backupSegmentTime;
        }

        public bool IsBestSegment()
        {
            bool bestSegment = ((segmentTime < backupBestSegmentTime || backupBestSegmentTime == 0.0) && !wasSkipped);
            if (bestSegment)
            {
                bestSegmentTime = segmentTime;
            }
            return bestSegment;
        }

        public void SaveTimes(bool saveOnlyBest)
        {
            if (!saveOnlyBest)
            {
                if (!wasSkipped && !previousWasSkipped)
                {
                    backupSegmentTime = segmentTime;
                }
                else
                {
                    backupSegmentTime = 0.0;
                }
                backupSplitTime = splitTime;
            }
            backupBestSegmentTime = bestSegmentTime;
        }

        public void ResetTimes(bool resetBest)
        {
            splitTime = backupSplitTime;
            segmentTime = backupSegmentTime;
            if (resetBest)
            {
                bestSegmentTime = backupBestSegmentTime;
            }
            wasSkipped = false;
        }

        public void Skip(double segmentTime)
        {
            wasSkipped = true;
            splitTime = 0.0;
            this.segmentTime = segmentTime;
        }

    }
}
