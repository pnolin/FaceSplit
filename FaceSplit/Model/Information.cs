using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FaceSplit.Model
{
    /// <summary>
    /// Class use to store data of information that will be shown on the timer.
    /// </summary>
    public class Information
    {
        private String informationName;
        private String informationText;
        private int position;
        private bool display;
        private bool above;
        private TextFormatFlags informationFlags;
        private Color informationColor;

        public Information(string text, int position, Boolean display, Boolean above)
        {
            this.informationText = text;
            this.position = position;
            this.display = display;
            this.above = above;
            this.informationFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
            this.informationColor = Color.White;
        }

        public String InformationText
        {
            get { return this.informationText; }
        }

        public Boolean Above
        {
            get { return this.above; }
        }

        public TextFormatFlags InformationFlags
        {
            get { return this.informationFlags; }
        }

        public Color InformationColor
        {
            get { return this.informationColor; }
        }
    }
}
