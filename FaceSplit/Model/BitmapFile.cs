using System.Drawing;
using FaceSplit.Properties;

namespace FaceSplit.Model
{
    public class BitmapFile
    {
        private Bitmap icon;
        private string iconPath;

        public Bitmap Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string IconPath
        {
            get { return iconPath; }
            set { this.iconPath = value; }
        }

        public BitmapFile(string iconPath = null)
        {
            icon = (iconPath == null || iconPath.Equals("")) ? Resources.noicon : new Bitmap(iconPath);
            iconPath = (iconPath == null || iconPath.Equals("")) ? "" : iconPath;
        }

    }
}
