using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceSplit.Model
{
    public class Split
    {
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

        public List<Segment> Segments
        {
            get { return this.segments; }
            set { this.segments = value; }
        }

    }
}
