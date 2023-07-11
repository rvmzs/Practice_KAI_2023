using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class InsertBankCardGap : CardGap
    {
        private TerminalScreen2 terminalScreen2;

        public InsertBankCardGap(int gridCol, int gridRow, Grid grid, TerminalScreen2 terminalScreen2) : base(gridCol, gridRow, grid)
        {
            enterPassive = new GapState(HelpMethods.getHexBrush("#7B68EE"), "Вставить карту банка");
            active = new GapState(HelpMethods.getHexBrush("#BA55D3"), "Карта банка вставлена");
            enterActive = new GapState(HelpMethods.getHexBrush("#7B68EE"), "Забрать карту банка");

            this.terminalScreen2 = terminalScreen2;
        }

        protected override void Gap_MouseDown(object sender, MouseEventArgs e)
        {
            CardInGap = !CardInGap;
            HelpMethods.InvertBoolBankCardInHand();

            if (Accessible & HelpMethods.GetAccountIsDone())
            {
                terminalScreen2.switchScreenToMain(CardInGap);
            }
        }
    }
}
