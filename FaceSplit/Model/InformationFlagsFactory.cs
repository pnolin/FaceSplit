using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceSplit.Model
{
    public class InformationFlagsFactory
    {
        public static List<TextFormatFlags> GetInformationFlags(String informationName)
        {
            List<TextFormatFlags> flags = new List<TextFormatFlags>();
            if (informationName == InformationName.TITLE)
            {
                flags.Add(TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
                flags.Add(TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            }
            else if (informationName == InformationName.GOAL)
            {
                flags.Add(TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            }
            else
            {
                flags.Add(TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
                flags.Add(TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            }
            return flags;
        }
    }
}
