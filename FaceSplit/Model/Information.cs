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
        private String primaryText;
        private String secondaryText;
        private int position;
        private bool display;
        private bool above;
        private TextFormatFlags primaryTextFlags;
        private TextFormatFlags secondaryTextFlags;
        private Font primaryTextFont;
        private Font secondaryTextFont;
        private Color primaryTextColor;
        private Color secondaryTextColor;
        private Color backgroundColor;

        public Information(string informationName, string primaryText, string secondaryText, int position, Boolean display, Boolean above)
        {
            List<TextFormatFlags> flags = new List<TextFormatFlags>();
            this.informationName = informationName;
            this.primaryText = primaryText;
            this.secondaryText = secondaryText;
            this.position = position;
            this.display = display;
            this.above = above;
            flags = InformationFlagsFactory.GetInformationFlags(this.informationName);
            this.primaryTextFlags = flags.ElementAt(0);
            if (this.secondaryText != null)
            {
                this.secondaryTextFlags = flags.ElementAt(1);
            }
            InformationStyleFactory.SetInformationStyle(this);
        }

        public String InformationName
        {
            get { return this.informationName; }
        }

        public String PrimaryText
        {
            get { return this.primaryText; }
            set { this.primaryText = value; }
        }

        public String SecondaryText
        {
            get { return this.secondaryText; }
            set { this.secondaryText = value; }
        }

        public Boolean Above
        {
            get { return this.above; }
        }

        public TextFormatFlags PrimaryTextFlags
        {
            get { return this.primaryTextFlags; }
        }

        public TextFormatFlags SecondaryTextFlags
        {
            get { return this.secondaryTextFlags; }
        }

        public Color PrimaryTextColor
        {
            get { return this.primaryTextColor; }
            set { this.primaryTextColor = value; }
        }

        public Color SecondaryTextColor
        {
            get { return this.secondaryTextColor; }
            set { this.secondaryTextColor = value; }
        }

        public Color BackgroundColor
        {
            get { return this.backgroundColor; }
            set { this.backgroundColor = value; }
        }

        public Font PrimaryTextFont
        {
            get { return this.primaryTextFont; }
            set { this.primaryTextFont = value; }
        }

        public Font SecondaryTextFont
        {
            get { return this.secondaryTextFont; }
            set { this.secondaryTextFont = value; }
        }

        public void UpdateStyle()
        {
            InformationStyleFactory.SetInformationStyle(this);
        }
    }
}
