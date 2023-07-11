using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using Praktika_Lavrentev_Abdrahmanov;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class InsertPassCardGap : CardGap
    {
        public TerminalScreen terminalScreen;

        public InsertPassCardGap(int gridCol, int gridRow, Grid grid, TerminalScreen terminalScreen) : base(gridCol, gridRow, grid)
        {
            enterPassive = new GapState(HelpMethods.getHexBrush("#98FB98"), "Вставить карту-пропуск");
            active = new GapState(HelpMethods.getHexBrush("#00FF7F"), "Карта-пропуск вставлена");
            enterActive = new GapState(HelpMethods.getHexBrush("#98FB98"), "Забрать карту-пропуск");

            this.terminalScreen = terminalScreen;
        }

        protected override void Gap_MouseDown(object sender, MouseEventArgs e)
        {
            if (!CardInGap & !HelpMethods.GetPassCardInHand())
            {
                MessageBox.Show("В ваших руках нет карты пропуска, чтобы вставить её в терминал");
            }
            else
            {
                CardInGap = !CardInGap;
                HelpMethods.InvertBoolPassCardInHand();

                if(Accessible)
                {
                    terminalScreen.switchScreenToMain(CardInGap);
                }
            }
        }

        public bool GetCardInGap() { return CardInGap; }
    }
}
