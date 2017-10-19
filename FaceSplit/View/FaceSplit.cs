using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using FaceSplit.Model;
using System.IO;
using Shortcut;
using FaceSplit.Properties;
using Microsoft.WindowsAPICodePack.Taskbar;
using FaceSplit.Dtos;
using Newtonsoft.Json;
using FaceSplit.services;

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

        public const string CLEAR_LAST_RUNS = "Clear";

        public int splitY_start;
        /// <summary>
        /// When you unsplit, the segment timer has to be set to the actual time since you did that split.
        /// </summary>
        public double timeElapsedSinceSplit;


        Split split;
        DisplayMode displayMode;
        List<Information> informations;

        Model.LayoutSettings layoutSettings;

        SaveFileDialog saveRunDialog;
        SaveFileDialog saveLayoutDialog;

        OpenFileDialog openRunDialog;
        OpenFileDialog openLayoutDialog;

        XmlSerializer serializer;

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
        double segmentTimeOnCompletionPause;

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
        private bool globalHotkeysActive;

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
            ConfigureFilesDialogs();
            layoutSettings = new Model.LayoutSettings();
            hotkeyBinder = new HotkeyBinder();
            BindHotkeys();
            globalHotkeysActive = true;
            segmentsRectangles = new List<Rectangle>();
            watchRectangle = new Rectangle(ZERO, ZERO, DEFAULT_WIDTH, DEFAULT_HEIGHT);
            displayMode = DisplayMode.TIMER_ONLY;
            watchColor = SettingsLayout.Default.TimerNotRunningColor;
            segmentWatchColor = SettingsLayout.Default.SegmentTimerNotRunningColor;
            informations = new List<Information>();
            splitY_start = 0;
            base.Paint += new PaintEventHandler(DrawFaceSplit);
            base.Size = new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            watch = new Stopwatch();
            segmentWatch = new Stopwatch();
            ticksTimer.Enabled = true;
            InitialLoad();
        }

        private void InitialLoad()
        {
            SettingsApp.Default.LastRunsFile = (SettingsApp.Default.LastRunsFile == null) ? new StringCollection() : SettingsApp.Default.LastRunsFile;
            mnuLastRuns.DropDownItemClicked += (s, e) => LoadRecentRunFromMenu(e.ClickedItem.Text);
            if (!SettingsLayout.Default.LayoutSettingsFile.Equals(""))
            {
                layoutSettings.File = SettingsLayout.Default.LayoutSettingsFile;
            }
            if (!SettingsApp.Default.LastRunFile.Equals(string.Empty))
            {
                try
                {
                    LoadRunFromFile(SettingsApp.Default.LastRunFile);
                }
                catch(DirectoryNotFoundException)
                {
                    MessageBox.Show(SettingsApp.Default.LastRunFile + " Was not found", "File not found", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateLastRunMenu();
                }
                catch(FileNotFoundException)
                {
                    MessageBox.Show(SettingsApp.Default.LastRunFile + " Was not found", "File not found",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateLastRunMenu();
                }
                catch (JsonReaderException)
                {
                    MessageBox.Show(SettingsApp.Default.LastRunFile + " Was not recognized as a FaceSplit split file.", "Wrong format",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateLastRunMenu();
                }
            }
            else
            {
                UpdateLastRunMenu();
            }
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
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            }
            else
            {
                UnbindHotkeys();
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
            }
        }

        /// <summary>
        /// Function executed by the timer on each tick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TimerTicks(object sender, EventArgs e)
        {
            Invalidate();
            if (displayMode == DisplayMode.SEGMENTS)
            {
                UpdateInformationsData();
            }
        }


        private void mnuEditRun_Click(object sender, EventArgs e)
        {
            string splitFile = (split == null) ? null : split.File;
            int runsCompleted = (split == null) ? 0 : split.RunsCompleted;
            RunEditor runEditor = new RunEditor(split);
            runEditor.ShowDialog();
            if (runEditor.DialogResult == DialogResult.OK)
            {
                string runTitle = runEditor.Split.RunTitle;
                string runGoal = runEditor.Split.RunGoal;
                int attemptsCount = runEditor.Split.AttemptsCount;
                List<Segment> segments = runEditor.Split.Segments;
                split = new Split(runTitle, runGoal, attemptsCount, segments);
                split.File = splitFile;
                split.RunsCompleted = runsCompleted;
                informations.Clear();
                FillInformations();
                CreateSegmentsRectangles();
                displayMode = DisplayMode.SEGMENTS;
            }
        }

        private void mnuSaveRun_Click(object sender, EventArgs e)
        {
            if (split != null)
            {
                if (split.File == null)
                {
                    SaveRunToFileAs();
                }
                else
                {
                    SaveRunToFile();
                }
                
            }
        }

        private void mnuSaveRunAs_Click(object sender, EventArgs e)
        {
            SaveRunToFileAs();
        }

        private void mnuLoadRun_Click(object sender, EventArgs e)
        {
            if (openRunDialog.ShowDialog() == DialogResult.OK)
            {
                LoadRunFromFile(openRunDialog.FileName);
            }
        }

        private void mnuEditLayout_Click(object sender, EventArgs e)
        {
            LayoutSettingsEditor layoutSettings = new LayoutSettingsEditor();
            if (layoutSettings.ShowDialog() == DialogResult.OK)
            {
                SettingsLayout.Default.Save();
            }
            else
            {
                SettingsLayout.Default.Reload();
            }
        }

        private void mnuSaveLayout_Click(object sender, EventArgs e)
        {
            if (layoutSettings.File == null)
            {
                SaveLayoutToFileAs();
            }
            else
            {
                SaveLayoutToFile();
            }
        }

        private void mnuSaveLayoutAs_Click(object sender, EventArgs e)
        {
            SaveLayoutToFileAs();
        }


        private void loadLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openLayoutDialog.ShowDialog() == DialogResult.OK)
            {
                LoadLayoutFromFile(openLayoutDialog.FileName);
            }
        }

        private void mnuResetLayout_Click(object sender, EventArgs e)
        {
            SettingsLayout.Default.Reset();
        }

        private void mnuCloseSplit_Click(object sender, EventArgs e)
        {
            split = null;
            SettingsApp.Default.LastRunFile = string.Empty;
            SettingsApp.Default.Save();
            displayMode = DisplayMode.TIMER_ONLY;
            watchRectangle.Y = ZERO;
            Height = DEFAULT_HEIGHT;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void DrawFaceSplit(object sender, PaintEventArgs e)
        {
            DrawWatch(e.Graphics);
            if (displayMode == DisplayMode.SEGMENTS)
            {                
                DrawInformations(e.Graphics);
                DrawSegments(e.Graphics);
                if (split.RunStatus == RunStatus.STOPPED || split.PreviousSegmentWasSkipped())
                {
                    FillEmptySegmentTimer(e.Graphics);
                }
                else if (split.RunStatus != RunStatus.STOPPED)
                {
                    DrawSegmentTimer(e.Graphics);
                }
            }
            UpdateInformationsStyle();
        }

        private void UpdateInformationsStyle()
        {
            foreach (Information information in informations)
            {
                information.UpdateStyle();
            }
        }

        private void ConfigureFilesDialogs()
        {
            saveRunDialog = new SaveFileDialog();
            saveRunDialog.DefaultExt = ".fss";
            saveRunDialog.Filter = "FaceSplit split file (*.fss)|*.fss";
            saveRunDialog.AddExtension = true;

            saveLayoutDialog = new SaveFileDialog();
            saveLayoutDialog.DefaultExt = ".fsl";
            saveLayoutDialog.Filter = "FaceSplit layout file (*.fsl)|*.fsl";
            saveLayoutDialog.AddExtension = true;

            openRunDialog = new OpenFileDialog();
            openRunDialog.DefaultExt = ".fss";
            openRunDialog.Filter = "FaceSplit split file (*.fss)|*.fss";
            openRunDialog.AddExtension = true;

            openLayoutDialog = new OpenFileDialog();
            openLayoutDialog.DefaultExt = ".fsl";
            openLayoutDialog.Filter = "FaceSplit layout file (*.fsl)|*.fsl";
            openLayoutDialog.AddExtension = true;
        }

        private void SaveRunToFileAs()
        {           
            if (split != null)
            {
                if (saveRunDialog.ShowDialog() == DialogResult.OK)
                {
                    split.File = saveRunDialog.FileName;
                    SaveRunToFile();
                }
            }
        }

        private void SaveRunToFile()
        {
            RunDto runDto = new RunDto();
            runDto = runDto.fromModel(split);

            RunSaver runSaver = new RunSaver();
            runSaver.SaveRun(runDto, split.File);
        }

        private void LoadRecentRunFromMenu(string fileName)
        {
            if (!fileName.Equals(CLEAR_LAST_RUNS))
            {
                try
                {
                    LoadRunFromFile(fileName);
                }
                catch (DirectoryNotFoundException)
                {
                    MessageBox.Show(fileName + " Was not found", "File not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(fileName + " Was not found", "File not found",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (JsonReaderException)
                {
                    MessageBox.Show(fileName + " Was not recognized as a FaceSplit split file.", "Wrong format",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                mnuLastRuns.DropDownItems.Clear();
                SettingsApp.Default.LastRunsFile.Clear();
            }
        }

        private void LoadRunFromFile(string fileName)
        {
            RunLoader runLoader = new RunLoader();
            runLoader.LoadRun(fileName);

            RunDto runDto = runLoader.LoadRun(fileName);

            split = runDto.toModel();
            split.File = fileName;
            informations.Clear();
            FillInformations();
            CreateSegmentsRectangles();
            displayMode = DisplayMode.SEGMENTS;
            SettingsApp.Default.LastRunFile = fileName;
            AddRunToLastRuns(fileName);
            SettingsApp.Default.Save();
        }

        private void SaveLayoutToFileAs()
        {
            if (saveLayoutDialog.ShowDialog() == DialogResult.OK)
            {
                layoutSettings.File = saveLayoutDialog.FileName;
                SaveLayoutToFile();
            }
        }

        private void SaveLayoutToFile()
        {
            layoutSettings.SaveLayoutSettings();
            SettingsLayout.Default.LayoutSettingsFile = layoutSettings.File;
            serializer = new XmlSerializer(layoutSettings.GetType());
            serializer.Serialize(new StreamWriter(layoutSettings.File, false), layoutSettings);
            SettingsLayout.Default.Save();
        }

        private void LoadLayoutFromFile(string file)
        {
            serializer = new XmlSerializer(layoutSettings.GetType());
            layoutSettings = (Model.LayoutSettings)serializer.Deserialize(new StreamReader(file));
            layoutSettings.LoadLayoutSettings();
            layoutSettings.File = file;
            SettingsLayout.Default.Save();
        }

        private void AddRunToLastRuns(String runFile)
        {
            int alreadyExistingRunIndex = SettingsApp.Default.LastRunsFile.IndexOf(runFile);
            if (alreadyExistingRunIndex != -1)
            {
                SettingsApp.Default.LastRunsFile.RemoveAt(alreadyExistingRunIndex);
                SettingsApp.Default.LastRunsFile.Insert(0, runFile);
            }
            if (!SettingsApp.Default.LastRunsFile.Contains(runFile))
            {
                SettingsApp.Default.LastRunsFile.Insert(0, runFile);
            }
            if (SettingsApp.Default.LastRunsFile.Count > 5)
            {
                SettingsApp.Default.LastRunsFile.RemoveAt(5);
            }
            UpdateLastRunMenu();
        }

        private void UpdateLastRunMenu()
        {
            mnuLastRuns.DropDownItems.Clear();
            List<String> lastRuns = SettingsApp.Default.LastRunsFile.Cast<string>().ToList();
            foreach (String run in lastRuns)
            {
                mnuLastRuns.DropDownItems.Add(run);
            }
            if(mnuLastRuns.DropDownItems.Count > 0)
            {
                mnuLastRuns.DropDownItems.Add(new ToolStripSeparator());
                mnuLastRuns.DropDownItems.Add(CLEAR_LAST_RUNS);
            }
        }

        /// <summary>
        /// Create a rectangle for each segment and adjust the position of the clock
        /// and the heigt of FaceSplit.
        /// </summary>
        private void CreateSegmentsRectangles()
        {
            segmentsRectangles.Clear();
            int index = 0;
            foreach (Segment segment in split.Segments)
            {
                segmentsRectangles.Add(new Rectangle(ZERO, (index * SEGMENT_HEIGHT) + splitY_start, DEFAULT_WIDTH, SEGMENT_HEIGHT));
                index++;
            }
            watchRectangle.Y = segmentsRectangles.Count() * SEGMENT_HEIGHT + splitY_start;
            Height = (segmentsRectangles.Count() * SEGMENT_HEIGHT) + (informations.Count * SEGMENT_HEIGHT) + (DEFAULT_HEIGHT * 2);
        }

        private void FillInformations()
        {
            informations.Insert((int)InformationIndexs.TITLE, new Information(InformationName.TITLE, split.RunTitle, split.RunsCompleted + "/" + split.AttemptsCount, (int)InformationIndexs.TITLE, true, true));
            informations.Insert((int)InformationIndexs.GOAL, new Information(InformationName.GOAL, "Goal: " + split.RunGoal, null,(int)InformationIndexs.GOAL, true, true));
            informations.Insert((int)InformationIndexs.PREVIOUS_SEGMENT, new Information(InformationName.PREVIOUS_SEGMENT, "Previous segment: ", "-", (int)InformationIndexs.PREVIOUS_SEGMENT, true, false));
            informations.Insert((int)InformationIndexs.POSSIBLE_TIMESAVE, new Information(InformationName.POSSIBLE_TIME_SAVE, "Possible time save: ", "-", (int)InformationIndexs.POSSIBLE_TIMESAVE, true, false));
            informations.Insert((int)InformationIndexs.PREDICTED_TIME, new Information(InformationName.PREDICTED_TIME, "Predicted time: ", "-", (int)InformationIndexs.PREDICTED_TIME, true, false));
            informations.Insert((int)InformationIndexs.SUM_OF_BEST, new Information(InformationName.SUM_OF_BEST, "Sum of best: ", "-", (int)InformationIndexs.SUM_OF_BEST, true, false));
            splitY_start = AboveInformationCount() * SEGMENT_HEIGHT;
        }

        private int AboveInformationCount()
        {
            int aboveNumber = 0;
            foreach (Information information in informations)
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
            string timeString;
            timeString = (displayMode == DisplayMode.SEGMENTS && split.RunStatus == RunStatus.DONE) ? runTimeOnCompletionPause.ToString("hh\\:mm\\:ss\\.ff") : watch.Elapsed.ToString("hh\\:mm\\:ss\\.ff");
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.TimerBackgroundColor), watchRectangle);
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(graphics, timeString, SettingsLayout.Default.TimerFont, watchRectangle, watchColor, flags);
        }

        /// <summary>
        /// Draw the list of segments.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawSegments(Graphics graphics)
        {
            string segmentName;
            string segmentSplitTime;
            string runDeltaString = "";
            Bitmap segmentIcon;
            
            TextFormatFlags nameFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.WordEllipsis;
            TextFormatFlags splitTimeFlags = TextFormatFlags.Right | TextFormatFlags.VerticalCenter | 
                TextFormatFlags.WordBreak;
            TextFormatFlags runDeltaFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.WordBreak;

            Rectangle segmentIconRectangle;
            Rectangle segmentNameRectangle;
            Rectangle segmentSplitTimeRectangle;
            
            Color rectangleColor = SettingsLayout.Default.SplitsBackgroundColor;

            for (int i = 0; i < segmentsRectangles.Count; ++i)
            {
                rectangleColor = (i == split.LiveIndex) ? SettingsLayout.Default.CurrentSegmentColor : SettingsLayout.Default.SplitsBackgroundColor;
                segmentName = split.Segments.ElementAt(i).SegmentName;
                segmentSplitTime = (split.Segments.ElementAt(i).SplitTime == 0) ? "-" : FaceSplitUtils.TimeFormat(split.Segments.ElementAt(i).SplitTime);
                segmentSplitTime = FaceSplitUtils.CutDecimals(segmentSplitTime, 2);
                segmentIcon = split.Segments.ElementAt(i).Icon;
                runDeltaString = GetRunDeltaString(i);
                runDeltaString = FaceSplitUtils.CutDecimals(runDeltaString, 2);
                segmentNameRectangle = segmentsRectangles.ElementAt(i);
                segmentNameRectangle.Width /= 2;
                segmentNameRectangle.X = 17;
                segmentSplitTimeRectangle = segmentsRectangles.ElementAt(i);
                segmentSplitTimeRectangle.Width /= 2;
                segmentSplitTimeRectangle.X = segmentNameRectangle.Width;
                segmentIconRectangle = new Rectangle(0, segmentNameRectangle.Y, 16, 16);
                graphics.FillRectangle(new SolidBrush(rectangleColor), segmentsRectangles.ElementAt(i));
                graphics.DrawImage(segmentIcon, segmentIconRectangle);
                TextRenderer.DrawText(graphics, segmentName, SettingsLayout.Default.SplitNamesFont,
                    segmentNameRectangle, SettingsLayout.Default.SplitNamesColor, nameFlags);
                TextRenderer.DrawText(graphics, segmentSplitTime, SettingsLayout.Default.SplitTimesFont,
                    segmentSplitTimeRectangle, SettingsLayout.Default.SplitTimesColor, splitTimeFlags);
                if(!string.IsNullOrEmpty(runDeltaString.Trim()))
                {
                    TextRenderer.DrawText(graphics, runDeltaString, SettingsLayout.Default.SplitDeltasFont,
                    segmentSplitTimeRectangle, split.GetSegmentColor(i), runDeltaFlags);
                }
            }
        }

        /// <summary>
        /// Fetch the run delta for each split with the index.
        /// Returns it into a string.
        /// </summary>
        /// <param name="index">The index of the split.</param>
        /// <returns>The run delta into a string.</returns>
        private string GetRunDeltaString(int index)
        {
            bool lostTime;
            double runDelta;
            double timeElapsed = (Math.Truncate(segmentWatch.Elapsed.TotalSeconds * 100) / 100) + timeElapsedSinceSplit;
            string runDeltaString = "";
            if (index < split.LiveIndex)
            {
                //Done mean we are after the last split but we still have the possiblity of going back.
                if ((split.RunStatus == RunStatus.ON_GOING || split.RunStatus == RunStatus.DONE) && !split.FirstSplit() && split.SegmentHasRunDelta(index))
                {
                    runDelta = split.GetRunDelta(index);
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
            else if (index == split.LiveIndex && split.SegmentHasRunDelta(index))
            {
                runDelta = split.GetLiveRunDelta(Math.Truncate(watch.Elapsed.TotalSeconds * 100) / 100);
                lostTime = (runDelta > 0);
                runDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(runDelta));
                if (lostTime)
                {
                    runDeltaString = runDeltaString.Insert(0, "+");
                    if ((index == 0) || (index > 0 && runDelta > split.GetRunDelta(index - 1)))
                    {
                        split.SetCurrentSegmentColor(SettingsLayout.Default.SplitDeltasBehindLosingColor);
                    }
                    else
                    {
                        split.SetCurrentSegmentColor(SettingsLayout.Default.SplitDeltasBehindSavingColor);
                    }
                    watchColor = SettingsLayout.Default.TimerBehindColor;
                }
                else if ((index > 0 && runDelta > split.GetRunDelta(index - 1)))
                {
                    runDeltaString = runDeltaString.Insert(0, "-");
                    split.SetCurrentSegmentColor(SettingsLayout.Default.SplitDeltasAheadLosingColor);
                }
                else if (split.CurrentSegmentHasLiveDelta(timeElapsed))
                {
                    runDeltaString = runDeltaString.Insert(0, "-");
                    split.SetCurrentSegmentColor(SettingsLayout.Default.SplitDeltasAheadSavingColor);
                }
                else
                {
                    runDeltaString = "";
                    watchColor = SettingsLayout.Default.TimerRunningColor;
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
            for (int i = 0; i < informations.Count; i++)
            {
                if (informations.ElementAt(i).Above)
                {
                    Rectangle informationRectangle = new Rectangle(0, aboveDrawn * SEGMENT_HEIGHT, DEFAULT_WIDTH, SEGMENT_HEIGHT);
                    graphics.FillRectangle(new SolidBrush(informations.ElementAt(i).BackgroundColor), informationRectangle);
                    TextRenderer.DrawText(graphics, informations.ElementAt(i).PrimaryText, informations.ElementAt(i).PrimaryTextFont,
                        informationRectangle, informations.ElementAt(i).PrimaryTextColor, informations.ElementAt(i).PrimaryTextFlags);
                    if (informations.ElementAt(i).SecondaryText != null)
                    {
                        TextRenderer.DrawText(graphics, informations.ElementAt(i).SecondaryText, informations.ElementAt(i).SecondaryTextFont,
                            informationRectangle, informations.ElementAt(i).SecondaryTextColor, informations.ElementAt(i).SecondaryTextFlags);
                    }
                    aboveDrawn++;
                }
                else
                {
                    Rectangle informationRectangle = new Rectangle(0, (watchRectangle.Y + (watchRectangle.Height * 2)) + (belowDrawn * SEGMENT_HEIGHT), DEFAULT_WIDTH, SEGMENT_HEIGHT);
                    graphics.FillRectangle(new SolidBrush(informations.ElementAt(i).BackgroundColor), informationRectangle);
                    TextRenderer.DrawText(graphics, informations.ElementAt(i).PrimaryText, informations.ElementAt(i).PrimaryTextFont,
                        informationRectangle, informations.ElementAt(i).PrimaryTextColor, informations.ElementAt(i).PrimaryTextFlags);
                    if (informations.ElementAt(i).SecondaryText != null)
                    {
                        TextRenderer.DrawText(graphics, informations.ElementAt(i).SecondaryText, informations.ElementAt(i).SecondaryTextFont,
                            informationRectangle, informations.ElementAt(i).SecondaryTextColor, informations.ElementAt(i).SecondaryTextFlags);
                    }
                    belowDrawn++;
                }
            }
        }

        private void FillEmptySegmentTimer(Graphics graphics)
        {
            Rectangle emptySegmentTimerRectangle = new Rectangle(0, watchRectangle.Y + watchRectangle.Height, DEFAULT_WIDTH, DEFAULT_HEIGHT);
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), emptySegmentTimerRectangle);
        }

        private void DrawSegmentTimer(Graphics graphics)
        {
            TextFormatFlags segmentTimeFlags = TextFormatFlags.Left | TextFormatFlags.Bottom | TextFormatFlags.WordEllipsis;
            TextFormatFlags segmentBestTimeFlags = TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordEllipsis;

            Rectangle segmentTimeRectangle = new Rectangle(0, watchRectangle.Y + watchRectangle.Height, DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2);
            Rectangle segmentBestimeRectangle = new Rectangle(0, segmentTimeRectangle.Y + segmentTimeRectangle.Height, DEFAULT_WIDTH / 2, DEFAULT_HEIGHT / 2);
            Rectangle segmentTimerRectangle = new Rectangle(DEFAULT_WIDTH / 2, watchRectangle.Y + watchRectangle.Height, DEFAULT_WIDTH / 2, DEFAULT_HEIGHT);

            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), segmentTimeRectangle);
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), segmentBestimeRectangle);
            graphics.FillRectangle(new SolidBrush(SettingsLayout.Default.SegmentTimerBackgroundColor), segmentTimerRectangle);

            string segmentTime = (split.RunStatus == RunStatus.ON_GOING) ? FaceSplitUtils.TimeFormat(split.CurrentSegment.BackupSegmentTime) : FaceSplitUtils.TimeFormat(split.Segments.Last().BackupSegmentTime);
            string segmentBestTime = (split.RunStatus == RunStatus.ON_GOING) ? FaceSplitUtils.TimeFormat(split.CurrentSegment.BackupBestSegmentTime) : FaceSplitUtils.TimeFormat(split.Segments.Last().BackupBestSegmentTime);
            string segmentTimerString;
            segmentTimerString = (split.RunStatus == RunStatus.DONE) ? FaceSplitUtils.TimeFormat(segmentTimeOnCompletionPause)
                : FaceSplitUtils.TimeFormat((Math.Truncate(segmentWatch.Elapsed.TotalSeconds * 100) / 100) + timeElapsedSinceSplit);

            segmentTimerString = segmentTimerString.Replace(',', '.');

            TextRenderer.DrawText(graphics, "PB: " + segmentTime, SettingsLayout.Default.SegmentTimerPBFont,
                segmentTimeRectangle, SettingsLayout.Default.SegmentTimerPBColor, segmentTimeFlags);

            TextRenderer.DrawText(graphics, "BEST: " + segmentBestTime, SettingsLayout.Default.SegmentTimerBestFont,
                segmentBestimeRectangle, SettingsLayout.Default.SegmentTimerBestColor, segmentBestTimeFlags);

            TextRenderer.DrawText(graphics, segmentTimerString, SettingsLayout.Default.SegmentTimerFont,
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

        private void FaceSplit_Activated(object sender, EventArgs e)
        {
            TaskbarManager.Instance.SetProgressValue(1, 1);
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
            if (displayMode == DisplayMode.TIMER_ONLY)
            {
                if (watch.IsRunning)
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
            if (displayMode == DisplayMode.SEGMENTS)
            {
                split.ResetRun();
                ResetSegmentTimer();
            }
            timeElapsedSinceSplit = 0;
        }

        private void KeyboardUnsplit()
        {
            if (displayMode == DisplayMode.SEGMENTS)
            {
                segmentWatchColor = SettingsLayout.Default.SegmentTimerRunningColor;
                if (split.RunStatus == RunStatus.DONE)
                {
                    split.ResumeRun();
                    StartTimer();
                }
                if (split.LiveIndex > 0)
                {
                    Segment lastSegment = split.Segments.ElementAt(split.LiveIndex - 1);
                    timeElapsedSinceSplit += split.Segments.ElementAt(split.LiveIndex - 1).SegmentTime;
                }
                split.UnSplit();
            }
        }

        private void KeyboardSkip()
        {
            if (displayMode == DisplayMode.SEGMENTS && split.RunStatus == RunStatus.ON_GOING && !split.CurrentSplitIsLastSplit())
            {
                segmentWatchColor = SettingsLayout.Default.SegmentTimerRunningColor;
                split.SkipSegment((Math.Truncate(segmentWatch.Elapsed.TotalSeconds * 100) / 100));
                segmentWatch.Restart();
            }
        }

        private void KeyboardPause()
        {
            if (split != null && split.RunStatus == RunStatus.ON_GOING)
            {
                if (segmentWatch.IsRunning)
                {
                    segmentWatch.Stop();
                }
                else
                {
                    segmentWatch.Start();
                }
            }
            if (watch.IsRunning)
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
            segmentWatchColor = SettingsLayout.Default.SegmentTimerRunningColor;
            if (split.RunStatus == RunStatus.STOPPED)
            {
                StartTimer();
                StartSegmentTimer();
                split.StartRun();
            }
            else if(split.RunStatus == RunStatus.ON_GOING && watch.IsRunning)
            {
                double splitTime = Math.Truncate(watch.Elapsed.TotalSeconds * 100) / 100;
                double segmentTime = (Math.Truncate(segmentWatch.Elapsed.TotalSeconds * 100) / 100) + timeElapsedSinceSplit;
                if (!split.CurrentSplitIsLastSplit())
                {
                    split.DoSplit(splitTime, segmentTime);
                }
                else
                {
                    split.DoSplit(splitTime, segmentTime);
                    split.CompleteRun();
                    runTimeOnCompletionPause = watch.Elapsed;
                    segmentTimeOnCompletionPause = segmentTime;
                    watchColor = SettingsLayout.Default.TimerPausedColor;
                    segmentWatchColor = SettingsLayout.Default.SegmentTimerPausedColor;
                }
                segmentWatch.Restart();
            }
            else if (split.RunStatus == RunStatus.DONE)
            {
                split.SaveRun();
                ResetTimer();
                ResetSegmentTimer();
            }
            timeElapsedSinceSplit = 0;
        }

        /// <summary>
        /// Update the data that is shown by each information.
        /// </summary>
        public void UpdateInformationsData()
        {
            informations[(int)InformationIndexs.TITLE].SecondaryText = split.RunsCompleted + "/" + split.AttemptsCount;
            informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryText = GetPreviousSegmentDeltaString();
            informations[(int)InformationIndexs.POSSIBLE_TIMESAVE].SecondaryText = GetPossibleTimeSave();
            informations[(int)InformationIndexs.PREDICTED_TIME].SecondaryText = GetPredictedTime();
            informations[(int)InformationIndexs.SUM_OF_BEST].SecondaryText = GetSOB();
        }

        private string GetPreviousSegmentDeltaString()
        {
            string segmentDeltaString;
            double segmentDelta;
            bool lostTime;
            bool bestSegment = false;
            double timeElapsed = (Math.Truncate(segmentWatch.Elapsed.TotalSeconds * 100) / 100) + timeElapsedSinceSplit;
            if (split.LiveIndex > 0)
            {
                bestSegment = split.PreviousSegmentIsBestSegment();
            }
            if (split.CurrentSegmentHasLiveDelta(timeElapsed))
            {
                informations[(int)InformationIndexs.PREVIOUS_SEGMENT].PrimaryText = "Live segment: ";
                segmentDelta = split.GetLiveSegmentDelta(timeElapsed);
                segmentDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(segmentDelta));
                lostTime = (segmentDelta > 0);
                if (lostTime)
                {
                    informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = SettingsLayout.Default.PreviousSegmentDeltaLostColor;
                    segmentDeltaString = segmentDeltaString.Insert(0, "+");
                    segmentWatchColor = SettingsLayout.Default.SegmentTimerLosingTimeColor;
                }
                else
                {
                    informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = SettingsLayout.Default.PreviousSegmentDeltaSavedColor;
                    segmentDeltaString = segmentDeltaString.Insert(0, "-");
                }
            }
            else if (split.PreviousSegmentHasSegmentDelta())
            {
                informations[(int)InformationIndexs.PREVIOUS_SEGMENT].PrimaryText = "Previous segment: ";
                segmentDelta = split.GetPreviousSegmentDelta();
                segmentDeltaString = FaceSplitUtils.TimeFormat(Math.Abs(segmentDelta));
                lostTime = (segmentDelta > 0);
                if (bestSegment)
                {
                    informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = SettingsLayout.Default.PreviousSegmentDeltaBestSegmentColor;
                    segmentDeltaString = segmentDeltaString.Insert(0, "-");
                }
                else
                {
                    if (lostTime)
                    {
                        informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = SettingsLayout.Default.PreviousSegmentDeltaLostColor;
                        segmentDeltaString = segmentDeltaString.Insert(0, "+");
                    }
                    else
                    {
                        informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = SettingsLayout.Default.PreviousSegmentDeltaSavedColor;
                        segmentDeltaString = segmentDeltaString.Insert(0, "-");
                    }
                }
                split.SetPreviousSegmentColor(bestSegment, lostTime);
            }
            else
            {
                informations[(int)InformationIndexs.PREVIOUS_SEGMENT].PrimaryText = "Previous segment: ";
                informations[(int)InformationIndexs.PREVIOUS_SEGMENT].SecondaryTextColor = SettingsLayout.Default.PreviousSegmentDeltaNoDeltaColor;
                segmentDeltaString = "-";
            }
            segmentDeltaString = FaceSplitUtils.CutDecimals(segmentDeltaString, 2);
            return segmentDeltaString;
        }

        public string GetPossibleTimeSave()
        {
            if (split.SegmentHasPossibleTimeSave())
            {
                double possibleTimeSave = split.GetPossibleTimeSave();
                string possibleTimeSaveString = FaceSplitUtils.TimeFormat(possibleTimeSave);
                possibleTimeSaveString = FaceSplitUtils.CutDecimals(possibleTimeSaveString, 2);
                return possibleTimeSaveString;
            }
            return "-";
        }

        public string GetPredictedTime()
        {
            double predictedTime = split.GetPredictedTime();
            string predictedTimeString = "-";
            if (predictedTime != 0.0)
            {
                predictedTimeString = FaceSplitUtils.TimeFormat(predictedTime);
            }
            predictedTimeString = FaceSplitUtils.CutDecimals(predictedTimeString, 2);
            return predictedTimeString;
        }

        public string GetSOB()
        {
            double sob = split.GetSOB();
            string sobString = "-";
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
            watch.Start();
            watchColor = SettingsLayout.Default.TimerRunningColor;
            segmentWatchColor = SettingsLayout.Default.SegmentTimerRunningColor;
        }

        /// <summary>
        /// Stop the timer and set the color of the watch.
        /// </summary>
        private void StopTimer()
        {
            watch.Stop();
            watchColor = SettingsLayout.Default.TimerPausedColor;
            segmentWatchColor = SettingsLayout.Default.SegmentTimerPausedColor;
        }

        /// <summary>
        /// Reset the timer and set the color of the watch.
        /// </summary>
        private void ResetTimer()
        {
            watch.Reset();
            watchColor = SettingsLayout.Default.TimerNotRunningColor;
            segmentWatchColor = SettingsLayout.Default.SegmentTimerNotRunningColor;
        }

        private void StartSegmentTimer()
        {
            segmentWatch.Start();
        }

        private void StopSegmentTimer()
        {
            segmentWatch.Stop();
        }

        private void ResetSegmentTimer()
        {
            segmentWatch.Reset();
        }
    }
}
