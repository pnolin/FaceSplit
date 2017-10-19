using FaceSplit.Model;
using System;

namespace FaceSplit.Dtos
{
    public class SegmentDto
    {
        private string segmentName;
        private double splitTime;
        private double segmentTime;
        private double bestSegmentTime;
        private string iconPath;

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

        public string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }

        public SegmentDto fromModel(Segment segment)
        {
            SegmentDto segmentDto = new SegmentDto();
            segmentDto.segmentName = segment.SegmentName;
            segmentDto.splitTime = segment.SplitTime;
            segmentDto.segmentTime = segment.SegmentTime;
            segmentDto.bestSegmentTime = segment.BestSegmentTime;
            segmentDto.iconPath = segment.IconPath;

            return segmentDto;
        }

        public Segment toModel()
        {
            return new Segment(SegmentName, SplitTime, SegmentTime, BestSegmentTime, 
                new BitmapFile(IconPath));
        }
    }
}
