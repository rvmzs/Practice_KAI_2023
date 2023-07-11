using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class TerminalScreen3 : TerminalScreen
    {
        public TerminalScreen3(int gridCol, int gridRow, Grid grid, int terminalNum, params string[] messages)
            : base(gridCol, gridRow, grid, terminalNum, messages) { }

        public override void switchScreenToMain(bool cardInGap)
        {
            if(cardInGap)
            {
                switchScreenToIndex(1);
            }
            else
            {
                switchScreenToIndex(0);
            }
        }
    }
}
