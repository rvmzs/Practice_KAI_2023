using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Praktika_Lavrentev_Abdrahmanov
{
    public class MenuPassCard : MenuCard
    {
        public MenuPassCard(int gridCol, int gridRow, Grid grid) : base(gridCol, gridRow, grid)
        {
            passive = new GapState(HelpMethods.getHexBrush("#D3D3D3"), "Карта-пропуск не в руках");
            active = new GapState(HelpMethods.getHexBrush("#00FF7F"), "Ваша карта-пропуск");

            panel.Background = passive.Color;
            label.Content = passive.Text;
        }

        public void AddTextToActiveText(string text) { 
            active.Text = "Ваша карта-пропуск" + text;
            label.Content = active.Text;
        }
    }
}
