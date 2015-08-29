using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using FaceSplit.Properties;

namespace FaceSplit.Model
{
    public class Split 
    {
        private RunStatus runStatus;
        private List<Segment> segments;
        private string runTitle;
        private string runGoal;
        private int attemptsCount;
        private int runsCompleted;
        private int liveIndex;
        private string file;

        public Split()
        {
            segments = new List<Segment>();
            liveIndex = -1;
            runStatus = RunStatus.STOPPED;
        }

        public Split(string runTitle, string runGoal, int attemptsCount, List<Segment> segments)
        {
            liveIndex = -1;
            this.runTitle = runTitle;
            this.runGoal = runGoal;
            this.attemptsCount = attemptsCount;
            this.segments = new List<Segment>();
            foreach (Segment segment in segments)
            {
                this.segments.Add(segment);
            }
            runStatus = RunStatus.STOPPED;
        }

        public string RunTitle
        {
            get { return runTitle; }
            set { runTitle = value; }
        }

        public string RunGoal
        {
            get { return runGoal; }
            set { runGoal = value; }
        }

        public int RunsCompleted
        {
            get { return runsCompleted; }
            set { runsCompleted = value; }
        }

        public int AttemptsCount
        {
            get { return attemptsCount; }
            set { attemptsCount = value; }
        }

        public int LiveIndex
        {
            get { return liveIndex; }
        }

        public RunStatus RunStatus
        {
            get { return runStatus; }
        }

        public List<Segment> Segments
        {
            get { return segments; }
            set { segments = value; }
        }

        public Segment CurrentSegment
        {
            get { return segments.ElementAt(liveIndex); }
        }

        public string File
        {
            get { return file; }
            set { file = value; }
        }

        /// <summary>
        /// Star the run by incresing indexes and run attempts.
        /// </summary>
        public void StartRun()
        {
            liveIndex = 0;
            attemptsCount++;
            runStatus = RunStatus.ON_GOING;
        }

        /// <summary>
        /// The the time split of the actual segment.
        /// </summary>
        /// <param name="splitTime"></param>
        public void DoSplit(double splitTime, double segmentTime)
        {
            segments.ElementAt(liveIndex).DoSplit(splitTime, segmentTime);
            liveIndex++;
        }


        /// <summary>
        /// Go back to the previous split.
        /// </summary>
        public void UnSplit()
        {
            if (liveIndex > 0)
            {
                liveIndex--;
                segments.ElementAt(liveIndex).ResetTimes(true);
                if (liveIndex < segments.Count - 1)
                {
                    segments.ElementAt(liveIndex + 1).PreviousWasSkipped = false;
                }
            }
        }

        public void ResumeRun()
        {
            runStatus = RunStatus.ON_GOING;
        }

        /// <summary>
        /// Check if the split we can calculte run delta from segment.
        /// </summary>
        /// <param name="index">The index of the segment</param>
        /// <returns></returns>
        public bool SegmentHasRunDelta(int index)
        {
            return segments.ElementAt(index).HasRunDelta();
        }

        /// <summary>
        /// Get the run delta from the segment.
        /// </summary>
        /// <param name="index">Index of the split.</param>
        /// <returns>The delta.</returns>
        public double GetRunDelta(int index)
        {
            return segments.ElementAt(index).CalculateRunDelta();
        }

        public void SetCurrentSegmentColor(Color color)
        {
            segments.ElementAt(liveIndex).RunDeltaColor = color;
        }

        public bool PreviousSegmentHasSegmentDelta()
        {
            if (liveIndex > 0)
            {
                return segments.ElementAt(liveIndex - 1).HasSegmentDelta();
            }
            return false;
        }

        public double GetPreviousSegmentDelta()
        {
            if (liveIndex > 0)
            {
                return segments.ElementAt(liveIndex - 1).CalculateSegmentDelta();
            }
            return 0.0;
        }

        public bool PreviousSegmentIsBestSegment()
        {
            return segments.ElementAt(liveIndex - 1).IsBestSegment();
        }

        public void SetPreviousSegmentColor(bool bestSegment, bool lostTime)
        {
            if (liveIndex > 0)
            {
                if (bestSegment)
                {
                    segments.ElementAt(liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasBestSegmentColor;
                }
                else
                {
                    if (liveIndex == 1)
                    {
                        if (!lostTime)
                        {
                            segments.ElementAt(liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasAheadSavingColor;
                        }
                        else
                        {
                            segments.ElementAt(liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasBehindLosingColor;
                        }
                    }
                    else
                    {
                        if (!lostTime)
                        {
                            if (GetRunDelta(liveIndex - 1) > 0.0)
                            {
                                segments.ElementAt(liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasBehindSavingColor;
                            }
                            else
                            {
                                segments.ElementAt(liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasAheadSavingColor;
                            }
                        }
                        else
                        {
                            if (GetRunDelta(liveIndex - 1) > 0.0)
                            {
                                segments.ElementAt(liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasBehindLosingColor;
                            }
                            else
                            {
                                segments.ElementAt(liveIndex - 1).RunDeltaColor = Settings.Default.SplitDeltasAheadLosingColor;
                            }
                        }
                    }
                }
            }
        }

        public Color GetSegmentColor(int index)
        {
            return segments.ElementAt(index).RunDeltaColor;
        }

        public double GetLiveRunDelta(double runTimeElapsed)
        {
            return runTimeElapsed - segments.ElementAt(liveIndex).SplitTime;
        }

        public bool CurrentSegmentHasLiveDelta(double segmentTimeElapsed)
        {
            if (liveIndex >= 0 && liveIndex < segments.Count)
            {
                return segments.ElementAt(liveIndex).HasLiveSegmentDelta(segmentTimeElapsed);
            }
            return false;
        }

        public double GetLiveSegmentDelta(double segmentTimeElapsed)
        {
            return segments.ElementAt(liveIndex).CalculateLiveSegmentDelta(segmentTimeElapsed);
        }

        public bool SegmentHasPossibleTimeSave()
        {
            if (liveIndex != -1 && liveIndex < segments.Count)
            {
                return segments.ElementAt(liveIndex).HasPossibleTimeSave();
            }
            return false;
        }

        public double GetPossibleTimeSave()
        {
            return segments.ElementAt(liveIndex).BackupSegmentTime - segments.ElementAt(liveIndex).BackupBestSegmentTime;
        }

        public double GetPredictedTime()
        {
            double pred = GetSOB();
            if (liveIndex <= 0)
            {
                return pred;
            }
            else if(pred != 0.0)
            {
                pred = 0.0;
                for (int i = 0; i < liveIndex; ++i)
                {
                    if (!segments.ElementAt(i).WasSkipped && !segments.ElementAt(i).PreviousWasSkipped)
                    {
                        pred += segments.ElementAt(i).SegmentTime;
                    }
                    else
                    {
                        pred = 0.0;
                        break;
                    }
                }
                if (pred != 0.0)
                {
                    for (int i = liveIndex; i < segments.Count; ++i)
                    {
                        pred += segments.ElementAt(i).BestSegmentTime;
                    }
                }
                return pred;
            }
            return 0.0;
        }

        public double GetSOB()
        {
            bool incalculableSob = false;
            double sob = 0.0;
            double bestSegmentTime = 0.0;
            int i = 0;
            for (i = 0; i < liveIndex; ++i )
            {
                bestSegmentTime = segments.ElementAt(i).BestSegmentTime;
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
                for (i = (liveIndex == -1) ? 0 : liveIndex; i < segments.Count; ++i)
                {
                    bestSegmentTime = segments.ElementAt(i).BackupBestSegmentTime;
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
            runStatus = RunStatus.DONE;
        }

        /// <summary>
        /// Hitting the split button after having done all the splits will
        /// result in the run being save and set as completed. This is not saving into a 
        /// file.
        /// </summary>
        public void SaveRun()
        {
            runsCompleted++;
            if(IsNewPb())
            {
                foreach (Segment segment in segments)
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
            runStatus = RunStatus.STOPPED;
            foreach (Segment segment in segments)
            {
                segment.ResetTimes(false);
                segment.SaveTimes(true);
                segment.PreviousWasSkipped = false;
            }
            liveIndex = -1;
        }

        public void SkipSegment(double segmentTime)
        {
            segments.ElementAt(liveIndex).Skip(segmentTime);
            if (liveIndex < segments.Count - 1)
            {
                segments.ElementAt(liveIndex + 1).PreviousWasSkipped = true;
            }
            liveIndex++;
        }

        public bool PreviousSegmentWasSkipped()
        {
            if (liveIndex == segments.Count)
            {
                return segments.Last().PreviousWasSkipped;
            }

            return CurrentSegment.PreviousWasSkipped;
        }

        private bool IsNewPb()
        {
            return segments.Last().SplitTime < segments.Last().BackupSplitTime || (segments.Last().BackupSplitTime == 0.0);
        }

        public bool FirstSplit()
        {
            return liveIndex == 0;
        }

        /// <summary>
        /// If the current split is the last split.
        /// </summary>
        /// <returns></returns>
        public bool CurrentSplitIsLastSplit()
        {
            return liveIndex == segments.Count - 1;
        }

    }
}
