using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Praktika_Lavrentev_Abdrahmanov
{
    internal class GetPassCardGap : CardGap
    {
        public GetPassCardGap(int gridCol, int gridRow, Grid grid) : base(gridCol, gridRow, grid)
        {
            enterPassive = passive;
            active = new GapState(HelpMethods.getHexBrush("#00FF7F"), "Карта-пропуск получена");
            enterActive = new GapState(HelpMethods.getHexBrush("#98FB98"), "Забрать карту-пропуск");
        }

        protected override void Gap_MouseDown(object sender, MouseEventArgs e)
        {
            if (CardInGap)
            {
                CardInGap = false;
                HelpMethods.InvertBoolPassCardInHand();
                (Window.GetWindow(App.Current.MainWindow) as MainWindow).terminalScreen1.switchScreenToIndex(0);
                new TimeWindow();
                HelpMethods.MainWindowHide();
            }
        }

        public void GetCardRequest()
        {
            CardInGap = true;
            panel.Background = active.Color;
            label.Content = active.Text;

            Accessible = false;
            (Window.GetWindow(App.Current.MainWindow) as MainWindow).terminalScreen1.switchScreenToIndex(1);
        }
    }
}
