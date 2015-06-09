using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using FaceSplit.Model;
using FaceSplit;

public class LiveSplitXMLReader
{
    private const String GAME_NAME = "GameName";
    private const String CATEGORY_NAME = "CategoryName";
    private const String OFFSET = "Offset";
    private const String ATTEMPTS_COUNT = "AttemptCount";
    private const String SEGMENTS = "Segments";
    private const String SEGMENT_NAME = "Name";
    private const String SPLIT_TIMES = "SplitTimes";
    private const String BEST_SEGMENT = "BestSegmentTime";

    private Split split;
    private XmlDocument xmlDocument;

    public LiveSplitXMLReader()
    {
        this.split = new Split();
        xmlDocument = new XmlDocument();
    }

    /// <summary>
    /// Read split information from the file and returns it.
    /// </summary>
    /// <param name="file">The filename of the LiveSplit XML file.</param>
    /// <returns>The split with all its information.</returns>
    public Split ReadSplit(String file)
    {
        xmlDocument.Load(file);
        StringBuilder stringBuilder = new StringBuilder();
        String runTitle = "";
        String attemptsCountString = "";
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
        this.split.RunTitle = runTitle;
        Int32.TryParse(attemptsCountString, out attemptsCount);
        this.split.AttemptsCount = attemptsCount;
        this.split.Segments = segments;
        return this.split;
    }

    /// <summary>
    /// Read the segments from the file and populate the segment list.
    /// </summary>
    /// <param name="segments">The array list of segments.</param>
    /// <param name="segmentsNode">The node containing the segments in the xml file.</param>
    private void PopulateSegments(List<Segment> segments, XmlNode segmentsNode)
    {
        Segment newSegment;
        String segmentName = "";
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
            newSegment = new Segment(segmentName, segmentBestTime, 0.0, segmentBestSegment);
            segments.Add(newSegment);
        }
    }
}

