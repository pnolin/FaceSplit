using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceSplit.Model
{
    public class Split
    {
        private RunStatus runStatus;
        private List<Segment> segments;
        private String runTitle;
        private String runGoal;
        private int attemptsCount;
        private int runsCompleted;
        private int liveIndex;
        private double personalBest;
        private double sumOfBests;

        public Split()
        {
            this.segments = new List<Segment>();
            this.liveIndex = -1;
            this.runStatus = RunStatus.STOPPED;
        }

        public Split(String runTitle, String runGoal, int attemptsCount, List<Segment> segments)
        {
            this.liveIndex = -1;
            this.runTitle = runTitle;
            this.runGoal = runGoal;
            this.attemptsCount = attemptsCount;
            this.segments = new List<Segment>();
            foreach (Segment segment in segments)
            {
                this.segments.Add(segment);
            }
            this.runStatus = RunStatus.STOPPED;
        }

        public String RunTitle
        {
            get { return this.runTitle; }
            set { this.runTitle = value; }
        }

        public String RunGoal
        {
            get { return this.runGoal; }
            set { this.runGoal = value; }
        }

        public int AttemptsCount
        {
            get { return this.attemptsCount; }
            set { this.attemptsCount = value; }
        }

        public int LiveIndex
        {
            get { return this.liveIndex; }
        }

        public RunStatus RunStatus
        {
            get { return this.runStatus; }
        }

        public List<Segment> Segments
        {
            get { return this.segments; }
            set { this.segments = value; }
        }

        /// <summary>
        /// Star the run by incresing indexes and run attempts.
        /// </summary>
        public void StartRun()
        {
            this.liveIndex = 0;
            this.attemptsCount++;
            this.runStatus = RunStatus.ON_GOING;
        }

        /// <summary>
        /// The the time split of the actual segment.
        /// </summary>
        /// <param name="splitTime"></param>
        public void DoSplit(Double splitTime)
        {
            this.segments.ElementAt(liveIndex).DoSplit(splitTime);
            this.liveIndex++;
        }


        /// <summary>
        /// Go back to the previous split.
        /// </summary>
        public void UnSplit()
        {
            if (this.liveIndex > 0)
            {
                this.liveIndex--;
                this.segments.ElementAt(liveIndex).ResetTimes();
            }
        }

        public void ResumeRun()
        {
            this.runStatus = RunStatus.ON_GOING;
        }

        /// <summary>
        /// Check if the split we can calculte run delta from segment.
        /// </summary>
        /// <param name="index">The index of the segment</param>
        /// <returns></returns>
        public Boolean SegmentHasRunDelta(int index)
        {
            return this.segments.ElementAt(index).HasRunDelta();
        }

        /// <summary>
        /// Get the run delta from the segment.
        /// </summary>
        /// <param name="index">Index of the split.</param>
        /// <returns>The delta.</returns>
        public double GetRunDelta(int index)
        {
            return this.segments.ElementAt(index).CalculateRunDelta();
        }

        public double GetLiveRunDelta(double runTimeElapsed)
        {
            return runTimeElapsed - this.segments.ElementAt(liveIndex).SplitTime;
        }

        /// <summary>
        /// When you split on the last split, the run is complete.
        /// </summary>
        public void CompleteRun()
        {
            this.runStatus = RunStatus.DONE;
        }

        /// <summary>
        /// Hitting the split button after having done all the splits will
        /// result in the run being save and set as completed. This is not saving into a 
        /// file.
        /// </summary>
        public void SaveRun()
        {
            this.runsCompleted++;
            foreach (Segment segment in this.segments)
            {
                segment.SaveTimes();
            }
            ResetRun();
        }

        /// <summary>
        /// Set the run status to resetted.
        /// </summary>
        public void ResetRun()
        {
            this.runStatus = RunStatus.STOPPED;
            foreach (Segment segment in this.segments)
            {
                segment.ResetTimes();
            }
            this.liveIndex = -1;
        }

        public void SkipSegment()
        {
            this.segments.ElementAt(liveIndex).Skip();
            this.liveIndex++;
        }

        public Boolean FirstSplit()
        {
            return this.liveIndex == 0;
        }

        /// <summary>
        /// If the current split is the last split.
        /// </summary>
        /// <returns></returns>
        public Boolean LastSplit()
        {
            return liveIndex == this.segments.Count - 1;
        }

    }
}
