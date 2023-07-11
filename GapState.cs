using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class GapState
    {
        public SolidColorBrush Color { get; set; }
        public string Text { get; set; }

        public GapState(SolidColorBrush color, string text)
        {
            Color = color;
            Text = text;
        }
    }
}
