using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FaceSplit.Model
{
    /// <summary>
    /// Class use to store data of information that will be shown on the timer.
    /// </summary>
    public class Information
    {
        private string informationName;
        private string primaryText;
        private string secondaryText;
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

        public Information(string informationName, string primaryText, string secondaryText, int position, bool display, bool above)
        {
            List<TextFormatFlags> flags = new List<TextFormatFlags>();
            this.informationName = informationName;
            this.primaryText = primaryText;
            this.secondaryText = secondaryText;
            this.position = position;
            this.display = display;
            this.above = above;
            flags = InformationFlagsFactory.GetInformationFlags(this.informationName);
            primaryTextFlags = flags.ElementAt(0);
            if (this.secondaryText != null)
            {
                secondaryTextFlags = flags.ElementAt(1);
            }
            InformationStyleFactory.SetInformationStyle(this);
        }

        public string InformationName
        {
            get { return informationName; }
        }

        public string PrimaryText
        {
            get { return primaryText; }
            set { primaryText = value; }
        }

        public string SecondaryText
        {
            get { return secondaryText; }
            set { secondaryText = value; }
        }

        public bool Above
        {
            get { return above; }
        }

        public TextFormatFlags PrimaryTextFlags
        {
            get { return primaryTextFlags; }
        }

        public TextFormatFlags SecondaryTextFlags
        {
            get { return secondaryTextFlags; }
        }

        public Color PrimaryTextColor
        {
            get { return primaryTextColor; }
            set { primaryTextColor = value; }
        }

        public Color SecondaryTextColor
        {
            get { return secondaryTextColor; }
            set { secondaryTextColor = value; }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        public Font PrimaryTextFont
        {
            get { return primaryTextFont; }
            set { primaryTextFont = value; }
        }

        public Font SecondaryTextFont
        {
            get { return secondaryTextFont; }
            set { secondaryTextFont = value; }
        }

        public void UpdateStyle()
        {
            InformationStyleFactory.SetInformationStyle(this);
        }
    }
}
