using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Runtime.InteropServices;
using FaceSplit.Model;
using System.Xml.Serialization;
using System.IO;
using Shortcut;
using FaceSplit.Properties;

namespace FaceSplit
{
    public partial class FaceSplit : Form
    {
        /// <summary>
        /// Default height and width.
        /// </summary>
        public const int DEFAULT_WIDTH = 250;
        public const int DEFAULT_HEIGHT = 38;

        public const int ZERO = 0;

        public const int SEGMENT_HEIGHT = 15;

        public int splitY_start;
        /// <summary>
        /// When you unsplit, the segment timer has to be set to the actual time since you did that split.
        /// </summary>
        public double timeElapsedSinceSplit;


        Split split;
        DisplayMode displayMode;
        List<Information> informations;

        SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;

        /// <summary>
        /// The watch on the screen.
        /// </summary>
        Stopwatch watch;
        /// <summary>
        /// The watch for segments.
        /// </summary>
        Stopwatch segmentWatch;
        /// <summary>
        /// Use when the run is done but you want to unsplit.
        /// We keep the timer going but we show the time when you split on the last split.
        /// Same for segment timer.
        /// </summary>
        TimeSpan runTimeOnCompletionPause;
        Double segmentTimeOnCompletionPause;

        Color watchColor;
        Color segmentWatchColor;

        /// <summary>
        /// Rectangle for each segments.
        /// </summary>
        List<Rectangle> segmentsRectangles;

        /// <summary>
        /// The rectangle for the watch.
        /// </summary>
        Rectangle watchRectangle;

        private Hotkey hotkeyTrigger = new Hotkey(Modifiers.None, Keys.Add);
        private HotkeyBinder hotkeyBinder;
        private Boolean globalHotkeysActive;

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
            this.ConfigureFilesDialogs();
            this.hotkeyBinder = new HotkeyBinder();
            this.BindHotkeys();
            this.globalHotkeysActive = true;
            segmentsRectangles = new List<Rectangle>();
            watchRectangle = new Rectangle(ZERO, ZERO, DEFAULT_WIDTH, DEFAULT_HEIGHT);
            this.displayMode = DisplayMode.TIMER_ONLY;
            this.watchColor = Settings.Default.TimerNotRunningColor;
            this.segmentWatchColor = Settings.Default.SegmentTimerNotRunningColor;
            informations = new List<Information>();
            this.splitY_start = 0;
            base.Paint += new PaintEventHandler(this.DrawFaceSplit);
            base.Size = new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            watch = new Stopwatch();
            segmentWatch = new Stopwatch();
            this.ticksTimer.Enabled = true;
        }

        private void BindHotkeys()
        {
            hotkeyBinder.Bind(Modifiers.None, Keys.Space).To(KeyboardSplit);
            hotkeyBinder.Bind(Modifiers.None, Keys.Multiply).To(KeyboardReset);
            hotkeyBinder.Bind(Modifiers.None, Keys.Subtract).To(KeyboardUnsplit);
            hotkeyBinder.Bind(Modifiers.None, Keys.Divide).To(KeyboardSkip);
            hotkeyBinder.Bind(Modifiers.None, Keys.Decimal).To(KeyboardPause);
            if (!hotkeyBinder.IsHotkeyAlreadyBound(hotkeyTrigger))
            {
                hotkeyBinder.Bind(hotkeyTrigger).To(ToggleGlobalHotkeys);
            }
        }

        private void UnbindHotkeys()
        {
            hotkeyBinder.Unbind(Modifiers.None, Keys.Space);
            hotkeyBinder.Unbind(Modifiers.None, Keys.Multiply);
            hotkeyBinder.Unbind(Modifiers.None, Keys.Subtract);
            hotkeyBinder.Unbind(Modifiers.None, Keys.Divide);
            hotkeyBinder.Unbind(Modifiers.None, Keys.Decimal);
        }

        private void ToggleGlobalHotkeys()
        {
            globalHotkeysActive = !globalHotkeysActive;
            if (globalHotkeysActive)
            {
                BindHotkeys();
                this.Icon = Properties.Resources.hotkeysOn;
            }
            else
            {
                UnbindHotkeys();
                this.Icon = Properties.Resources.hotkeysOff;
            }
        }

        /// <summary>
        /// Function executed by the timer on each tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TimerTicks(object sender, EventArgs e)
        {
            this.Invalidate();
            if (this.displayMode == DisplayMode.SEGMENTS)
            {
                UpdateInformationsData();
            }
        }


        private void mnuEditRun_Click(object sender, EventArgs e)
        {
            String splitFile = (this.split == null) ? null : this.split.File;
            int runsCompleted = (this.split == null) ? 0 : this.split.RunsCompleted;
            RunEditor runEditor = new RunEditor(this.split);
            runEditor.ShowDialog();
            if (runEditor.DialogResult == DialogResult.OK)
            {
                String runTitle = runEditor.Split.RunTitle;
                String runGoal = runEditor.Split.RunGoal;
                int attemptsCount = runEditor.Split.AttemptsCount;
                List<Segment> segments = runEditor.Split.Segments;
                this.split = new Split(runTitle, runGoal, attemptsCount, segments);
                this.split.File = splitFile;
                this.split.RunsCompleted = runsCompleted;
                this.informations.Clear();
                FillInformations();
                CreateSegmentsRectangles();
                this.displayMode = DisplayMode.SEGMENTS;
            }
        }

        private void mnuSaveRun_Click(object sender, EventArgs e)
        {
            if (this.split != null)
            {
                if (this.split.File == null)
                {
                    this.SaveFileAs();
                }
                else
                {
                    this.SaveFile();
                }
                
            }
        }

        private void mnuSaveRunAs_Click(object sender, EventArgs e)
        {
            this.SaveFileAs();
        }

        private void mnuLoadRun_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.LoadFile(openFileDialog.FileName);
            }
        }

        private void mnuEditLayout_Click(object sender, EventArgs e)
        {
            LayoutSettings layoutSettings = new LayoutSettings();
            if (layoutSettings.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.Reload();
            }
        }

        private void mnuResetLayout_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
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
                DrawInformations(e.Graphics);
                DrawSegments(e.Graphics);
                if (this.split.RunStatus == RunStatus.STOPPED || this.split.PreviousSegmentWasSkipped())
                {
                    FillEmptySegmentTimer(e.Graphics);
                }
                else if (this.split.RunStatus != RunStatus.STOPPED)
                {
                    DrawSegmentTimer(e.Graphics);
                }
            }
            UpdateInformationsStyle();
        }

        private void UpdateInformationsStyle()
        {
            foreach (Information information in this.informations)
            {
                information.UpdateStyle();
            }
        }

        private void ConfigureFilesDialogs()
        {
            this.saveFileDialog = new SaveFileDialog();
            this.saveFileDialog.DefaultExt = ".fss";
            this.saveFileDialog.Filter = "FaceSplit split file (*.fss)|*.fss";
            this.saveFileDialog.AddExtension = true;

            this.openFileDialog = new OpenFileDialog();
            this.openFileDialog.DefaultExt = ".fss";
            this.openFileDialog.Filter = "FaceSplit split file (*.fss)|*.fss";
            this.openFileDialog.AddExtension = true;
        }

        private void SaveFileAs()
        {           
            if (this.split != null)
            {
                if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.split.File = saveFileDialog.FileName;
                    this.SaveFile();
                }
            }
        }

        private void SaveFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.split.File, false))
            {
                file.WriteLine(this.split.RunTitle);
                file.WriteLine(this.split.RunGoal);
                file.WriteLine(this.split.AttemptsCount);
                file.WriteLine(this.split.RunsCompleted);
                foreach (Segment segment in this.split.Segments)
                {
                    file.WriteLine(segment.SegmentName + "-" + segment.SplitTime + "-" + segment.SegmentTime + "-" + segment.BestSegmentTime);
                }
                file.Close();
            }
        }

        private void LoadFile(String fileName)
        {
            String[] lines = File.ReadAllLines(fileName);
            String runTitle = "";
            String runGoal = "";
            int runCount = 0;
            int runsCompleted = 0;
            String segmentName = "";
            String segmentSplitTime = "";
            String segmentTime = "";
            String segmentBestTime = "";
            List<Segment> segments = new List<Segment>();
            try
            {
                runTitle = lines.ElementAt(0);
                runGoal = lines.ElementAt(1);
                runCount = Int32.Parse(lines.ElementAt(2));
                runsCompleted = Int32.Parse(lines.ElementAt(3));
                for (int i = 4; i < lines.Length; ++i)
                {
                    segmentName = lines.ElementAt(i).Split('-').ElementAt(0);
                    segmentSplitTime = lines.ElementAt(i).Split('-').ElementAt(1);
                    segmentTime = lines.ElementAt(i).Split('-').ElementAt(2);
                    segmentBestTime = lines.ElementAt(i).Split('-').ElementAt(3);
                    segments.Add(new Segment(segmentName, FaceSplitUtils.TimeParse(segmentSplitTime), FaceSplitUtils.TimeParse(segmentTime), FaceSplitUtils.TimeParse(segmentBestTime)));
                }
                this.split = new Split(runTitle, runGoal, runCount, segments);
                this.split.RunsCompleted = runsCompleted;
                this.split.File = fileName;
                this.informations.Clear();
                FillInformations();
                CreateSegmentsRectangles();
                this.displayMode = DisplayMode.SEGMENTS;
            }
            catch (FormatException fe)
            {
                MessageBox.Show("This file was not recognize as a FaceSplit split file.");
            }
            catch (IndexOutOfRangeException iore)
            {
                MessageBox.Show("This file was not recognize as a FaceSplit split file.");
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
            watchRectangle.Y = segmentsRectangles.Count() * SEGMENT_HEIGHT + splitY_start;
            this.Height = (this.segmentsRectangles.Count() * SEGMENT_HEIGHT) + (this.informations.Count * SEGMENT_HEIGHT) + (DEFAULT_HEIGHT * 2);
        }

        private void FillInformations()
        {
            this.informations.Insert((int)InformationIndexs.TITLE, new Information(InformationName.TITLE, this.split.RunTitle, this.split.RunsCompleted + "/" + this.split.AttemptsCount, (int)InformationIndexs.TITLE, true, true));
            this.informations.Insert((int)InformationIndexs.GOAL, new Information(InformationName.GOAL, "Goal: " + this.split.RunGoal, null,(int)InformationIndexs.GOAL, true, true));
            this.informations.Insert((int)InformationIndexs.PREVIOUS_SEGMENT, new Information(InformationName.PREVIOUS_SEGMENT, "Previous segment: ", "-", (int)InformationIndexs.PREVIOUS_SEGMENT, true, false));
            this.informations.Insert((int)InformationIndexs.POSSIBLE_TIMESAVE, new Information(InformationName.POSSIBLE_TIME_SAVE, "Possible time save: ", "-", (int)InformationIndexs.POSSIBLE_TIMESAVE, true, false));
            this.informations.Insert((int)InformationIndexs.PREDICTED_TIME, new Information(InformationName.PREDICTED_TIME, "Predicted time: ", "-", (int)InformationIndexs.PREDICTED_TIME, true, false));
            this.informations.Insert((int)InformationIndexs.SUM_OF_BEST, new Information(InformationName.SUM_OF_BEST, "Sum of best: ", "-", (int)InformationIndexs.SUM_OF_BEST, true, false));
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
            graphics.FillRectangle(new SolidBrush(Settings.Default.TimerBackgroundColor), this.watchRectangle);
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(graphics, timeString, Settings.Default.TimerFont, watchRectangle, watchColor, flags);
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
            Color rectangleColor = Settings.Default.SplitsBackgroundColor;

            for (int i = 0; i < segmentsRectangles.Count; ++i)
            {
                rectangleColor = (i == this.split.LiveIndex) ? Settings.Default.CurrentSegmentColor : Settings.Default.SplitsBackgroundColor;
                segmentName = this.split.Segments.ElementAt(i).SegmentName;
                segmentSplitTime = (this.split.Segments.ElementAt(i).SplitTime == 0) ? "-" : FaceSplitUtils.TimeFormat(this.split.Segments.ElementAt(i).SplitTime);
                segmentSplitTime = FaceSplitUtils.CutDecimals(segmentSplitTime, 2);
                runDeltaString = GetRunDeltaString(i);
                //if (i == this.split.LiveIndex && (runDeltaString.IndexOf("+") == -1 && runDeltaString.IndexOf("-") == -1))
                //{
                //    runDeltaString = "";
                //}
                runDeltaString = FaceSplitUtils.CutDecimals(runDeltaString, 2);
                segmentNameRectangle = segmentsRectangles.ElementAt(i);
                segmentNameRectangle.Width /= 2;
                segmentSplitTimeRectangle = segmentsRectangles.ElementAt(i);
                segmentSplitTimeRectangle.Width /= 2;
                segmentSplitTimeRectangle.X = segmentNameRectangle.Width;
                graphics.FillRectangle(new SolidBrush(rectangleColor), segmentsRectangles.ElementAt(i));
                TextRenderer.DrawText(graphics, segmentName, Settings.Default.SplitNamesFont,
                    segmentNameRectangle, Settings.Default.SplitNamesColor, nameFlags);
                TextRenderer.DrawText(graphics, segmentSplitTime, Settings.Default.SplitTimesFont,
                    segmentSplitTimeRectangle, Settings.Default.SplitTimesColor, splitTimeFlags);
                if(!String.IsNullOrEmpty(runDeltaString.Trim()))
                {
                    TextRenderer.DrawText(graphics, runDeltaString, Settings.Default.SplitDeltasFont,
                    segmentSplitTimeRectangle, this.split.GetSegmentColor(i), runDeltaFlags);
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
            Double timeElapsed = (Math.Truncate(this.segmentWatch.Elapsed.TotalSeconds * 100) / 100) + this.timeElapsedSinceSplit;
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
            else if (index == this.split.LiveIndex && this.split.SegmentHasRunDelta(index))
            {
                runDelta = this.split.GetLiveRunDelta(Math.Truncate(this.watch.Elapsed.TotalSeconds * 100) / 100);
                lostTime = (runDelta > 0);
                runDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(runDelta));
                if (lostTime)
                {
                    runDeltaString = runDeltaString.Insert(0, "+");
                    if ((index == 0) || (index > 0 && runDelta > this.split.GetRunDelta(index - 1)))
                    {
                        this.split.SetCurrentSegmentColor(Settings.Default.SplitDeltasBehindLosingColor);
                    }
                    else
                    {
                        this.split.SetCurrentSegmentColor(Settings.Default.SplitDeltasBehindSavingColor);
                    }
                    this.watchColor = Settings.Default.TimerBehindColor;
                }
                else if ((index > 0 && runDelta > this.split.GetRunDelta(index - 1)))
                {
                    runDeltaString = runDeltaString.Insert(0, "-");
                    this.split.SetCurrentSegmentColor(Settings.Default.SplitDeltasAheadLosingColor);
                }
                else if (this.split.CurrentSegmentHasLiveDelta(timeElapsed))
                {
                    runDeltaString = runDeltaString.Insert(0, "-");
                    this.split.SetCurrentSegmentColor(Settings.Default.SplitDeltasAheadSavingColor);
                }
                else
                {
                    runDeltaString = "";
                    this.watchColor = Settings.Default.TimerRunningColor;
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
            int aboveDrawn = 0;
            int belowDrawn = 0;
            for (int i = 0; i < this.informations.Count; i++)
            {
                if (this.informations.ElementAt(i).Above)
                {
                    Rectangle informationRectangle = new Rectangle(0, aboveDrawn * SEGMENT_HEIGHT, DEFAULT_WIDTH, SEGMENT_HEIGHT);
                    graphics.FillRectangle(new SolidBrush(this.informations.ElementAt(i).BackgroundColor), informationRectangle);
                    TextRenderer.DrawText(graphics, this.informations.ElementAt(i).PrimaryText, this.informations.ElementAt(i).PrimaryTextFont,
                        informationRectangle, this.informations.ElementAt(i).PrimaryTextColor, this.informations.ElementAt(i).PrimaryTextFlags);
                    if (informations.ElementAt(i).SecondaryText != null)
                    {
                        TextRenderer.DrawText(graphics, this.informations.ElementAt(i).SecondaryText, this.informations.ElementAt(i).SecondaryTextFont,
                            informationRectangle, this.informations.ElementAt(i).SecondaryTextColor, this.informations.ElementAt(i).SecondaryTextFlags);
                    }
                    aboveDrawn++;
                }
                else
                {
                    Rectangle informationRectangle = new Rectangle(0, (watchRectangle.Y + (watchRectangle.Height * 2)) + (belowDrawn * SEGMENT_HEIGHT), DEFAULT_WIDTH, SEGMENT_HEIGHT);
                    graphics.FillRectangle(new SolidBrush(this.informations.ElementAt(i).BackgroundColor), informationRectangle);
                    TextRenderer.DrawText(graphics, this.informations.ElementAt(i).PrimaryText, this.informations.ElementAt(i).PrimaryTextFont,
                        informationRectangle, this.informations.ElementAt(i).PrimaryTextColor, this.informations.ElementAt(i).PrimaryTextFlags);
                    if (informations.ElementAt(i).SecondaryText != null)
                    {
                        TextRenderer.DrawText(graphics, this.informations.ElementAt(i).SecondaryText, this.informations.ElementAt(i).SecondaryTextFont,
                            informationRectangle, this.informations.ElementAt(i).SecondaryTextColor, this.informations.ElementAt(i).SecondaryTextFlags);
                    }
                    belowDrawn++;
                }
            }
        }

        private void FillEmptySegmentTimer(Graphics graphics)
        {
            Rectangle emptySegmentTimerRectangle = new Rectangle(0, watchRectangle.Y + watchRectangle.Height, DEFAULT_WIDTH, DEFAULT_HEIGHT);
            graphics.FillRectangle(new SolidBrush(Settings.Default.SegmentTimerBackgroundColor), emptySegmentTimerRectangle);
        }

        private void DrawSegmentTimer(Graphics graphics)
        {
            TextFormatFlags segmentTimeFlags = TextFormatFlags.Left | TextFormatFlags.Bottom | TextFormatFlags.WordEllipsis;
            TextFormatFlags segmentBestTimeFlags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordEllipsis;

            Rectangle segmentTimeRectangle = new Rectangle(0, watchRectangle.Y + watchRectangle.Height, DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2);
            Rectangle segmentBestimeRectangle = new Rectangle(0, segmentTimeRectangle.Y + segmentTimeRectangle.Height, DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2);
            Rectangle segmentTimerRectangle = new Rectangle(DEFAULT_WIDTH / 2, watchRectangle.Y + watchRectangle.Height, DEFAULT_WIDTH / 2, DEFAULT_HEIGHT);

            graphics.FillRectangle(new SolidBrush(Settings.Default.SegmentTimerBackgroundColor), segmentTimeRectangle);
            graphics.FillRectangle(new SolidBrush(Settings.Default.SegmentTimerBackgroundColor), segmentBestimeRectangle);
            graphics.FillRectangle(new SolidBrush(Settings.Default.SegmentTimerBackgroundColor), segmentTimerRectangle);

            String segmentTime = (this.split.RunStatus == RunStatus.ON_GOING) ? FaceSplitUtils.TimeFormat(this.split.CurrentSegment.BackupSegmentTime) : FaceSplitUtils.TimeFormat(this.split.Segments.Last().BackupSegmentTime);
            String segmentBestTime = (this.split.RunStatus == RunStatus.ON_GOING) ? FaceSplitUtils.TimeFormat(this.split.CurrentSegment.BackupBestSegmentTime) : FaceSplitUtils.TimeFormat(this.split.Segments.Last().BackupBestSegmentTime);
            String segmentTimerString;
            segmentTimerString = (this.split.RunStatus == RunStatus.DONE) ? segmentTimeOnCompletionPause.ToString()
                : FaceSplitUtils.TimeFormat((Math.Truncate(this.segmentWatch.Elapsed.TotalSeconds * 100) / 100) + timeElapsedSinceSplit);

            TextRenderer.DrawText(graphics, "PB: " + segmentTime, Settings.Default.SegmentTimerPBFont,
                segmentTimeRectangle, Settings.Default.SegmentTimerPBColor, segmentTimeFlags);

            TextRenderer.DrawText(graphics, "BEST: " + segmentBestTime, Settings.Default.SegmentTimerBestFont,
                segmentBestimeRectangle, Settings.Default.SegmentTimerBestColor, segmentBestTimeFlags);

            TextRenderer.DrawText(graphics, segmentTimerString, Settings.Default.SegmentTimerFont,
                segmentTimerRectangle, segmentWatchColor);
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
            if (!globalHotkeysActive)
            {
                switch (e.KeyData)
                {
                    case Keys.Space:
                        KeyboardSplit();
                        break;
                    case Keys.Multiply:
                        KeyboardReset();
                        break;
                    case Keys.Subtract:
                        KeyboardUnsplit();
                        break;
                    case Keys.Divide:
                        KeyboardSkip();
                        break;
                    case Keys.Decimal:
                        KeyboardPause();
                        break;
                }
            }
        }

        private void KeyboardSplit()
        {
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
        }

        private void KeyboardReset()
        {
            ResetTimer();
            if (this.displayMode == DisplayMode.SEGMENTS)
            {
                this.split.ResetRun();
                this.ResetSegmentTimer();
            }
            this.timeElapsedSinceSplit = 0;
        }

        private void KeyboardUnsplit()
        {
            if (this.displayMode == DisplayMode.SEGMENTS)
            {
                this.segmentWatchColor = Settings.Default.SegmentTimerRunningColor;
                if (this.split.RunStatus == RunStatus.DONE)
                {
                    this.split.ResumeRun();
                    this.StartTimer();
                }
                if (this.split.LiveIndex > 0)
                {
                    Segment lastSegment = this.split.Segments.ElementAt(this.split.LiveIndex - 1);
                    this.timeElapsedSinceSplit += this.split.Segments.ElementAt(this.split.LiveIndex - 1).SegmentTime;
                }
                this.split.UnSplit();
            }
        }

        private void KeyboardSkip()
        {
            if (this.displayMode == DisplayMode.SEGMENTS && this.split.RunStatus == RunStatus.ON_GOING && !this.split.CurrentSplitIsLastSplit())
            {
                this.segmentWatchColor = Settings.Default.SegmentTimerRunningColor;
                this.split.SkipSegment((Math.Truncate(this.segmentWatch.Elapsed.TotalSeconds * 100) / 100));
                this.segmentWatch.Restart();
            }
        }

        private void KeyboardPause()
        {
            if (this.split != null && this.split.RunStatus == RunStatus.ON_GOING)
            {
                if (this.segmentWatch.IsRunning)
                {
                    this.segmentWatch.Stop();
                }
                else
                {
                    this.segmentWatch.Start();
                }
            }
            if (this.watch.IsRunning)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            } 
        }

        /// <summary>
        /// When you are in Split mode and you press your split button.
        /// </summary>
        private void DoSplit()
        {
            this.segmentWatchColor = Settings.Default.SegmentTimerRunningColor;
            if (this.split.RunStatus == RunStatus.STOPPED)
            {
                this.StartTimer();
                this.StartSegmentTimer();
                this.split.StartRun();
            }
            else if(this.split.RunStatus == RunStatus.ON_GOING && this.watch.IsRunning)
            {
                double splitTime = Math.Truncate(this.watch.Elapsed.TotalSeconds * 100) / 100;
                double segmentTime = (Math.Truncate(this.segmentWatch.Elapsed.TotalSeconds * 100) / 100) + timeElapsedSinceSplit;
                if (!this.split.CurrentSplitIsLastSplit())
                {
                    this.split.DoSplit(splitTime, segmentTime);
                }
                else
                {
                    this.split.DoSplit(splitTime, segmentTime);
                    this.split.CompleteRun();
                    this.runTimeOnCompletionPause = this.watch.Elapsed;
                    this.segmentTimeOnCompletionPause = segmentTime;
                    this.watchColor = Settings.Default.TimerPausedColor;
                    this.segmentWatchColor = Settings.Default.SegmentTimerPausedColor;
                }
                this.segmentWatch.Restart();
            }
            else if (this.split.RunStatus == RunStatus.DONE)
            {
                this.split.SaveRun();
                this.ResetTimer();
                this.ResetSegmentTimer();
            }
            this.timeElapsedSinceSplit = 0;
        }

        /// <summary>
        /// Update the data that is shown by each information.
        /// </summary>
        public void UpdateInformationsData()
        {
            this.informations[(int)InformationIndexs.TITLE].SecondaryText = this.split.RunsCompleted + "/" + this.split.AttemptsCount;
            this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryText = GetPreviousSegmentDeltaString();
            this.informations[(int)InformationIndexs.POSSIBLE_TIMESAVE].SecondaryText = GetPossibleTimeSave();
            this.informations[(int)InformationIndexs.PREDICTED_TIME].SecondaryText = GetPredictedTime();
            this.informations[(int)InformationIndexs.SUM_OF_BEST].SecondaryText = GetSOB();
        }

        private String GetPreviousSegmentDeltaString()
        {
            String segmentDeltaString;
            double segmentDelta;
            Boolean lostTime;
            Boolean bestSegment = false;
            double timeElapsed = (Math.Truncate(this.segmentWatch.Elapsed.TotalSeconds * 100) / 100) + this.timeElapsedSinceSplit;
            if (this.split.LiveIndex > 0)
            {
                bestSegment = this.split.PreviousSegmentIsBestSegment();
            }
            if (this.split.CurrentSegmentHasLiveDelta(timeElapsed))
            {
                this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].PrimaryText = "Live segment: ";
                segmentDelta = this.split.GetLiveSegmentDelta(timeElapsed);
                segmentDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(segmentDelta));
                lostTime = (segmentDelta > 0);
                if (lostTime)
                {
                    this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = Settings.Default.PreviousSegmentDeltaLostColor;
                    segmentDeltaString = segmentDeltaString.Insert(0, "+");
                    this.segmentWatchColor = Settings.Default.SegmentTimerLosingTimeColor;
                }
                else
                {
                    this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = Settings.Default.PreviousSegmentDeltaSavedColor;
                    segmentDeltaString = segmentDeltaString.Insert(0, "-");
                }
            }
            else if (this.split.PreviousSegmentHasSegmentDelta())
            {
                this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].PrimaryText = "Previous segment: ";
                segmentDelta = this.split.GetPreviousSegmentDelta();
                segmentDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(segmentDelta));
                lostTime = (segmentDelta > 0);
                if (bestSegment)
                {
                    this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = Settings.Default.PreviousSegmentDeltaBestSegmentColor;
                    segmentDeltaString = segmentDeltaString.Insert(0, "-");
                }
                else
                {
                    if (lostTime)
                    {
                        this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = Settings.Default.PreviousSegmentDeltaLostColor;
                        segmentDeltaString = segmentDeltaString.Insert(0, "+");
                    }
                    else
                    {
                        this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = Settings.Default.PreviousSegmentDeltaSavedColor;
                        segmentDeltaString = segmentDeltaString.Insert(0, "-");
                    }
                }
                this.split.SetPreviousSegmentColor(bestSegment, lostTime);
            }
            else
            {
                this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].PrimaryText = "Previous segment: ";
                this.informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = Settings.Default.PreviousSegmentDeltaNoDeltaColor;
                segmentDeltaString = "-";
            }
            segmentDeltaString = FaceSplitUtils.CutDecimals(segmentDeltaString, 2);
            return segmentDeltaString;
        }

        public String GetPossibleTimeSave()
        {
            if (this.split.SegmentHasPossibleTimeSave())
            {
                Double possibleTimeSave = this.split.GetPossibleTimeSave();
                String possibleTimeSaveString = FaceSplitUtils.TimeFormat(possibleTimeSave);
                possibleTimeSaveString = FaceSplitUtils.CutDecimals(possibleTimeSaveString, 2);
                return possibleTimeSaveString;
            }
            return "-";
        }

        public String GetPredictedTime()
        {
            Double predictedTime = this.split.GetPredictedTime();
            String predictedTimeString = "-";
            if (predictedTime != 0.0)
            {
                predictedTimeString = FaceSplitUtils.TimeFormat(predictedTime);
            }
            predictedTimeString = FaceSplitUtils.CutDecimals(predictedTimeString, 2);
            return predictedTimeString;
        }

        public String GetSOB()
        {
            Double sob = this.split.GetSOB();
            String sobString = "-";
            if (sob != 0.0)
            {
                sobString = FaceSplitUtils.TimeFormat(sob);
            }
            sobString = FaceSplitUtils.CutDecimals(sobString, 2);
            return sobString;
        }

        /// <summary>
        /// Start the timer and set the color of the watch.
        /// </summary>
        private void StartTimer()
        {
            this.watch.Start();
            this.watchColor = Settings.Default.TimerRunningColor;
            this.segmentWatchColor = Settings.Default.SegmentTimerRunningColor;
        }

        /// <summary>
        /// Stop the timer and set the color of the watch.
        /// </summary>
        private void StopTimer()
        {
            this.watch.Stop();
            this.watchColor = Settings.Default.TimerPausedColor;
            this.segmentWatchColor = Settings.Default.SegmentTimerPausedColor;
        }

        /// <summary>
        /// Reset the timer and set the color of the watch.
        /// </summary>
        private void ResetTimer()
        {
            this.watch.Reset();
            this.watchColor = Settings.Default.TimerNotRunningColor;
            this.segmentWatchColor = Settings.Default.SegmentTimerNotRunningColor;
        }

        private void StartSegmentTimer()
        {
            this.segmentWatch.Start();
        }

        private void StopSegmentTimer()
        {
            this.segmentWatch.Stop();
        }

        private void ResetSegmentTimer()
        {
            this.segmentWatch.Reset();
        }
    }
}
