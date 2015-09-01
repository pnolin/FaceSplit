using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using FaceSplit.Model;
using FaceSplit;

public class LiveSplitXMLReader
{
    private const string GAME_NAME = "GameName";
    private const string CATEGORY_NAME = "CategoryName";
    private const string OFFSET = "Offset";
    private const string ATTEMPTS_COUNT = "AttemptCount";
    private const string SEGMENTS = "Segments";
    private const string SEGMENT_NAME = "Name";
    private const string SPLIT_TIMES = "SplitTimes";
    private const string BEST_SEGMENT = "BestSegmentTime";

    private Split split;
    private XmlDocument xmlDocument;

    public LiveSplitXMLReader()
    {
        split = new Split();
        xmlDocument = new XmlDocument();
    }

    /// <summary>
    /// Read split information from the file and returns it.
    /// </summary>
    /// <param name="file">The filename of the LiveSplit XML file.</param>
    /// <returns>The split with all its information.</returns>
    public Split ReadSplit(string file)
    {
        xmlDocument.Load(file);
        StringBuilder stringBuilder = new StringBuilder();
        string runTitle = "";
        string attemptsCountString = "";
        int attemptsCount = 0;
        XmlNodeList rootNode;
        List<Segment> segments = new List<Segment>();

        rootNode = xmlDocument.DocumentElement.SelectNodes("/Run");
        foreach(XmlNode runNode in rootNode)
        {
            foreach (XmlNode infoNode in runNode.ChildNodes)
            {
                if (infoNode.Name == GAME_NAME)
                {
                    stringBuilder.Append(infoNode.InnerText + " ");
                }
                else if (infoNode.Name == CATEGORY_NAME)
                {
                    stringBuilder.Append(infoNode.InnerText);
                }
                else if (infoNode.Name == ATTEMPTS_COUNT)
                {
                    attemptsCountString = infoNode.InnerText;
                }
                else if (infoNode.Name == SEGMENTS)
                {
                    PopulateSegments(segments, infoNode);
                }
            }  
        }

        runTitle = stringBuilder.ToString();
        split.RunTitle = runTitle;
        int.TryParse(attemptsCountString, out attemptsCount);
        split.AttemptsCount = attemptsCount;
        split.Segments = segments;
        return split;
    }

    /// <summary>
    /// Read the segments from the file and populate the segment list.
    /// </summary>
    /// <param name="segments">The array list of segments.</param>
    /// <param name="segmentsNode">The node containing the segments in the xml file.</param>
    private void PopulateSegments(List<Segment> segments, XmlNode segmentsNode)
    {
        Segment newSegment;
        string segmentName = "";
        double segmentBestTime = 0.0;
        double segmentBestSegment = 0.0;
        XmlNode nodeSegmentTime;
        foreach(XmlNode segmentNode in segmentsNode.ChildNodes)
        {
            foreach (XmlNode segmentInfoNode in segmentNode.ChildNodes)
            {
                if (segmentInfoNode.Name == SEGMENT_NAME)
                {
                    segmentName = segmentInfoNode.InnerText;
                }
                else if (segmentInfoNode.Name == SPLIT_TIMES)
                {
                    nodeSegmentTime = segmentInfoNode.FirstChild.FirstChild;
                    segmentBestTime = FaceSplitUtils.TimeParse(nodeSegmentTime.InnerText.Replace('.', ','));
                }
                else if (segmentInfoNode.Name == BEST_SEGMENT)
                {
                    nodeSegmentTime = segmentInfoNode.FirstChild;
                    segmentBestSegment = FaceSplitUtils.TimeParse(nodeSegmentTime.InnerText.Replace('.', ','));
                }
            }
            newSegment = new Segment(segmentName, segmentBestTime, 0.0, segmentBestSegment, new BitmapFile());
            segments.Add(newSegment);
        }
    }
}

