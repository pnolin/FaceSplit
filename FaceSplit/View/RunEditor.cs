using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FaceSplit.Model;
using FaceSplit.Properties;

namespace FaceSplit
{
    public partial class RunEditor : Form
    {
        private const int INVALID_VALUE = -1;
        private const int SEGMENT_NAME_ROW = 0;
        private const int SEGMENT_SPLIT_TIME_ROW = 1;
        private const int SEGMENT_TIME_ROW = 2;
        private const int SEGMENT_BEST_TIME_ROW = 3;
        private const int SEGMENT_ICON_ROW = 4;

        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private Split split;
        private int rowHeight;

        public RunEditor(Split split)
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            txtAttemptsCount.Text = "0";
            rowHeight = segmentsGridView.RowTemplate.Height;
            AddRow();
            if (split != null)
            {
                this.split = split;
                txtRunTitle.Text = this.split.RunTitle;
                txtRunGoal.Text = this.split.RunGoal;
                txtAttemptsCount.Text = this.split.AttemptsCount.ToString();
                FillSegmentRows();
            }
        }

        public Split Split
        {
            get { return split; }
        }


        private void segmentsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == segmentsGridView.ColumnCount - 1)
            {
                openFileDialog.AddExtension = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    segmentsGridView.Rows[e.RowIndex].Cells[SEGMENT_ICON_ROW].Value = new Bitmap(openFileDialog.FileName);
                }
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSplit();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            AddRow();
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveRow(segmentsGridView.CurrentCell.RowIndex);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuImport.Show(ptLowerLeft);
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            FillSegmentsTime();
        }

        private void mnuImportFromLivesplit_Click(object sender, EventArgs e)
        {
            string fileName = "";
            openFileDialog.DefaultExt = ".lss";
            openFileDialog.Filter = "LiveSplit split file (*.lss)|*.lss";
            openFileDialog.AddExtension = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                LiveSplitXMLReader liveSplitXmlReader = new LiveSplitXMLReader();
                split = liveSplitXmlReader.ReadSplit(fileName);
                ResetDataGridView();
                if (split != null)
                {
                    txtRunTitle.Text = split.RunTitle;
                    txtAttemptsCount.Text = split.AttemptsCount.ToString();
                    FillSegmentRows();
                    FillSegmentTimeAfterImportFromLiveSplit();
                }
                else
                {
                    MessageBox.Show("The import from livesplit has failed.");
                }
            }
        }

        private void txtAttemptsCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Proceed to add a row in the table view and set a higher 
        /// height to the window if needed.
        /// </summary>
        private void AddRow()
        {
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.Height = rowHeight;
            segmentsGridView.Rows.Insert(segmentsGridView.Rows.Count, newRow);
            if (segmentsGridView.Rows.Count <= 15)
            {
                segmentsGridView.Height += rowHeight;
            }
            if (segmentsGridView.Rows.Count > 1 && segmentsGridView.Rows.Count <= 15)
            {
                Height += rowHeight;
                MoveButtonsUnderGridView();
            }
        }

        private void RemoveRow(int index = -1)
        {
            index = (index == -1) ? segmentsGridView.Rows.Count -1 : index;
            segmentsGridView.Rows.RemoveAt(index);
            if (segmentsGridView.Rows.Count < 15)
            {
                segmentsGridView.Height -= rowHeight;            
            }
            if (segmentsGridView.Rows.Count > 0 && segmentsGridView.Rows.Count < 15)
            {
                Height -= rowHeight;
                MoveButtonOnRemoveRow();
            }
        }

        /// <summary>
        /// When adding a row in the grid view, the buttons under it need to go down.
        /// This is what we do here.
        /// </summary>
        private void MoveButtonsUnderGridView()
        {
            btnInsert.Top += rowHeight;
            btnRemove.Top += rowHeight;
            btnImport.Top += rowHeight;
            btnFill.Top += rowHeight;
            btnSave.Top += rowHeight;
            btnCancel.Top += rowHeight;
            lblAttemptsCount.Top += rowHeight;
            txtAttemptsCount.Top += rowHeight;
        }

        private void MoveButtonOnRemoveRow()
        {
            btnInsert.Top -= rowHeight;
            btnRemove.Top -= rowHeight;
            btnImport.Top -= rowHeight;
            btnFill.Top -= rowHeight;
            btnSave.Top -= rowHeight;
            btnCancel.Top -= rowHeight;
            lblAttemptsCount.Top -= rowHeight;
            txtAttemptsCount.Top -= rowHeight;
        }

        private void segmentsGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl gridTextChangeControl = (DataGridViewTextBoxEditingControl)e.Control;
            gridTextChangeControl.KeyPress += new KeyPressEventHandler(segmentGridView_KeyPress);
        }

        private void segmentGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (segmentsGridView.CurrentCell.ColumnIndex != 0)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ':' && e.KeyChar != '.' && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Save split with the information in the editor.
        /// </summary>
        private void SaveSplit()
        {
            split = new Split();
            split.RunTitle = txtRunTitle.Text;
            split.RunGoal = txtRunGoal.Text;
            split.AttemptsCount = (string.IsNullOrEmpty(txtAttemptsCount.Text.Trim())) ? 0 : int.Parse(txtAttemptsCount.Text);
            FillSplitSegments();

        }

        private void FillSplitSegments()
        {
            foreach (DataGridViewRow rows in segmentsGridView.Rows)
            {
                string segmentName = (rows.Cells[SEGMENT_NAME_ROW].Value == null) ? "-" : rows.Cells[SEGMENT_NAME_ROW].Value.ToString();
                double splitTime = (rows.Cells[SEGMENT_SPLIT_TIME_ROW].Value == null) ? 0.0 : FaceSplitUtils.TimeParse(rows.Cells[SEGMENT_SPLIT_TIME_ROW].Value.ToString());
                double segmentTime = (rows.Cells[SEGMENT_TIME_ROW].Value == null) ? 0.0 : FaceSplitUtils.TimeParse(rows.Cells[SEGMENT_TIME_ROW].Value.ToString());
                double bestSegmentTime = (rows.Cells[SEGMENT_BEST_TIME_ROW].Value == null) ? 0.0 : FaceSplitUtils.TimeParse(rows.Cells[SEGMENT_BEST_TIME_ROW].Value.ToString());
                //TODO: Set noicon in Segment.cs instead of here.
                Bitmap icon = (rows.Cells[SEGMENT_ICON_ROW].Value == null) ? (Bitmap) Resources.noicon : (Bitmap) rows.Cells[SEGMENT_ICON_ROW].Value;
                split.Segments.Add(new Segment(segmentName, splitTime, segmentTime, bestSegmentTime, icon));
            }
        }

        /// <summary>
        /// Fill the rows in the table with the split information.
        /// </summary>
        private void FillSegmentRows()
        {
            for (int i = 0; i < split.Segments.Count; ++i)
            {
                if (i >= segmentsGridView.Rows.Count)
                {
                    AddRow();
                }
                segmentsGridView.Rows[i].Cells[0].Value = split.Segments.ElementAt(i).SegmentName;
                segmentsGridView.Rows[i].Cells[1].Value = FaceSplitUtils.TimeFormat(split.Segments.ElementAt(i).SplitTime);
                segmentsGridView.Rows[i].Cells[2].Value = FaceSplitUtils.TimeFormat(split.Segments.ElementAt(i).SegmentTime);
                segmentsGridView.Rows[i].Cells[3].Value = FaceSplitUtils.TimeFormat(split.Segments.ElementAt(i).BestSegmentTime);
            }
        }

        /// <summary>
        /// Fill the segment time and the best segment time column.
        /// </summary>
        private void FillSegmentsTime()
        {
            List<double> splitsTime = new List<double>();
            List<double> segmentsTime = new List<double>();

            FillSplitsTime(splitsTime);
            CalculateSegmentsTime(splitsTime, segmentsTime);
            FillSegmentColumns(segmentsTime); 
        }

        private void FillSegmentTimeAfterImportFromLiveSplit()
        {
            List<double> splitsTime = new List<double>();
            List<double> segmentsTime = new List<double>();

            FillSplitsTime(splitsTime);
            CalculateSegmentsTime(splitsTime, segmentsTime);
            FillOnlySegmentTimeColumn(segmentsTime);
        }

        /// <summary>
        /// Get the list of splits time from the data grid view.
        /// </summary>
        /// <param name="splitsTime">The list of splits time to be fill.</param>
        private void FillSplitsTime(List<double> splitsTime)
        {
            foreach (DataGridViewRow rows in segmentsGridView.Rows)
            {
                string splitTimeString = (rows.Cells[SEGMENT_SPLIT_TIME_ROW].Value == null) ? "" : rows.Cells[SEGMENT_SPLIT_TIME_ROW].Value.ToString();
                if (!string.IsNullOrEmpty(splitTimeString.Trim()))
                {
                    splitsTime.Add(FaceSplitUtils.TimeParse(splitTimeString));
                }
                else
                {
                    splitsTime.Add(INVALID_VALUE);
                }
            }
        }

        /// <summary>
        /// Take the splits time and calculate segments time from them.
        /// </summary>
        /// <param name="splitsTime">The list of splits time.</param>
        /// <param name="segmentsTime">The list of segments time to be fill.</param>
        private void CalculateSegmentsTime(List<double> splitsTime, List<double> segmentsTime)
        {
            for (int i = 0; i < splitsTime.Count; ++i)
            {
                if (i > 0)
                {
                    if (splitsTime.ElementAt(i - 1) != INVALID_VALUE && splitsTime.ElementAt(i) != INVALID_VALUE)
                    {
                        double segmentTime = splitsTime.ElementAt(i) - splitsTime.ElementAt(i - 1);
                        segmentsTime.Add(segmentTime);
                    }
                    else
                    {
                        segmentsTime.Add(INVALID_VALUE);
                    }
                }
                else
                {
                    if (splitsTime.ElementAt(i) != INVALID_VALUE)
                    {
                        segmentsTime.Add(splitsTime.ElementAt(i));
                    }
                    else
                    {
                        segmentsTime.Add(INVALID_VALUE);
                    }
                }
            }
        }

        /// <summary>
        /// Fill the segment cells in the table with the segments time from the list.
        /// </summary>
        /// <param name="segmentsTime">The list we use to fill the cells.</param>
        private void FillSegmentColumns(List<double> segmentsTime)
        {
            int index = 0;
            foreach (DataGridViewRow rows in segmentsGridView.Rows)
            {
                DataGridViewCell cellSegmentTime = rows.Cells[SEGMENT_TIME_ROW];
                DataGridViewCell cellBestSegmentTime = rows.Cells[SEGMENT_BEST_TIME_ROW];
                if (segmentsTime.ElementAt(index) != INVALID_VALUE)
                {
                    cellSegmentTime.Value = FaceSplitUtils.TimeFormat(segmentsTime.ElementAt(index));
                    cellBestSegmentTime.Value = FaceSplitUtils.TimeFormat(segmentsTime.ElementAt(index));
                }
                else
                {
                    cellSegmentTime.Value = "";
                    cellBestSegmentTime.Value = "";
                }
                index++;
            }
        }

        private void FillOnlySegmentTimeColumn(List<double> segmentsTime)
        {
            int index = 0;
            foreach (DataGridViewRow rows in segmentsGridView.Rows)
            {
                DataGridViewCell cellSegmentTime = rows.Cells[SEGMENT_TIME_ROW];
                if (segmentsTime.ElementAt(index) != INVALID_VALUE)
                {
                    cellSegmentTime.Value = FaceSplitUtils.TimeFormat(segmentsTime.ElementAt(index));
                }
                else
                {
                    cellSegmentTime.Value = "";
                }
                index++;
            }
        }

        private void ResetDataGridView()
        {
            int numberOfRows = segmentsGridView.Rows.Count;
            for (int i = 0; i < numberOfRows; ++i)
            {
                RemoveRow();
            }
        }
    }
}
