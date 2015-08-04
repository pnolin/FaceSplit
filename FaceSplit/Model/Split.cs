using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FaceSplit.Properties;

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
        private String file;

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

        public int RunsCompleted
        {
            get { return this.runsCompleted; }
            set { this.runsCompleted = value; }
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

        public Segment CurrentSegment
        {
            get { return this.segments.ElementAt(this.liveIndex); }
        }

        public String File
        {
            get { return this.file; }
            set { this.file = value; }
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
        public void DoSplit(Double splitTime, Double segmentTime)
        {
            this.segments.ElementAt(liveIndex).DoSplit(splitTime, segmentTime);
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
                this.segments.ElementAt(liveIndex).ResetTimes(true);
                if (this.liveIndex < this.segments.Count - 1)
                {
                    this.segments.ElementAt(liveIndex + 1).PreviousWasSkipped = false;
                }
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

        public void SetCurrentSegmentColor(Color color)
        {
            this.segments.ElementAt(this.liveIndex).RunDeltaColor = color;
        }

        public Boolean PreviousSegmentHasSegmentDelta()
        {
            if (this.liveIndex > 0)
            {
                return this.segments.ElementAt(this.liveIndex - 1).HasSegmentDelta();
            }
            return false;
        }

        public double GetPreviousSegmentDelta()
        {
            if (this.liveIndex > 0)
            {
                return this.segments.ElementAt(this.liveIndex - 1).CalculateSegmentDelta();
            }
            return 0.0;
        }

        public Boolean PreviousSegmentIsBestSegment()
        {
            return this.segments.ElementAt(this.liveIndex - 1).IsBestSegment();
        }

        public void SetPreviousSegmentColor(Boolean bestSegment, bool lostTime)
        {
            if (this.liveIndex > 0)
            {
                if (bestSegment)
                {
                    this.segments.ElementAt(this.liveIndex - 1).RunDeltaColor = Color.Gold;
                }
                else
                {
                    if (this.liveIndex == 1)
                    {
                        if (!lostTime)
                        {
                            this.segments.ElementAt(this.liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasAheadSavingColor;
                        }
                        else
                        {
                            this.segments.ElementAt(this.liveIndex - 1).RunDeltaColor = Color.DarkRed;
                        }
                    }
                    else
                    {
                        if (!lostTime)
                        {
                            if (GetRunDelta(this.liveIndex - 1) > 0.0)
                            {
                                this.segments.ElementAt(this.liveIndex - 1).RunDeltaColor = Color.Red;
                            }
                            else
                            {
                                this.segments.ElementAt(this.liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasAheadSavingColor;
                            }
                        }
                        else
                        {
                            if (GetRunDelta(this.liveIndex - 1) > 0.0)
                            {
                                this.segments.ElementAt(this.liveIndex - 1).RunDeltaColor = Color.DarkRed;
                            }
                            else
                            {
                                this.segments.ElementAt(this.liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasAheadLosingColor;
                            }
                        }
                    }
                }
            }
        }

        public Color GetSegmentColor(int index)
        {
            return this.segments.ElementAt(index).RunDeltaColor;
        }

        public double GetLiveRunDelta(double runTimeElapsed)
        {
            return runTimeElapsed - this.segments.ElementAt(liveIndex).SplitTime;
        }

        public Boolean CurrentSegmentHasLiveDelta(double segmentTimeElapsed)
        {
            if (this.liveIndex >= 0 && this.liveIndex < this.segments.Count)
            {
                return this.segments.ElementAt(this.liveIndex).HasLiveSegmentDelta(segmentTimeElapsed);
            }
            return false;
        }

        public Double GetLiveSegmentDelta(double segmentTimeElapsed)
        {
            return this.segments.ElementAt(this.liveIndex).CalculateLiveSegmentDelta(segmentTimeElapsed);
        }

        public Boolean SegmentHasPossibleTimeSave()
        {
            if (this.liveIndex != -1 && this.liveIndex < this.segments.Count)
            {
                return this.segments.ElementAt(this.liveIndex).HasPossibleTimeSave();
            }
            return false;
        }

        public Double GetPossibleTimeSave()
        {
            return this.segments.ElementAt(this.liveIndex).BackupSegmentTime - this.segments.ElementAt(this.liveIndex).BackupBestSegmentTime;
        }

        public Double GetPredictedTime()
        {
            Double pred = this.GetSOB();
            if (this.liveIndex <= 0)
            {
                return pred;
            }
            else if(pred != 0.0)
            {
                pred = 0.0;
                for (int i = 0; i < this.liveIndex; ++i)
                {
                    if (!this.segments.ElementAt(i).WasSkipped && !this.segments.ElementAt(i).PreviousWasSkipped)
                    {
                        pred += this.segments.ElementAt(i).SegmentTime;
                    }
                    else
                    {
                        pred = 0.0;
                        break;
                    }
                }
                if (pred != 0.0)
                {
                    for (int i = this.liveIndex; i < this.segments.Count; ++i)
                    {
                        pred += this.segments.ElementAt(i).BestSegmentTime;
                    }
                }
                return pred;
            }
            return 0.0;
        }

        public Double GetSOB()
        {
            Boolean incalculableSob = false;
            Double sob = 0.0;
            Double bestSegmentTime = 0.0;
            int i = 0;
            for (i = 0; i < this.liveIndex; ++i )
            {
                bestSegmentTime = this.segments.ElementAt(i).BestSegmentTime;
                if (bestSegmentTime == 0.0)
                {
                    incalculableSob = true;
                    sob = 0.0;
                    break;
                }
                sob += bestSegmentTime;
            }
            if (!incalculableSob)
            {
                for (i = (this.liveIndex == -1) ? 0 : this.liveIndex; i < this.segments.Count; ++i)
                {
                    bestSegmentTime = this.segments.ElementAt(i).BackupBestSegmentTime;
                    if (bestSegmentTime == 0.0)
                    {
                        sob = 0.0;
                        break;
                    }
                    sob += bestSegmentTime;
                }
            }
            return sob;
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
            if(IsNewPb())
            {
                foreach (Segment segment in this.segments)
                {
                    segment.SaveTimes(false);
                    segment.PreviousWasSkipped = false;
                }
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
                segment.ResetTimes(false);
                segment.SaveTimes(true);
                segment.PreviousWasSkipped = false;
            }
            this.liveIndex = -1;
        }

        public void SkipSegment(double segmentTime)
        {
            this.segments.ElementAt(liveIndex).Skip(segmentTime);
            if (this.liveIndex < this.segments.Count - 1)
            {
                this.segments.ElementAt(liveIndex + 1).PreviousWasSkipped = true;
            }
            this.liveIndex++;
        }

        public Boolean PreviousSegmentWasSkipped()
        {
            if (this.liveIndex == this.segments.Count)
            {
                return this.segments.Last().PreviousWasSkipped;
            }

            return this.CurrentSegment.PreviousWasSkipped;
        }

        private Boolean IsNewPb()
        {
            return this.segments.Last().SplitTime < this.segments.Last().BackupSplitTime || (this.segments.Last().BackupSplitTime == 0.0);
        }

        public Boolean FirstSplit()
        {
            return this.liveIndex == 0;
        }

        /// <summary>
        /// If the current split is the last split.
        /// </summary>
        /// <returns></returns>
        public Boolean CurrentSplitIsLastSplit()
        {
            return liveIndex == this.segments.Count - 1;
        }

    }
}
