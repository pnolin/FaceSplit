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
        public const int DEFAULT_WIDTH = 132;
        public const int DEFAULT_HEIGHT = 38;

        /// <summary>
        /// Clock position.
        /// </summary>
        public const int WATCH_X = 0;
        public const int WATCH_Y = 0;

        Split split;

        /// <summary>
        /// The watch on the screen.
        /// </summary>
        Stopwatch watch;

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
            watchRectangle = new Rectangle(WATCH_X, WATCH_Y, DEFAULT_WIDTH, DEFAULT_HEIGHT);
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
                this.split = new Split();
                this.split.RunTitle = runEditor.Split.RunTitle;
                this.split.RunGoal = runEditor.Split.RunGoal;
                this.split.AttemptsCount = runEditor.Split.AttemptsCount;
                foreach (Segment segment in runEditor.Split.Segments)
                {
                    this.split.Segments.Add(segment);
                }
                MessageBox.Show("Run Title : " + this.split.RunTitle + " run goal : " + this.split.RunGoal);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void DrawFaceSplit(object sender, PaintEventArgs e)
        {
            DrawWatch(e.Graphics);
        }

        /// <summary>
        /// Used to draw the clock.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        private void DrawWatch(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(Color.Black), this.watchRectangle);
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(graphics, this.watch.Elapsed.ToString("hh\\:mm\\:ss\\.ff"), new Font(FontFamily.GenericSansSerif, 14.0F, FontStyle.Bold), watchRectangle, Color.White, flags);
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
                    if (this.watch.IsRunning)
                    {
                        this.watch.Stop();
                    }
                    else if (this.watch.ElapsedTicks > 0L)
                    {
                        this.watch.Reset();
                    }
                    else
                    {
                        this.watch.Start();
                    }
                    break;
            }
        }
    }
}
