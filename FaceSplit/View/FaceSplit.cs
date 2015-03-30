using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using FaceSplit.Model;

namespace FaceSplit
{
    public partial class FaceSplit : Form
    {
        /// <summary>
        /// Default height and width.
        /// </summary>
        public const int DEFAULT_WIDTH = 200;
        public const int DEFAULT_HEIGHT = 38;

        public const int ZERO = 0;

        public const int SEGMENT_HEIGHT = 15;

        public int splitY_start;

        Split split;
        DisplayMode displayMode;
        List<Information> informations;

        /// <summary>
        /// The watch on the screen.
        /// </summary>
        Stopwatch watch;
        /// <summary>
        /// Use when the run is done but you want to unsplit.
        /// We keep the timer going but 
        /// </summary>
        TimeSpan runTimeOnCompletionPause;
        Color watchColor;

        /// <summary>
        /// Rectangle for each segments.
        /// </summary>
        List<Rectangle> segmentsRectangles;

        /// <summary>
        /// The rectangle for the watch.
        /// </summary>
        Rectangle watchRectangle;

        /// <summary>
        /// Code starting from here is for moving the window without having a border.
        /// </summary>
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //End of the code for the window moving.

        /// <summary>
        /// Initial constructor.
        /// </summary>
        public FaceSplit()
        {
            InitializeComponent();
            segmentsRectangles = new List<Rectangle>();
            watchRectangle = new Rectangle(ZERO, ZERO, DEFAULT_WIDTH, DEFAULT_HEIGHT);
            this.displayMode = DisplayMode.TIMER_ONLY;
            this.watchColor = Color.White;
            informations = new List<Information>();
            this.splitY_start = 0;
            base.Paint += new PaintEventHandler(this.DrawFaceSplit);
            base.Size = new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            watch = new Stopwatch();
            this.ticksTimer.Enabled = true;
        }

        /// <summary>
        /// Function executed by the timer on each tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TimerTicks(object sender, EventArgs e)
        {
            this.Invalidate();
        }


        private void mnuEditRun_Click(object sender, EventArgs e)
        {
            RunEditor runEditor = new RunEditor(null);
            runEditor.ShowDialog();
            if (runEditor.DialogResult == DialogResult.OK)
            {
                String runTitle = runEditor.Split.RunTitle;
                String runGoal = runEditor.Split.RunGoal;
                int attemptsCount = runEditor.Split.AttemptsCount;
                List<Segment> segments = runEditor.Split.Segments;
                this.split = new Split(runTitle, runGoal, attemptsCount, segments);
                this.informations.Clear();
                FillInformations();
                CreateSegmentsRectangles();
                this.displayMode = DisplayMode.SEGMENTS;
            }
        }

        private void mnuCloseSplit_Click(object sender, EventArgs e)
        {
            this.split = null;
            this.displayMode = DisplayMode.TIMER_ONLY;
            this.watchRectangle.Y = ZERO;
            this.Height = DEFAULT_HEIGHT;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void DrawFaceSplit(object sender, PaintEventArgs e)
        {
            DrawWatch(e.Graphics);
            if (this.displayMode == DisplayMode.SEGMENTS)
            {
                DrawSegments(e.Graphics);
                DrawInformations(e.Graphics);
            }
        }

        /// <summary>
        /// Create a rectangle for each segment and adjust the position of the clock
        /// and the heigt of FaceSplit.
        /// </summary>
        private void CreateSegmentsRectangles()
        {
            this.segmentsRectangles.Clear();
            int index = 0;
            foreach (Segment segment in this.split.Segments)
            {
                segmentsRectangles.Add(new Rectangle(ZERO, (index * SEGMENT_HEIGHT) + splitY_start, DEFAULT_WIDTH, SEGMENT_HEIGHT));
                index++;
            }
            watchRectangle.Y = segmentsRectangles.Count() * SEGMENT_HEIGHT + (this.informations.Count * SEGMENT_HEIGHT);
            this.Height = (this.segmentsRectangles.Count() * SEGMENT_HEIGHT) + (this.informations.Count * SEGMENT_HEIGHT) + DEFAULT_HEIGHT;
        }

        private void FillInformations()
        {
            this.informations.Add(new Information(this.split.RunTitle, 0, true, true));
            this.informations.Add(new Information(this.split.RunGoal, 1, true, true));
            this.splitY_start = AboveInformationCount() * SEGMENT_HEIGHT;
        }

        private int AboveInformationCount()
        {
            int aboveNumber = 0;
            foreach (Information information in this.informations)
            {
                if (information.Above)
                {
                    aboveNumber++;
                }
            }
            return aboveNumber;
        }

        /// <summary>
        /// Used to draw the clock.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawWatch(Graphics graphics)
        {
            String timeString;
            timeString = (this.displayMode == DisplayMode.SEGMENTS && this.split.RunStatus == RunStatus.DONE) ? runTimeOnCompletionPause.ToString("hh\\:mm\\:ss\\.ff") : this.watch.Elapsed.ToString("hh\\:mm\\:ss\\.ff");
            graphics.FillRectangle(new SolidBrush(Color.Black), this.watchRectangle);
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(graphics, timeString, new Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold), watchRectangle, watchColor, flags);
        }

        /// <summary>
        /// Draw the list of segments.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawSegments(Graphics graphics)
        {
            String segmentName;
            String segmentSplitTime;
            String runDeltaString = "";
            
            TextFormatFlags nameFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.WordEllipsis;
            TextFormatFlags splitTimeFlags = TextFormatFlags.Right | TextFormatFlags.VerticalCenter | 
                TextFormatFlags.WordBreak;
            TextFormatFlags runDeltaFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.WordBreak;

            Rectangle segmentNameRectangle;
            Rectangle segmentSplitTimeRectangle;
            Color rectangleColor = Color.Black;
            Color runDeltaColor = Color.White;

            for (int i = 0; i < segmentsRectangles.Count; ++i)
            {
                rectangleColor = (i == this.split.LiveIndex) ? Color.Blue : Color.Black;
                segmentName = this.split.Segments.ElementAt(i).SegmentName;
                segmentSplitTime = (this.split.Segments.ElementAt(i).SplitTime == 0) ? "-" : FaceSplitUtils.TimeFormat(this.split.Segments.ElementAt(i).SplitTime);
                runDeltaString = GetRunDeltaString(i);
                if (i == this.split.LiveIndex && runDeltaString.IndexOf("+") == -1)
                {
                    runDeltaString = "";
                }
                runDeltaColor = (runDeltaString.IndexOf("+") == -1) ? Color.LightGreen : Color.DarkRed;
                segmentNameRectangle = segmentsRectangles.ElementAt(i);
                segmentNameRectangle.Width /= 2;
                segmentSplitTimeRectangle = segmentsRectangles.ElementAt(i);
                segmentSplitTimeRectangle.Width /= 2;
                segmentSplitTimeRectangle.X = segmentNameRectangle.Width;
                graphics.FillRectangle(new SolidBrush(rectangleColor), segmentsRectangles.ElementAt(i));
                TextRenderer.DrawText(graphics, segmentName, new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold),
                    segmentNameRectangle, Color.White, nameFlags);
                TextRenderer.DrawText(graphics, segmentSplitTime, new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold),
                    segmentSplitTimeRectangle, Color.White, splitTimeFlags);
                if(!String.IsNullOrEmpty(runDeltaString.Trim()))
                {
                    TextRenderer.DrawText(graphics, runDeltaString, new Font(FontFamily.GenericSansSerif, 8.0F, FontStyle.Bold),
                    segmentSplitTimeRectangle, runDeltaColor, runDeltaFlags);
                }
            }
        }

        /// <summary>
        /// Fetch the run delta for each split with the index.
        /// Returns it into a string.
        /// </summary>
        /// <param name="index">The index of the split.</param>
        /// <returns>The run delta into a string.</returns>
        private String GetRunDeltaString(int index)
        {
            Boolean lostTime;
            double runDelta;
            String runDeltaString = "";
            if (index < this.split.LiveIndex)
            {
                //Done mean we are after the last split but we still have the possiblity of going back.
                if ((this.split.RunStatus == RunStatus.ON_GOING || this.split.RunStatus == RunStatus.DONE) && !this.split.FirstSplit() && this.split.SegmentHasRunDelta(index))
                {
                    runDelta = this.split.GetRunDelta(index);
                    lostTime = (runDelta > 0);
                    runDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(runDelta));
                    if (lostTime)
                    {
                        runDeltaString = runDeltaString.Insert(0, "+");
                    }
                    else
                    {
                        runDeltaString = runDeltaString.Insert(0, "-");
                    }

                }
            }
            else if (index == this.split.LiveIndex)
            {
                runDelta = this.split.GetLiveRunDelta(Math.Truncate(this.watch.Elapsed.TotalSeconds * 100) / 100);
                lostTime = (runDelta > 0);
                runDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(runDelta));
                if (lostTime)
                {
                    runDeltaString = runDeltaString.Insert(0, "+");
                }
            }
            return runDeltaString;
        }

        /// <summary>
        /// Draw the list of informations. Such as run title, run goal and previous segment.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawInformations(Graphics graphics)
        {
            for (int i = 0; i < this.informations.Count; i++)
            {
                Rectangle informationRectangle = new Rectangle(0, i * SEGMENT_HEIGHT, DEFAULT_WIDTH, SEGMENT_HEIGHT);
                graphics.FillRectangle(new SolidBrush(Color.Black), informationRectangle);
                TextRenderer.DrawText(graphics, this.informations.ElementAt(i).InformationText, new Font(FontFamily.GenericSansSerif, 8.0F),
                    informationRectangle, this.informations.ElementAt(i).InformationColor, this.informations.ElementAt(i).InformationFlags);
            }
        }

        /// <summary>
        /// For moving the window without a border.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FaceSplit_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Space:
                    if (this.displayMode == DisplayMode.TIMER_ONLY)
                    {
                        if (this.watch.IsRunning)
                        {
                            StopTimer();
                        }
                        else
                        {
                            StartTimer();
                        }
                    }
                    else
                    {
                        DoSplit();
                    }
                    break;
                case Keys.Multiply:
                    ResetTimer();
                    if (this.displayMode == DisplayMode.SEGMENTS)
                    {
                        this.split.ResetRun();
                    }
                    break;
                case Keys.Subtract:
                    if (this.displayMode == DisplayMode.SEGMENTS)
                    {
                        if (this.split.RunStatus == RunStatus.DONE)
                        {
                            this.split.ResumeRun();
                            this.StartTimer();
                        }
                        this.split.UnSplit();
                    }
                    break;
                case Keys.Divide:
                    if (this.displayMode == DisplayMode.SEGMENTS && this.split.RunStatus == RunStatus.ON_GOING && !this.split.LastSplit())
                    {
                        this.split.SkipSegment();
                    }
                    break;
                case Keys.Decimal:
                    if (this.watch.IsRunning)
                    {
                        StopTimer();
                    }
                    else
                    {
                        StartTimer();
                    } 
                    break;
            }
        }

        /// <summary>
        /// When you are in Split mode and you press your split button.
        /// </summary>
        private void DoSplit()
        {
            if (this.split.RunStatus == RunStatus.STOPPED)
            {
                StartTimer();
                this.split.StartRun();
            }
            else if(this.split.RunStatus == RunStatus.ON_GOING && this.watch.IsRunning)
            {
                if (!this.split.LastSplit())
                {
                    this.split.DoSplit(Math.Truncate(this.watch.Elapsed.TotalSeconds * 100) / 100);
                }
                else
                {
                    this.split.DoSplit(Math.Truncate(this.watch.Elapsed.TotalSeconds * 100) / 100);
                    this.split.CompleteRun();
                    this.runTimeOnCompletionPause = this.watch.Elapsed;
                    this.watchColor = Color.Yellow;
                }
                
            }
            else if (this.split.RunStatus == RunStatus.DONE)
            {
                this.split.SaveRun();
                ResetTimer();
            }
        }

        /// <summary>
        /// Start the timer and set the color of the watch.
        /// </summary>
        private void StartTimer()
        {
            this.watch.Start();
            this.watchColor = Color.LimeGreen;
        }

        /// <summary>
        /// Stop the timer and set the color of the watch.
        /// </summary>
        private void StopTimer()
        {
            this.watch.Stop();
            this.watchColor = Color.Yellow;
        }

        /// <summary>
        /// Reset the timer and set the color of the watch.
        /// </summary>
        private void ResetTimer()
        {
            this.watch.Reset();
            this.watchColor = Color.White;
        }
    }
}
