using FaceSplit.Model;
using System;
using System.Collections.Generic;

namespace FaceSplit.Dtos
{
    public class RunDto
    {
        private string runTitle;
        private string runGoal;
        private int attemptsCount;
        private int runsCompleted;
        private List<SegmentDto> segments;

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

        public int AttemptsCount
        {
            get { return attemptsCount; }
            set { attemptsCount = value; }
        }

        public int RunsCompleted
        {
            get { return runsCompleted; }
            set { runsCompleted = value; }
        }

        public List<SegmentDto> Segments
        {
            get { return segments; }
            set { segments = value; }
        }

        public RunDto fromModel(Split split)
        {
            RunDto runDto = new RunDto();

            runDto.runTitle = split.RunTitle;
            runDto.runGoal = split.RunGoal;
            runDto.attemptsCount = split.AttemptsCount;
            runDto.runsCompleted = split.RunsCompleted;

            runDto.segments = new List<SegmentDto>();

            foreach(Segment segment in split.Segments)
            {
                runDto.segments.Add((SegmentDto)new SegmentDto().fromModel(segment));
            }

            return runDto;
        }

        public Split toModel()
        {
            Split split = new Split();

            split.RunTitle = RunTitle;
            split.RunGoal = RunGoal;
            split.AttemptsCount = AttemptsCount;
            split.RunsCompleted = RunsCompleted;

            foreach(SegmentDto segmentDto in Segments)
            {
                split.Segments.Add(segmentDto.toModel());
            }

            return split;
        }
    }
}
